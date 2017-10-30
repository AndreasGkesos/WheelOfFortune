using System;
using System.Collections.Generic;
using WheelOfFortune.Models.Domain;
using WheelOfFortune.Models.ViewModels;

namespace WheelOfFortune.Repos.Interfaces
{
    public interface IWheelConfigurationSliceRepo
    {
        IEnumerable<WheelConfigurationSlice> GetByWheelConfigurationId(int configId);
        WheelConfigurationSlice CreateSlice(WheelConfigurationSliceBindingModel model);
    }
}