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

        public BalanceRepo(ApplicationDbContext context)
        {
            this.context = context;
        }

        public Balance GetByUserId(string userId)
        {
            return context.Balances.Where(x => x.User.Id == userId).First();
        }

        public Balance UpdateBalance(decimal balance)
        {
            var userId = HttpContext.Current.User.Identity.GetUserId();
            var blc = GetByUserId(userId);

            blc.BalanceValue = blc.BalanceValue + balance;

            context.Entry(blc).State = EntityState.Modified;
            context.SaveChanges();
            return blc;
        }

        public Balance CreateBalance()
        {
            var userId = HttpContext.Current.User.Identity.GetUserId().ToString();
            var user = context.Users.Where(x => x.Id == userId).First();

            var balance = new Balance();
            if (user != null)
            {
                context.Balances.Add(balance);
                context.SaveChanges();
                return balance;
            }
            else { return null; }

        }
    }
}