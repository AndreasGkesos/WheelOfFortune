using WheelOfFortune.Models.Domain;

namespace WheelOfFortune.Repos.Interfaces
{
    public interface ICouponValueRepo
    {
        CouponValue CreateCouponValue(int value, string userId);
        CouponValue UpdateCouponValue(int id, int value);
    }
}