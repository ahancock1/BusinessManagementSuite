using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Restaurant.Data;

namespace Restaurant.Network.Packets
{
    public enum OrderResponse : byte
    {
        Accepted = 1,
        Refused,
        Error
    }

    [Serializable]
    public class NetOrderCreate : INetPacket
    {
        public Order Order { get; set; }
    }

    [Serializable]
    public class NetOrderUpdate : INetPacket
    {
        public int OrderID { get; set; }
    }

    [Serializable]
    public class NetOrderResponse : INetPacket
    {
        public OrderResponse Response { get; set; }

        public NetOrderResponse()
        {
            Response = OrderResponse.Error;
        }
    }

    [Serializable]
    public class NetOrderDelete : INetPacket
    {
        public Order Order { get; set; }
    }

    [Serializable]
    public class NetOrderRequest : INetPacket
    {
        public int OrderID { get; set; }
    }
}
