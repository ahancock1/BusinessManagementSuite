using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using Com.Framework.Common.Logging;
using Com.Framework.Network.Packets;

namespace Com.Framework.Network
{
    [Flags]
    public enum ConnectionType : byte
    {
        None = 1,
        Floor = 1 << 1,
        Bar = 1 << 2,
        Kitchen = 1 << 3,
        Management = 1 << 4,
        Administrator = 1 << 5 //TODO remove - this is pointless but useful for testing
    }

    public interface IConnection : IListener
    {
        void Send(object data);

        void Close();

        void AddListener(IListener listener);

        void RemoveListener(IListener listener);
    }

    /// <summary>
    /// Class for maintaining an active connection to a host or client.
    /// </summary>
    public class Connection : IConnection
    {
        public int ConnectionID { get; set; }

        public readonly byte[] Buffer;

        public TcpClient Client { get; set; }

        public NetworkStream Stream { get; set; }

        private readonly List<IListener> listeners;

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

        /// <summary>
        /// Write object to stream.
        /// </summary>
        /// <param name="o"></param>
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
                        // Serialise object and write to stream
                        (new BinaryFormatter()).Serialize(memoryStream, o);
                        Stream.Write(memoryStream.ToArray(), 0, (int)memoryStream.Length);
                        Stream.FlushAsync();
                    }

                    Logger.Info(String.Format("Sent: {0}", o.GetType().Name));
                }
                catch (IOException e)
                {
                    Logger.Error(String.Format("Error sending {0} to {1}:{2}", o.GetType().Name, IpEndPoint.Address, IpEndPoint.Port), e);
                    Close();
                }
            }
        }

        /// <summary>
        /// ASync read data.
        /// </summary>
        /// <param name="result"></param>
        public void ReadCallBack(IAsyncResult result)
        {
            try
            {
                // Check connection is still open
                if (IsConnected && Stream.EndRead(result) != 0)
                {
                    object packet;
                    using (var memoryStream = new MemoryStream(Buffer))
                    {
                        memoryStream.Seek(0, SeekOrigin.Begin);
                        memoryStream.Position = 0;
                        packet = (new BinaryFormatter()).Deserialize(memoryStream);
                    }

                    Stream.BeginRead(Buffer, 0, Buffer.Length, ReadCallBack, Stream);

                    // Framework packets
                    if (!(packet is INetPacket))
                    {
                        if (packet is NetAcceptConnection)
                        {
                            // Clients connection has been accepted, let the server know the type of connection and ID
                            ConnectionID = ((NetAcceptConnection)packet).ConnectionID;
                            Send(new NetRegisterConnection
                            {
                                ConnectionID = ConnectionID,
                                ConnectionName = Name
                            });
                        }
                        else if (packet is NetRegisterConnection)
                        {
                            // Server received clients connection name
                            Name = ((NetRegisterConnection)packet).ConnectionName;
                            Connected(this);
                        }
                        else if (packet is NetConnectionType)
                        {
                            // Set connection type
                            ConnectionType = (ConnectionType)((NetConnectionType)packet).ConnectionType;
                        }
                        else if (packet is NetPing)
                        {
                            // Process ping
                            NetPing response = (NetPing)packet;
                            if (response.IsReply)
                            {
                                if (response.PingID == lastPingID - 1)
                                {
                                    int tripTime = (int)(DateTime.Now.Millisecond - lastPingTime);
                                    Logger.Info(String.Format("Ping reply from {0}:{1} time = {2} ms", IpEndPoint.Address, IpEndPoint.Port, tripTime));
                                }
                            }
                            else
                            {
                                response.IsReply = true;
                                Send(response);
                            }
                        }
                        else
                        {
                            Logger.Info(String.Format("Invalid packet: {0}", packet));
                        }
                    }
                    else
                    {
                        // Non-framework packet so process it through attached listeners
                        Received(this, packet);
                    }
                }
                else
                {
                    Close();
                    Disconnected(this);
                }
            }
            catch (Exception e)
            {
                Logger.Error("Error reading data", e);
                Close();
                Disconnected(this);
            }
        }

        /// <summary>
        /// Check the connection is open.
        /// </summary>
        public bool IsConnected
        {
            get
            {
                // TODO extend NetworkStream to access socket connected
                if (!Client.Connected || Stream == null) return false;

                try
                {
                    // Write 0 bytes to test connection is still open
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

        /// <summary>
        /// Close connection.
        /// </summary>
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
            get
            {
                return ((IPEndPoint)Client.Client.RemoteEndPoint);
            }
        }

        /// <summary>
        /// Returns the IP Address of the remote end of the connection.
        /// </summary>
        public IPAddress IpAddress
        {
            get
            {
                return IpEndPoint.Address;
            }
        }

        /// <summary>
        /// Attach a listener to the connection.
        /// </summary>
        /// <param name="listener"></param>
        public void AddListener(IListener listener)
        {
            listeners.Add(listener);
        }

        /// <summary>
        /// Remove a listener from the connection.
        /// </summary>
        /// <param name="listener"></param>
        public void RemoveListener(IListener listener)
        {
            listeners.Remove(listener);
        }

        public virtual void Connected(Connection connection)
        {
#if DEBUG
            Logger.Debug(String.Format("Connected: {0}", connection));
#endif
            // Fire each listener attached to the connection
            listeners.ForEach(l => l.Connected(connection));
        }

        public virtual void Disconnected(Connection connection)
        {
#if DEBUG
            Logger.Debug(String.Format("Disconnected: {0}", connection));
#endif
            // Fire each listener attached to the connection
            listeners.ForEach(l => l.Disconnected(connection));
        }

        public virtual void Received(Connection connection, object o)
        {
#if DEBUG
            Logger.Debug(String.Format("Data received: {0}", o.GetType().Name));
#endif
            // Fire each listener attached to the connection
            listeners.ForEach(l => l.Received(connection, o));
        }

        public override string ToString()
        {
            return String.IsNullOrEmpty(Name) ? "Connection " + ConnectionID : Name;
        }
    }
}
