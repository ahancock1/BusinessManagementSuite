using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Restaurant.DataModels.Management.Menus
{
    public class MenuItem: Item
    {
        [Required]
        public string Description { get; set; }

        public float Multiplier { get; set; }



        public virtual ICollection<MenuItemPortion> MenuItemPortions { get; set; } 
        
        public virtual ICollection<Menu> Menus { get; set; }

        public MenuItem()
        {
            
        }
    }

    // MenuItem is made up of items - MenuItemPortions
    // ie classic burger; bun, burger, salad, cheese, chips, coleslaw
}