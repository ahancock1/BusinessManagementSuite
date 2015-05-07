using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Restaurant.Data;


namespace Restaurant.Network.Packets
{
    [Serializable]
    public class NetTableRequest : INetPacket
    {
        public int? Number { get; set; }

        public NetTableRequest()
        {
            Number = null;
        }
    }

    [Serializable]
    public class NetTableCreate : INetPacket
    {
        public Table Table { get; set; }
    }

    [Serializable]
    public class NetTableUpdate : INetPacket
    {
        public Table Table { get; set; }
    }

    [Serializable]
    public class NetTableDelete : INetPacket
    {
        public int ID { get; set; }
    }

    [Serializable]
    public class NetTableResponse : INetPacket
    {
        public Table Table { get; set;}
    }

    [Serializable]
    public class NetTablesResponse : INetPacket
    {
        public Table[] Tables { get; set; }
    }
}
