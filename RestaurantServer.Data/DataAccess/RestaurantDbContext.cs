using System.Collections.Generic;
using System.Data.Entity;
using RestaurantServer.Data.DataModel;

namespace RestaurantServer.Data.DataAccess
{
    public class RestaurantDbContext : DbContext
    {
        public RestaurantDbContext()
            : base("RestaurantContext")
        {
            Database.SetInitializer(new RestaurantInitialiser());
            Configuration.ProxyCreationEnabled = false;

        }

        public DbSet<User> Users { get; set; }

        public DbSet<UserType> UserTypes { get; set; }
    }

    public class RestaurantInitialiser : DropCreateDatabaseIfModelChanges<RestaurantDbContext>
    {
        protected override void Seed(RestaurantDbContext context)
        {
            // Seed the database with users
            List<User> users = new List<User>
            {
                new User
                {
                    FirstName = "Adam",
                    LastName = "Hancock",
                    EmailAddress = "a.hancock@hotmail.co.uk",
                    Password = "password",
                    PhoneNumber = "07891599243",
                    Username = "ahancock1"
                }
            };
            users.ForEach(u => context.Users.Add(u));

            // Seed the database with user types
            List<UserType> userTypes = new List<UserType>
            {
                new UserType
                {
                    Name = "Administrator"
                }
            };
            userTypes.ForEach(u => context.UserTypes.Add(u));
        }
    }
}
