using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WheelOfFortune.Models;
using WheelOfFortune.Models.Domain;
using WheelOfFortune.Models.ViewModels;

namespace WheelOfFortune.Repos.Interfaces
{
    public interface ISpinRepo
    {
        IList<Spin> GetByUserId(string userId);
        Spin CreateSpin(SpinBindingModel model);
    }
}