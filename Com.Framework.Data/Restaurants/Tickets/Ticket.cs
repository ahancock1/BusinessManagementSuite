using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Com.Framework.Data.Restaurants.Menus;
using Com.Framework.Data.Restaurants.Tables;

namespace Com.Framework.Data.Restaurants.Tickets
{
    [DataContract]
    public class Ticket : Entity<long>, IBillable, IEnumerable<TicketItem>
    {
        [DataMember]
        public DateTime Created { get; set; }

        [DataMember]
        public DateTime Modified { get; set; }

        [DataMember]
        public ICollection<TicketItem> Items { get; set; }

        [DataMember]
        public Table Table { get; set; }

        [DataMember]
        public Employee Employee { get; set; }

        [DataMember]
        protected Restaurant Restaurant { get; set; }

        [DataMember]
        public TicketType TicketType { get; set; }

        [DataMember]
        public float Cost { get; set; }


        public Ticket()
        {
            Items = new List<TicketItem>();
            Modified = Created = DateTime.Now;
        }


        public void AddRange(params MenuItem[] items)
        {
            AddRange(items.ToList());
        }

        public void AddRange(List<MenuItem> items)
        {
            items.ForEach(Add);
        }

        public void Add(MenuItem item)
        {
            if (Items.First(i => i.MenuItem == item) != null)
            {
                Items.First(i => i.MenuItem == item).Quantity++;
            }
            else
            {
                Items.Add(new TicketItem
                {
                    MenuItem = item,
                    Quantity = 1
                });
            }

            Modified = DateTime.Now;
        }

        public IEnumerable<TicketItem> Get<T>() where T : MenuItem, IBillable
        {
            return this.Where(i => i.MenuItem.GetType() == typeof(T));
        }

        public IEnumerable<TicketItem> Get(MenuItemType menuItemType)
        {
            return this.Where(i => i.MenuItem.MenuItemType == menuItemType);
        }

        public IEnumerator<TicketItem> GetEnumerator()
        {
            return Items.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
