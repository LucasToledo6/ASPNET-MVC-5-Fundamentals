using OdeToFood.Data.Services;
using System.Web.Mvc;

namespace OdeToFood.Web.Controllers
{
    public class HomeController : Controller //this class is responsible for handling incoming HTTP requests, processing them, and returning the appropriate response or view
    {
        private readonly IRestaurantData db; //an interface to interact with restaurant data

        public HomeController(IRestaurantData db) //this is an example of constructor injection, a form of dependency injection
                                                  //the ASP.NET MVC framework will inject an instance of IRestaurantData when creating an instance of HomeController
        {
            this.db = db;
        }
        public ActionResult Index() //this action method is called when a user navigates to the home page of your application (usually the root URL /)
        {
            var model = db.GetAll(); //retrieving all restaurant data

            return View(model); //the restaurant data is then passed to the view
        }

        public ActionResult About() //this action method is called when a user navigates to the /Home/About URL
        {
            ViewBag.Message = "Your application description page.";

            return View(); //here, ViewBag is used to pass data to the view
                           //viewBag is a dynamic object that allows you to add properties to it dynamically
        }

        public ActionResult Contact() //this action method responds to navigation to /Home/Contact.
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}