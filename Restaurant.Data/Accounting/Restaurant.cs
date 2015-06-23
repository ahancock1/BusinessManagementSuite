using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Restaurant.Data.Accounting
{
    [Serializable]
    public class RestaurantType
    {
        public int RestaurantTypeID { get; set; }

        [Required]
        public string Name { get; set; }

        public virtual ICollection<Restaurant> Restaurants {get; set; } 
    }
    
    [Serializable]
    public class Restaurant
    {
        public int RestaurantID { get; set; }

        [Required]
        public string Name { get; set; }
        
        [Required]
        public string Description { get; set; }

        public RestaurantType RestaurantType { get; set; }

        public int UserRating { get; set; }

        public int Rating { get; set; }


        public Restaurant()
        {
            Name = String.Empty;
            Description = String.Empty;
        }
    }
}
