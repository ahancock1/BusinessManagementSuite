using System;

using Restaurant.Data;

namespace Restaurant.Network.Packets
{
    [Serializable]
    public class NetReservationRequest : INetPacket
    {
        public string Where { get; set; }
    }
    
    [Serializable]
    public class NetReservationUpdate : INetPacket
    { 
        public Reservation[] Reservations { get; set; }
    }

    [Serializable]
    public class NetReservationsResponse : INetPacket
    {
        public Reservation[] Reservations { get; set; }
    }

    [Serializable]
    public class NetReservationResponse : INetPacket
    {
        public Reservation Reservation { get; set; }
    }
}
