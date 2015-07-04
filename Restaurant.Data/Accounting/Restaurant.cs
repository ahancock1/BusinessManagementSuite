using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Restaurant.Data.Accounting
{
    [DataContract]
    public class RestaurantType : Entity
    {
        public int RestaurantTypeID { get; set; }

        [Required, DataMember]
        public string Name { get; set; }

        public virtual ICollection<Restaurant> Restaurants {get; set; } 
    }

    [DataContract]
    public class Restaurant : Entity
    {
        [DataMember]
        public int RestaurantID { get; set; }

        [Required, DataMember]
        public string Name { get; set; }
        
        [Required, DataMember]
        public string Description { get; set; }

        [DataMember]
        public int UserRating { get; set; }

        [DataMember]
        public int Rating { get; set; }

        public virtual ICollection<User> Users { get; set; } 

        public virtual RestaurantType RestaurantType { get; set; }

        public virtual Account Account { get; set; }

        public Restaurant()
        {
            Name = String.Empty;
            Description = String.Empty;
        }


    }
}
