using WheelOfFortune.Models.Domain;

namespace WheelOfFortune.Repos.Interfaces
{
    public interface IBalanceRepo
    {
        Balance GetByUserId(string userId);
        Balance UpdateBalance(decimal balance, string userId);
        Balance CreateBalance(string userId);
        decimal GetBalanceByUserId(string userId);
    }
}