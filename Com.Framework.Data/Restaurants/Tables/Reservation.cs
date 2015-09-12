using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Com.Framework.Data.Restaurants.Tables
{
    [DataContract]
    public class Reservation : Entity
    {
        [DataMember]
        public int ReservationID { get; set; }

        [DataMember]
        public int PartySize { get; set; }

        [DataMember]
        public ICollection<Table> Tables { get; set; }

        [DataMember]
        public Employee Employee { get; set; }

        [DataMember]
        public User Guest { get; set; }

        [DataMember]
        public Hours Hours { get; set; }

        [DataMember]
        public DateTime Created { get; set; }

        [DataMember]
        public DateTime Modified { get; set; }

        [DataMember]
        public Premise Premise { get; set; }

    }
}
