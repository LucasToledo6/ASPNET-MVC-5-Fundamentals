using OdeToFood.Web.Models;
using System.Configuration;
using System.Web.Mvc;

namespace OdeToFood.Web.Controllers
{
    public class GreetingController : Controller
    {
        // The GreetingController's Index method is designed to display a greeting message to the user
        // It demonstrates the use of a ViewModel, fetching data from a query string, retrieving application settings, and passing data to a view
        // GET: Greeting
        public ActionResult Index(string name) //this is the Index action method of the GreetingController
                                               //it's designed to respond to GET requests and accepts a name parameter from the query string
        {
            var model = new GreetingViewModel();
            model.Name = name ?? "no name"; //the ?? operator is a null-coalescing operator in C#
                                            //it returns the left-hand operand if it is not null; otherwise, it returns the right-hand operand

            //var name = HttpContext.Request.QueryString["name"];
            model.Message = ConfigurationManager.AppSettings["message"]; //this line fetches a value from the application's configuration (likely defined in Web.config) with the key "message"
                                                                         //and assigns it to the Message property of the ViewModel

            return View(model); //this line returns a view to the user
                                //by passing model to the View method, the GreetingViewModel instance is passed to the view for rendering
        }
    }
}