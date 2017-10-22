using Microsoft.AspNet.Identity;
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
    public class CouponValueRepo : ICouponValueRepo
    {
        private readonly ApplicationDbContext context;

        public CouponValueRepo(ApplicationDbContext context)
        {
            this.context = context;
        }

        public CouponValue CreateCouponValue(int value)
        {
            var userId = HttpContext.Current.User.Identity.GetUserId().ToString();
            var user = context.Users.Where(x => x.Id == userId).First();

            var cv = new CouponValue();
            
            if (user != null)
            {
                cv.Value = value;

                context.CouponValues.Add(cv);
                context.SaveChanges();
                return cv;
            }
            else { return null; }
        }

        public CouponValue UpdateCouponValue(int id, int value)
        {
            var cv = context.CouponValues.Where(c => c.Id == id).SingleOrDefault();
            cv.Value = value;

            using (var dbCtx = new ApplicationDbContext())
            {
                dbCtx.Entry(cv).State = EntityState.Modified;
                dbCtx.SaveChanges();
                return cv;
            }
        }
    }
}