using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WheelOfFortune.Models.Domain;

namespace WheelOfFortune.Models.ViewModels
{
    public class TransactionBindingModel
    {
        public decimal Value { get; set; }
        public TransactionType Type { get; set; }
        public DateTime TransactionDate { get; set; }
        public ApplicationUser User { get; set; }
    }
}