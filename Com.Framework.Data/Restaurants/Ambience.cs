using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Com.Framework.Data.Restaurants
{
    [DataContract]
    public class Ambience : BaseEntity
    {
        [DataMember]
        public int AmbienceID { get; set; }

        [DataMember]
        public string Name { get; set; }

        public virtual ICollection<Restaurant> Restaurants { get; set; }
    }
}