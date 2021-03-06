﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Gcon.Website
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Language",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Mural", action = "Index", id = UrlParameter.Optional },
                constraints: new { lang = @"pt-br|en|es" }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Mural", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
