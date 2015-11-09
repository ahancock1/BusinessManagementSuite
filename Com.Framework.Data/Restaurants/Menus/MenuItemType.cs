using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Com.Framework.Data.Restaurants.Menus
{
    [DataContract]
    public class MenuItemType : Entity<long>
    {

        [DataMember]
        public string Name { get; set; }

        public virtual ICollection<MenuItem> MenuItems { get; set; }

        public virtual ICollection<Premise> Premises { get; set; }
    }
}