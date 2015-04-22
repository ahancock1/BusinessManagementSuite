using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using RestaurantServer.Data;
using RestaurantServer.Network;
using RestaurantServer.Data;

namespace RestaurantClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = String.Format("Restaurant Client v{0}", Assembly.GetEntryAssembly().GetName().Version);

            Console.WriteLine("Enter client name:");
            RestaurantClient client = new RestaurantClient(Console.ReadLine());

            Console.WriteLine("Press any key to terminate");
            client.Connect("localhost", 7777);

            // Constantly ping server every 2 seconds
            while (!Console.KeyAvailable)
            {
                Thread.Sleep(2000);
                client.Client.Ping();
            }

            client.Client.Close();
        }
    }
}
