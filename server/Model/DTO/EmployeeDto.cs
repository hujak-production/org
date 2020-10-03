using Server.Infrastructure.CustomDataAnnotations;
using Server.Model.Data;
using System;
using System.ComponentModel.DataAnnotations;

namespace Server.Model.DTO
{
    public class EmployeeDto
    {
        [Required, StringLength(50)]
        public string FirstName { get; set; }

        [Required, StringLength(50)]
        public string LastName { get; set; }

        [Required, DataType(DataType.Date), DateInPast]
        public DateTime DateOfBirth { get; set; }

        [Required]
        public JobTitle JobTitle { get; set; }
    }
}
