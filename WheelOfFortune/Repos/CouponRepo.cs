using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WheelOfFortune.Models;
using WheelOfFortune.Models.Domain;
using WheelOfFortune.Models.ViewModels;
using WheelOfFortune.Repos.Interfaces;

namespace WheelOfFortune.Repos
{
    public class CouponRepo : ICouponRepo
    {
        private readonly ApplicationDbContext _context;

        public CouponRepo(ApplicationDbContext context)
        {
          _context = context;
        }

        public IEnumerable<Coupon> GetByUserId(string userId)
        {
            return _context.Coupons.Where(x => x.User.Id == userId).ToList();
        }

        public Coupon UpdateExpirationDate(Coupon coupon, DateTime date)
        {
            var c = _context.Coupons.SingleOrDefault(code => code.Id == coupon.Id);
            if (c == null) return null;

            c.DateExpired = date;

            _context.Entry(c).State = EntityState.Modified;
            _context.SaveChanges();
            return c;
        }

        public Coupon CreateCoupon(CouponBindingModel model)
        {
            var userId = HttpContext.Current.User.Identity.GetUserId();
            var user = _context.Users.First(x => x.Id == userId);        

            if (user == null)
                return null;

           
               var  coupon = new Coupon
                {
                    Code = model.Code,
                    Value = model.Value,
                    DateCreated = DateTime.Now,
                    DateExpired = DateTime.Now.AddHours(24),
                    Active = true,
                    User = user                    
                };

                _context.Coupons.Add(coupon);
                _context.SaveChanges();
                return coupon;
           
        }
    }
}