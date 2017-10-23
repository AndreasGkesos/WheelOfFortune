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
using WheelOfFortune.Models.ViewModels;

namespace WheelOfFortune.Repos
{
    public class TransactionRepo : ITransactionRepo
    {
        private readonly ApplicationDbContext context;

        public TransactionRepo(ApplicationDbContext context)
        {
            this.context = context;
        }

        public Tuple<Transaction, Exception> CreateTransaction(TransactionBindingModel model)
        {
            try
            {
                var userId = HttpContext.Current.User.Identity.GetUserId().ToString();
                var user = context.Users.Where(x => x.Id == userId).First();

                var transaction = new Transaction();
                if (user != null)
                {
                    transaction = new Transaction
                    {
                        TransactionDate = model.TransactionDate,
                        Value = model.Value,
                        Type = model.Type,
                        User = user
                    };

                    context.Transactions.Add(transaction);
                    context.SaveChanges();
                    return new Tuple<Transaction, Exception>(transaction, null);
                }
                else { return new Tuple<Transaction, Exception>(null, new Exception("You are not Logged In")); }
            }
            catch (NullReferenceException e)
            {
                return new Tuple<Transaction, Exception>(null, new Exception("You are not Logged In")); ;
            }
        }

        public IList<Transaction> GetByUserId(string userId)
        {
            return context.Transactions.Where(x => x.User.Id == userId).ToList();
        }
    }
}