using Restaurant.Data;
using Restaurant.DataAccess.Services;
using Restaurant.Network;
using Restaurant.Network.Packets;

namespace Restaurant.Listeners
{
    public class OrderListener : PacketHandler
    {
        private readonly IGenericService<Order> service;

        public OrderListener(Server server)
            : base(server)
        {
            service = new GenericService<Order>();

            Register<NetOrderUpdate>(UpdateOrder);
        }

        private void UpdateOrder(Connection connection, INetPacket packet)
        {
            Order[] orders = ((NetOrderUpdate)packet).Orders;

            if (orders == null) return;

            bool result = service.Update(orders);

            foreach (Order order in orders)
            {
                Server.SendToAll(order.GetItems<FoodItem>(), ConnectionType.Kitchen | ConnectionType.Management);

                Server.SendToAll(order.GetItems<DrinkItem>(), ConnectionType.Bar | ConnectionType.Management);
            }

            connection.Send(new NetOrderResponseCode { Response = result ? OrderResponse.Accepted : OrderResponse.Error });
        }
    }
}
