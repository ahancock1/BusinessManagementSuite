using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantServer.Common
{
    public interface IClient
    {
        void Start();

        void Connect(int bufferSize, string hostName, int port);

        void Send(object o);
    }

    public class Client
    {



        public Client()
        {
            
        }

    }
}
