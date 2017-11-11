using System;
using System.Collections.Generic;
using System.Linq;
using WheelOfFortune.Models.Domain;
using WheelOfFortune.Models.ViewModels;
using WheelOfFortune.Repos.Interfaces;

namespace WheelTestingProject.RepoTest
{
//    class SpinRepoTest : ISpinRepo
//    {
//        private List<Spin> list = new List<Spin>();
//
//        public SpinRepoTest ()
//        {
//
//        }
//
//        public Spin CreateSpin(SpinBindingModel model)
//        {
//            var spin = new Spin
//            {
//                BetValue = model.BetValue,
//                ResultValue = model.ResultValue,
//                ScoreValue = model.ScoreValue,
//                //User = user,
//                ExecutionDate = DateTime.Now,
//                //WheelConfiguration = _context.WheelConfigurations.FirstOrDefault(x => x.Id == model.WheelConfigurationId)
//            };
//
//            list.Add(spin);
//
//            return spin;
//        }
//
//        public IEnumerable<Spin> GetAll()
//        {
//            return list;
//        }
//
//        public IEnumerable<Spin> GetByUserId(string userId)
//        {
//            return list.Where(x => x.User.Id == userId);
//        }
//    }
}
