using System;
using System.ComponentModel.DataAnnotations;

namespace WheelOfFortune.Models.Domain
{
    public enum TransactionType
    {
        FromCoupon,
        FromSpin
    }

    public class Transaction
    {
        public int  Id { get; set; }

        [Required]
        public decimal Value { get; set; }

        [Required]
        public TransactionType Type { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime TransactionDate { get; set; }

        [Required]
        public ApplicationUser User { get; set; } 
    }
}