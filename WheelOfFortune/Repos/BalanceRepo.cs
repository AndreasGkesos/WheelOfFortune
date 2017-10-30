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

        public Tuple<Balance, Exception> UpdateBalance(decimal balance)
        {
            try
            {
                var userId = HttpContext.Current.User.Identity.GetUserId();
                var blc = GetByUserId(userId);

                if(userId == null)
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