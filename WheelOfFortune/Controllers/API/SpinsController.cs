using System;
using System.Collections.Generic;
using System.Web.Http;
using System.Linq;
using WheelOfFortune.Models.Domain;
using WheelOfFortune.Models.ViewModels;
using WheelOfFortune.Repos.Interfaces;

namespace WheelOfFortune.Controllers.API
{   
    
    public class SpinsController : ApiController
    {
        private readonly ISpinRepo _repo;
        private readonly ITransactionRepo _transactionRepo;
        private readonly IBalanceRepo _balanceRepo;

        public SpinsController(ISpinRepo repo, ITransactionRepo transactionRepo, IBalanceRepo balanceRepo)
        {
           _repo = repo;
           _transactionRepo = transactionRepo;
           _balanceRepo = balanceRepo;
        }

        [HttpGet]
        public IEnumerable<SpinViewModel> GetAll()
        {
            return _repo.GetAll().Select(TransformModels.ToSpinViewModel);
        }
        

        [HttpGet]
        public IEnumerable<SpinViewModel> GetByUserId(string userId)
        {
            return _repo.GetByUserId(userId).Select(TransformModels.ToSpinViewModel);
        }

        [HttpPost]
        public SpinViewModel AddSpin(SpinBindingModel model)
        {
            var spin = _repo.CreateSpin(model);
            UpdateTransactionAndBalance(spin);
            return TransformModels.ToSpinViewModel(spin);
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

            _balanceRepo.UpdateBalance(t.Value);
        }
    }
}