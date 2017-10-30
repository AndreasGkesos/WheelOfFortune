using System;
using System.Collections.Generic;
using System.Web.Http;
using WheelOfFortune.Models.Domain;
using WheelOfFortune.Models.ViewModels;
using WheelOfFortune.Repos.Interfaces;

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
            List<CouponViewModel> list = new List<CouponViewModel>();
            foreach (Coupon c in _repo.GetAll())
            {
                list.Add(TransformModels.ToCouponViewModel(c));
            }
            return list;
        }

        [HttpGet]
        public IEnumerable<CouponViewModel> GetByUserId(string userId)
        {
            List<CouponViewModel> list = new List<CouponViewModel>();
            foreach (Coupon c in _repo.GetByUserId(userId))
            {
                list.Add(TransformModels.ToCouponViewModel(c));
            }
            return list;
        }

        [HttpPost]
        public CouponViewModel AddCoupon(CouponBindingModel model)
        {
            return _repo.CreateCoupon(model);
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
            _balanceRepo.UpdateBalance(t.Item1.Value);
        }
    }
}