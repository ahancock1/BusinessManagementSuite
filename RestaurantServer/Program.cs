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
            
            Console.WriteLine("Press any key to terminate");
            Console.ReadKey();
            
            server.Stop();
        }
    }
}
