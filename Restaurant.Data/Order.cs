using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Restaurant.Data
{
    

    [Serializable]
    public class Order : ItemList
    {
        public int OrderID { get; set; }

        public User User { get; set; }

        public Table Table { get; set; }

        public Order()
        {
        }
    }
}
