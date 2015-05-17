using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Restaurant.Data
{
    [Serializable]
    public class MenuType : Entity
    {
        public int MenuTypeID { get; set; }

        [Required]
        public string Name { get; set; }

        public virtual ICollection<Menu> Menus { get; set; }
        

        public MenuType()
        {
            Name = String.Empty;
        }
    }

    [Serializable]
    public class Menu : Entity
    {
        public int MenuID { get; set; }
        
        [Required]
        public DateTime Created { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string Title { get; set; }

        public List<Item> Items { get; set; }
        
        [Required]
        public DateTime Start { get; set; }

        [Required]
        public DateTime Finish { get; set; }
        
        [Required]
        public virtual MenuType MenuType { get; set; }

        public virtual SeasonType SeasonType { get; set; }


        public Menu()
        {
            Description = String.Empty;
            Title = String.Empty;
        }
    }

    [Serializable]
    public class SeasonType : Entity
    {
        public int SeasonTypeID { get; set; }

        [Required]
        public string Name { get; set; }

        public virtual ICollection<Menu> Menu { get; set; }

        public SeasonType()
        {
        }
    }

    [Serializable]
    public class MenuItem : Item
    {
        public int MenuItemID { get; set; }
        
        public int Quantity { get; set; }

        public string Description { get; set; }

        public virtual Item Item { get; set; }

        public MenuItem()
        {
            
        }

        public bool IsAvailable
        {
            get { return Quantity > 0; }
        }
    }
}
