using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Http.Results;
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
            return context.Balances.First(x => x.User.Id == userId);
        }

        public Tuple<Balance, Exception> UpdateBalance(decimal balance)
        {
            try
            {
                var userId = HttpContext.Current.User.Identity.GetUserId();
                var blc = GetByUserId(userId);

                if(userId==null)
                    return new Tuple<Balance, Exception>(null, new Exception("You are not Logged In"));

               
                    blc.BalanceValue = blc.BalanceValue + balance;
                    context.Entry(blc).State = EntityState.Modified;
                    context.SaveChanges();
                    return new Tuple<Balance, Exception>(blc, null);
                
                
            }
            catch (NullReferenceException e) {
                return new Tuple<Balance, Exception>(null, new Exception("You are not Logged In")); }
        }

        public Balance CreateBalance(string userId)
        {
         
            var user = context.Users.FirstOrDefault(x => x.Id == userId);

            if (user == null)
               throw new InvalidOperationException();

            var balance = new Balance
            {
                User = user,
                BalanceValue = 100
            };

            context.Balances.Add(balance);
            context.SaveChanges();
            return balance;
        }
    }
}