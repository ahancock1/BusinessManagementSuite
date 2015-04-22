using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;

namespace RestaurantServer.Network
{
    public interface IConnection : IDisposable
    {
        void Send(object data);

        void Close();

        bool Connected { get; }

        void AddListener(IListener listener);

        void RemoveListener(IListener listener);
    }

    public class Connection : IConnection
    {
        public readonly byte[] Buffer;

        public TcpClient Client { get; set; }

        public NetworkStream Stream { get; set; }

        public List<IListener> Listeners { get; set; }

        public int ID { get; set; }

        public string Name { get; set; }

        private int lastPingID;

        private long lastPingTime;


        public Connection(int bufferSize)
        {
            Buffer = new byte[bufferSize];
            Client = new TcpClient();
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
                    using (var memoryStream = new MemoryStream(Buffer))
                    {
                        // Deserialise packet
                        memoryStream.Seek(0, SeekOrigin.Begin);
                        object packet = (new BinaryFormatter()).Deserialize(memoryStream);

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
                                NotifyConnected();
                            }
                            else if (packet is NetCloseConnection)
                            {
                                NotifyDisconnected();
                            }
                        }
                        else
                        {
                            NotifyReceived(packet);
                        }
                    }
                }
                Stream.BeginRead(Buffer, 0, Buffer.Length, ReadCallBack, Stream);
            }
            catch (IOException e)
            {
                Close();
                NotifyDisconnected();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error reading data: {0}", e.Message);
                Close();
                NotifyDisconnected();
            }
        }

        public void Close()
        {
            if (!Connected) return;

            Send(new NetCloseConnection { ConnectionID = ID });

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

        public bool Connected
        {
            get { return Client.Connected; }
        }

        public void AddListener(IListener listener)
        {
            Listeners.Add(listener);
        }

        public void RemoveListener(IListener listener)
        {
            Listeners.Remove(listener);
        }

        public override string ToString()
        {
            return String.IsNullOrEmpty(Name) ? "Connection " + ID : Name;
        }

        public void Dispose()
        {
            Close();
        }

        private void NotifyConnected()
        {
            foreach (IListener listener in Listeners)
            {
                listener.Connected(this);
            }
        }

        private void NotifyDisconnected()
        {
            foreach (IListener listener in Listeners)
            {
                listener.Disconnected(this);
            }
        }

        private void NotifyReceived(object packet)
        {
            if (packet is NetPing)
            {
                NetPing response = (NetPing)packet;
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

            foreach (IListener listener in Listeners)
            {
                listener.Received(this, packet);
            }
        }
    }
}
