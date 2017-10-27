using System.Web.Mvc;

namespace WheelOfFortune.Controllers
{
    public class TransactionsController : Controller
    {
        
        public ActionResult ShowTransactionsHistory()
        {
            return View();
        }
    }
}