using System;
using System.Collections.Generic;
using System.Linq;
using WheelOfFortune.Models;
using WheelOfFortune.Models.Domain;
using WheelOfFortune.Models.ViewModels;
using WheelOfFortune.Repos.Interfaces;

namespace WheelTestingProject.RepoTest
{
    class UserRepoTest : IUserRepo
    {
        private List<ApplicationUser> list = new List<ApplicationUser>();

        public UserRepoTest()
        {
            list.Add(new ApplicationUser { Id = "aaaaa", Email = "andreas1@gmail.com", UserName = "andreas1", Active = true });
            list.Add(new ApplicationUser { Id = "bbbbb", Email = "andreas2@gmail.com", UserName = "andreas2", Active = true });
            list.Add(new ApplicationUser { Id = "ccccc", Email = "andreas3@gmail.com", UserName = "andreas3", Active = true });
            list.Add(new ApplicationUser { Id = "ddddd", Email = "andreas4@gmail.com", UserName = "andreas4", Active = true });
            list.Add(new ApplicationUser { Id = "eeeee", Email = "andreas5@gmail.com", UserName = "andreas5", Active = true });
        }

        public ApplicationUser GetAllById(string userId)
        {
            return list.Where(x => x.Id == userId).First();
        }

        public byte[] GetUserPicture(string userId)
        {
            throw new NotImplementedException();
        }

        public bool UpdateUserActiveStatusById(bool status, string userId)
        {
            var user = list.Where(x => x.Id == userId).First();

            if (user == null) { return false; }

            user.Active = status;
            return true;
        }

        IEnumerable<ApplicationUser> IUserRepo.GetAll()
        {
            return list;
        }
    }
}
