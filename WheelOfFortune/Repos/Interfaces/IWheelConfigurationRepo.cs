using System;
using System.Collections.Generic;
using WheelOfFortune.Models.Domain;

namespace WheelOfFortune.Repos.Interfaces
{
    public interface IWheelConfigurationRepo
    {
        IEnumerable<WheelConfiguration> GetByUserId(string userId);
        WheelConfiguration GetWheelConfiguration();
        WheelConfiguration CreateWheelConfig(string userId);
    }
}