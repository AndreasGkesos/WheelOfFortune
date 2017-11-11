
using WheelOfFortune.Repos.Interfaces;
using WheelOfFortune.Controllers.API;
using WheelTestingProject.RepoTest;
using System.Linq;
using WheelOfFortune.Services;
using Xunit;
using WheelOfFortune.Models.Domain;
using System;
using WheelOfFortune.Models;

namespace WheelTestingProject.ControllerTest
{
    public class WheelServiceTest
    {
        [Fact]
        public void TestGetAllSpins()
        {
            var wheelService = new WheelService(new SpinRepoTest(),
                new TransactionRepoTest(),
                new BalanceRepoTest(),
                new CouponRepoTest(),
                new CouponValueRepoTest(),
                new WheelConfigurationTest(),
                new WheelConfigurationSliceTest());
            int count = wheelService.GetAllSpins().Count();

            Assert.Equal(2, count);
        }

        [Fact]
        public void TestCreateSpin()
        {
            ApplicationUser user = new ApplicationUser { Id = "aaaaa", Email = "andreas@gmail.com", UserName = "andreas" };
            WheelConfiguration wheel = new WheelConfiguration { Id = 1, DateCreated = DateTime.Now, User = user };

            var wheelService = new WheelService(new SpinRepoTest(),
                new TransactionRepoTest(),
                new BalanceRepoTest(),
                new CouponRepoTest(),
                new CouponValueRepoTest(),
                new WheelConfigurationTest(),
                new WheelConfigurationSliceTest());
            Spin spin = wheelService.CreateSpin(new WheelOfFortune.Models.ViewModels.SpinBindingModel { BetValue = 10, ExecutionDate = DateTime.Now, ResultValue = 20, ScoreValue = 2, WheelConfigurationId = 1}, "aaaaa");

            Assert.Equal(new Spin { Id = 6, BetValue = 20, ScoreValue = -1.0m, ResultValue = -20.0m, ExecutionDate = new DateTime(2017, 11, 11, 8, 20, 4), User = user, WheelConfiguration = wheel }, spin);
        }
    }
}