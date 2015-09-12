using System;
using System.Collections;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Com.Framework.Data.Restaurants.Menus;
using Com.Framework.Data.Restaurants.Tables;

namespace Com.Framework.Data.Restaurants.Tickets
{
    [DataContract]
    public class TicketItem : Entity, IBillable
    {
        [DataMember]
        public int TicketItemID { get; set; }

        [DataMember]
        public MenuItem MenuItem { get; set; }

        [DataMember]
        public int Quantity { get; set; }

        public float Cost => MenuItem.Cost * Quantity;
    }
}
