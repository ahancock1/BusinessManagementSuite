using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace Restaurant.Data
{
    [Serializable]
    public class ItemType : Entity
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

    [Serializable]
    public abstract class Item : Entity
    {
        public int ItemID { get; set; }

        [Required(ErrorMessage = "Price is required")]
        [Range(0.0, 999.99, ErrorMessage = "Price must be between 0 and 999.99")]
        public float Cost { get; set; }

        [Required(ErrorMessage = "An Item Name is required")]
        [StringLength(160)]
        public string Name { get; set; }

        [Required]
        public string Code { get; set; }

        public int Quantity { get; set; }

        public DateTime LastUpdted { get; set; }

        public virtual ItemType ItemType { get; set; }

        public virtual ICollection<Menu> Menus { get; set; }

        public virtual ICollection<Ticket> Tickets { get; set; } 
        

        public Item()
        {
            LastUpdted = DateTime.Now;
            Name = String.Empty;
            Code = String.Empty;
        }
    }

    [Serializable]
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

    [Serializable]
    public class DrinkItem : Item
    {
        public DrinkType DrinkType { get; set; }

        public float AlcoholVolume { get; set; }

        public string Description { get; set; }


        public DrinkItem()
        {
        }

        public bool IsAlcoholic
        {
            get { return Math.Abs(AlcoholVolume) <= 0; }
        }
    }

    [Serializable]
    public class FoodItem : Item
    {


        public virtual ICollection<Menu> Menus { get; set; }

        public FoodItem()
        {
            
        }
    }
}
