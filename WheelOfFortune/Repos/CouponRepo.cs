using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WheelOfFortune.Models;
using WheelOfFortune.Models.Domain;
using WheelOfFortune.Repos.Interfaces;

namespace WheelOfFortune.Repos
{
    public class CouponRepo : ICouponRepo
    {
        private readonly ApplicationDbContext context;
        public DbSet<Coupon> DbSet { get; }

        public CouponRepo(ApplicationDbContext context)
        {
            this.context = context;
        }

        public IList<Coupon> GetByUserId(string userId)
        {
            return context.Coupons.Where(x => x.User.Id == userId).ToList();
        }

        public Coupon UpdateExpirationDate(Coupon coupon, DateTime date)
        {
            var c = context.Coupons.Where(code => code.Id == coupon.Id).SingleOrDefault();
            c.DateExpired = date;

            using (var dbCtx = new ApplicationDbContext())
            {
                dbCtx.Entry(c).State = EntityState.Modified;
                dbCtx.SaveChanges();
                return c;
            }
        }
    }
}