using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Com.Framework.Data.Restaurants.Tables
{
    [DataContract]
    public class Section : Entity<long>
    {

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        protected virtual Premise Premise { get; set; }

        [DataMember]
        protected virtual ICollection<Table> Tables { get; set; }
    }
}