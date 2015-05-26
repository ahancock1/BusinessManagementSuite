using System;
using System.Collections.Generic;
using System.Linq;

namespace Restaurant.DataModels.Management.Inventory
{
    public class Order : Entity
    {
        public List<OrderItem> Items { get; set; }

        public DateTime Created { get; set; }

        public string Name { get; set; }


        public Order()
        {
            Items = new List<OrderItem>();
        }

        public IList<T> GetItems<T>() where T : OrderItem
        {
            return Items.Where(i => i.GetType() == typeof (T)).Cast<T>().ToList();
        } 
    }


}
