using System;
using WheelOfFortune.Models.Domain;

namespace WheelOfFortune.Models.ViewModels
{
    public class TransformModels
    {
        public static WheelConfigurationSliceViewModel ToWheelConfigurationSliceViewModel(WheelConfigurationSlice model)
        {
            return new WheelConfigurationSliceViewModel
            {
                probability = model.Propability,
                resultText = model.ResultText,
                type = model.Type,
                value = model.Value,
                win = model.Win,
                userData = new UserDataViewModel { score = model.Score }
            };
        }

        public static CouponViewModel ToCouponViewModel(Coupon model)
        {
            return new CouponViewModel
            {
                Id = model.Id,
                Value = Convert.ToInt32(model.Value.Value),
                Code = model.Code,
                DateCreated = model.DateCreated,
                DateExpired = model.DateExpired,
                DateExchanged = model.DateExchanged,
                User = ToApplicationUserViewModel(model.User),
                Active = model.Active
            };
        }

        public static SpinViewModel ToSpinViewModel(Spin model)
        {
            return new SpinViewModel
            {
                Id = model.Id,
                BetValue = model.BetValue,
                ScoreValue = model.ScoreValue,
                ResultValue = model.ResultValue,
                ExecutionDate = model.ExecutionDate,
                WheelConfigurationId = model.WheelConfiguration.Id,
                User = ToApplicationUserViewModel(model.User)
            };
        }

        public static ApplicationUserViewModel ToApplicationUserViewModel(ApplicationUser model)
        {
            return new ApplicationUserViewModel
            {
                Id = model.Id,
                Email = model.Email,
                UserName = model.UserName,
                UName = model.UName,
                UserPhoto = model.UserPhoto,
                Active = model.Active
            };
        }

        public static TransactionViewModel ToTransactionViewModel(Transaction model)
        {
            return new TransactionViewModel
            {
                Id = model.Id,
                Value = model.Value,
                Type = model.Type,
                TransactionDate = model.TransactionDate,
                User = ToApplicationUserViewModel(model.User)
            };
        }

        public static BalanceViewModel ToBalanceViewModel(Balance model)
        {
            return new BalanceViewModel
            {
                Id = model.Id,
                BalanceValue = model.BalanceValue,
                User = ToApplicationUserViewModel(model.User)
            };
        }

        public static WheelConfigurationViewModel ToWheelConfigurationViewModel(WheelConfiguration model)
        {
            return new WheelConfigurationViewModel
            {
                Id = model.Id,
                DateCreated = model.DateCreated,
                User = ToApplicationUserViewModel(model.User)
            };
        }
    }
}