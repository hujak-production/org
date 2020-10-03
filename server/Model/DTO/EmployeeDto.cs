﻿using Newtonsoft.Json.Converters;
using Server.Infrastructure.CustomDataAnnotations;
using Server.Model.Data;
using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Server.Model.DTO
{
    public class EmployeeDto
    {
        public long Id { get; set; }

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
