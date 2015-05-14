using System.Collections.Generic;
using System.Data.Entity;
using Restaurant.Data;

namespace Restaurant.DataAccess
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

        public DbSet<Table> Tables { get; set; }

        public DbSet<Guest> Guests { get; set; }

        public DbSet<Reservation> Reservations { get; set; }
    }

    public class RestaurantInitialiser : DropCreateDatabaseAlways<RestaurantDbContext>
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

            // Seed the database with tables
            List<Table> tables = new List<Table>
            {
                new Table
                {
                    Number = 1,
                    Section = new Section
                    {
                        Name = "Bar"
                    },
                    Seats = 4
                }
            };
            tables.ForEach(t => context.Tables.Add(t));
        }
    }
}
