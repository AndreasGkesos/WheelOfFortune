using WheelOfFortune.Models.Domain;

namespace WheelOfFortune.Repos.Interfaces
{
    public interface ICouponValueRepo
    {
        CouponValue CreateCouponValue(int value);
        CouponValue UpdateCouponValue(int id, int value);
    }
}