using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;

namespace RestaurantServer.Common
{
    public interface IServer : IDisposable
    {
        void Bind(int port);

        void Start();

        void Stop();
        
        void SendToAll(object o);

        void SendToAllExcept(object o, int id);

        void SendToAllExcept(object o, params int[] id);
    }

    public class Server : IServer
    {
        private readonly byte[] buffer;

        private int bufferSize;

        public List<Connection> Connections { get; set; }

        public Listener Listener { get; set; }
        
        public int Port { get; set; }

        public int Timeout { get; set; }

        private int nextConnectionID;
        
        private TcpListener clientListener;


        public Server(int bufferSize = 1024)
        {
            this.bufferSize = bufferSize;
            buffer = new byte[bufferSize];

            Connections = new List<Connection>();
        }

        public void Start()
        {
            Console.WriteLine("Server started");

            clientListener = new TcpListener(IPAddress.Any, Port);
            clientListener.Start();

            clientListener.BeginAcceptSocket(AcceptCallBack, clientListener);
        }

        public void Bind(int port)
        {
            Port = port;
        }

        public void Stop()
        {
            // Close all connections
            foreach (Connection connection in Connections)
            {
                connection.Close();
            }
            Connections = new List<Connection>();

            clientListener.Stop();

            Console.WriteLine("Server stopping");
        }

        private void AcceptCallBack(IAsyncResult result)
        {
            // Get the socket that handles the client request
            TcpClient client = ((TcpListener)result.AsyncState).EndAcceptTcpClient(result);
            
            // Create a connection
            Connection connection = new Connection(bufferSize)
            {
                Client = client,
                Stream = client.GetStream(),
                ID = nextConnectionID++,
                Listener = Listener
            };

            connection.Send(new NetRegisterConnection
            {
                ConnectionID = connection.ID
            });
            connection.Listener.Connected(connection);
            
            Connections.Add(connection);

        }
        
        public void SendToAll(object o)
        {
            foreach (IConnection connection in Connections)
            {
                connection.Send(o);
            }
        }

        public void SendToAllExcept(object o, int id)
        {
            foreach (IConnection connection in Connections.Where(c => c.ID != id))
            {
                connection.Send(o);
            }
        }

        public void SendToAllExcept(object o, params int[] ids)
        {
            foreach (IConnection connection in Connections.Where(connection => !ids.Any(id => connection.ID == id)))
            {
                connection.Send(o);
            }
        }

        public void SendToAllExcept(object o, List<int> ids)
        {
            SendToAllExcept(o, ids.ToArray());
        }

        public void Dispose()
        {
            Stop();
        }
    }

    public interface INetMessage
    {
        
    }

    public class NetResponse : INetMessage
    {
        public string Message { get; set; }

        public NetResponse()
        {
            Message = String.Empty;
        }
    }

    public class NetRegisterConnection : INetMessage
    {
        public int ConnectionID { get; set; }

        public string ConnectionName { get; set; }

        public NetRegisterConnection()
        {
            ConnectionName = String.Empty;
        }
    }

    public class NetPing : INetMessage
    {
        
    }
}
