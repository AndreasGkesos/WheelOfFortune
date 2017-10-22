using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WheelOfFortune.Models.Domain;

namespace WheelOfFortune.Repos.Interfaces
{
    public interface IWheelConfigurationSliceRepo
    {
        IList<WheelConfigurationSlice> GetByWheelConfigurationId(int configId);
    }
}