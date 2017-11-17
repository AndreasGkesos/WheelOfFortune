using System;
using System.Collections.Generic;
using System.Linq;
using WheelOfFortune.Models;
using WheelOfFortune.Models.Domain;
using WheelOfFortune.Models.ViewModels;
using WheelOfFortune.Repos.Interfaces;

namespace WheelOfFortune.Services
{
    public class WheelService : IWheelService
    {
        private readonly ISpinRepo _spinRepo;
        private readonly ITransactionRepo _transactionRepo;
        private readonly IBalanceRepo _balanceRepo;
        private readonly ICouponRepo _couponRepo;
        private readonly ICouponValueRepo _couponValueRepo;
        private readonly IWheelConfigurationRepo _wheelConfigurationRepo;
        private readonly IWheelConfigurationSliceRepo _wheelConfigurationSliceRepo;
        private readonly IUserRepo _userRepo;

        public WheelService(ISpinRepo spinRepo,
                            ITransactionRepo transactionRepo,
                            IBalanceRepo balanceRepo,
                            ICouponRepo couponRepo,
                            ICouponValueRepo couponValueRepo,
                            IWheelConfigurationRepo wheelConfigurationRepo,
                            IWheelConfigurationSliceRepo wheelConfigurationSliceRepo,
                            IUserRepo userRepo)
        {
            _spinRepo = spinRepo;
            _transactionRepo = transactionRepo;
            _balanceRepo = balanceRepo;
            _couponRepo = couponRepo;
            _couponValueRepo = couponValueRepo;
            _wheelConfigurationRepo = wheelConfigurationRepo;
            _wheelConfigurationSliceRepo = wheelConfigurationSliceRepo;
            _userRepo = userRepo;
        }

        public Spin CreateSpin(SpinBindingModel model, string userId)
        {
            var spin = _spinRepo.CreateSpin(model, userId);
            UpdateTransactionAndBalance(spin, userId);
            return spin;
        }

        private void UpdateTransactionAndBalance(Spin spin, string userId)
        {
            var t = _transactionRepo.CreateTransaction(
                new TransactionBindingModel
                {
                    TransactionDate = DateTime.Now,
                    Type = TransactionType.FromSpin,
                    Value = spin.ResultValue
                }, userId);

            _balanceRepo.UpdateBalance(t.Value, userId);
        }

        public IEnumerable<Spin> GetAllSpins()
        {
            return _spinRepo.GetAll();
        }

        public IEnumerable<Spin> GetSpinByUserId(string userId)
        {
            return _spinRepo.GetByUserId(userId);
        }

        public Balance GetBalanceObjectByUserId(string userId)
        {
            return _balanceRepo.GetByUserId(userId);
        }

        public Balance CreateBalance(string userId)
        {
            return _balanceRepo.CreateBalance(userId);
        }

        public decimal GetBalanceByUserId(string userId)
        {
            return _balanceRepo.GetBalanceByUserId(userId);
        }

        public Balance UpdateBalance(decimal balance, string userId)
        {
            return _balanceRepo.UpdateBalance(balance, userId);
        }

        public IEnumerable<Coupon> GetCouponByUserId(string userId)
        {
            return _couponRepo.GetByUserId(userId);
        }

        public Coupon UpdateCouponExpirationDate(Coupon coupon, DateTime date)
        {
            return _couponRepo.UpdateExpirationDate(coupon, date);
        }

        public Coupon CreateCoupon(CouponBindingModel model, string userId)
        {
            return _couponRepo.CreateCoupon(model, userId);
        }

        public IEnumerable<Coupon> GetAllCoupons()
        {
            return _couponRepo.GetAll();
        }

        public bool ExchangeCoupon(string code, string userId)
        {
            var value = _couponRepo.Exchange(code);

            if (value == null)
                return false; //false for fail exchange

            UpdateTransactionAndBalance(Convert.ToDecimal(value), userId);
            return true;
        }

        public bool DeleteCoupon(int id)
        {
            return _couponRepo.Delete(id);
        }

