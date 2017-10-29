using System;
using WheelOfFortune.Models.Domain;

namespace WheelOfFortune.Repos.Interfaces
{
    public interface IBalanceRepo
    {
        Balance GetByUserId(string userId);
        Tuple<Balance, Exception> UpdateBalance(decimal balance);
        Balance CreateBalance(string userId);
        decimal GetBalanceByUserId(string userId);
    }
}