using System.Web.Mvc;
using System.Web.Routing;

namespace Techorama2014
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute("ClientTemplates", "Templates/Books/{action}",
                 new { controller = "Books" });

            routes.MapRoute("DirectiveTemplates", "Templates/Directives/{action}",
                 new { controller = "Directives" });

            routes.MapRoute("BooksApp", "Books/{*all}",
                new {controller = "Books", action = "Index"});

            routes.MapRoute("Default", "{controller}/{action}/{id}",
                new {controller = "Home", action = "Index", id = UrlParameter.Optional});
        }
    }
}