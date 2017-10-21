using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WheelOfFortune.Models.Domain;

namespace WheelOfFortune.Repos.Interfaces
{
    public interface ICouponValueRepo
    {
        CouponValues CreateCouponValue(int value);
        CouponValues UpdateCouponValue(int id, int value);
    }
}