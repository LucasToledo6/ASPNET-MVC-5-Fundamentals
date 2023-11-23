using OdeToFood.Data.Models;
using System.Collections.Generic;
using System.Linq;

namespace OdeToFood.Data.Services
{
    public class InMemoryRestaurantData : IRestaurantData
    {
        readonly List<Restaurant> Restaurants; //in-memory store for our restaurants

        public InMemoryRestaurantData()
        {
            Restaurants = new List<Restaurant>(); //this implementation is suitable for a small application or for initial testing and prototyping
                                                  //however, in a production application, you'd likely use a more persistent form of storage, like a database, and an ORM (Object-Relational Mapper) such as Entity Framework for data access
        }

        public void Add(Restaurant restaurant) //adds a new Restaurant to the list
        {
            Restaurants.Add(restaurant); //this Add method comes from the List class
            restaurant.Id = Restaurants.Max(r => r.Id) + 1; //sets the Id of the new restaurant by finding the maximum Id in the current list and adding 1
        }

        public void Update(Restaurant restaurant) //updates an existing Restaurant
                                                  //finds the restaurant by Id and then updates its Name and Cuisine properties  
        {
            var existing = Get(restaurant.Id);
            if(existing != null) //assuming the Restaurant exists
            {
                existing.Name = restaurant.Name;
                existing.Cuisine = restaurant.Cuisine;
            }
        }
        public Restaurant Get(int id) //retrieves a Restaurant by Id
        {
            return Restaurants.FirstOrDefault(r => r.Id == id); //returns the first restaurant that matches the given Id, or null if no match is found
        }
        public IEnumerable<Restaurant> GetAll() //returns all restaurants, ordered by their Name
                                                //IEnumerable<Restaurant> is a collection of Restaurant objects that can be enumerated over (like in a foreach loop)
        {
            return Restaurants.OrderBy(r => r.Name);
        }

        public void Delete(int id) //removes a restaurant from the list based on Id
        {
            var restaurant = Get(id);
            if(restaurant != null)
            {
                Restaurants.Remove(restaurant); //this Remove method comes from the List class
            }
        }
    }
}
