using System;
using System.Collections.Generic;
using System.Linq;
using WheelOfFortune.Models;
using WheelOfFortune.Models.Domain;
using WheelOfFortune.Models.ViewModels;
using WheelOfFortune.Repos.Interfaces;

namespace WheelTestingProject.RepoTest
{
    class WheelConfigurationSliceTest : IWheelConfigurationSliceRepo
    {
        private List<WheelConfigurationSlice> list = new List<WheelConfigurationSlice>();
        private ApplicationUser user = new ApplicationUser { Id = "aaaaa", Email = "andreas@gmail.com", UserName = "andreas" };

        public WheelConfigurationSliceTest()
        {
            WheelConfiguration wheel = new WheelConfiguration { Id = 1, DateCreated = DateTime.Now, User = user };

            list.Add(new WheelConfigurationSlice { Id = 1, Propability = 25, Type = "string", Value = "Win 1.5", Win = true, ResultText = "Win 1.5", Score = 1.5, User = user, WheelConfiguration = wheel });
            list.Add(new WheelConfigurationSlice { Id = 2, Propability = 25, Type = "string", Value = "Win 2", Win = true, ResultText = "Win 2", Score = 2, User = user, WheelConfiguration = wheel });
            list.Add(new WheelConfigurationSlice { Id = 3, Propability = 25, Type = "string", Value = "Lose 1.5", Win = false, ResultText = "Lose 1.5", Score = -1.5, User = user, WheelConfiguration = wheel });
            list.Add(new WheelConfigurationSlice { Id = 4, Propability = 25, Type = "string", Value = "Lose 2", Win = false, ResultText = "Lose 2", Score = -2, User = user, WheelConfiguration = wheel });
        }

        public WheelConfigurationSlice CreateSlice(WheelConfigurationSliceBindingModel model)
        {
            WheelConfiguration wheel = new WheelConfiguration { Id = 1, DateCreated = DateTime.Now, User = user };

            return new WheelConfigurationSlice { Id = 1, Propability = 25, Type = "string", Value = "Win 1.5", Win = true, ResultText = "Win 1.5", Score = 1.5, User = user, WheelConfiguration = wheel };
        }

        public IEnumerable<WheelConfigurationSlice> GetByWheelConfigurationId(int configId)
        {
            return list.Where(x => x.WheelConfiguration.Id == configId);
        }
    }
}
