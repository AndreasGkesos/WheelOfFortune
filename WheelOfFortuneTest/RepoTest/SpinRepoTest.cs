using System;
using System.Collections.Generic;
using System.Linq;
using WheelOfFortune.Models;
using WheelOfFortune.Models.Domain;
using WheelOfFortune.Models.ViewModels;
using WheelOfFortune.Repos.Interfaces;

namespace WheelTestingProject.RepoTest
{
    class SpinRepoTest : ISpinRepo
    {
        private List<Spin> list = new List<Spin>();
        private ApplicationUser user = new ApplicationUser { Id = "aaaaa", Email = "andreas@gmail.com", UserName = "andreas" };

        public SpinRepoTest()
        {
            WheelConfiguration wheel = new WheelConfiguration { Id = 1, DateCreated = new DateTime(2017, 10, 10, 10, 20, 4), User = user };

            list.Add(new Spin { Id = 1, BetValue = 10, ScoreValue = 2.0m, ResultValue = 20.0m, ExecutionDate = new DateTime (2017, 11, 11, 8, 23, 4), User = user, WheelConfiguration = wheel });
            list.Add(new Spin { Id = 2, BetValue = 20, ScoreValue = 2.0m, ResultValue = 40.0m, ExecutionDate = new DateTime(2017, 11, 10, 8, 23, 4), User = user, WheelConfiguration = wheel });
        }

        public Spin CreateSpin(SpinBindingModel model, string userId)
        {
            WheelConfiguration wheel = new WheelConfiguration { Id = 1, DateCreated = new DateTime(2017, 10, 10, 10, 20, 4), User = user };

            return new Spin { Id = 6, BetValue = 20, ScoreValue = -1, ResultValue = -20.0m, ExecutionDate = new DateTime(2017, 11, 11, 8, 20, 4), User = user, WheelConfiguration = wheel };
        }

        public IEnumerable<Spin> GetAll()
        {
            return list;
        }

        public IEnumerable<Spin> GetByUserId(string userId)
        {
            return list.Where(x => x.User.Id == userId);
        }
    }
}
