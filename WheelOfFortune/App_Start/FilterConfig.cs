﻿using System.Web;
using System.Web.Mvc;

namespace WheelOfFortune
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            //filters.Add(new AuthorizeAttribute());
            //filters.Add(new ValidateAntiForgeryTokenAttribute());
        }
    }
}
