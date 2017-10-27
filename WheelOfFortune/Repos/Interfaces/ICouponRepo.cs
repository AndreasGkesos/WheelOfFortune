using System;
using System.Collections.Generic;
using WheelOfFortune.Models.Domain;
using WheelOfFortune.Models.ViewModels;

namespace WheelOfFortune.Repos.Interfaces
{
    public interface ICouponRepo
    {
        IList<Coupon> GetByUserId(string userId);
        Coupon UpdateExpirationDate(Coupon coupon, DateTime date);
        Coupon CreateCoupon(CouponBindingModel model);
    }
}