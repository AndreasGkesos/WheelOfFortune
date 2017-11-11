using System;
using System.Collections.Generic;
using System.Linq;
using WheelOfFortune.Models.Domain;
using WheelOfFortune.Models.ViewModels;
using WheelOfFortune.Repos.Interfaces;
using WheelOfFortune.Models;

namespace WheelTestingProject.RepoTest
{
    class BalanceRepoTest : IBalanceRepo
    {
        private List<Balance> list = new List<Balance>();

        public BalanceRepoTest()
        {
            ApplicationUser user1 = new ApplicationUser { Id = "aaaaa", Email = "andreas1@gmail.com", UserName = "andreas1" };
            ApplicationUser user2 = new ApplicationUser { Id = "bbbbb", Email = "andreas2@gmail.com", UserName = "andreas2" };


            list.Add(new Balance { Id = 1, BalanceValue = 100, User = user1 });
            list.Add(new Balance { Id = 2, BalanceValue = 120, User = user2 });
        }

        public Balance CreateBalance(string userId)
        {
            ApplicationUser user = new ApplicationUser { Id = "aaaaa", Email = "andreas@gmail.com", UserName = "andreas" };

            return new Balance { Id = 1, BalanceValue = 100, User = user };
        }

        public decimal GetBalanceByUserId(string userId)
        {
            return list.Where(x => x.User.Id == userId).First().BalanceValue;
        }

        public Balance GetByUserId(string userId)
        {
            return list.Where(x => x.User.Id == userId).First();
        }

        public Balance UpdateBalance(decimal balance, string userId)
        {
            ApplicationUser user = new ApplicationUser { Id = "aaaaa", Email = "andreas@gmail.com", UserName = "andreas" };
            Balance blc = new Balance { Id = 1, BalanceValue = 100, User = user };

            blc.BalanceValue = blc.BalanceValue + balance;
            return blc;
        }
    }
}
