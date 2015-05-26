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
    public abstract class Listener : IListener
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

        public abstract void Connected(Connection connection);

        public abstract void Disconnected(Connection connection);

        public abstract void Received(Connection connection, object o);
    }
}
