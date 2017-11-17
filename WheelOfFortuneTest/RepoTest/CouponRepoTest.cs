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
        private CouponValue cv1, cv2, cv3;
        private ApplicationUser user;

        public CouponRepoTest()
        {
            user = new ApplicationUser { Id = "aaaaa", Email = "andreas@gmail.com", UserName = "andreas" };
            cv1 = new CouponValue { Id = 1, Value = 10 };
            cv2 = new CouponValue { Id = 2, Value = 20 };
            cv3 = new CouponValue { Id = 3, Value = 50 };

            list.Add(new Coupon { Id = 1, Active = true, Code = "ASDFG12345", DateCreated = new DateTime(2017, 10, 10, 8, 23, 4), DateExpired = new DateTime(2017, 12, 10, 8, 23, 4), DateExchanged = new DateTime(2017, 11, 11, 8, 23, 4), Value = cv1, User = user });
            list.Add(new Coupon { Id = 2, Active = true, Code = "12345ASDFG", DateCreated = new DateTime(2017, 10, 10, 8, 23, 4), DateExpired = new DateTime(2017, 12, 10, 8, 23, 4), DateExchanged = new DateTime(2017, 11, 11, 8, 23, 4), Value = cv1, User = user });
            list.Add(new Coupon { Id = 3, Active = true, Code = "A1S2D3F4GU", DateCreated = new DateTime(2017, 10, 10, 8, 23, 4), DateExpired = new DateTime(2017, 12, 10, 8, 23, 4), DateExchanged = new DateTime(2017, 11, 11, 8, 23, 4), Value = cv2, User = user });
            list.Add(new Coupon { Id = 4, Active = true, Code = "ASD123DFG3", DateCreated = new DateTime(2017, 10, 10, 8, 23, 4), DateExpired = new DateTime(2017, 12, 10, 8, 23, 4), DateExchanged = new DateTime(2017, 11, 11, 8, 23, 4), Value = cv2, User = user });
            list.Add(new Coupon { Id = 5, Active = true, Code = "GFD54RFG67", DateCreated = new DateTime(2017, 10, 10, 8, 23, 4), DateExpired = new DateTime(2017, 12, 10, 8, 23, 4), DateExchanged = new DateTime(2017, 11, 11, 8, 23, 4), Value = cv3, User = user });
        }

        public Coupon CreateCoupon(CouponBindingModel model, string userId)
        {
            return new Coupon { Id = 1, Active = true, Code = "ASDFG12345", DateCreated = new DateTime(2017, 10, 10, 8, 23, 4), DateExpired = new DateTime(2017, 12, 10, 8, 23, 4), DateExchanged = new DateTime(2017, 11, 11, 8, 23, 4), Value = cv1, User = user };
        }

        public bool Delete(int id)
        {
            var coupon = list.Where(x => x.Id == id).FirstOrDefault();
            return coupon != null;
        }

        public decimal? Exchange(string code)
        {
            return list.Where(x => x.Code == code).FirstOrDefault().Value.Value;
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
