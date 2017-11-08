using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using WheelOfFortune.Models.Domain;
using WheelOfFortune.Models.ViewModels;
using WheelOfFortune.Repos.Interfaces;
using WheelOfFortune.Services;

namespace WheelOfFortune.Controllers.API
{
    public class CouponController : ApiController
    {
        private readonly ICouponRepo _repo;
        private readonly ITransactionRepo _transactionRepo;
        private readonly IBalanceRepo _balanceRepo;

        public CouponController(ICouponRepo repo, ITransactionRepo transactionRepo, IBalanceRepo balanceRepo)
        {
            _repo = repo;
            _transactionRepo = transactionRepo;
            _balanceRepo = balanceRepo;
        }

        [HttpGet]
        public IEnumerable<CouponViewModel> GetAll()
        {
            return _repo.GetAll().Select(x => TransformModels.ToCouponViewModel(x));
        }

        [HttpGet]
        public IEnumerable<CouponViewModel> GetByUserId(string userId)
        {       
                return _repo.GetByUserId(EncryptionService.DecryptString(userId)).Select(x => TransformModels.ToCouponViewModel(x));   
        }

        [HttpPost]
        public CouponViewModel AddCoupon(CouponBindingModel model)
        {
            return TransformModels.ToCouponViewModel(_repo.CreateCoupon(model));
        }

        [HttpGet]
        public bool ExchangeCoupon(string code)
        {
            var value = _repo.Exchange(code);

            if (value == null)
                return false; //false for fail exchange

            UpdateTransactionAndBalance(Convert.ToDecimal(value));
            return true;
        }

        private void UpdateTransactionAndBalance(decimal value)
        {
            var t = _transactionRepo.CreateTransaction(
                new TransactionBindingModel
                {
                    TransactionDate = DateTime.Now,
                    Type = TransactionType.FromCoupon,
                    Value = value
                });
            _balanceRepo.UpdateBalance(t.Value);
        }
    }
}