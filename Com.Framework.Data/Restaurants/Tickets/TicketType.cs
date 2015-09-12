using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Com.Framework.Data.Restaurants.Tickets
{
    [DataContract]
    public class TicketType : Entity
    {
        [DataMember]
        public int TicketTypeID { get; set; }

        [DataMember]
        public string Name { get; set; }

        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}