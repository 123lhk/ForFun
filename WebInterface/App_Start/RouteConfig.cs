using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace WebInterface
{
	public class RouteConfig
	{
		public static void RegisterRoutes(RouteCollection routes)
		{
			routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

			//routes.MapRoute(
			//	name: "Default",
			//	url: "{controller}/{action}/{id}",
			//	defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional, area = "Home" },
			//	namespaces: new string[] { "WebInterface.Areas.Home.Controllers" }
			//).DataTokens["UseNamespaceFallback"] = false;

			routes.MapRoute("redirect_all_other_requests", "",
				new
				{
					controller = "Home",
					action = "Dashboard"
				}).DataTokens = new RouteValueDictionary(new { area = "Home" });
		}
	}
}
