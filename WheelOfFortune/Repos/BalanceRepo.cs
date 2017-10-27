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
    public class BalanceRepo : IBalanceRepo
    {
        private readonly ApplicationDbContext _context;

        public BalanceRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public Balance GetByUserId(string userId)
        {
            return _context.Balances.First(x => x.User.Id == userId);
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
                    _context.Entry(blc).State = EntityState.Modified;
                    _context.SaveChanges();
                    return new Tuple<Balance, Exception>(blc, null);
                
                
            }
            catch (NullReferenceException e) {
                return new Tuple<Balance, Exception>(null, new Exception($"You are not Logged In {e.Message}")); }
        }

        public Balance CreateBalance(string userId)
        {
         
            var user = _context.Users.FirstOrDefault(x => x.Id == userId);

            if (user == null)
               throw new InvalidOperationException();

            var balance = new Balance
            {
                User = user,
                BalanceValue = 100
            };

            _context.Balances.Add(balance);
            _context.SaveChanges();
            return balance;
        }
    }
}