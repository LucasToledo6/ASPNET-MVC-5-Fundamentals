using OdeToFood.Data.Models;
using OdeToFood.Data.Services;
using System.Collections.Generic;
using System.Web.Http;

// This controller is part of our application and is designed to provide a RESTful interface for accessing Restaurant data
// A RESTful API is an architectural style for an application program interface (API) that uses HTTP requests to access and use data
// This controller is shown just for presentation, to show how to structure an API Controller
// We don't use it to build our application

namespace OdeToFood.Web.API
{
    // This declares RestaurantController, which inherits from ApiController
    // The ApiController class is part of the ASP.NET Web API framework, and controllers inheriting from it are meant to serve HTTP API responses rather than HTML views
    public class RestaurantController : ApiController
    {
        private readonly IRestaurantData db;

        public RestaurantController(IRestaurantData db)  //dependency injection
        {
            this.db = db;
        }
        public IEnumerable<Restaurant> Get() //this action method handles HTTP GET requests
        {
            var model = db.GetAll(); //retrieves all restaurants
            return model;

            // This data is then returned directly to the client
            // In a Web API context, ASP.NET will automatically serialize this collection of Restaurant objects to a format like JSON or XML
        }

        // In a client application or script, we would access this API endpoint with a URL like http://[your-app-domain]/api/restaurant to retrieve the list of restaurants
    }
}
