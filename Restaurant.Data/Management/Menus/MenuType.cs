using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Restaurant.Data.Management.Menus
{
    [Serializable]
    public class MenuType : Entity
    {
        public int MenuTypeID { get; set; }

        [Required]
        public string Name { get; set; }

        public virtual ICollection<Menu> Menus { get; set; } 
    }
}