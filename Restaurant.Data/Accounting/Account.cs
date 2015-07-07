using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Restaurant.Data.Accounting
{
    [DataContract]
    public class Account: Entity
    {
        [DataMember]
        public int AccountID { get; set; }

        [DataMember]
        public string BaseUrl { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Description { get; set; }

        [DataMember]
        public byte[] Image { get; set; }


        public virtual ICollection<User> Users { get; set; }

        public virtual ICollection<Venue> Restaurants { get; set; } 

    }
}
