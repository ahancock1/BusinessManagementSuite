using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using Com.Framework.Common.Logging;
using Com.Framework.Network.Packets;

namespace Com.Framework.Network
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

        private int nextConnectionID;

        private TcpListener clientListener;


        public Server(int port, int bufferSize = 4096)
        {
            Port = port;
            buffer = new byte[bufferSize];

            Connections = new List<Connection>();
            Listeners = new List<IListener>();
        }

        /// <summary>
        /// Start the server to listen for connections
        /// </summary>
        public void Start()
        {
            clientListener = new TcpListener(IPAddress.Any, Port);
            clientListener.Start();

            Logger.Info(String.Format("Server started on: {0}", Port));

            // ASync accept connections
            clientListener.BeginAcceptSocket(AcceptCallBack, clientListener);

            clientConnectedReset.WaitOne();
        }

        /// <summary>
        /// Stop server and discard of all active connections
        /// </summary>
        public void Stop()
        {
            Logger.Info("Server stopping");

            // Close all connections
            Connections.ForEach(c => c.Close());
            Connections = new List<Connection>();

            // Release thread and close listener
            clientConnectedReset.Set();
            clientListener.Server.Close();
        }

        /// <summary>
        /// ASync accept connection
        /// </summary>
        /// <param name="result"></param>
        private void AcceptCallBack(IAsyncResult result)
        {
            // Get the socket that handles the client request
            TcpClient client;
            try
            {
                client = ((TcpListener)result.AsyncState).EndAcceptTcpClient(result);

                clientListener.BeginAcceptSocket(AcceptCallBack, clientListener);
            }
            catch (SocketException e)
            {
                Logger.Error("Error accepting TCP Connection", e);

                // unrecoverable
                clientConnectedReset.Set();
                return;
            }
            catch (ObjectDisposedException)
            {
                // The listener was Stop()'d, disposing the underlying socket and
                // triggering the completion of the callback. We're already exiting,
                // so just return.
                Logger.Info("Server stopped");
                return;
            }

            // TODO: Introduce ssl


            // Create a connection
            Connection connection = new Connection(buffer.Length)
            {
                Client = client,
                Stream = client.GetStream(),
                ConnectionID = nextConnectionID++
            };
            connection.AddListener(this);
            connection.Stream.BeginRead(connection.Buffer, 0, connection.Buffer.Length, connection.ReadCallBack, connection.Stream);

            // Let the client know its connection ID
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

        /// <summary>
        /// Send serialisable object to all connections
        /// </summary>
        /// <param name="o"></param>
        public void SendToAll(object o)
        {
            Connections.ForEach(c => c.Send(o));
        }

        /// <summary>
        /// Send serialisable object to all connections specified by connection type
        /// </summary>
        /// <param name="o"></param>
        /// <param name="connectionType"></param>
        public void SendToAll(object o, ConnectionType connectionType)
        {
            Connections.ForEach(c =>
            {
                // Check connetion type is right
                if (c.ConnectionType.HasFlag(connectionType))
                {
                    c.Send(o);
                }
            });
        }

        /// <summary>
        /// Send serialisable object to all connections except the specified connection type
        /// </summary>
        /// <param name="o"></param>
        /// <param name="connectionType"></param>
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

        /// <summary>
        /// Attach a listener to the server
        /// </summary>
        /// <param name="listener"></param>
        public void AddListener(IListener listener)
        {
            Listeners.Add(listener);
        }

        /// <summary>
        /// Attach list of listeners to the server
        /// </summary>
        /// <param name="listeners"></param>
        public void AddListeners(IEnumerable<IListener> listeners)
        {
            listeners.ToList().ForEach(AddListener);
        }

        /// <summary>
        /// Attach array of listeners to the server
        /// </summary>
        /// <param name="listeners"></param>
        public void AddListeners(params IListener[] listeners)
        {
            AddListeners(listeners.ToList());
        }

        public void Connected(Connection connection)
        {
            // When a connection is received process all listeners
            Listeners.ForEach(l => l.Connected(connection));
        }

        public void Disconnected(Connection connection)
        {
            // Remove connection
            lock (Connections)
            {
                Connections.Remove(connection);
            }

            // Process all listeners disconnected methods
            Listeners.ForEach(l => l.Disconnected(connection));
        }

        public void Received(Connection connection, object o)
        {
            // Process all listeners for received packet
            Listeners.ForEach(l => l.Received(connection, o));
        }

        /// <summary>
        /// Dispose of server
        /// </summary>
        public void Dispose()
        {
            Stop();
        }
    }
}
