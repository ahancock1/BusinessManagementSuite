using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Com.Framework.Data.Restaurants.Menus
{
    [DataContract]
    public class Menu : Entity
    {
        [DataMember]
        public int MenuID { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Description { get; set; }

        [DataMember]
        public bool Active { get; set; }

        [DataMember]
        public DateTime Created { get; set; }

        [DataMember]
        public DateTime Modified { get; set; }

        [DataMember]
        public ICollection<MenuCategory> MenuCategories { get; set; }

        [DataMember]
        public ICollection<Hours> Hours { get; set; }

        public virtual Premise Premise { get; set; }
    }
}
