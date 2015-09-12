using System;
using System.Net.Sockets;
using System.Threading;
using Com.Framework.Common.Logging;

namespace Com.Framework.Network
{
    public interface IClient
    {
        void Reconnect();

        bool Connect(string hostName, int port);
    }

    public class Client : Connection, IClient
    {
        private string hostName;

        private int port;

        public Client(int bufferSize = 4096)
            : base(bufferSize)
        {
        }

        /// <summary>
        /// Connect to host via name and port
        /// </summary>
        /// <param name="hostName"></param>
        /// <param name="port"></param>
        /// <returns></returns>
        public bool Connect(string hostName, int port)
        {
            if (Client.Connected) return true;

            this.hostName = hostName;
            this.port = port;

            try
            {
                Client = new TcpClient(hostName, port);
                Stream = Client.GetStream();

                Logger.Info(String.Format("Connected to: {0}", IpAddress));

                Stream.BeginRead(Buffer, 0, Buffer.Length, ReadCallBack, Stream);
            }
            catch (Exception e)
            {
                Logger.Error(String.Format("Couldn't establish connection to: {0}:{1}", hostName, port), e);
            }

            return Client.Connected;
        }

        public void Reconnect()
        {
            if (hostName == null) throw new Exception("Client was never connected.");

            while (!Client.Connected)
            {
                Logger.Info(String.Format("Trying to reconnect to {0}:{1}", hostName, port));
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
