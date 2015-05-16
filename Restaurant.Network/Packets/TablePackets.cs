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
    public class NetTableUpdate : INetPacket
    {
        public Table[] Tables { get; set; }
    }
    
    [Serializable]
    public class NetTableResponse : INetPacket
    {
        public Table[] Tables { get; set; }
    }
}
