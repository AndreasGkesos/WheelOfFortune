using System;
using System.Collections.Generic;
using System.Linq;
using WheelOfFortune.Models;
using WheelOfFortune.Models.Domain;
using WheelOfFortune.Models.ViewModels;
using WheelOfFortune.Repos.Interfaces;

namespace WheelTestingProject.RepoTest
{
    class TransactionRepoTest : ITransactionRepo
    {
        private List<Transaction> list = new List<Transaction>();
        private ApplicationUser user = new ApplicationUser { Id = "aaaaa", Email = "andreas@gmail.com", UserName = "andreas" };

        public TransactionRepoTest()
        {
            list.Add(new Transaction { Id = 1, TransactionDate = new DateTime(2017, 8, 9, 8, 23, 4), Type = TransactionType.FromCoupon, Value = 20, User = user });
            list.Add(new Transaction { Id = 2, TransactionDate = new DateTime(2017, 8, 10, 8, 13, 4), Type = TransactionType.FromCoupon, Value = 50, User = user });
            list.Add(new Transaction { Id = 3, TransactionDate = new DateTime(2017, 9, 11, 8, 33, 4), Type = TransactionType.FromSpin, Value = 40, User = user });
            list.Add(new Transaction { Id = 4, TransactionDate = new DateTime(2017, 9, 10, 8, 43, 4), Type = TransactionType.FromSpin, Value = 15, User = user });
            list.Add(new Transaction { Id = 5, TransactionDate = new DateTime(2017, 10, 10, 8, 53, 4), Type = TransactionType.FromSpin, Value = 20, User = user });
        }

        public Transaction CreateTransaction(TransactionBindingModel model, string userId)
        {
            return new Transaction { Id = 1, TransactionDate = new DateTime(2017, 10, 10, 8, 53, 4), Type = TransactionType.FromSpin, Value = 20, User = user };
        }

        public IEnumerable<Transaction> GetAll()
        {
            return list;
        }

        IEnumerable<Transaction> ITransactionRepo.GetByUserId(string userId)
        {
            return list.Where(x => x.User.Id == userId);
        }
    }
}