        private void UpdateTransactionAndBalance(decimal value, string userId)
        {
            var t = _transactionRepo.CreateTransaction(
                new TransactionBindingModel
                {
                    TransactionDate = DateTime.Now,
                    Type = TransactionType.FromCoupon,
                    Value = value
                }, userId);
            _balanceRepo.UpdateBalance(t.Value, userId);
        }

        public IEnumerable<Transaction> GetTransactionsByUserId(string userId)
        {
            return _transactionRepo.GetByUserId(userId);
        }

        public Transaction CreateTransaction(TransactionBindingModel model, string userId)
        {
            return _transactionRepo.CreateTransaction(model, userId);
        }

        public IEnumerable<Transaction> GetAllTransactions()
        {
            return _transactionRepo.GetAll();
        }

        public CouponValue CreateCouponValue(int value, string userId)
        {
            return _couponValueRepo.CreateCouponValue(value, userId);
        }

        public CouponValue UpdateCouponValue(int id, int value)
        {
            return _couponValueRepo.UpdateCouponValue(id, value);
        }

        public IEnumerable<WheelConfiguration> GetWheelConfigurationByUserId(string userId)
        {
            return _wheelConfigurationRepo.GetByUserId(userId);
        }

        public WheelDataViewModel GetWheelConfiguration()
        {
            var config = _wheelConfigurationRepo.GetWheelConfiguration();
            var slices = _wheelConfigurationSliceRepo.GetByWheelConfigurationId(config.Id).Select(x => TransformModels.ToWheelConfigurationSliceViewModel(x));

            return new WheelDataViewModel
            {
                configId = config.Id,
                colorArray = new List<string> { "#364C62", "#F1C40F", "#E67E22", "#E74C3C", "#ECF0F1", "#95A5A6", "#16A085", "#27AE60", "#2980B9", "#8E44AD", "#2C3E50", "#F39C12", "#D35400", "#C0392B", "#BDC3C7", "#1ABC9C", "#2ECC71", "#E87AC2", "#3498DB", "#9B59B6", "#7F8C8D" },
                segmentValuesArray = slices,
                svgWidth = 1024,
                svgHeight = 768,
                wheelStrokeColor = "#D0BD0C",
                wheelStrokeWidth = 18,
                wheelSize = 700,
                wheelTextOffsetY = 80,
                wheelTextColor = "#000",
                wheelTextSize = "2.3em",
                wheelImageOffsetY = 40,
                wheelImageSize = 50,
                centerCircleSize = 0,
                centerCircleStrokeColor = "#F1DC15",
                centerCircleStrokeWidth = 12,
                centerCircleFillColor = "#EDEDED",
                segmentStrokeColor = "#E2E2E2",
                segmentStrokeWidth = 4,
                centerX = 512,
                centerY = 384,
                hasShadows = false,
                numSpins = 999,
                spinDestinationArray = new List<string>(),
                minSpinDuration = 6,
                gameOverText = "GAME OVER",
                invalidSpinText = "INVALID SPIN. PLEASE SPIN AGAIN.",
                introText = "YOU HAVE TO<br>SPIN IT <span style='color:#F282A9;'>2</span> WIN IT!",
                hasSound = true,
                gameId = "9a0232ec06bc431114e2a7f3aea03bbe2164f1aa",
                clickToSpin = true

            };
        }

        public WheelConfiguration CreateWheelConfig(WheelConfigurationBindingModel model, string userId)
        {
            var wheel = _wheelConfigurationRepo.CreateWheelConfig(userId);

            if (wheel == null)
                throw new Exception("Wheel config could not be created");

            foreach (var s in model.Slices)
            {
                s.WheelConfiguration = wheel;
                _wheelConfigurationSliceRepo.CreateSlice(s);
            }
            return wheel;
        }

        public IEnumerable<ApplicationUser> GetAllUsers()
        {
            return _userRepo.GetAll();
        }

        public ApplicationUser GetUserById(string userId)
        {
            return _userRepo.GetAllById(userId);
        }

        public byte[] GetUserImage(string userId)
        {
            return _userRepo.GetUserPicture(userId);
        }

        public bool UpdateUserActiveStatusById(bool status, string userId)
        {
            return _userRepo.UpdateUserActiveStatusById(status, userId);
        }
    }
}