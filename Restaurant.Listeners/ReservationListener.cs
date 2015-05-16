using System;
using Restaurant.DataAccess.Services;
using Restaurant.Network;
using Restaurant.Network.Packets;

namespace Restaurant.Listeners
{
    public class ReservationListener : PacketHandler
    {
        private readonly IReservationService service;

        public ReservationListener(Server server = null) : base(server)
        {
            // Create data access
            service = new ReservationService();
            
            Register<NetReservationUpdate>(UpdateReservation);
        }

        public void RequestReservations(Connection connection, INetPacket packet)
        {
            throw new NotImplementedException();
        }

        public void UpdateReservation(Connection connection, INetPacket packet)
        {
            service.Update(((NetReservationUpdate)packet).Reservation);
        }

    }
}
