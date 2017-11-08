using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WheelOfFortune.Services;
using Xunit;

namespace WheelOfFortuneTest
{
    public class WheelServiceTest
    {
        [Fact]
        public void TestGetAll()
        {
            var wheelService = new WheelService(new SpinRepoTest(),
                new TransactionRepoTest(),
                new BalanceRepoTest());

            int count = wheelService.GetAllSpins().Count();

            Assert.Equal(5, count);
        }
    }
}
