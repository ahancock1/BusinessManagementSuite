using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Restaurant.Data;
using Restaurant.DataAccess.Services;
using Restaurant.Network;
using Restaurant.Network.Packets;

namespace Restaurant.Listeners
{
    public class OrderListener : PacketHandler
    {
        private OrderService service;

        public OrderListener(Server server)
            : base(server)
        {
            service = new OrderService();

            Register<NetOrderCreate>(CreateOrder);
            Register<NetOrderDelete>(DeleteOrder);
        }

        public void CreateOrder(Connection connection, INetPacket packet)
        {
            Order order = ((NetOrderCreate)packet).Order;

            if (order == null) return;

            bool result = service.Create(order);

            Server.SendToAll(order.GetItems<FoodItem>(), ConnectionType.Kitchen | ConnectionType.Management);

            Server.SendToAll(order.GetItems<DrinkItem>(), ConnectionType.Bar | ConnectionType.Management);

            connection.Send(new NetOrderResponse { Response = result ? OrderResponse.Accepted : OrderResponse.Error });
        }

        public void DeleteOrder(Connection connection, INetPacket packet)
        {
            
        }
    }
}
