using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
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
    public class SpinRepo : ISpinRepo
    {
        private readonly ApplicationDbContext context;
        public DbSet<Spin> DbSet { get; }

        public SpinRepo(ApplicationDbContext context)
        {
            this.context = context;
        }

        public IList<Spin> GetByUserId(string userId)
        {
            return context.Spins.Where(x => x.User.Id == userId).ToList();
        }

        public Spin CreateSpin(string userId)
        {
            var spin = new Spin();
            ApplicationUser user = HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>().FindById(HttpContext.Current.User.Identity.GetUserId());

            if (user != null)
                spin.User = user;
            using (var dbCtx = new ApplicationDbContext())
            {
                dbCtx.Spins.Add(spin);
                dbCtx.SaveChanges();
                return spin;
            }
        }
    }
}