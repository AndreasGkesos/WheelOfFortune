using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using WheelOfFortune.Services;

namespace WheelOfFortune.Controllers
{
    public class ProfileController : Controller
    {
        // GET: Profile
        public new ActionResult Profile()
        {
            var userid = HttpContext.User.Identity.GetUserId();

            ViewBag.UserId = EncryptionService.EncryptString(userid);

            return View();
        }
    }
}