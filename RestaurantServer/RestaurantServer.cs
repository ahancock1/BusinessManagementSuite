using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using RestaurantServer.Network;

namespace RestaurantServer
{
    public class RestaurantServer : Listener
    {
        private readonly Server server;

        public bool Running { get; private set; }


        public RestaurantServer(int port)
        {
            server = new Server(port)
            {
                Listener = this,
                Timeout = 1000
            };
        }

        public void Start()
        {
            // Start server in separate thread
            new Thread(server.Start) { Name = "Server" }.Start();
            Running = true;
        }

        public void Stop()
        {
            server.Stop();
            Running = false;
        }

        public override void Connected(Connection connection)
        {
            Console.WriteLine("SERVER - Client connected: {0}", connection.ID);
        }

        public override void Disconnected(Connection connection)
        {
            Console.WriteLine("SERVER - Client disconnected: {0}", connection.ID);
        }

        public override void Received(Connection connection, object o)
        {
            Console.WriteLine("SERVER - Data received: {0}", o.GetType().Name);
        }
    }
}
