using OdeToFood.Data.Models;
using System.Data.Entity;

namespace OdeToFood.Data.Services
{
    public class OdeToFoodDbContext : DbContext //DbContext is part of the Entity Framework
                                                //DbContext is an important class that represents a session with the database, allowing us to query and save data
                                                //in this case, OdeToFoodDbContext represents a session with our specific database, using our domain class, Restaurant
    {
        public DbSet<Restaurant> Restaurants { get; set; } //this is a representation of the Restaurants table in our database
                                                           //used to perform CRUD (Create, Read, Update, Delete) operations against the database using our entity classes
    }
}
