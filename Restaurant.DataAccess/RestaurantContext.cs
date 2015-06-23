using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Diagnostics;
using Restaurant.Data.Management;
using Restaurant.Data.Management.Floor;
using Restaurant.Data.Management.Menus;
using Restaurant.Data.Management.Staff;

namespace Restaurant.DataAccess
{
    public class RestaurantContext : DbContext
    {
        public DbSet<Member> Members { get; set; }

        public DbSet<StaffMember> StaffMembers { get; set; }

        public DbSet<Table> Tables { get; set; }

        public DbSet<Reservation> Reservations { get; set; }

        public DbSet<Menu> Menus { get; set; }

        public DbSet<MenuType> MenuTypes { get; set; }

        public DbSet<Ticket> Tickets { get; set; }

        public DbSet<Shift> Shifts { get; set; } 


        public RestaurantContext()
            : base("RestaurantContext")
        {
            Database.SetInitializer(new RestaurantInitialiser());

            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
        }

        public override int SaveChanges()
        {
            try
            {
                return base.SaveChanges();
            }
            catch (DbEntityValidationException dbEx)
            {
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        Trace.TraceInformation("Class: {0}, Property: {1}, Error: {2}",
                            validationErrors.Entry.Entity.GetType().FullName,
                            validationError.PropertyName,
                            validationError.ErrorMessage);
                    }
                }

                throw; 
            }
        }
    }

    public class RestaurantInitialiser : DropCreateDatabaseAlways<RestaurantContext>
    {
        protected override void Seed(RestaurantContext context)
        {
            // Seed the database with users
            List<StaffMember> members = new List<StaffMember>
            {
                new StaffMember
                {
                    Username = "admin",
                    Password = "password",
                    DateHired = DateTime.Now,
                    ConnectionType = 1 << 5,

                    FirstName = "admin",
                    LastName = "user",
                    PhoneNumber = "0",
                    Email = "0"
                }
            };
            members.ForEach(u => context.StaffMembers.Add(u));
  
            List<MenuType> menuTypes = new List<MenuType>
            {
                new MenuType
                {
                    Name = "Breakfast"
                },
                new MenuType
                {
                    Name = "Lunch"
                },
                new MenuType
                {
                    Name = "Daytime"
                },
                new MenuType
                {
                    Name = "Drinks"
                },
                new MenuType
                {
                    Name = "Dessert"
                }
            };
            menuTypes.ForEach(m => context.MenuTypes.Add(m));

            List<FoodItem> foodItems = new List<FoodItem>
            {
                new FoodItem
                {
                    
                }
            };

//            // Seed the database with tables
//            List<Table> tables = new List<Table>
//            {
//                new Table
//                {
//                    Number = 1,
//                    Section = new Section
//                    {
//                        Name = "Bar"
//                    },
//                    Seats = 4
//                }
//            };
//            tables.ForEach(t => context.Tables.Add(t));
//
//            List<Menu> menus = new List<Menu>
//            {
//                new Menu()
//            };
//            menus.ForEach(m => context.Menus.Add(m));
        }
    }
}
