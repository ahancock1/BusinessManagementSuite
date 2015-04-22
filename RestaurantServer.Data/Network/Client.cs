using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RestaurantServer.Data.Network
{
    public interface IClient
    {
        void Reconnect();

        void Connect(string hostName, int port);
    }

    public class Client : Connection, IClient
    {
        private string hostName;

        private int port;

        public Client(int bufferSize = 1024) : base(bufferSize)
        {
        }
        
        public void Connect(string hostName, int port)
        {
            if (Client.Connected) return;

            this.hostName = hostName;
            this.port = port;

            try
            {
                Client = new TcpClient(hostName, port);
                Stream = Client.GetStream();

                Console.WriteLine("Connected to: {0} as: {1}", IpAddress, Name);

                Stream.BeginRead(Buffer, 0, Buffer.Length, ReadCallBack, Stream);
            }
            catch (Exception e)
            {
                Console.WriteLine("Couldn't establishing connection to: {0}:{1}", hostName, port);
            }
        }

        public void Reconnect()
        {
            if (hostName == null) throw new Exception("Client was never connected.");

            while (!Client.Connected)
            {
                Console.WriteLine("Trying to connect to: {0}:{1}", hostName, port);
                Connect(hostName, port);

                // TODO remove the sleep. I dont like Thread.Sleep
                Thread.Sleep(5000);
            }
        }
        
        public override void Disconnected(Connection connection)
        {
            base.Disconnected(connection);
            Reconnect();
        }
    }
}
