using System.Collections.Generic;
using System.Web.Http;
using WheelOfFortune.Models.ViewModels;
using WheelOfFortune.Repos.Interfaces;

namespace WheelOfFortune.Controllers.API
{
    public class CouponController : ApiController
    {
        private readonly ICouponRepo _repo;

        public CouponController(ICouponRepo repo)
        {
            _repo = repo;
        }

        [HttpPost]
        public IEnumerable<CouponViewModel> GetByUserId(string userId)
        {
            return _repo.GetByUserId(userId);
        }

        [HttpPost]
        public CouponViewModel AddCoupon(CouponBindingModel model)
        {
            return _repo.CreateCoupon(model);
        }
    }
}