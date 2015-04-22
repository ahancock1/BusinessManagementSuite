using System;
using System.Reflection;
using RestaurantServer.Data.DataAccess;
using RestaurantServer.Data.DataModel;

namespace RestaurantServer
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = String.Format("Restaurant Server v{0}", Assembly.GetEntryAssembly().GetName().Version);

            RestaurantServer server = new RestaurantServer(7777);
            server.Start();
            
            // Entity code
            using (var context = new RestaurantDbContext())
            {
                User user = new User
                {
                    FirstName = "Adam",
                    LastName = "Hancock",
                    EmailAddress = "a.hancock@hotmail.co.uk",
                    Password = "password",
                    PhoneNumber = "07891599243",
                    Username = "ahancock1"
                };

                context.Users.Add(user);
                context.SaveChanges();
            }

            Console.WriteLine("Press any key to terminate");
            Console.ReadKey();
            
            server.Stop();
        }
    }
}
