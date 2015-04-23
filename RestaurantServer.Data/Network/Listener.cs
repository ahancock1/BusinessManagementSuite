using System;

namespace RestaurantServer.Data.Network
{
    public interface IListener
    {
        void Connected(Connection connection);

        void Disconnected(Connection connection);

        void Received(Connection connection, object o);
    }

    // TODO make class abstract - used for logging at the moment
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
