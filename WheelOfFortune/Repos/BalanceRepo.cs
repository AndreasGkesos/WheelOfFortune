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
    public class BalanceRepo : IBalanceRepo
    {
        private readonly ApplicationDbContext context;
        public DbSet<Balance> DbSet { get; }

        public BalanceRepo(ApplicationDbContext context)
        {
            this.context = context;
        }

        public Balance GetByUserId(string userId)
        {
            return context.Balances.Where(x => x.User.Id == userId).First();
        }

        public Balance UpdateBalance(long balance)
        {
            var userId = HttpContext.Current.User.Identity.GetUserId();
            var blc = GetByUserId(userId);

            blc.BalanceValue = balance;

            using (var dbCtx = new ApplicationDbContext())
            {
                dbCtx.Entry(blc).State = EntityState.Modified;
                dbCtx.SaveChanges();
                return blc;
            }
        }

        public Balance CreateBalance(ApplicationUser user)
        {
            var balance = new Balance();

            using (var dbCtx = new ApplicationDbContext())
            {
                dbCtx.Balances.Add(balance);
                dbCtx.SaveChanges();
                return balance;
            }
        }
    }
}