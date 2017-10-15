using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using static WheelOfFortune.Models.ViewModels.TransactionViewModel;

namespace WheelOfFortune.Models.Domain
{
    public class Transaction
    {
        public int  Id { get; set; }

        [Required]
        public double Value { get; set; }

        [Required]
        public TransactionType Type { get; set; }

        [Required]
        public DateTime TransactionDate { get; set; }

        [Required]
        public ApplicationUser User { get; set; } 
    }
}