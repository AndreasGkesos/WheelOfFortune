using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using WheelOfFortune.Services;

namespace WheelOfFortune.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        


        public ActionResult Index()
        {
            var userid = HttpContext.User.Identity.GetUserId();

            ViewBag.UserId = EncryptionService.EncryptString(userid);

            return View("Index");
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