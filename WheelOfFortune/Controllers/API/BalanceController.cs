using Microsoft.AspNet.Identity;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;
using WheelOfFortune.Models.ViewModels;
using WheelOfFortune.Services;

namespace WheelOfFortune.Controllers.API
{
    public class BalanceController : ApiController
    {
        private readonly IWheelService _wheelService;

        public BalanceController(IWheelService wheelService)
        {
            _wheelService = wheelService;
        }

        [ResponseType(typeof(decimal))]
        [HttpGet]
        public IHttpActionResult GetBalance(string userId)
        {
           var balance = _wheelService.GetBalanceByUserId(userId);

            return Ok(balance);
        }

        [HttpPost]
        public BalanceViewModel UpdateBalance(decimal balance)
        {
            var userId = HttpContext.Current.User.Identity.GetUserId();
            return TransformModels.ToBalanceViewModel(_wheelService.UpdateBalance(balance, userId));
        }

        [HttpPost]
        public BalanceViewModel CreateBalance()
        {
            var userId = HttpContext.Current.User.Identity.GetUserId();
            return TransformModels.ToBalanceViewModel(_wheelService.CreateBalance(userId));
        }
    }
}
