using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using WheelOfFortune.Models.ViewModels;
using WheelOfFortune.Services;

namespace WheelOfFortune.Controllers
{
    public class SpinController : Controller
    {
        // GET: Spin
        public ActionResult ShowSpinsHistory()
        {
            var userid = HttpContext.User.Identity.GetUserId();
          
                ViewBag.UserId = EncryptionService.EncryptString(userid); 

                return View("ShowSpinsHistory", new ApplicationUserViewModel
                {
                    Id = EncryptionService.EncryptString(userid)
                });
            
           
        }
    }
}