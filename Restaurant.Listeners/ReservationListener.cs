using System;
using Restaurant.Data;
using Restaurant.DataAccess.Services;
using Restaurant.Network;
using Restaurant.Network.Packets;

namespace Restaurant.Listeners
{
    public class ReservationListener : PacketHandler
    {
        private readonly IGenericService<Reservation> service;

        public ReservationListener(Server server = null) : base(server)
        {
            // Create data access
            service = new GenericService<Reservation>();
            
            Register<NetReservationUpdate>(UpdateReservation);
        }

        private void RequestReservations(Connection connection, INetPacket packet)
        {
            // TODO implement
            throw new NotImplementedException();
        }

        private void UpdateReservation(Connection connection, INetPacket packet)
        {
            service.Update(((NetReservationUpdate)packet).Reservations);
        }

    }
}
