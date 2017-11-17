using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using WheelOfFortune.Models.ViewModels;
using WheelOfFortune.Services;

namespace WheelOfFortune.Controllers
{
    public class TransactionsController : Controller
    {

        public ActionResult ShowTransactionsHistory()
        {

            var userid = HttpContext.User.Identity.GetUserId();

            return View("ShowTransactionsHistory", new ApplicationUserViewModel
            {
                Id = userid
            });


        }
    }
}