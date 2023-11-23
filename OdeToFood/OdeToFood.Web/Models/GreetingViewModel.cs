using OdeToFood.Data.Models;
using System.Collections.Generic;

namespace OdeToFood.Web.Models
{
    public class GreetingViewModel
    {
        public IEnumerable<Restaurant> Restaurants { get; set; }
        public string Message { get; set; }
        public string Name { get; set; }
    }

    // USAGE OF VIEWMODEL IN MVC

    // Purpose:
    // ViewModels in MVC are used to pass data from controllers to views. Instead of passing the model directly to the view, you often use a ViewModel to shape the data into a form that is easier to manage and display in the view.
    
    // Advantages:
    // Using a ViewModel allows you to include only the data you need in the view, which can improve performance and security. It also makes your views more maintainable because the ViewModel can be changed without modifying the underlying model classes.
    
    // Typical Scenario:
    // In a typical use case, a controller action method would create an instance of GreetingViewModel, populate its properties with data (possibly retrieved from a database or a service), and then pass that object to the view.
}