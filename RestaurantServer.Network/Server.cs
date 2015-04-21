﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace RestaurantServer.Network
{
    public interface IServer : IDisposable
    {
        void Start();
        
        void Stop();
        
        void SendToAll(object o);

        void SendToAllExcept(object o, int id);

        void SendToAllExcept(object o, params int[] ids);

        void SendToAllExcept(object o, IEnumerable<int> ids);
    }

    public class Server : IServer
    {
        private readonly ManualResetEvent clientConnectedReset =
            new ManualResetEvent(false);

        private readonly byte[] buffer;
        
        public List<Connection> Connections { get; set; }

        public Listener Listener { get; set; }
        
        public int Port { get; set; }

        public int Timeout { get; set; }

        private int nextConnectionID;
        
        private TcpListener clientListener;
        

        public Server(int port, int bufferSize = 1024)
        {
            Port = port;
            buffer = new byte[bufferSize];

            Connections = new List<Connection>();
        }

        public void Start()
        {
            clientListener = new TcpListener(IPAddress.Any, Port);
            clientListener.Start();

            Console.WriteLine("Server started on: {0}", Port);

            clientListener.BeginAcceptSocket(AcceptCallBack, clientListener);

            clientConnectedReset.WaitOne();
        }
        
        public void Stop()
        {
            // Close all connections
            foreach (Connection connection in Connections)
            {
                connection.Close();
            }
            Connections = new List<Connection>();

            // Release thread and close listener
            clientConnectedReset.Set();
            clientListener.Stop();

            Console.WriteLine("Server stopping");
        }
        
        private void AcceptCallBack(IAsyncResult result)
        {
            // Get the socket that handles the client request
            TcpClient client = ((TcpListener)result.AsyncState).EndAcceptTcpClient(result);

            clientListener.BeginAcceptSocket(AcceptCallBack, clientListener);

            // Create a connection
            Connection connection = new Connection(buffer.Length)
            {
                Client = client,
                Stream = client.GetStream(),
                ID = nextConnectionID++,
                Listener = Listener
            };
            connection.Stream.BeginRead(connection.Buffer, 0, connection.Buffer.Length, connection.ReadCallBack, connection.Stream);

            // Let the client know its ID
            connection.Send(new NetAcceptConnection
            {
                ConnectionID = connection.ID
            });

            // Add connection
            Connections.Add(connection);

            // Signal the calling thread to continue
            clientConnectedReset.Set();
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

        public void SendToAllExcept(object o, IEnumerable<int> ids)
        {
            SendToAllExcept(o, ids.ToArray());
        }

        public void Dispose()
        {
            Stop();
        }
    }
    
    #region Framework Messages

    internal interface INetMessage
    {
        
    }

    [Serializable]
    internal class NetResponse : INetMessage
    {
        public string Message { get; set; }

        public NetResponse()
        {
            Message = String.Empty;
        }
    }

    [Serializable]
    internal class NetRegisterConnection : INetMessage
    {
        public int ConnectionID { get; set; }

        public string ConnectionName { get; set; }

        public NetRegisterConnection()
        {
            ConnectionName = String.Empty;
        }
    }

    [Serializable]
    internal class NetPing : INetMessage
    {
        
    }

    [Serializable]
    internal class NetAcceptConnection : INetMessage
    {
        public int ConnectionID { get; set; }    
    }

    [Serializable]
    internal class NetCloseConnection : INetMessage
    {
        public int ConnectionID { get; set; }
    }

    #endregion
}
