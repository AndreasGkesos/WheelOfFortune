using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WheelOfFortune.Models;
using WheelOfFortune.Models.Domain;

namespace WheelOfFortune.Repos.Interfaces
{
    public interface IBalanceRepo
    {
        Balance GetByUserId(string userId);
        Balance UpdateBalance(long balance);
        Balance CreateBalance();
    }
}