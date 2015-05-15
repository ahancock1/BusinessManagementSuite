using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

using Restaurant.Data;

namespace Restaurant.DataAccess.Services
{
    public interface IOrderService
    {
        bool Create(Order order);

        bool Delete(int id);
    }

    public class OrderService : IOrderService
    {
        public bool Create(Order order)
        {
            using (var context = new RestaurantDbContext())
            {
                context.Orders.Add(order);
                return context.SaveChanges() > 0;
            }
        }

        public bool Delete(int id)
        {
            using (var context = new RestaurantDbContext())
            {
                Order order = context.Orders.Find(id);
                context.Orders.Remove(order);
                return context.SaveChanges() > 0;
            }
        }
    }
}
