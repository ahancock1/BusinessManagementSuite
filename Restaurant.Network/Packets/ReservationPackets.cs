using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Restaurant.Data;

namespace Restaurant.Network.Packets
{
    [Serializable]
    public class NetReservationRequest : INetPacket
    {
        // TODO implement this
    }

    [Serializable]
    public class NetReservationCreate : INetPacket
    {
        public Reservation Reservation { get; set; }
    }

    [Serializable]
    public class NetReservationUpdate : INetPacket
    { 
        public Reservation Reservation { get; set; }
    }

    [Serializable]
    public class NetReservationDelete : INetPacket
    {
        public int ID { get; set; }
    }
}
