using System;
using System.Collections.Generic;

namespace Restaurant.DataModels.Management.Menus
{
    [Serializable]
    public class DrinkItem : MenuItem
    {
        public DrinkType DrinkType { get; set; }

        public float AlcoholVolume { get; set; }

        // Cocktails and drinks that require mixers
        public List<Item> Items { get; set; } 

        public DrinkItem()
        {
        }

        public bool IsAlcoholic
        {
            get { return Math.Abs(AlcoholVolume) <= 0; }
        }
    }
}