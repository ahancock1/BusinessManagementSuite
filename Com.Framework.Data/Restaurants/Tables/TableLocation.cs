using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Com.Framework.Data.Restaurants.Tables
{
    public class TableLocation : Entity
    {
        [DataMember]
        public float X { get; }

        [DataMember]
        public float Y { get; }

        protected virtual ICollection<Table> Tables { get; set; }

        public TableLocation(float x, float y)
        {
            X = x; Y = y;
        }
    }
}
