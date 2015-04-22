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


        public RestaurantClient(string name)
        {
            Client = new Client { Listener = this, Name = name};
//            Client.AddListener(this);
        }
        
        public void Connect(string hostName, int port)
        {
            Client.Connect(hostName, port);
        }

        public override void Received(Connection connection, object o)
        {
            base.Received(connection, o);
        }
    }
}
