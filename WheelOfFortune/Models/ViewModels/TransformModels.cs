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
                Value = Convert.ToInt32(model.Value.Value),
                DateCreated = model.DateCreated,
                DateExpired = model.DateExpired,
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
                UserPhoto = model.UserPhoto
            };
        }
    }
}