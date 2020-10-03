using System;
using System.Collections.Generic;
using server.Model.Data;

namespace server.Model.DTO
{
    public class SearchCondition
    {
        public string Keyword { get; set; }
        public DateTime? EmployeeDateOfBirthFrom { get; set; }
        public DateTime? EmployeeDateOfBirthTo { get; set; }
        public IEnumerable<JobTitle> EmployeeJobTitles { get; set; }
    }
}
