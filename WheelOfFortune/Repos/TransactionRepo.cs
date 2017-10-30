using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WheelOfFortune.Models;
using WheelOfFortune.Models.Domain;
using WheelOfFortune.Repos.Interfaces;
using WheelOfFortune.Models.ViewModels;
using System.Data.Entity;

namespace WheelOfFortune.Repos
{
    public class TransactionRepo : ITransactionRepo
    {
        private readonly ApplicationDbContext _context;

        public TransactionRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Transaction> GetAll()
        {
            return _context.Transactions.Include(x => x.User).ToList();
        }

        public IEnumerable<Transaction> GetByUserId(string userId)
        {
            return _context.Transactions.Where(x => x.User.Id == userId).Include(x => x.User).ToList();
        }

        public Transaction CreateTransaction(TransactionBindingModel model)
        {
            var userId = HttpContext.Current.User.Identity.GetUserId();
            var user = _context.Users.First(x => x.Id == userId);

            if (user == null)
                throw new Exception("You are not Logged In");

            var transaction = new Transaction
            {
                TransactionDate = model.TransactionDate,
                Value = model.Value,
                Type = model.Type,
                User = user
            };

            _context.Transactions.Add(transaction);
            _context.SaveChanges();

            return transaction;
        }
    }
}