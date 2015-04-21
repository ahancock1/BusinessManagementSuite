using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;

namespace RestaurantServer.Common
{
    public interface IConnection : IDisposable
    {
        void Send(object data);

        void Close();

        bool Connected { get; }
    }

    public class Connection : IConnection
    {
        protected readonly byte[] buffer;

        private int bufferSize;

        public TcpClient Client { get; set; }

        public NetworkStream Stream { get; set; }

        public Listener Listener { get; set; }

        public int ID { get; set; }

        public string Name { get; set; }

        private bool shutdown;

        public Connection(int bufferSize)
        {
            this.bufferSize = bufferSize;
            buffer = new byte[bufferSize];
            Client = new TcpClient();
        }

        public void Send(object o)
        {
            if (o == null) throw new Exception("object cannot be null.");

            if (Stream == null) throw new Exception("Stream cannot be null.");

            if (Stream.CanWrite)
            {
                using (var memoryStream = new MemoryStream())
                {
                    (new BinaryFormatter()).Serialize(memoryStream, o);
                    Stream.Write(memoryStream.ToArray(), 0, (int)memoryStream.Length);
                }

                Console.WriteLine("Sent: {0}", o.GetType().Name);
            }
        }

        public void ReadCallBack(IAsyncResult result)
        {
            try
            {
                int length = Stream.EndRead(result);
                if (length > 0)
                {
                    using (var memoryStream = new MemoryStream(buffer))
                    {
                        memoryStream.Seek(0, SeekOrigin.Begin);
                        object o = (new BinaryFormatter()).Deserialize(memoryStream);

                        if (o is INetMessage)
                        {
                            // TODO handle framework messages here
                            if (o is NetRegisterConnection)
                            {
                                NetRegisterConnection response = (NetRegisterConnection) o;
                                ID = response.ConnectionID;
                                Name = response.ConnectionName;
                            }
                            if (o is NetAcceptConnection)
                            {
                                
                            }
                            if (o is NetCloseConnection)
                            {
                                Listener.Disconnected(this);
                            }
                        }
                        else
                        {
                            if (Listener != null)
                            {
                                Listener.Received(this, o);
                            }
                        }
                    }
                }
                Stream.BeginRead(buffer, 0, buffer.Length, ReadCallBack, Stream);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error reading data: {0}", "");
                Close();
            }
        }

        public void Close()
        {
            if (!Connected) return;
            
            Send(new NetCloseConnection { ConnectionID = ID });

            Stream.Close();
            Client.Close();
        }

        public IPEndPoint IpEndPoint
        {
            get { return ((IPEndPoint) Client.Client.RemoteEndPoint); }
        }

        public IPAddress IpAddress
        {
            get { return IpEndPoint.Address; }
        }

        public bool Connected
        {
            get { return Client.Connected; }
        }

        public override string ToString()
        {
            return String.IsNullOrEmpty(Name) ? "Connection " + ID : Name;
        }

        public void Dispose()
        {
            Close();
        }
    }
}
