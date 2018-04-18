using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace theBlackSmithsHouse.WebUI
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            /* '/' - Lists the first page of products from all the rarities */
            routes.MapRoute(null, "", new
            {
                controller = "Product",
                action = "List",
                rarity = (string)null,
                page = 1
            });

            /* '/Page2' - Lists the specified page (in this case, page 2), showing items from all rarities */
            routes.MapRoute(null, "Page{page}", new
            {
                controller = "Product",
                action = "List",
                rarity = (string)null
            },
            new { page = @"\d+" });

            /* '/Common' - Shows the first page of items from a specified rarity (in this case Common) */
            routes.MapRoute(null, "{rarity}", new
            {
                controller = "Product",
                action = "List",
                page = 1
            });

            /* '/Common/Page2' -Shows the specified page (in this case, page 2) of items from the specified
                                rarity (in this case, Common) */
            routes.MapRoute(null, "{rarity}/Page{page}", new
            {
                controller = "Product",
                action = "List"
            },
            new { page = @"\d+" });

            routes.MapRoute(null, "{controller}/{action}");

            // added MapRoute method
            routes.MapRoute(name: null,
                             url: "Page{page}",
                             defaults: new
                             {
                                 Controller = "Product",
                                 action = "List"
                             });

            // DEFAULT MapRoute Method changed controller from Home to Product and action from Index to List
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Product", action = "List", id = UrlParameter.Optional }
            );
        }
    }
}
