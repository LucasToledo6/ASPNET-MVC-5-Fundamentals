using OdeToFood.Data.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace OdeToFood.Data.Services
{
    public class SqlRestaurantData : IRestaurantData //class responsible for performing CRUD (Create, Read, Update, Delete) operations on Restaurant entities using a SQL database
    {
        private readonly OdeToFoodDbContext db;

        public SqlRestaurantData(OdeToFoodDbContext db) //this db context is used to interact with the database.
        {
            this.db = db;
        }
        public void Add(Restaurant restaurant) //adds a new Restaurant to the database
        {
            db.Restaurants.Add(restaurant); //this Add method comes from the DbSet class
            db.SaveChanges(); //an essential method from the DbContext class that saves all changes made in this context to the database
        }

        public void Delete(int id) //deletes a Restaurant from the database by its ID
        {
            var restaurant = db.Restaurants.Find(id); //finds the restaurant by its primary key (id)
            db.Restaurants.Remove(restaurant); //this Remove method comes from the DbSet class
            db.SaveChanges();
        }

        public Restaurant Get(int id) //retrieves a single Restaurant based on its ID
        {
            return db.Restaurants.FirstOrDefault(r => r.Id == id); //LINQ's FirstOrDefault extension
        }

        public IEnumerable<Restaurant> GetAll() //returns an IEnumerable<Restaurant> representing all restaurants
        {
            return db.Restaurants.OrderBy(r => r.Name); //LINQ's OrderBy extension
        }

        public void Update(Restaurant restaurant) //updates an existing Restaurant
        {
            //var r = Get(restaurant.Id);
            //r.Name = "";
            var entry = db.Entry(restaurant); //this gets the DbEntityEntry for the restaurant entity, allowing you to access its state
                                              //optimistic concurrency
                                              //this can be useful to prevent conflicts if two people are updating the same Restaurant at the same time

            entry.State = EntityState.Modified; //This marks the entity as modified
                                                //Entity Framework will generate SQL to update the database when SaveChanges is called
            db.SaveChanges();
        }
    }
}
