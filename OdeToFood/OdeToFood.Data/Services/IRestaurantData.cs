using OdeToFood.Data.Models;
using System.Collections.Generic;

namespace OdeToFood.Data.Services
{
    public interface IRestaurantData //an interface defines a contract that can be implemented by any class
                                     //used to achieve abstraction, polymorphism, and to provide a layer of separation between the definition of operations and their implementation
                                     //we use Dependency Injection to inject an implementation of this interface into the controllers
    {
        IEnumerable<Restaurant> GetAll(); //designed to retrieve all restaurants
        Restaurant Get(int id); //designed to retrieve a single Restaurant object based on its id
        void Add(Restaurant restaurant); //designed to receive a Restaurant object as a parameter and add it to the data store
        void Update(Restaurant restaurant); //designed to update an existing Restaurant in the data store
        void Delete(int id);  //designed to delete a restaurant from the data store, identified by its id.
    }
}
