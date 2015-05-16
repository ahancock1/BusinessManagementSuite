using System.Collections.Generic;
using System.Data.Entity;
using Restaurant.Data;

namespace Restaurant.DataAccess
{
    public class RestaurantDbContext : DbContext
    {
        public DbSet<Member> Members { get; set; }

        public DbSet<Table> Tables { get; set; }

        public DbSet<Reservation> Reservations { get; set; }

        public DbSet<Menu> Menus { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<Shift> Shifts { get; set; } 


        public RestaurantDbContext()
            : base("RestaurantContext")
        {
            Database.SetInitializer(new RestaurantInitialiser());

            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
        }
    }

    public class RestaurantInitialiser : DropCreateDatabaseAlways<RestaurantDbContext>
    {
        protected override void Seed(RestaurantDbContext context)
        {
            // Seed the database with users
            List<StaffMember> members = new List<StaffMember>
            {
                new StaffMember
                {
                    FirstName = "admin",
                    LastName = "user",
                    Email = "",
                    Password = "password",
                    PhoneNumber = "",
                    Username = "admin",
                    ConnectionType = 1 << 5
                }
            };
            members.ForEach(u => context.Members.Add(u));
            
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
