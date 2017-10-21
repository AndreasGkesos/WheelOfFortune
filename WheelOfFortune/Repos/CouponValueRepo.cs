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
            var cv = new CouponValue();
            cv.Value = value;

            using (var dbCtx = new ApplicationDbContext())
            {
                dbCtx.CouponValues.Add(cv);
                dbCtx.SaveChanges();
                return cv;
            }
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