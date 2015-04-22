using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using RestaurantServer.Data.Network;

namespace RestaurantServer
{
    public class RestaurantServer : Listener
    {
        private readonly Server server;

        public bool Running { get; private set; }


        public RestaurantServer(int port)
        {
            server = new Server(port);
            server.AddListener(this);
            // Add packet listeners to server
//            server.AddListener(new UserListener());

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

        public override void Received(Connection connection, object o)
        {
            base.Received(connection, o);
            if (o is INetKitchenMessage)
            {
                server.SendToAllExcept(o, server.Connections.Where(c => c.Name.ToLower() != "kitchen").Select(c => c.ID));
            }
        }
    }
}
