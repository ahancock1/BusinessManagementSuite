using System;

namespace Restaurant.Data
{
    [Serializable]
    public class Order : ItemList
    {
        public int OrderID { get; set; }

        public StaffMember Member { get; set; }

        public Table Table { get; set; }

        
        public Order()
        {
        }
    }
}
