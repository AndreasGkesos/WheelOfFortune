using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WheelOfFortune.Models.Domain;
using WheelOfFortune.Models.ViewModels;

namespace WheelOfFortune.Repos.Interfaces
{
    public interface IWheelConfigurationSliceRepo
    {
        IList<WheelConfigurationSliceViewModel> GetByWheelConfigurationId(int configId);
    }
}