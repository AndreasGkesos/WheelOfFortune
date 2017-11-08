using Microsoft.AspNet.Identity;
using System;
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
        private readonly ApplicationDbContext _context;

        public CouponValueRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public CouponValue CreateCouponValue(int value, string userId)
        {
            var user = _context.Users.First(x => x.Id == userId);

            if (user == null)
                throw new Exception("User does not exist");

            var cv = new CouponValue{
               Value = value
            };

            _context.CouponValues.Add(cv);
            _context.SaveChanges();
            return cv;
        }

        public CouponValue UpdateCouponValue(int id, int value)
        {
            var cv = _context.CouponValues.SingleOrDefault(c => c.Id == id);

            if (cv == null)
                throw new Exception("Value does not exist");

            cv.Value = value;

            _context.Entry(cv).State = EntityState.Modified;
            _context.SaveChanges();

            return cv;
        }
    }
}