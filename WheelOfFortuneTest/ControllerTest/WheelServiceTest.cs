
using WheelOfFortune.Repos.Interfaces;
using WheelOfFortune.Controllers.API;
using WheelTestingProject.RepoTest;
using System.Linq;
using WheelOfFortune.Services;
using Xunit;

namespace WheelTestingProject.ControllerTest
{
    public class WheelServiceTest
    {
        [Fact]
        public void TestGetAll ()
        {
            var wheelService = new WheelService(new SpinRepoTest(),
                new TransactionRepoTest(),
                new BalanceRepoTest());

            int count = wheelService.GetAllSpins().Count();

            Assert.Equal(5, count);
        }
    }
}