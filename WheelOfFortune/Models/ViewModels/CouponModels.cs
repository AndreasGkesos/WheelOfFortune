using System;
using WheelOfFortune.Models.Domain;

namespace WheelOfFortune.Models.ViewModels
{
    public class CouponBindingModel
    {
        public int Value { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateExpired { get; set; }
        public bool Active { get; set; }
    }
}