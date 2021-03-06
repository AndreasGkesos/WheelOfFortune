﻿using System;
using System.Collections.Generic;
using WheelOfFortune.Models.Domain;
using WheelOfFortune.Models.ViewModels;

namespace WheelOfFortune.Repos.Interfaces
{
    public interface ICouponRepo
    {
        IEnumerable<Coupon> GetByUserId(string userId);
        Coupon UpdateExpirationDate(Coupon coupon, DateTime date);
        Coupon CreateCoupon(int value, string userId);
        IEnumerable<Coupon> GetAll();
        decimal? Exchange(string code);
        bool Delete(int id);
    }
}