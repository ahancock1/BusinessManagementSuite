using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Restaurant.Listeners;
using Restaurant.Network;

namespace Restaurant.Server
{
    class Program
    {
        private static Network.Server server;

        static void Main(string[] args)
        {
            // Initiate and start the server
            server = new Network.Server(7777);
            server.AddListener(new UserListener());
            server.AddListener(new OrderListener(server));
            new Thread(server.Start) { Name = "Server" }.Start();

            Console.ReadKey();
        }
    }
}
