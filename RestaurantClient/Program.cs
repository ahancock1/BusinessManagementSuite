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

            RestaurantClient client = new RestaurantClient();
            client.Connect("localhost", 7777);


            Console.WriteLine("Press any key to terminate");
            Console.ReadKey();

            client.Client.Close();

        }
    }
}
