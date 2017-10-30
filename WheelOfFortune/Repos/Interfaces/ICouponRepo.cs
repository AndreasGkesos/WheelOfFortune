using System;
using System.Collections.Generic;
using WheelOfFortune.Models.Domain;
using WheelOfFortune.Models.ViewModels;

namespace WheelOfFortune.Repos.Interfaces
{
    public interface ICouponRepo
    {
        IEnumerable<Coupon> GetByUserId(string userId);
        CouponViewModel UpdateExpirationDate(Coupon coupon, DateTime date);
        CouponViewModel CreateCoupon(CouponBindingModel model);
        IEnumerable<Coupon> GetAll();
        decimal? Exchange(string code);
    }
}