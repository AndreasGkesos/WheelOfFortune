using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WheelOfFortune.Controllers
{
    public class SpinController : Controller
    {
        // GET: Spin
        public ActionResult ShowSpinsHistory()
        {
            return View();
        }
    }
}