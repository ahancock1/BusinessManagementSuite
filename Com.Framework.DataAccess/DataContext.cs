using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Diagnostics;
using Com.Framework.Data;
using Com.Framework.Data.Restaurants;
using Com.Framework.Data.Restaurants.Menus;


namespace Com.Framework.DataAccess
{
    public class DataContext : DbContext
    {
        public DbSet<Premise> Premises { get; set; }


        public DataContext()
            : base("DataContext")
        {
            Database.SetInitializer(new DataContextInitialiser());

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

    public class DataContextInitialiser : DropCreateDatabaseAlways<DataContext>
    {
        protected override void Seed(DataContext context)
        {
            List<Premise> premises = new List<Premise>
            {
                new Restaurant
                {
                    Name = "TestRestaurant",
                    Description = "The restaurant that is used to test the database table \"Restaurants\"",
                    Addresses = new List<Address>
                    {
                        new Address
                        {
                            House = "42",
                            Street = "The answer",
                            City = "To everything",
                            Region = "Meaning of life",
                            Country = "Galaxy",
                            PostalCode = "Hitch-hikers"

                        }
                    },
                    OpenHours = new List<Hours>
                    {
                        new Hours
                        {
                            DayOfWeek = (int) DayOfWeek.Monday,
                            From = new TimeSpan(0, 8, 0, 0),
                            To = new TimeSpan(0, 18, 0 ,0)
                        },
                        new Hours
                        {
                            DayOfWeek = (int) DayOfWeek.Tuesday,
                            From = new TimeSpan(0, 8, 0, 0),
                            To = new TimeSpan(0, 12, 0, 0)
                        },
                        new Hours
                        {
                            DayOfWeek = (int) DayOfWeek.Tuesday,
                            From = new TimeSpan(0, 14, 0, 0),
                            To = new TimeSpan(0, 18, 0, 0)
                        }
                    },
                    Menus = new List<Menu>
                    {
                        new Menu
                        {
                            Name = "Normal Menu",
                            Description = "All our burgers are home made and serverd with french fries and salad",
                            Active = true,
                            Created = DateTime.Now,
                            Hours = new List<Hours>
                            {
                                new Hours
                                {
                                    DayOfWeek = (int) (DayOfWeek.Monday),
                                    From = new TimeSpan(0, 12, 0, 0),
                                    To = new TimeSpan(0, 22, 0, 0)
                                }
                            },
                            MenuCategories = new List<MenuCategory>
                            {
                                new MenuCategory
                                {
                                    Name = "Starters",
                                    Description = "The starters",
                                    MenuItems = new List<MenuItem>
                                    {
                                        new MenuItem
                                        {
                                            Name = "Greek Salad",
                                            Description = "Gem lettuce, Olives, Feta Cheese, Tomato, Peppers, Cucumber and Onions drizzled with Olive Oil",
                                            Active = true,
                                            Cost = 4.5f
                                        }
                                    }
                                },
                                new MenuCategory
                                {
                                    Name = "Mains",
                                    Description = "The mains",
                                    MenuItems = new List<MenuItem>
                                    {
                                        new MenuItem
                                        {
                                            Name = "Greek Salad",
                                            Description = "Gem lettuce, Olives, Feta Cheese, Tomato, Peppers, Cucumber and Onions drizzled with Olive Oil",
                                            Active = true,
                                            Cost = 7.5f
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            };
            premises.ForEach(p => context.Premises.Add(p));
            //            restaurants.WriteToFile(".\\Data\\Restaurants.xml");

        }
    }
}
