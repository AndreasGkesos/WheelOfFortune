﻿using Microsoft.AspNet.Identity;
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
        private readonly ApplicationDbContext context;

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

            context.Entry(c).State = EntityState.Modified;
            context.SaveChanges();
            return c;
        }

        public Coupon CreateCoupon(CouponBindingModel model)
        {
            var userId = HttpContext.Current.User.Identity.GetUserId().ToString();
            var user = context.Users.Where(x => x.Id == userId).First();

            var coupon = new Coupon();
            if (user != null)
            {
                coupon = new Coupon
                {
                    Code = model.Code,
                    Value = model.Value,
                    DateCreated = DateTime.Now,
                    DateExpired = DateTime.Now.AddHours(24),
                    Active = true,
                    User = user                    
                };

                context.Coupons.Add(coupon);
                context.SaveChanges();
                return coupon;
            }
            else { return null; }
        }
    }
}