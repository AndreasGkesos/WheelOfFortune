using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WheelOfFortune.Models;

namespace WheelOfFortune.Repos.Interfaces
{
    public interface IUserRepo
    {
        IEnumerable<ApplicationUser> GetAll();
        ApplicationUser GetAllById(string userId);
    }
}