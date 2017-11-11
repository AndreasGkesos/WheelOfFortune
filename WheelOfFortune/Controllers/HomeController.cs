using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using WheelOfFortune.Models.ViewModels;
using WheelOfFortune.Services;

namespace WheelOfFortune.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
         


        public ActionResult Index()
        {
            var userid = HttpContext.User.Identity.GetUserId();

            return View("Index", new ApplicationUserViewModel
            {
                Id = EncryptionService.EncryptString(userid)
            });
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}