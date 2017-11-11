using System;
using System.Collections.Generic;
using System.Linq;
using WheelOfFortune.Models.Domain;
using WheelOfFortune.Models.ViewModels;
using WheelOfFortune.Repos.Interfaces;

namespace WheelTestingProject.RepoTest
{
    class WheelConfigurationSliceTest : IWheelConfigurationSliceRepo
    {
        private List<WheelConfigurationSlice> list = new List<WheelConfigurationSlice>();

        public WheelConfigurationSliceTest()
        {

        }

        public WheelConfigurationSlice CreateSlice(WheelConfigurationSliceBindingModel model)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<WheelConfigurationSlice> GetByWheelConfigurationId(int configId)
        {
            throw new NotImplementedException();
        }
    }
}
