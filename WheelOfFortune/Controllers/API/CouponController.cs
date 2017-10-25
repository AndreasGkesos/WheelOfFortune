using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WheelOfFortune.Models.Domain;
using WheelOfFortune.Models.ViewModels;
using WheelOfFortune.Repos.Interfaces;

namespace WheelOfFortune.Controllers.API
{
    public class CouponController : ApiController
    {
        private readonly ICouponRepo _repo;

        public CouponController(ICouponRepo repo)
        {
            this._repo = repo;
        }

        [HttpPost]
        public IList<Coupon> GetByUserId(string userId)
        {
            return _repo.GetByUserId(userId);
        }

        [HttpPost]
        public Coupon AddCoupon(CouponBindingModel model)
        {
            return _repo.CreateCoupon(model);
        }
    }
}