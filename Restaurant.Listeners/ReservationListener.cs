using System;
using Restaurant.DataAccess.Services;
using Restaurant.Network;
using Restaurant.Network.Packets;

namespace Restaurant.Listeners
{
    public interface IReservationListener
    {
        void RequestReservations(Connection connection, INetPacket packet);

        void CreateReservation(Connection connection, INetPacket packet);

        void UpdateReservation(Connection connection, INetPacket packet);

        void DeleteReservation(Connection connection, INetPacket packet);
    }

    public class ReservationListener : PacketHandler, IReservationListener
    {
        private readonly IReservationService service;

        public ReservationListener(Server server = null) : base(server)
        {
            // Create data access
            service = new ReservationService();

            // Register packets to listen for
            Register<NetReservationRequest>(RequestReservations);
            Register<NetReservationCreate>(CreateReservation);
            Register<NetReservationUpdate>(UpdateReservation);
            Register<NetReservationDelete>(DeleteReservation);
        }

        public void RequestReservations(Connection connection, INetPacket packet)
        {
            throw new NotImplementedException();
        }

        public void CreateReservation(Connection connection, INetPacket packet)
        {
            service.Create(((NetReservationCreate) packet).Reservation);
        }

        public void UpdateReservation(Connection connection, INetPacket packet)
        {
            service.Update(((NetReservationUpdate)packet).Reservation);
        }

        public void DeleteReservation(Connection connection, INetPacket packet)
        {
            service.Delete(((NetReservationDelete) packet).ID);
        }
    }
}
