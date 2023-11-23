using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using OdeToFood.Data.Services;
using System.Web.Http;
using System.Web.Mvc;

// This code is used for setting up dependency injection using the Autofac library.

namespace OdeToFood.Web
{
    public class ContainerConfig
    {
        internal static void RegisterContainer(HttpConfiguration httpConfiguration)
        {
            var builder = new ContainerBuilder(); //this initializes a new instance of the ContainerBuilder class, which is used to register dependencies

            builder.RegisterControllers(typeof(MvcApplication).Assembly); //this line registers all MVC controllers found in the assembly where MvcApplication (our MVC application) is defined
            builder.RegisterApiControllers(typeof(MvcApplication).Assembly); //similar to the previous line, this registers Web API controllers found in the assembly
            
            //builder.RegisterType<InMemoryRestaurantData>()
            builder.RegisterType<SqlRestaurantData>().As<IRestaurantData>().InstancePerRequest(); //here, the SqlRestaurantData class is registered as the implementation of the IRestaurantData interface
                                                                                                  //InstancePerRequest ensures that a new instance of SqlRestaurantData is created for each HTTP request
                                                                                                  //HTTP works as a request-response protocol between a client and server (The two most common methods are GET and POST)

            builder.RegisterType<OdeToFoodDbContext>().InstancePerRequest(); //registers OdeToFoodDbContext to be created once per HTTP request

            var container = builder.Build(); //this builds the container based on the registrations we have made.

            DependencyResolver.SetResolver(new AutofacDependencyResolver(container)); //this sets the MVC DependencyResolver to use Autofac
                                                                                      //it tells MVC how to resolve dependencies for controllers.

            httpConfiguration.DependencyResolver = new AutofacWebApiDependencyResolver(container); //similarly, this line sets the resolver for Web API controllers
        }
    }
}