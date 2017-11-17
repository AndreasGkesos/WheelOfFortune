using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace WheelOfFortune
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}",
                new { controller = "Account", action = "Login", id = UrlParameter.Optional },
                new[] { "WheelOfFortune.Controllers" }
            );
        }
    }
}
