using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Server.Model.Data;

namespace Server.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder builder, IPasswordHasher<User> hasher)
        {
            builder.Entity<User>().HasData(
                new User()
                {
                    Id = "1",
                    UserName = "Admin",
                    NormalizedUserName = "ADMIN",
                    PasswordHash = hasher.HashPassword(null, "password")
                });

            builder.Entity<Company>().HasData(
                new Company()
                {
                    CompanyId = 1,
                    Name = "Pumox",
                    EstablishmentYear = 2015
                },
                new Company()
                {
                    CompanyId = 2,
                    Name = "Intel",
                    EstablishmentYear = 2000
                },
                new Company()
                {
                    CompanyId = 3,
                    Name = "Nvidia",
                    EstablishmentYear = 2004
                });

            builder.Entity<Employee>().HasData(
                //Pumox employees
                new Employee()
                {
                    EmployeeId = 1,
                    CompanyId = 1,
                    FirstName = "Dmytro",
                    LastName = "Lynda",
                    DateOfBirth = DateTime.Parse("06.08.1998"),
                    JobTitle = JobTitle.Developer
                },
                new Employee()
                {
                    EmployeeId = 2,
                    CompanyId = 1,
                    FirstName = "Piotr",
                    LastName = "Kowalski",
                    DateOfBirth = DateTime.Parse("17.03.1990"),
                    JobTitle = JobTitle.Administrator
                },
                new Employee()
                {
                    EmployeeId = 3,
                    CompanyId = 1,
                    FirstName = "Jakub",
                    LastName = "Kosmalski",
                    DateOfBirth = DateTime.Parse("17.03.1990"),
                    JobTitle = JobTitle.Manager
                },
                
                //Intel employees
                new Employee()
                {
                    EmployeeId = 4,
                    CompanyId = 2,
                    FirstName = "Grzegorz",
                    LastName = "Słowiński",
                    DateOfBirth = DateTime.Parse("12.07.1987"),
                    JobTitle = JobTitle.Manager
                },
                new Employee()
                {
                    EmployeeId = 5,
                    CompanyId = 2,
                    FirstName = "Grzegorz",
                    LastName = "Kowalski",
                    DateOfBirth = DateTime.Parse("02.09.1994"),
                    JobTitle = JobTitle.Architect
                },

                //Nvidia employees
                new Employee()
                {
                    EmployeeId = 6,
                    CompanyId = 3,
                    FirstName = "Jarosław",
                    LastName = "Łojko",
                    DateOfBirth = DateTime.Parse("02.09.1996"),
                    JobTitle = JobTitle.Administrator
                },
                new Employee()
                {
                    EmployeeId = 7,
                    CompanyId = 3,
                    FirstName = "Tomasz",
                    LastName = "Stefaniszyn",
                    DateOfBirth = DateTime.Parse("23.01.1995"),
                    JobTitle = JobTitle.Developer
                });
        }
    }
}
