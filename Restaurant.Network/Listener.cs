using System;

namespace Restaurant.Network
{
    public interface IListener
    {
        void Connected(Connection connection);

        void Disconnected(Connection connection);

        void Received(Connection connection, object o);
    }

    /// <summary>
    /// Class that listens for connection, packets and disconnections.
    /// Can be attached to server or client
    /// </summary>
    public class Listener : IListener
    {
        protected readonly Server Server;

        public Listener(Server server = null)
        {
            Server = server;
        }

        public bool Host
        {
            get { return Server != null; }
        }

        public virtual void Connected(Connection connection)
        {
            Console.WriteLine("Connected: {0}", connection);
        }

        public virtual void Disconnected(Connection connection)
        {
            Console.WriteLine("Disconnected: {0}", connection);
        }

        public virtual void Received(Connection connection, object o)
        {
            Console.WriteLine("Data received: {0}", o.GetType().Name);
        }
    }
}
