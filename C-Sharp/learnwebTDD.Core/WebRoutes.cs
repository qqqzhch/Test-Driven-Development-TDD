using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using System.Web.Routing;

namespace learnwebTDD.Core
{
    public class WebRoutes
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.IgnoreRoute("{resource}.ico/{*pathInfo}");
            //favicon.ico

            //"~Problem/index/598121646/cannot-download-a-document-from-email-on-the-internet/"
            routes.MapRoute(
               "Problem_other", // Route name
               "Problem/index/{id}/{other}/", // URL with parameters
               new { controller = "Problem", action = "Index", id = 0, other ="" } // Parameter defaults
           );
            routes.MapRoute(
               "browse_other", // Route name
               "browse/{action}/{id}/{other}/", // URL with parameters
               new { controller = "browse", action = "Index", id = 0, other = "" } // Parameter defaults
           );
                    routes.MapRoute(
            "Default7", // Route name
            "tag/index/page{page}", // URL with parameters
            new { controller = "tag", action = "Index", page = 1 } // Parameter defaults
           );


                    routes.MapRoute(
        "Default5", // Route name
        "home/tag/{name}/page{page}", // URL with parameters
        new { controller = "Home", action = "tag", page = 1, name = "name" } // Parameter defaults
        );
                        routes.MapRoute(
            "Default4", // Route name
            "home/tag/{name}", // URL with parameters
            new { controller = "Home", action = "tag", name = "name" } // Parameter defaults
            );

         

             routes.MapRoute(
           "Default2", // Route name
           "Home/{action}/page{page}", // URL with parameters
            new { controller = "Home", action = "Index", page = 1 } // Parameter defaults
              );

              routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new { controller = "Home", action = "Index", id = UrlParameter.Optional } // Parameter defaults
              );

        }
    }
}

