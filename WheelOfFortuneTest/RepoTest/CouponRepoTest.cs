using System;
using System.Collections.Generic;
using System.Linq;
using WheelOfFortune.Models;
using WheelOfFortune.Models.Domain;
using WheelOfFortune.Models.ViewModels;
using WheelOfFortune.Repos.Interfaces;

namespace WheelTestingProject.RepoTest
{
    class CouponRepoTest : ICouponRepo
    {
        private List<Coupon> list = new List<Coupon>();
        private CouponValue cv = new CouponValue();

        public CouponRepoTest()
        {

        }

        public Coupon CreateCoupon(CouponBindingModel model)
        {


            var c = new Coupon
            {
                Code = "10AAAAAAAA",
                Active = true,
                DateCreated = DateTime.Now,
                DateExpired = DateTime.Now.AddHours(24),
                Value = cv
            };
            list.Add(c);
            return c;
        }

        public decimal? Exchange(string code)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Coupon> GetAll()
        {
            return list;
        }

        public IEnumerable<Coupon> GetByUserId(string userId)
        {
            return list.Where(x => x.User.Id == userId);
        }

        public Coupon UpdateExpirationDate(Coupon coupon, DateTime date)
        {
            var c = list.Where(x => x.Id == coupon.Id).First();
            c.DateExpired = date;
            return c;
        }
    }
}
