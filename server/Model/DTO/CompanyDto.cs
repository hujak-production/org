﻿using Server.Infrastructure.CustomDataAnnotations;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Server.Model.DTO
{
    public class CompanyDto
    {
        [Required, StringLength(50)]
        public string Name { get; set; }

        [Required, YearInPast]
        public int EstablishmentYear { get; set; }

        [Required, MinLength(0)]
        public ICollection<EmployerDto> Employees { get; set; }
    }
}
