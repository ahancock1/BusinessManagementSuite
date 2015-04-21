using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
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
            RestaurantClient client = new RestaurantClient();
            client.Connect("localhost", 8001);


            Console.WriteLine("Press any key to terminate");
            Console.ReadKey();

            client.Client.Close();

        }
    }
}
