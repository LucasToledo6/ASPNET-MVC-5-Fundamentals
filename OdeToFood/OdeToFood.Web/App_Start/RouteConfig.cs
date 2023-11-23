using System.Web.Mvc;
using System.Web.Routing;

// This file is used for configuring routes in our MVC application
// Routing is essential for mapping URL patterns to the corresponding controllers and actions

namespace OdeToFood.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes) //this method is used to define the routes for our application
                                                                  //it takes a RouteCollection object as a parameter, to which we add routes
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}"); //this line tells the routing system to ignore any route that matches an .axd file (ex: trace.axd)
                                                              //this is typically used to prevent requests for web resource files (like trace logs) from being processed by the routing system

            // This is where we define a pattern for our application's URLs
            // The pattern {controller}/{action}/{id} means the routing system should expect URLs to be in the format of "/ ControllerName / ActionName / ID", where ID is optional.
            // If the URL does not contain enough segments, the default values are used

            routes.MapRoute( // this method will try to find existing controllers and actions
                name: "Default",
                url: "{controller}/{action}/{id}",  // This defines the URL pattern
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
                // defaults: new { controller = "Home", action = "Index", key = UrlParameter.Optional }
            );
        }
    }
}
