﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class DealerDTO
    {
        [Required]
        [MinLength(5)]
        [MaxLength(30)]
        public string Name { get; set; }

        [Required]
        public string UserId { get; set; }
    }
}
