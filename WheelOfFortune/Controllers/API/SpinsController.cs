using System.Collections.Generic;
using System.Web.Http;
using System.Linq;
using WheelOfFortune.Models.ViewModels;
using WheelOfFortune.Services;
using System.Web;
using System.Web.Http.Cors;
using Microsoft.AspNet.Identity;

namespace WheelOfFortune.Controllers.API
{
    [EnableCors(origins: "http://localhost:50576", headers: "*", methods: "*")]
    public class SpinsController : ApiController
    {
        private readonly IWheelService _wheelService;

        public SpinsController(IWheelService wheelService)
        {
            _wheelService = wheelService;
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IEnumerable<SpinViewModel> GetAll()
        {
            return _wheelService.GetAllSpins().Select(TransformModels.ToSpinViewModel);
        }

        [HttpGet]
        [EnableCors(origins: "http://localhost:50576", headers: "*", methods: "*")]

        public IEnumerable<SpinViewModel> GetByUserId(string userId)
        {
            return _wheelService.GetSpinByUserId(userId).Select(TransformModels.ToSpinViewModel);
        }

        [HttpPost]
        public SpinViewModel AddSpin(SpinBindingModel model)
        {
            var userId = HttpContext.Current.User.Identity.GetUserId();
            return TransformModels.ToSpinViewModel(_wheelService.CreateSpin(model, userId));
        }
    }
}