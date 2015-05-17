using System;
using System.Collections.Generic;
using Restaurant.Network.Packets;

namespace Restaurant.Network
{
    public delegate void OnPacketReceived<in T>(Connection connection, T packet) where T : INetPacket;

    /// <summary>
    /// Class that listens for a single type of packet
    /// </summary>
    /// <typeparam name="T">Packet type</typeparam>
    public class PacketListener<T> : Listener where T : INetPacket
    {
        private event OnPacketReceived<T> PacketReceived;

        public PacketListener(OnPacketReceived<T> packetReceived)
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

    /// <summary>
    /// Class that listens for specific types of packets
    /// </summary>
    public class PacketHandler : Listener
    {
        private Dictionary<Type, Delegate> listeners;

        public PacketHandler(Server server = null)
            : base(server)
        {
            listeners = new Dictionary<Type, Delegate>();
        }

        public void Register<T>(OnPacketReceived<T> packetReceived) where T : INetPacket
        {
            if (!listeners.ContainsKey(typeof(T)))
            {
                listeners.Add(typeof(T), packetReceived);
            }
        }

        public override void Received(Connection connection, object o)
        {
            Delegate listener;
            if (listeners.TryGetValue(o.GetType(), out listener))
            {
                listener.DynamicInvoke(connection, o);
            }
        }
    }
}
