using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestaurantServer.Common;

namespace RestaurantServer
{
    public class RestaurantServer : Listener
    {
        public Server Server;


        public RestaurantServer(int port)
        {
            Server = new Server(port)
            {
                Listener = this,
                Timeout = 1000
            };
        }

        public override void Start()
        {
//            base.Start();
            Server.Start();
        }

        public void Stop()
        {
            Server.Stop();
        }

        public override void Connected(Connection connection)
        {
            Console.WriteLine("SERVER - Client connected: {0}", connection.ID);
        }

        public override void Disconnected(Connection connection)
        {
            Console.WriteLine("SERVER - Client disconnected: {0}", connection.ID);
        }
    }
}
