using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WheelOfFortune.Models.Domain;
using WheelOfFortune.Models.ViewModels;

namespace WheelOfFortune.Repos.Interfaces
{
    public interface IWheelConfigurationRepo
    {
        IList<WheelConfiguration> GetByUserId(string userId);
        WheelConfiguration GetWheelConfiguration();
        Tuple<WheelConfiguration, Exception> CreateWheelConfig();
    }
}