using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Server.Model.Data;
using Server.Model.DTO;
using System.Collections.Generic;
using System.Linq;

namespace Server.Model.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly ILogger<CompanyService> _logger;

        public CompanyService(ILogger<CompanyService> logger)
        {
            _logger = logger;
        }

        public IEnumerable<Company> Search(SearchCondition condition, IQueryable<Company> from)
        {
            IQueryable<Company> companies = from
                .AsNoTracking()
                .Include(c => c.Employees);

            if (condition.Keyword != null)
            {
                _logger.LogInformation("Search companies with a keyword: {0}", condition.Keyword);

                //Selects a company from companies if the condition.
                //Keyword matches with company.Name or with First or Last name of any employee from the company.
                companies = from company in companies
                            where EF.Functions.Like(company.Name, condition.Keyword) ||
                                  (from employee in company.Employees
                                   where EF.Functions.Like(employee.FirstName, condition.Keyword) ||
                                         EF.Functions.Like(employee.LastName, condition.Keyword)
                                   select employee).Any()
                            select company;
            }

            if (condition.EmployeeDateOfBirthFrom.HasValue)
            {
                _logger.LogInformation("Search companies with employees who were born from {0}", condition.EmployeeDateOfBirthFrom.Value);

                companies = from company in companies
                            from employer in company.Employees
                            where employer.DateOfBirth >= condition.EmployeeDateOfBirthFrom.Value
                            select company;
            }

            if (condition.EmployeeDateOfBirthTo.HasValue)
            {
                _logger.LogInformation("Search companies with employees who were born to {0}", condition.EmployeeDateOfBirthTo.Value);

                companies = from company in companies
                            from employer in company.Employees
                            where employer.DateOfBirth <= condition.EmployeeDateOfBirthTo.Value
                            select company;
            }

            IEnumerable<Company> result = companies.ToList();

            if (condition.EmployeeJobTitles != null && condition.EmployeeJobTitles.Any())
            {
                _logger.LogInformation("Search companies with employees who have these job titles: {0}",
                    string.Join(',', condition.EmployeeJobTitles.ToArray()));

                result = from company in result
                         from employer in company.Employees
                         where condition.EmployeeJobTitles.Any(e => e.Equals(employer.JobTitle))
                         select company;
            }

            return result;
        }

        public void Update(ref Company updatedEntry, Company update)
        {
            updatedEntry.Name = update.Name;
            updatedEntry.EstablishmentYear = update.EstablishmentYear;
            updatedEntry.Employees = updatedEntry.Employees.Zip(update.Employees,
                (first, second) => new Employee()
                {
                    EmployeeId = first.EmployeeId,
                    CompanyId = first.CompanyId,
                    FirstName = second.FirstName,
                    LastName = second.LastName,
                    DateOfBirth = second.DateOfBirth,
                    JobTitle = second.JobTitle
                }).ToList();
        }
    }
}
