using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Com.Framework.Data.Restaurants
{
    [DataContract]
    public class Cuisine : BaseEntity
    {
        [DataMember]
        public int CuisineID { get; set; }

        [DataMember]
        public string Name { get; set; }

        public virtual ICollection<Restaurant> Restaurants { get; set; }
    }
}