using System;

namespace Server.Model.Data
{
    public class Employee
    {
        public long EmployeeId { get; set; }
        public long CompanyId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public JobTitle JobTitle { get; set; }
    }
}