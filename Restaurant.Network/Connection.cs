using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Remoting.Messaging;
using System.Runtime.Serialization.Formatters.Binary;
using Restaurant.Data;
using Restaurant.Network.Packets;

namespace Restaurant.Network
{
    [Flags]
    public enum ConnectionType : byte
    {
        None = 1,
        Floor = 1 << 1,
        Bar = 1 << 2,
        Kitchen = 1 << 3,
        Management = 1 << 4,
        Administration = 1 << 5
    }

    public interface IConnection : IListener
    {
        void Send(object data);

        void Close();

        void AddListener(IListener listener);

        void RemoveListener(IListener listener);
    }

    public class Connection : IConnection
    {
        public readonly byte[] Buffer;

        public TcpClient Client { get; set; }

        public NetworkStream Stream { get; set; }

        private readonly List<IListener> listeners;

        public int ID { get; set; }

        public string Name { get; set; }

        public ConnectionType ConnectionType { get; set; }

        private int lastPingID;

        private long lastPingTime;
        
        public Connection(int bufferSize)
        {
            Buffer = new byte[bufferSize];
            Client = new TcpClient();
            listeners = new List<IListener>();
            ConnectionType = 0x0;
        }

        public void Ping()
        {
            Send(new NetPing
            {
                PingID = lastPingID++
            });
            lastPingTime = DateTime.Now.Millisecond;
        }

        public void Send(object o)
        {
            if (!IsConnected) throw new Exception("Connection is not open");

            if (o == null) throw new Exception("Object cannot be null.");

            if (Stream == null) throw new Exception("Stream cannot be null.");

            if (Stream.CanWrite)
            {
                try
                {
                    using (var memoryStream = new MemoryStream())
                    {
                        (new BinaryFormatter()).Serialize(memoryStream, o);
                        Stream.Write(memoryStream.ToArray(), 0, (int) memoryStream.Length);
                        Stream.FlushAsync();
                    }
                    Console.WriteLine("Sent: {0}", o.GetType().Name);
                }
                catch (IOException e)
                {
                    Console.WriteLine("Error sending {0} to {1}:{2}, {3}", o.GetType().Name, IpEndPoint.Address, IpEndPoint.Port, e.Message); 
                    Close();
                }
            }
        }

        public void ReadCallBack(IAsyncResult result)
        {
            try
            {
                if (IsConnected)
                {
                    if (Stream.EndRead(result) != 0)
                    {
                        object packet;
                        using (var memoryStream = new MemoryStream(Buffer))
                        {
                            memoryStream.Seek(0, SeekOrigin.Begin);
                            memoryStream.Position = 0;
                            packet = (new BinaryFormatter()).Deserialize(memoryStream);
                        }

                        if (packet is INetMessage)
                        {
                            if (packet is NetAcceptConnection)
                            {
                                ID = ((NetAcceptConnection) packet).ConnectionID;
                                Send(new NetRegisterConnection
                                {
                                    ConnectionID = ID,
                                    ConnectionName = Name
                                });
                            }
                            else if (packet is NetRegisterConnection)
                            {
                                Name = ((NetRegisterConnection) packet).ConnectionName;
                                Connected(this);
                            }
                            else if (packet is NetConnectionType)
                            {
                                ConnectionType = (ConnectionType) ((NetConnectionType) packet).ConnectionType;
                            }
                        }

                        Received(this, packet);
                    }

                    Stream.BeginRead(Buffer, 0, Buffer.Length, ReadCallBack, Stream);
                }
                else
                {
                    Close();
                    Disconnected(this);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error reading data: {0}", e.Message);
                Close();
                Disconnected(this);
            }
        }

        public bool IsConnected
        {
            get
            {
                // TODO extend NetworkStream to access socket connected
                if (!Client.Connected || Stream == null) return false;

                try
                {
                    // Write 0 bytes to test connection
                    Stream.Write(new byte[0], 0, 0);
                    Stream.FlushAsync();
                }
                catch (Exception)
                {
                    return false;
                }

                return true;
            }
        }

        public virtual void Close()
        {
            Stream.Close();
            Client.Close();
        }

        /// <summary>
        /// Returns the IP adress and port of the remote end of the connection.
        /// </summary>
        public IPEndPoint IpEndPoint
        {
            get { return ((IPEndPoint)Client.Client.RemoteEndPoint); }
        }

        /// <summary>
        /// Returns the IP Address of the remote end of the connection
        /// </summary>
        public IPAddress IpAddress
        {
            get { return IpEndPoint.Address; }
        }
        
        public void AddListener(IListener listener)
        {
            listeners.Add(listener);
        }

        public void RemoveListener(IListener listener)
        {
            listeners.Remove(listener);
        }
        
        public virtual void Connected(Connection connection)
        {
            foreach (IListener listener in listeners)
            {
                listener.Connected(connection);
            }
        }

        public virtual void Disconnected(Connection connection)
        {
            foreach (IListener listener in listeners)
            {
                listener.Disconnected(connection);
            }
        }

        public virtual void Received(Connection connection, object o)
        {
            if (o is NetPing)
            {
                NetPing response = (NetPing)o;
                if (response.IsReply)
                {
                    if (response.PingID == lastPingID - 1)
                    {
                        int tripTime = (int)(DateTime.Now.Millisecond - lastPingTime);
                        Console.WriteLine("Ping reply from {0}:{1} time = {2} ms", IpEndPoint.Address, IpEndPoint.Port, tripTime);
                    }
                }
                else
                {
                    response.IsReply = true;
                    Send(response);
                }
            }

            foreach (IListener listener in listeners)
            {
                listener.Received(connection, o);
            }
        }

        public override string ToString()
        {
            return String.IsNullOrEmpty(Name) ? "Connection " + ID : Name;
        }
    }
}
