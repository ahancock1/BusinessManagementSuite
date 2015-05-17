using System;
using Restaurant.Data;

namespace Restaurant.Network.Packets
{
    [Serializable]
    public class NetMenuUpdate : INetPacket
    {
        public Menu[] Menus { get; set; }
    }
    
    [Serializable]
    public class NetMenuRequest : INetPacket
    {
        public string Where { get; set; }
    }
}
