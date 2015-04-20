using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.ServiceModel.Dispatcher;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RestaurantServer.Common
{
    public interface IServer : IDisposable
    {
        void Start();

        void Stop();
        
        void SendToAll(object o);

        void SendToAllExcept(object o, int id);

        void SendToAllExcept(object o, params int[] id);
    }

    public class Server : IServer
    {
        public List<Connection> Connections { get; set; }

        public Listener Listener { get; set; }
        
        public int Port { get; set; }

        public int Timeout { get; set; }

        private int nextConnectionID = 0;

        private bool shutdown;


        public Server(int port = 8000, int timeout = 250)
        {
            Port = port;
            Timeout = timeout;
        }

        /// <summary>
        /// Starts the server in a separate thread.
        /// </summary>
        public void Start()
        {
            new Thread(Run)
            {
                Name = "Server"
            }.Start();
        }

        public void Stop()
        {
            if (shutdown) return;

            Close();
            Console.WriteLine("Server stopping");
            shutdown = true;
        }

        public void Close()
        {
            foreach (Connection connection in Connections)
            {
                connection.Close();
            }
            Connections = new List<Connection>();


        }

        /// <summary>
        /// Starts the server in the same thread.
        /// </summary>
        public void Run()
        {
            Console.WriteLine("Server started");
            shutdown = false;
            while (!shutdown)
            {
                try
                {
                    Update(Timeout);
                }
                catch (IOException e)
                {
                    Close();
                }
            }
        }

        private void Update(int timeout)
        {
            
        }

        private void Accept()
        {
            
        }
        
        public void SendToAll(object o)
        {
            foreach (Connection connection in Connections)
            {
                connection.Send(o);
            }
        }

        public void SendToAllExcept(object o, int id)
        {
            foreach (Connection connection in Connections.Where(c => c.ID != id))
            {
                connection.Send(o);
            }
        }

        public void SendToAllExcept(object o, params int[] id)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            Close();
        }
    }
}
