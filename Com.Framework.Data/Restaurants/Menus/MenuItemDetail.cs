using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Com.Framework.Data.Restaurants.Menus
{
    [DataContract]
    public class MenuItemDetail
    {
        [DataMember]
        public int MenuItemDetailID { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public Image Image { get; set; }

        public virtual ICollection<MenuItem> MenuItems { get; set; }
    }
}