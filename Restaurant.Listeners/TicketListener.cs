using System;
using Restaurant.DataAccess.Services;
using Restaurant.Network;
using Restaurant.Network.Packets;

using Restaurant.Common.Extensions;
using Restaurant.DataModels.Management;
using Restaurant.DataModels.Management.Menus;

namespace Restaurant.Listeners
{
    public class TicketListener : GenericPacketHandler<Ticket>
    {
        private readonly IGenericService<Ticket> service;

        public TicketListener(Server server)
            : base(server)
        {
            service = new GenericService<Ticket>();

            Register<NetUpdate<Ticket>>(UpdatePacketReceived);
        }

        /// <summary>
        /// Overriden update packet method. Sends the updated ticket to the bar, kitchen, and management
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="packet"></param>
        public override void UpdatePacketReceived(Connection connection, NetUpdate<Ticket> packet)
        {
            Console.WriteLine("Update ticket received: {0}", packet);

            Ticket[] tickets = packet.Items;

            if (tickets == null) return;

            // Update tickets in database
            bool result = service.Update(tickets);

            foreach (Ticket ticket in tickets)
            {
                // Send kitchen and management the updated food ticket items
                Server.SendToAll(ticket.Items.GetTypes<FoodItem>(), ConnectionType.Kitchen | ConnectionType.Management);

                // Send bar and management the updated drink ticket items
                Server.SendToAll(ticket.Items.GetTypes<DrinkItem>(), ConnectionType.Bar | ConnectionType.Management);
            }

            // Send a response code to the client
            connection.Send(new NetResponseCode<Ticket> { Response = result ? NetResponseCode.Accepted : NetResponseCode.Error });
        }
    }
}
