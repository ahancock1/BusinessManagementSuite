using System;
using System.Collections.Generic;
using System.Linq;
using Restaurant.DataModels.Management.Floor;
using Restaurant.DataModels.Management.Menus;
using Restaurant.DataModels.Management.Staff;

namespace Restaurant.DataModels.Management
{
    [Serializable]
    public class Ticket: Entity
    {
        public int TicketID { get; set; }
        
        public DateTime Created { get; set; }

        public List<TicketItem> Items { get; set; }  
        



        public virtual StaffMember StaffMember { get; set; }

        public virtual Table Table { get; set; }
        
        public float PaidBalanace { get; set; }


        public Ticket()
        {
            Created = DateTime.Now;
            Items = new List<TicketItem>();
        }

        public IList<TicketItem> PaidItems
        {
            get { return Items.Where(i => i.IsPaid).ToList(); }
        }

        public IList<TicketItem> UnpaidItems
        {
            get { return Items.Where(i => !i.IsPaid).ToList(); }
        }

        public IList<TicketItem> GetTicketsByType<T>() where T : MenuItem
        {
            return Items.Where(i => i.Item.GetType() == typeof (T)).ToList();
        }

        public IList<T> GetItemsByType<T>() where T : MenuItem
        {
            return Items.Where(i => i.Item.GetType() == typeof(T)).Select(i => i.Item).Cast<T>().ToList();
        }

        public float Balance
        {
            get { return Items.Sum(i => i.Item.Cost); }
        }
    }

    [Serializable]
    public class TicketItem : Entity
    {
        public int TicketItemID { get; set; }
    
        public bool IsPaid { get; set; }

        public virtual MenuItem Item { get; set; }

        public virtual Ticket Ticket { get; set; }


        public TicketItem()
        {
        }
    }
}
