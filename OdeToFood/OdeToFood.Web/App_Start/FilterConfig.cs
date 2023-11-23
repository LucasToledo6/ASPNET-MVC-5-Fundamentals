using System.Web.Mvc;

// This file is used for configuring global filters that will be applied to our MVC application

namespace OdeToFood.Web
{
    public class FilterConfig //
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters) //this method is used to register global filters
                                                                                 //Global filters are applied to every action method across all controllers in our application.
        {
            filters.Add(new HandleErrorAttribute()); //the HandleErrorAttribute is a built-in filter in ASP.NET MVC that handles exceptions thrown by action methods
                                                     //when an unhandled exception occurs in our MVC application, this filter helps in redirecting to a custom error page,
                                                     //thus providing a better user experience and avoiding the display of a system error message to the end user
                                                     //by default, the HandleErrorAttribute directs to the 'Error.cshtml' view in the 'Shared' folder
        }
    }
}
