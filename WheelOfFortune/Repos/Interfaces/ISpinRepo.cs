using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WheelOfFortune.Models;
using WheelOfFortune.Models.Domain;

namespace WheelOfFortune.Repos.Interfaces
{
    public interface ISpinRepo
    {
        IList<Spin> GetByUserId(string userId);
        Spin CreateSpin(string userId);
    }
}