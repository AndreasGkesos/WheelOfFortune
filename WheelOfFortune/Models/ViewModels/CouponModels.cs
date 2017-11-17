using System;

namespace WheelOfFortune.Models.ViewModels
{
    public class CouponBindingModel
    {
        public int Value { get; set; }
    }

    public class CouponViewModel
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public int Value { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateExpired { get; set; }
        public DateTime DateExchanged { get; set; }
        public bool Active { get; set; }
        public ApplicationUserViewModel User { get; set; }
    }
}