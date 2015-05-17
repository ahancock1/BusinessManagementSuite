﻿using Restaurant.Data;
using Restaurant.DataAccess.Services;
using Restaurant.Network;
using Restaurant.Network.Packets;

namespace Restaurant.Listeners
{
    public class OrderListener : GenericPacketHandler<Order>
    {
        private readonly IGenericService<Order> service;

        public OrderListener(Server server)
            : base(server)
        {
            service = new GenericService<Order>();

        }

        public override void UpdatePacketReceived(Connection connection, NetUpdate<Order> packet)
        {
            Order[] orders = packet.Items;

            if (orders == null) return;

            bool result = service.Update(orders);

            foreach (Order order in orders)
            {
                Server.SendToAll(order.GetItems<FoodItem>(), ConnectionType.Kitchen | ConnectionType.Management);

                Server.SendToAll(order.GetItems<DrinkItem>(), ConnectionType.Bar | ConnectionType.Management);
            }

            connection.Send(new NetResponseCode<Order> { Response = result ? NetResponseCode.Accepted : NetResponseCode.Error });
        }
    }
}