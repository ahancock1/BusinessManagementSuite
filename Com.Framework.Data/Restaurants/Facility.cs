using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Com.Framework.Data.Restaurants
{
    [DataContract]
    public class Facility : BaseEntity
    {
        [DataMember]
        public int FacilityID { get; set; }

        [DataMember]
        public string Name { get; set; }

        public virtual ICollection<Restaurant> Restaurants { get; set; }
    }
}
