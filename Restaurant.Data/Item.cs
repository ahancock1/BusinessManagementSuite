using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Restaurant.DataModels
{
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
        
        public virtual ItemType ItemType { get; set; }

        public virtual ICollection<MenuItem> MenuItems { get; set; } 

        
        public Item()
        {
            Name = String.Empty;
        }
    }
}