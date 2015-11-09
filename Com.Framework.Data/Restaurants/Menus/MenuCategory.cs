using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Com.Framework.Data.Restaurants.Menus
{
    /// <summary>
    ///     Starters, Mains, Deserts
    /// </summary>
    [DataContract]
    public class MenuCategory : Entity<long>
    {

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Description { get; set; }

        [DataMember]
        public int Index { get; set; }

        [DataMember]
        public ICollection<MenuItem> MenuItems { get; set; }

        public virtual ICollection<Premise> Premises { get; set; }

        public virtual ICollection<Menu> Menus { get; set; }
    }
}