using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using WheelOfFortune.Models.ViewModels;
using WheelOfFortune.Services;

namespace WheelOfFortune.Controllers
{
    public class ProfileController : Controller
    {
        // GET: Profile
        public new ActionResult Profile()
        {
            var userid = HttpContext.User.Identity.GetUserId();
            

            return View("Profile", new ApplicationUserViewModel
            {
                Id = userid
            });
        }
    }
}