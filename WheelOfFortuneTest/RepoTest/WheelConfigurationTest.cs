using System;
using System.Collections.Generic;
using System.Linq;
using WheelOfFortune.Models;
using WheelOfFortune.Models.Domain;
using WheelOfFortune.Models.ViewModels;
using WheelOfFortune.Repos.Interfaces;

namespace WheelTestingProject.RepoTest
{
    class WheelConfigurationTest : IWheelConfigurationRepo
    {
        private List<WheelConfiguration> list = new List<WheelConfiguration>();
        private ApplicationUser user = new ApplicationUser { Id = "aaaaa", Email = "andreas@gmail.com", UserName = "andreas" };


        public WheelConfigurationTest()
        {
            list.Add(new WheelConfiguration { Id = 1, DateCreated = new DateTime(2017, 11, 10, 8, 23, 4), User = user });
            list.Add(new WheelConfiguration { Id = 2, DateCreated = new DateTime(2017, 11, 11, 3, 13, 4), User = user });
        }

        public WheelConfiguration CreateWheelConfig(string userId)
        {
            return new WheelConfiguration { Id = 2, DateCreated = new DateTime(2017, 11, 11, 3, 13, 4), User = user };
        }

        public IEnumerable<WheelConfiguration> GetByUserId(string userId)
        {
            return list.Where(x => x.User.Id == userId);
        }

        public WheelConfiguration GetWheelConfiguration()
        {
            var currentWheel = 2;
            return list.Where(x => x.Id == currentWheel).First();
        }
    }
}