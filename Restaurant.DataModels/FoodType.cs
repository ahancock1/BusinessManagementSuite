using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Restaurant.DataModels
{
    [Serializable]
    public class FoodType
    {
        public int FoodTypeID { get; set; }

        [Required]
        public string Name { get; set; }

        public virtual ICollection<FoodItem> Foods { get; set; } 
    }
}