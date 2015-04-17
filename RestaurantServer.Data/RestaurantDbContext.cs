using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantServer.Data
{
    public class RestaurantDbContext : DbContext 
    {

        public RestaurantDbContext()
            : base("RestaurantDbConnectionString")
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<RestaurantDbContext>());


        }

        public DbSet<User> Users { get; set; }

    }
}
