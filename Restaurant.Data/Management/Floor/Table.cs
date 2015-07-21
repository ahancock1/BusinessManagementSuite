using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using Restaurant.Data.Accounting;

namespace Restaurant.Data.Management.Floor
{
    [DataContract]
    public class Table : Entity
    {
        [Key, DataMember]
        public int TableID { get; set; }


        [DataMember]
        public byte Number { get; set; }

        [DataMember]
        public byte Seats { get; set; }

        [DataMember]
        public virtual Section Section { get; set; }

        [DataMember]
        public virtual Venue Venue { get; set; }


        public virtual ICollection<Reservation> Reservations { get; set; }
    }
}
