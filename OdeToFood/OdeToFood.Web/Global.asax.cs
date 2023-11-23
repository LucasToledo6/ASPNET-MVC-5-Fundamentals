using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Http;

namespace OdeToFood.Web
{
    public class MvcApplication : System.Web.HttpApplication //This class is key to configuring various aspects of an ASP.NET MVC application upon startup
    {
        protected void Application_Start()
        {
            // Registers all areas in the application
            // Areas are used in MVC to organize large applications into smaller functional groupings, each with its own set of controllers, views, and models
            AreaRegistration.RegisterAllAreas();

            // Registers global filters
            // Global filters are MVC filters that are applied to all controllers and actions (unless explicitly overridden
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);

            // Configures Web API routes and settings
            // This line is essential since our application also includes ASP.NET Web API controllers in addition to MVC controllers
            GlobalConfiguration.Configure(WebApiConfig.Register);

            // Registers MVC routes
            // This is where you define the URL patterns and map them to specific controllers and actions
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            // Sets up bundling and minification for our JavaScript and CSS files
            // This improves page load times by reducing the number and size of HTTP requests and the size of requested resources
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            // This line suggests that we're using Autofac, a dependency injection container
            // The method RegisterContainer is setting up the container with specific rules for dependency resolution
            // Dependency injection helps to manage dependencies between classes, making your application more modular and testable
            ContainerConfig.RegisterContainer(GlobalConfiguration.Configuration); ;
        }
    }
}
