using Microsoft.AspNet.Identity;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
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
        [Authorize(Roles = "Admin")]
        public IEnumerable<CouponViewModel> GetAll()
        {
            return _wheelService.GetAllCoupons().Select(x => TransformModels.ToCouponViewModel(x));
        }

        [HttpGet]
        public IEnumerable<CouponViewModel> GetByUserId(string userId)
        {
            return _wheelService.GetCouponByUserId(userId).Select(x => TransformModels.ToCouponViewModel(x));
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public CouponViewModel AddCoupon(CouponBindingModel model)
        {
            var userId = HttpContext.Current.User.Identity.GetUserId();
            return TransformModels.ToCouponViewModel(_wheelService.CreateCoupon(model, userId));
        }

        [HttpGet]
        public bool Exchange(string code)
        {
            var userId = HttpContext.Current.User.Identity.GetUserId();
            return _wheelService.ExchangeCoupon(code, userId);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public bool DeleteCoupon(int id)
        {
            return _wheelService.DeleteCoupon(id);
        }
    }
}