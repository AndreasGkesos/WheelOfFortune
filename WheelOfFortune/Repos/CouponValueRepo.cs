using Microsoft.AspNet.Identity;
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
            var userId = HttpContext.Current.User.Identity.GetUserId();
            var user = context.Users.First(x => x.Id == userId);

            if (user == null)
                return null;

            var cv = new CouponValue{
               Value = value
            };

                context.CouponValues.Add(cv);
                context.SaveChanges();
                return cv;
            
           
        }

        public CouponValue UpdateCouponValue(int id, int value)
        {
            var cv = context.CouponValues.SingleOrDefault(c => c.Id == id);

            if (cv == null)
                return null;

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