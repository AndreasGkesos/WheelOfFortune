using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WheelOfFortune.Models.Domain;
using WheelOfFortune.Models.ViewModels;
using WheelOfFortune.Repos.Interfaces;

namespace WheelOfFortune.Controllers.API
{
    public class SpinController : ApiController
    {
        private readonly ISpinRepo repo;
        private readonly ITransactionRepo transactionRepo;
        private readonly IBalanceRepo balanceRepo;

        public SpinController(ISpinRepo repo, ITransactionRepo transactionRepo, IBalanceRepo balanceRepo)
        {
            this.repo = repo;
            this.transactionRepo = transactionRepo;
            this.balanceRepo = balanceRepo;
        }

        [HttpGet]
        public IList<Spin> GetByUserId(string userId)
        {
            return repo.GetByUserId(userId);
        }

        [HttpPost]
        public Spin AddSpin(SpinBindingModel model)
        {
            var s = repo.CreateSpin(model);
            UpdateTransactionAndBalance(s);
            return s;
        }

        private void UpdateTransactionAndBalance(Spin s)
        {
            var t = transactionRepo.CreateTransaction(
                new TransactionBindingModel
                {
                    TransactionDate = DateTime.Now,
                    Type = TransactionType.FromSpin,
                    Value = s.ResultValue
                });
            balanceRepo.UpdateBalance(t.Value);
        }
    }
}