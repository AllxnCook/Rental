﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Rental.Models
{
    public class PaymentType
    {
        public int Id { get; set; }
        [Display(Name="Payment Method")]
        public string Name { get; set; }
        public int AccountNumber { get; set; }
        [Required]
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
    }
}
