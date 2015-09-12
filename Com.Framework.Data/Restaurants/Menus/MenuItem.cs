using System.Collections.Generic;
using System.Runtime.Serialization;
using Com.Framework.Data.Restaurants.Tickets;

namespace Com.Framework.Data.Restaurants.Menus
{
    [DataContract]
    public class MenuItem : Entity, IBillable
    {
        [DataMember]
        public int MenuItemID { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public bool Active { get; set; }

        [DataMember]
        public string Description { get; set; }

        [DataMember]
        public Image Image { get; set; }

        [DataMember]
        public virtual ICollection<MenuItemDetail> MenuItemDetails { get; set; }

        [DataMember]
        public virtual MenuItemType MenuItemType { get; set; }

        public virtual ICollection<MenuCategory> ManuCategories { get; set; }

        public virtual ICollection<Premise> Premises { get; set; }

        public virtual ICollection<TicketItem> TicketItems { get; set; }

        [DataMember]
        public float Cost { get; set; }
    }
}