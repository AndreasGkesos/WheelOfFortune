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
            return _context.Balances.Where(x => x.User.Id == userId).Include(x => x.User).First();
        }

        public string GetUser()
        {
            return  HttpContext.Current.User.Identity.GetUserName();

        }

        public Balance UpdateBalance(decimal balance, string userId)
        {
            var blc = _context.Balances.Where(x => x.User.Id == userId).Include(x => x.User).First();

            if (userId == null)
                throw new Exception("You are not Logged In");

            if (blc == null)
                throw new Exception("Balance not found");

            blc.BalanceValue = blc.BalanceValue + balance;
            _context.Entry(blc).State = EntityState.Modified;
            _context.SaveChanges();

            return blc;
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

        public decimal GetBalanceByUserId(string userId)
        {
            var user = _context.Users.FirstOrDefault(x => x.Id == userId);

            if (user == null)
                throw new InvalidOperationException();

            var balance = _context.Balances.FirstOrDefault(x => x.User.Id == userId);

            if(balance == null)
                throw new InvalidOperationException($"Balance not found for user {user.UName}");

            return balance.BalanceValue;

        }
    }
}