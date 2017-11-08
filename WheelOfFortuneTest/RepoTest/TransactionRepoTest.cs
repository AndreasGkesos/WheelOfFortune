using System;
using System.Collections.Generic;
using System.Linq;
using WheelOfFortune.Models.Domain;
using WheelOfFortune.Models.ViewModels;
using WheelOfFortune.Repos.Interfaces;

namespace WheelTestingProject.RepoTest
{
//    class TransactionRepoTest : ITransactionRepo
//    {
//        private List<Transaction> list = new List<Transaction>();
//
//        public TransactionRepoTest()
//        {
//
//        }
//
//        public Transaction CreateTransaction(TransactionBindingModel model)
//        {
//            var t = new Transaction
//            {
//                Id = 0,
//                TransactionDate = model.TransactionDate,
//                Type = model.Type,
//                Value = model.Value,
//                User = model.User
//            };
//
//            list.Add(t);
//            return t;
//        }
//
//        public IEnumerable<Transaction> GetAll()
//        {
//            return list;
//        }
//
//        IEnumerable<Transaction> ITransactionRepo.GetByUserId(string userId)
//        {
//            return list.Where(x => x.User.Id == userId);
//        }
//    }
}
