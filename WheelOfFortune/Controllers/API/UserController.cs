using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;
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
       
        [EnableCors(origins: "http://localhost:50576", headers: "*", methods: "*")]
       // [Authorize(Roles = "Admin")]
        public IEnumerable<ApplicationUserViewModel> GetAll()
        {
            return _wheelService.GetAllUsers().Select(x => TransformModels.ToApplicationUserViewModel(x));
        }

        [HttpGet]
        public ApplicationUserViewModel GetByUserId(string userId)
        {
            return TransformModels.ToApplicationUserViewModel(_wheelService.GetUserById(userId));
        }

        [HttpPost]
        [EnableCors(origins: "http://localhost:50576", headers: "*", methods: "*")]
        public bool UpdateUserActiveStatus(bool status, string userId)
        {
            return _wheelService.UpdateUserActiveStatusById(status, userId);
        }

        [HttpGet]
        public IHttpActionResult GetUserPhoto(string userId)
        {
            var result = _wheelService.GetUserImage(userId);

            return result == null ? Ok((byte[]) null) : Ok(result);
        }
    }
}