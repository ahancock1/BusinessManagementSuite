using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Restaurant.Data
{
    public class ItemType
    {
        public int ItemTypeID { get; set; }

        [Required]
        public string Name { get; set; }

        public virtual ICollection<Item> Items { get; set; }

        public ItemType()
        {
            Name = String.Empty;
        }
    }

    public abstract class Item
    {
        public int ItemID { get; set; }

        [Required]
        public float Cost { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Code { get; set; }

        public int Quantity { get; set; }

        public Item()
        {
            Name = String.Empty;
            Code = String.Empty;
        }
    }

    public enum DrinkType
    {
        None,
        Mixer,
        Spirit,
        Liquer,
        Juice,
        Wine,
        Beer
    }
    
    public class DrinkItem : Item
    {
        public DrinkType DrinkType { get; set; }

        public float AlcoholVolume { get; set; }

        public string Description { get; set; }



    }



}
