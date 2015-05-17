using System;

namespace Restaurant.Data
{
    [Serializable]
    public class Order : ItemList
    {
        public int ID { get; set; }

        public StaffMember Member { get; set; }

        public Table Table { get; set; }

        
        public Order()
        {
        }
    }
}
