using Microsoft.AspNet.Identity;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using WheelOfFortune.Models.ViewModels;
using WheelOfFortune.Services;

namespace WheelOfFortune.Controllers.API
{
    public class UserController : ApiController
    {
        private readonly IWheelService _wheelService;

        public UserController(IWheelService wheelService)
        {
            _wheelService = wheelService;
        }

        [HttpGet]
        public IEnumerable<ApplicationUserViewModel> GetAll()
        {
            return _wheelService.GetAllUsers().Select(x => TransformModels.ToApplicationUserViewModel(x));
        }

        [HttpGet]
        public ApplicationUserViewModel GetByUserId(string userId)
        {
            return TransformModels.ToApplicationUserViewModel(_wheelService.GetUserById(userId));
        } 
    }
}