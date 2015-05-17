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
    public class Menu : ItemList
    {
        public int MenuID { get; set; }
        
        [Required]
        public DateTime Created { get; set; }

        public string Season { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public MenuType MenuType { get; set; }


        public Menu()
        {
            Season = String.Empty;
        }
    }
}
