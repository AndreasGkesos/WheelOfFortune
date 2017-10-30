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
        public IEnumerable<SpinViewModel> GetAll()
        {
            List<SpinViewModel> list = new List<SpinViewModel>();
            foreach (Spin s in _repo.GetAll())
            {
                list.Add(TransformModels.ToSpinViewModel(s));
            }
            return list;
        }

        [HttpGet]
        public IEnumerable<SpinViewModel> GetByUserId(string userId)
        {
            List<SpinViewModel> list = new List<SpinViewModel>();
            foreach (Spin s in _repo.GetByUserId(userId))
            {
                list.Add(TransformModels.ToSpinViewModel(s));
            }
            return list;
        }

        [HttpPost]
        public SpinViewModel AddSpin(SpinBindingModel model)
        {
            var spin = _repo.CreateSpin(model);
            UpdateTransactionAndBalance(spin.Item1);
            return spin.Item1;
        }

        private void UpdateTransactionAndBalance(SpinViewModel spin)
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