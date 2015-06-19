using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.DataModels.Management.Menus
{
    public class MenuItemPortion : Item
    {
        public float PortionSize { get; set; }

        public string Description { get; set; }

        public virtual MenuItemCost MenuItemCost {get; set; }

        public virtual ICollection<MenuItemPortion> MenuItemPortions { get; set; }

        public virtual ICollection<MenuItem> MenuItems { get; set; }


        public MenuItemPortion()
        {
            Name = String.Empty;
            Description = String.Empty;
        }

        /// <summary>
        /// Recursively sum portion cost
        /// </summary>
        public float PortionCost
        {
            get { return (MenuItemCost.Cost * PortionSize) + MenuItemPortions.Sum(i => i.PortionCost); }
        }

    }

    public class MenuItemCost
    {
        public int MenuItemCostID { get; set; }

        public float Cost { get; set; }

        public virtual ICollection<MenuItemPortion> MenuItemPortions { get; set; }
    }
}
