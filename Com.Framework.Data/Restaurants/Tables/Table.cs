using System.Runtime.Serialization;
using Com.Framework.Data.Restaurants.Tables;

namespace Com.Framework.Data.Restaurants.Tables
{
    [DataContract]
    public class Table : Entity<long>
    {

        [DataMember]
        public int TableNumber { get; set; }

        [DataMember]
        public Section Section { get; set; }

        [DataMember]
        public TableLocation Location { get; set; }

    }
}
