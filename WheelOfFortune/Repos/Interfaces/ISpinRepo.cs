using System;
using System.Collections.Generic;
using WheelOfFortune.Models.Domain;
using WheelOfFortune.Models.ViewModels;

namespace WheelOfFortune.Repos.Interfaces
{
    public interface ISpinRepo
    {
        IEnumerable<Spin> GetByUserId(string userId);
        Spin CreateSpin(SpinBindingModel model, string userId);
        IEnumerable<Spin> GetAll();
    }
}