using System;
using System.Collections.Generic;

namespace Restaurant.Data
{
    [Serializable]
    public class Ticket: Entity
    {
        public int TicketID { get; set; }

        public DateTime LastUpdated { get; set; }

        public DateTime Ordered { get; set; }

        public List<Item> Items { get; set; }  

        public List<Item> PaidItems { get; set; }




        public Member Member { get; set; }

        public virtual StaffMember StaffMember { get; set; }

        public virtual Table Table { get; set; }


        public Ticket()
        {
            Items = new List<Item>();
        }
    }

    [Serializable]
    public class TicketItem : Entity
    {
        public int TicketItemID { get; set; }
    
        public bool IsPaid { get; set; }

        public virtual Item Item { get; set; }

        public virtual Ticket Ticket { get; set; }


        public TicketItem()
        {
            
        }
    }
}
