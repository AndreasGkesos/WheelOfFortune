using System.Web.Http;
using WheelOfFortune.Models.ViewModels;
using WheelOfFortune.Services;
using System.Web;
using Microsoft.AspNet.Identity;

namespace WheelOfFortune.Controllers.API
{   
    
    public class WheelConfigurationController : ApiController
    {
        private readonly IWheelService _wheelService;

        public WheelConfigurationController(IWheelService wheelService)
        {
           _wheelService = wheelService;
        }

        [HttpGet]
        public WheelDataViewModel GetWheelConfiguration()
        {
            return _wheelService.GetWheelConfiguration();
        }

        [HttpPost]
        public WheelConfigurationViewModel AddWheelConfiguration(WheelConfigurationBindingModel model)
        {
            var userId = HttpContext.Current.User.Identity.GetUserId();
            return TransformModels.ToWheelConfigurationViewModel(_wheelService.CreateWheelConfig(model, userId));
        }
    }
}