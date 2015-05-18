using System.Collections.Generic;

namespace Restaurant.DataModels.Management.Menus
{
    public class MenuType
    {
        public int MenuTypeID { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Menu> Menus { get; set; } 
    }
}