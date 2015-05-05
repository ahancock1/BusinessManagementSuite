using System;
using System.Collections.Generic;
using System.Linq;

namespace Restaurant.Network
{
    public interface IListener
    {
        void Connected(Connection connection);

        void Disconnected(Connection connection);

        void Received(Connection connection, object o);
    }

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

    public class PacketHandler : Listener
    {
        private Dictionary<Type, PacketListener<INetPacket>> listeners; 

        public PacketHandler(Server server = null) : base (server)
        {
            listeners = new Dictionary<Type, PacketListener<INetPacket>>();
        }

        public void Register<T>(PacketListener<INetPacket>.OnPacketReceived packetReceived) where T : INetPacket
        {
            if (!listeners.ContainsKey(typeof(T)))
            {
                listeners.Add(typeof(T), new PacketListener<INetPacket>(packetReceived));
            }
        }
        
        public void Remove<T>()
        {
            Remove(typeof(T));
        }

        public void Remove(Type type)
        {
            if (listeners.ContainsKey(type))
            {
                listeners.Remove(type);
            }
        }

        public override void Received(Connection connection, object o)
        {
            if (listeners.ContainsKey(o.GetType()))
            {
                listeners[o.GetType()].Received(connection, o);
            }
        }
    }

    public class PacketListener<T> : Listener where T : INetPacket
    {
        public delegate void OnPacketReceived(Connection connection, T packet);

        private event OnPacketReceived PacketReceived;

        public PacketListener(OnPacketReceived packetReceived)
        {
            PacketReceived = packetReceived;
        }

        public override void Received(Connection connection, object o)
        {
            // Log packet
            base.Received(connection, o);

            if (!(o is T)) return;

            if (PacketReceived != null)
            {
                PacketReceived(connection, (T)o);
            }
        }
    }
}
