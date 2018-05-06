﻿using Gcon.Website.Attributes;
using System.Web;
using System.Web.Mvc;

namespace Gcon.Website
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new LocalizationAttribute("pt-br"), 0);
        }
    }

    public class FiltroAcesso : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            object UsuarioLogado = filterContext.HttpContext.Session["Usuario"];
            if (UsuarioLogado == null)
            {
                filterContext.Result = new RedirectToRouteResult(
                            new System.Web.Routing.RouteValueDictionary(
                                new { action = "Index", controller = "Login" }));
            }
        }
    }
}
