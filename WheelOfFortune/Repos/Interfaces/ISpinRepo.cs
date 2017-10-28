using System;
using System.Collections.Generic;
using WheelOfFortune.Models.Domain;
using WheelOfFortune.Models.ViewModels;

namespace WheelOfFortune.Repos.Interfaces
{
    public interface ISpinRepo
    {
        IEnumerable<SpinViewModel> GetByUserId(string userId);
        Tuple<SpinViewModel, Exception> CreateSpin(SpinBindingModel model);
    }
}