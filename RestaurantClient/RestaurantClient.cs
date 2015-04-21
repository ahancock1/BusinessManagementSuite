using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestaurantServer.Network;

namespace RestaurantClient
{
    public class RestaurantClient : Listener, IClient
    {
        public Client Client { get; set; }


        public RestaurantClient()
        {
            Client = new Client { Listener = this, Name = "Adam-Spectre"};
        }
        
        public void Connect(string hostName, int port)
        {
            Client.Connect(hostName, port);
        }

        public override void Connected(Connection connection)
        {
            throw new NotImplementedException();
        }

        public override void Disconnected(Connection connection)
        {
            throw new NotImplementedException();
        }

        public override void Received(Connection connection, object o)
        {
            throw new NotImplementedException();
        }
    }
}
