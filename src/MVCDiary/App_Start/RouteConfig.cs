using System.Web.Mvc;
using System.Web.Routing;

namespace MVCDiary
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.MapRoute(
                name: "Pages",
                url: "{controller}",
                defaults: new { controller = "Home", action = "Index" }
            );

            routes.MapRoute(
                name: "Posts",
                url: "Post/{id}",
                defaults: new { controller = "Diary", action = "Index" }
            );

            routes.MapRoute(
                name: "Apis",
                url: "api/{action}",
                defaults: new { controller = "Api", action = "Index" }
            );
        }
    }
}