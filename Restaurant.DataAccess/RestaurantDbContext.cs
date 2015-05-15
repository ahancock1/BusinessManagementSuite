using System.Collections.Generic;
using System.ComponentModel.Design;
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
        
        public DbSet<Table> Tables { get; set; }

        public DbSet<Guest> Guests { get; set; }

        public DbSet<Reservation> Reservations { get; set; }

        public DbSet<Menu> Menus { get; set; }

        public DbSet<Order> Orders { get; set; }
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
                    FirstName = "admin",
                    LastName = "user",
                    EmailAddress = "",
                    Password = "password",
                    PhoneNumber = "",
                    Username = "admin",
                    ConnectionType = 1 << 5
                }
            };
            users.ForEach(u => context.Users.Add(u));
            
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

            List<Menu> menus = new List<Menu>
            {
                new Menu()
            };
            menus.ForEach(m => context.Menus.Add(m));
        }
    }
}
