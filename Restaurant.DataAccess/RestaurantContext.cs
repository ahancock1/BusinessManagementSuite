using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Diagnostics;
using Restaurant.Data;
using Restaurant.Data.Management;
using Restaurant.Data.Management.Floor;
using Restaurant.Data.Management.Menus;
using Restaurant.Data.Management.Staff;

namespace Restaurant.DataAccess
{
    public class RestaurantContext : DbContext
    {
        // TODO: remove
        public DbSet<Member> Members { get; set; }

        // TODO: remove
        public DbSet<Employee> Employees { get; set; }

        public DbSet<Credential> UserCredentials { get; set; }


        public DbSet<User> Users { get; set; }



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
            List<Employee> employees = new List<Employee>
            {
                new Employee
                {
                    Credential = new Credential
                    {
                        Password = "password",
                        PasswordSalt = "passwordsalt"
                    },
                    DateHired = DateTime.Now,
                    Email = "test.email@testemail.co.uk",
                    FirstName = "firstname",
                    LastName = "lastname",
                    Username = "username",
                    PhoneNumber = "01234567890"
                }
            };
            employees.ForEach(e => context.Employees.Add(e));
        }
    }
}
