using System;
using Microsoft.AspNet.Identity;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;
using WheelOfFortune.Models.ViewModels;
using WheelOfFortune.Services;

namespace WheelOfFortune.Controllers.API
{
    public class CouponController : ApiController
    {
        private readonly IWheelService _wheelService;

        public CouponController(IWheelService wheelService)
        {
            _wheelService = wheelService;
        }

        [HttpGet]
//        [Authorize(Roles = "Admin")]
        [EnableCors(origins: "http://localhost:50576", headers: "*", methods: "*")]
        public IEnumerable<CouponViewModel> GetAll()
        {
            return _wheelService.GetAllCoupons().Select(x => TransformModels.ToCouponViewModel(x));
        }

        [HttpGet]
        public IEnumerable<CouponViewModel> GetByUserId(string userId)
        {
            return _wheelService.GetCouponByUserId(userId).Select(x => TransformModels.ToCouponViewModel(x));
        }

        [HttpGet]
        [EnableCors(origins: "http://localhost:50576", headers: "*", methods: "*")]
        public CouponViewModel AddCoupon(string value)
        {
            var converted = Convert.ToInt32(value);
            var userId = HttpContext.Current.User.Identity.GetUserId();
            return TransformModels.ToCouponViewModel(_wheelService.CreateCoupon(converted, userId));
        }

        [HttpGet]
        public bool Exchange(string code)
        {
            var userId = HttpContext.Current.User.Identity.GetUserId();
            return _wheelService.ExchangeCoupon(code, userId);
        }

        [HttpPost]
//        [Authorize(Roles = "Admin")]
        [EnableCors(origins: "http://localhost:50576", headers: "*", methods: "*")]

        public bool DeleteCoupon(int id)
        {
            return _wheelService.DeleteCoupon(id);
        }
        [EnableCors(origins: "http://localhost:50576", headers: "*", methods: "*")]
        public IHttpActionResult GetCouponValues()
        {
            return Ok(_wheelService.GetCouponValues());
        }
    }
}