using server.Infrastructure.CustomDataAnnotations;
using server.Model.Data;
using System;
using System.ComponentModel.DataAnnotations;

namespace server.Model.DTO
{
    public class EmployerDto
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
