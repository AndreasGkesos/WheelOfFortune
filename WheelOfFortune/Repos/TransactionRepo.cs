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
    public class TransactionRepo : ITransactionRepo
    {
        private readonly ApplicationDbContext context;
        public DbSet<Balance> DbSet { get; }

        public TransactionRepo(ApplicationDbContext context)
        {
            this.context = context;
        }

        public IList<Transaction> GetByUserId(string userId)
        {
            return context.Transactions.Where(x => x.User.Id == userId).ToList();
        }
    }
}