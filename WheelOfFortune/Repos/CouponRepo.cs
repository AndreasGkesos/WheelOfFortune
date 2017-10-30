﻿using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
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
        private readonly string _validChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
        private readonly int _codeLength = 8;

        public CouponRepo(ApplicationDbContext context)
        {
          _context = context;
        }

        public IEnumerable<Coupon> GetAll()
        {
            return _context.Coupons.Include(x => x.User).Include(c => c.Value).ToList();
        }

        public IEnumerable<Coupon> GetByUserId(string userId)
        {
            return _context.Coupons.Where(x => x.User.Id == userId).Include(x => x.User).Include(c => c.Value).ToList();
        }

        public CouponViewModel UpdateExpirationDate(Coupon coupon, DateTime date)
        {
            var c = _context.Coupons.SingleOrDefault(code => code.Id == coupon.Id);
            if (c == null) return null;

            c.DateExpired = date;

            _context.Entry(c).State = EntityState.Modified;
            _context.SaveChanges();
            return TransformModels.ToCouponViewModel(c);
        }

        public CouponViewModel CreateCoupon(CouponBindingModel model)
        {
            var userId = HttpContext.Current.User.Identity.GetUserId();
            var user = _context.Users.First(x => x.Id == userId);        

            if (user == null)
                return null;

            var cv = new CouponValue();
            try
            {
                cv = _context.CouponValues.First(x => x.Value == model.Value);
            }
            catch (InvalidOperationException e)
            {
                return null; // value does not exist
            }
            
            var prefix = "";
            switch(model.Value)
            {
                case 5:
                    prefix = "05";
                    break;
                case 10:
                    prefix = "10";
                    break;
                case 20:
                    prefix = "20";
                    break;
                case 50:
                    prefix = "50";
                    break;
                default:
                    return null;
            }
           
            var  coupon = new Coupon
            {
                Code = prefix + GetCode(),
                Value = cv,
                DateCreated = DateTime.Now,
                DateExpired = DateTime.Now.AddHours(24),
                Active = true,                 
            };

            _context.Coupons.Add(coupon);
            _context.SaveChanges();
            return TransformModels.ToCouponViewModel(coupon);
        }

        private string GetCode()
        {
            StringBuilder sb = new StringBuilder();
            using (RNGCryptoServiceProvider provider = new RNGCryptoServiceProvider())
            {
                while (sb.Length < _codeLength)
                {
                    byte[] oneByte = new byte[1];
                    provider.GetBytes(oneByte);
                    char character = (char)oneByte[0];
                    if (_validChars.Contains(character))
                    {
                        sb.Append(character);
                    }
                }

                return sb.ToString();
            }
        }

        public decimal? Exchange(string code)
        {
            var coupon = _context.Coupons.Where(x => x.Code == code).Include(x => x.User).Include(c => c.Value).First();

            var now = DateTime.Now;
            if (coupon == null || !coupon.Active || coupon.DateExpired < now)
                return null;

            coupon.Active = false;
            coupon.DateExchanged = now;
            _context.Entry(coupon).State = EntityState.Modified;
            _context.SaveChanges();

            return coupon.Value.Value;
        }
    }
}