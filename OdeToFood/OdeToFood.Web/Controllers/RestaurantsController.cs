using OdeToFood.Data.Models;
using OdeToFood.Data.Services;
using System.Web.Mvc;

namespace OdeToFood.Web.Controllers
{
    public class RestaurantsController : Controller
    {
        private readonly IRestaurantData db;

        // GET: Restaurants
        public RestaurantsController(IRestaurantData db) //dependency injection
        {
            this.db = db;
        }

        [HttpGet]
        public ActionResult Index() //retrieves and displays a list of all restaurants
        {
            var restaurant = db.GetAll();
            return View(restaurant); //it passes the restaurant data to the Index view
        }

        [HttpGet]
        public ActionResult Details(int id) //shows details of a specific restaurant
        {
            var restaurant = db.Get(id);
            if(restaurant == null)
            {
                // return RedirectToAction("Index");
                return View("NotFound");
            }
            return View(restaurant); //it passes the restaurant data to the Details view
        }

        [HttpGet]
        public ActionResult Create() //returns a view with a form for creating a new restaurant
        {
            return View(); //for now, you're just giving the user the HTML to create a restaurant
        }

        [HttpPost]
        [ValidateAntiForgeryToken] //used to prevent cross-site request forgery attacks
        public ActionResult Create(Restaurant restaurant)
        {

            //A way of validation
            /* if (String.IsNullOrEmpty(restaurant.Name))
            {
                ModelState.AddModelError(nameof(restaurant.Name), "A name is required")
            } */

            if(ModelState.IsValid) //another way of validation
            {
                db.Add(restaurant); //adds the new restaurant
                return RedirectToAction("Details", new { id = restaurant.Id}); //redirects to the Details view of the newly created restaurant
            }
            return View();
        }

        [HttpGet] 
        public ActionResult Edit(int id) //similar to the Details action
                                         //it fetches an existing restaurant and returns a view containing a form pre-populated with the restaurant's data for editing
        {
            var restaurant = db.Get(id);
            if (restaurant == null)
            {
                // return HttpNotFound();
                return View("NotFound");
            }
            return View(restaurant);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Restaurant restaurant) //receives the edited restaurant data and updates it if the model state is valid
        {
            if (ModelState.IsValid)
            {
                db.Update(restaurant); //updates the restaurant
                TempData["Message"] = "You have successfully updated the restaurant!"; //success message
                return RedirectToAction("Details", new { id = restaurant.Id }); //redirectes to the Details view of the edited restaurant
            }
            return View(restaurant);
        }

        [HttpGet] //when you read
        public ActionResult Delete(int id) //displays a confirmation view for deleting a restaurant
        {
            var restaurant = db.Get(id);
            if (restaurant == null)
            {
                return View("NotFound");
            }

            return View(restaurant);
        }

        [HttpPost] //when you submit
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, FormCollection form)
        {
            db.Delete(id); //handles the actual deletion of the restaurant
            return RedirectToAction("Index"); //redirects to the Index view.
        }
    }
}