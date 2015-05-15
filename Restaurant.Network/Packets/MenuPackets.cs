using System;
using Restaurant.Data;

namespace Restaurant.Network.Packets
{
    [Serializable]
    public class NetMenuCreate : INetPacket
    {
        public Menu Menu { get; set; }
    }

    [Serializable]
    public class NetMenuUpdate : INetPacket
    {
        public Menu Menu { get; set; }
    }

    [Serializable]
    public class NetMenuDelete : INetPacket
    {
        public int MenuID { get; set; }
    }

    [Serializable]
    public class NetMenuRequest : INetPacket
    {
        public int MenuID { get; set; }

        public DateTime Created { get; set; }
    }
}
