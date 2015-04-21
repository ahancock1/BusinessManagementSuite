using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantServer.Network
{
    public interface IClient
    {
        void Connect(string hostName, int port);
    }

    public class Client : Connection, IClient
    {
        public Client(int bufferSize = 1024) : base(bufferSize)
        {
        }
        
        public void Connect(string hostName, int port)
        {
            if (Connected) return;

            try
            {
                Client.Connect(hostName, port);
                Stream = Client.GetStream();

                Console.WriteLine("Connected to: {0}", IpAddress);

                Stream.BeginRead(Buffer, 0, Buffer.Length, ReadCallBack, Stream);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error establishing connection to server: {0}", e.Message);
            }
        }
    }
}
