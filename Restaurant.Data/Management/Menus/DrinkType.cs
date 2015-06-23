using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Restaurant.Data.Management.Menus
{
    [Serializable]
    public class DrinkType : Entity
    {
        public int DrinkTypeID { get; set; }

        [Required]
        public string Name { get; set; }

        public virtual ICollection<DrinkItem> Drinks { get; set; } 
    }
}