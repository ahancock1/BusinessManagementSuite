using System;
using System.Collections.Generic;

namespace Restaurant.DataModels
{
    [Serializable]
    public class FoodItem : Item
    {


        public virtual ICollection<Menu> Menus { get; set; }

        public FoodItem()
        {
            
        }
    }
}