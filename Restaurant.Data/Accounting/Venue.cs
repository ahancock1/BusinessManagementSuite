using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Restaurant.Data.Accounting
{
    [DataContract]
    public class VenueType : Entity
    {
        public int VenueTypeID { get; set; }

        [Required, DataMember]
        public string Name { get; set; }

        public virtual ICollection<Venue> Restaurants {get; set; } 
    }

    [DataContract]
    public class Venue : Entity
    {
        [DataMember]
        public int VenueID { get; set; }

        [Required, DataMember]
        public string Name { get; set; }
        
        [Required, DataMember]
        public string Description { get; set; }

        [DataMember]
        public int UserRating { get; set; }

        [DataMember]
        public int Rating { get; set; }

        public virtual ICollection<User> Users { get; set; }

        public virtual VenueType RestaurantType { get; set; }

        public virtual Account Account { get; set; }

        public Venue()
        {
            Name = String.Empty;
            Description = String.Empty;
        }
    }

}
