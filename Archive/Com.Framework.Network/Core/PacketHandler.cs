using System;
using System.Collections.Generic;
using Com.Framework.Network.Packets;

namespace Com.Framework.Network
{
    public delegate void OnPacketReceived<in T>(Connection connection, T packet) where T : INetPacket;

    /// <summary>
    /// Class that listens for a single type of INetPacket packet
    /// </summary>
    /// <typeparam name="T">Packet type</typeparam>
    public class PacketListener<T> : Listener where T : INetPacket
    {
        private event OnPacketReceived<T> PacketReceived;

        public PacketListener(OnPacketReceived<T> packetReceived)
        {
            PacketReceived = packetReceived;
        }

        /// <summary>
        /// Fired when a packet is received
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="o"></param>
        public override void Received(Connection connection, object o)
        {
            // Check packet is the type it should be listening for, otherwise return to process other listeners
            if (!(o is T)) return;

            if (PacketReceived != null)
            {
                // Fire event for this type of packet
                PacketReceived(connection, (T)o);
            }
        }

        public override void Connected(Connection connection)
        {
            // Ignore this method
        }

        public override void Disconnected(Connection connection)
        {
            // Ignore this method
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
            // Check the packet and event hasn't already been added
            if (!listeners.ContainsKey(typeof(T)))
            {
                listeners.Add(typeof(T), packetReceived);
            }
        }

        public override void Received(Connection connection, object o)
        {
            // if listening for this type of packet, invoke event
            Delegate listener;
            if (listeners.TryGetValue(o.GetType(), out listener))
            {
                listener.DynamicInvoke(connection, o);
            }
        }

        public override void Connected(Connection connection)
        {
            // Ignore this method
        }

        public override void Disconnected(Connection connection)
        {
            // Ignore this method
        }
    }
}
