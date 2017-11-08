using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using WheelOfFortune.Services;

namespace WheelOfFortune.Controllers
{
    public class TransactionsController : Controller
    {

        public ActionResult ShowTransactionsHistory()
        {

            var userid = HttpContext.User.Identity.GetUserId();

            ViewBag.UserId = EncryptionService.EncryptString(userid);

            return View();


        }
    }
}