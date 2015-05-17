using System;
using Restaurant.Data;

namespace Restaurant.Network.Packets
{
    public enum OrderResponse : byte
    {
        Error,
        Accepted,
        Refused
    }

    [Serializable]
    public class NetOrderUpdate : INetPacket
    {
        public Order[] Orders { get; set; }
    }
    
    [Serializable]
    public class NetOrderResponseCode : INetPacket
    {
        public OrderResponse Response { get; set; }
    }
    
    [Serializable]
    public class NetOrderRequest : INetPacket
    {
        public string Where { get; set; }
    }

    [Serializable]
    public class NetOrderResponse : INetPacket
    {
        public Order Order { get; set; }
    }

    [Serializable]
    public class NetOrdersResponse : INetPacket
    {
        public Order[] Orders { get; set; }
    }
}
