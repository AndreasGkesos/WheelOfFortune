using System;
using System.Collections.Generic;
using System.Linq;
using WheelOfFortune.Models.Domain;
using WheelOfFortune.Models.ViewModels;
using WheelOfFortune.Repos.Interfaces;

namespace WheelTestingProject.RepoTest
{
    class WheelConfigurationTest : IWheelConfigurationRepo
    {
        private List<WheelConfiguration> list = new List<WheelConfiguration>();

        public WheelConfigurationTest()
        {

        }

        public WheelConfiguration CreateWheelConfig(string userId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<WheelConfiguration> GetByUserId(string userId)
        {
            throw new NotImplementedException();
        }

        public WheelConfiguration GetWheelConfiguration()
        {
            throw new NotImplementedException();
        }
    }
}
