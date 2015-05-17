﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using Restaurant.Network.Packets;

namespace Restaurant.Network
{
    public interface IServer : IListener, IDisposable
    {
        void Start();

        void Stop();

        void SendToAll(object o);

        void SendToAll(object o, ConnectionType connectionType);

        void SendToAllExcept(object o, ConnectionType connectionType);
    }

    public class Server : IServer
    {
        private readonly ManualResetEvent clientConnectedReset =
            new ManualResetEvent(false);

        private readonly byte[] buffer;

        public List<Connection> Connections { get; set; }

        public List<IListener> Listeners { get; set; }

        public int Port { get; set; }

        private int nextConnectionId;

        private TcpListener clientListener;


        public Server(int port, int bufferSize = 4096)
        {
            Port = port;
            buffer = new byte[bufferSize];

            Connections = new List<Connection>();
            Listeners = new List<IListener>();
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
            Console.WriteLine("Server stopping");

            // Close all connections
            Connections.ForEach(c => c.Close());
            Connections = new List<Connection>();

            // Release thread and close listener
            clientConnectedReset.Set();
            clientListener.Stop();
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
                ConnectionID = nextConnectionId++
            };
            connection.AddListener(this);
            connection.Stream.BeginRead(connection.Buffer, 0, connection.Buffer.Length, connection.ReadCallBack, connection.Stream);

            // Let the client know its Id
            connection.Send(new NetAcceptConnection
            {
                ConnectionID = connection.ConnectionID
            });

            // Add connection
            lock (Connections)
            {
                Connections.Add(connection);
            }

            // Signal the calling thread to continue
            clientConnectedReset.Set();
        }

        public void SendToAll(object o)
        {
            Connections.ForEach(c => c.Send(o));
        }

        public void SendToAll(object o, ConnectionType connectionType)
        {
            Connections.ForEach(c =>
            {
                if (c.ConnectionType.HasFlag(connectionType))
                {
                    c.Send(o);
                }
            });
        }

        public void SendToAllExcept(object o, ConnectionType connectionType)
        {
            Connections.ForEach(c =>
            {
                if (!c.ConnectionType.HasFlag(connectionType))
                {
                    c.Send(o);
                }
            });
        }

        public void AddListener(IListener listener)
        {
            Listeners.Add(listener);
        }

        public void AddListeners(IEnumerable<IListener> listeners)
        {
            listeners.ToList().ForEach(AddListener);
        }

        public void AddListeners(params IListener[] listeners)
        {
            AddListeners(listeners.ToList());
        }

        public void Connected(Connection connection)
        {
            Listeners.ForEach(l => l.Connected(connection));
        }

        public void Disconnected(Connection connection)
        {
            lock (Connections)
            {
                Connections.Remove(connection);
            }

            Listeners.ForEach(l => l.Disconnected(connection));
        }

        public void Received(Connection connection, object o)
        {
            Listeners.ForEach(l => l.Received(connection, o));
        }

        public void Dispose()
        {
            Stop();
        }
    }
}
