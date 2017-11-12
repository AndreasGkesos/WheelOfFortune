using System;
using System.ComponentModel.DataAnnotations;

namespace WheelOfFortune.Models.Domain
{
    public class Coupon
    {
        public int Id { get; set; }

        [Required]
        [StringLength(10)]
        public string Code { get; set; }

        [Required]
        public CouponValue Value { get; set; }

        [Required]
        public DateTime DateCreated { get; set; }

        [Required]
        public DateTime DateExpired { get; set; }

        public DateTime DateExchanged { get; set; }

        [Required]
        public bool Active { get; set; }

        public ApplicationUser User { get; set; }
    }
}