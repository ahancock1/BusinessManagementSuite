using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Data.Accounting
{
    [DataContract]
    public class Account: Entity
    {
        public string BaseUrl { get; set; }
        
        public string Name { get; set; }

        public string Description { get; set; }

        public byte[] Image { get; set; }


        public virtual ICollection<User> Users { get; set; }

        public virtual ICollection<Restaurant> Restaurants { get; set; } 

    }
}
