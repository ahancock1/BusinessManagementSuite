using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.ServiceModel;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using RestaurantServer.Common;
using RestaurantServer.Data;
using RestaurantServer.Service;

namespace RestaurantServer
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = String.Format("Restaurant Server v{0}", Assembly.GetEntryAssembly().GetName().Version);

            RestaurantServer server =new RestaurantServer(8001);
            server.Start();




//            // Entity code
//            using (var context = new RestaurantDbContext())
//            {
//                User user = new User
//                {
//                    FirstName = "Adam",
//                    LastName = "Hancock",
//                    EmailAddress = "a.hancock@hotmail.co.uk",
//                    Password = "password",
//                    PhoneNumber = "07891599243",
//                    Username = "ahancock1"
//                };
//
//                context.Users.Add(user);
//                context.SaveChanges();
//            }

            Console.WriteLine("Press any key to terminate");
            Console.ReadKey();

            server.Stop();

        }
    }
}
