using System.ComponentModel.DataAnnotations;

namespace WheelOfFortune.Models.Domain
{
    public class CouponValue
    {
        public int Id { get; set; }

        [Required]
        public decimal Value { get; set; }
    }
}