using System.Web.Http;

// This file where we define the routing rules for our Web API
// But, as I have noted in the controller, the API codes of this project are just for demonstration

namespace OdeToFood.Web
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config) //this method configures the routes for the Web API
                                                              //it's static and takes an HttpConfiguration object as a parameter, which represents the configuration of the HTTP server
        {
            config.MapHttpAttributeRoutes(); //this enables attribute routing
                                             //with attribute routing, we can define routes directly on our API controllers and actions.

            // This line defines a convention - based route
            config.Routes.MapHttpRoute(

                name: "DefaultApi", //this is the name of the route

                routeTemplate: "api/{controller}/{id}", //This is the URL pattern for the route
                                                        //It defines a default API route with an optional id parameter
                                                        //For example, api/restaurants for getting all restaurants or api/restaurants/5 for getting a specific restaurant with ID 5

                defaults: new { id = RouteParameter.Optional } //ID is optional


            );
        }
    }
}
