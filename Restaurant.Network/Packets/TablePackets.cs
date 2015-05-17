using System;
using Restaurant.Data;


namespace Restaurant.Network.Packets
{
    [Serializable]
    public class NetTableRequest : INetPacket
    {
        public string Where { get; set; }
    }

    [Serializable]
    public class NetTablesRequest : INetPacket
    {
        public string Where { get; set; }
    }

    [Serializable]
    public class NetTableResponse : INetPacket
    {
        public Table Table { get; set; }
    }

    [Serializable]
    public class NetTablesResponse : INetPacket
    {
        public Table[] Tables { get; set; }
    }

    [Serializable]
    public class NetTableUpdate : INetPacket
    {
        public Table[] Tables { get; set; }
    }
}
