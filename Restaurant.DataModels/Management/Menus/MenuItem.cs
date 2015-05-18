using System.Collections.Generic;

namespace Restaurant.DataModels.Management.Menus
{
    public class MenuItem: Item
    {
        public int Quantity { get; set; }

        public virtual ICollection<Menu> Menus { get; set; } 
    }
}