using Restaurant.Data;
using Restaurant.DataAccess.Services;
using Restaurant.Network;
using Restaurant.Network.Packets;

using Restaurant.Common.Extensions;

namespace Restaurant.Listeners
{
    public class TicketListener : GenericPacketHandler<Ticket>
    {
        private readonly IGenericService<Ticket> service;

        public TicketListener(Server server)
            : base(server)
        {
            service = new GenericService<Ticket>();

        }

        public override void UpdatePacketReceived(Connection connection, NetUpdate<Ticket> packet)
        {
            Ticket[] tickets = packet.Items;

            if (tickets == null) return;

            bool result = service.Update(tickets);

            foreach (Ticket ticket in tickets)
            {
                Server.SendToAll(ticket.Items.GetType<FoodItem>(), ConnectionType.Kitchen | ConnectionType.Management);

                Server.SendToAll(ticket.Items.GetType<DrinkItem>(), ConnectionType.Bar | ConnectionType.Management);
            }

            connection.Send(new NetResponseCode<Ticket> { Response = result ? NetResponseCode.Accepted : NetResponseCode.Error });
        }
    }
}
