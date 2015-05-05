using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Restaurant.DataAccess.Services;
using Restaurant.Network;

namespace Restaurant.Listeners
{
    public interface IOrderListener
    {
        
    }

    public class OrderListener : PacketHandler
    {
        private OrderService service;

        public OrderListener(Server server) : base (server)
        {
            service = new OrderService();

        }
    }
}
