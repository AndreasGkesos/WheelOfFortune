using System;
using System.Collections.Generic;
using System.Web.Http;
using WheelOfFortune.Models.Domain;
using WheelOfFortune.Models.ViewModels;
using WheelOfFortune.Repos.Interfaces;

namespace WheelOfFortune.Controllers.API
{   
    
    public class SpinController : ApiController
    {
        private readonly ISpinRepo _repo;
        private readonly ITransactionRepo _transactionRepo;
        private readonly IBalanceRepo _balanceRepo;

        public SpinController(ISpinRepo repo, ITransactionRepo transactionRepo, IBalanceRepo balanceRepo)
        {
           _repo = repo;
           _transactionRepo = transactionRepo;
           _balanceRepo = balanceRepo;
        }

        [HttpGet]
        public IEnumerable<Spin> GetByUserId(string userId)
        {
            return _repo.GetByUserId(userId);
        }

        [HttpPost]
        
        public Spin AddSpin(SpinBindingModel model)
        {
            var spin = _repo.CreateSpin(model);
            UpdateTransactionAndBalance(spin.Item1);
            return spin.Item1;
        }

        private void UpdateTransactionAndBalance(Spin spin)
        {
            var t = _transactionRepo.CreateTransaction(
                new TransactionBindingModel
                {
                    TransactionDate = DateTime.Now,
                    Type = TransactionType.FromSpin,
                    Value = spin.ResultValue
                });
            _balanceRepo.UpdateBalance(t.Item1.Value);
        }
    }
}