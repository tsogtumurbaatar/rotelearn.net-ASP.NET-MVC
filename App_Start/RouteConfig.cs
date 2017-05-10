using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace rotelearn
{
	public class RouteConfig
	{
		public static void RegisterRoutes(RouteCollection routes)
		{
			routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

			routes.MapRoute(
		        name: "List",
		        url: "list/{id}",
		        defaults: new { controller = "Home", action = "List", id = UrlParameter.Optional }
	        );

            routes.MapRoute(
                name: "Whatis",
                url: "whatis/{id}",
                defaults: new { controller = "Home", action = "Whatis", id = UrlParameter.Optional }
            );

            routes.MapRoute(
				name: "Default",
				url: "{controller}/{action}/{id}",
				defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
			);
		}
	}
}
