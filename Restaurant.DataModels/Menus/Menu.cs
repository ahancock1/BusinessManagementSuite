using System.Collections.Generic;

namespace Restaurant.DataModels.Menus
{
    public class Menu
    {
        public int MenuID { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public List<MenuItem> Items { get; set; }

        public MenuType MenuType { get; set; }

    }


    public class MenuItem: Item
    {
        public int MenuItemID { get; set; }

        public Item Item { get; set; }

        public virtual ICollection<Menu> Menus { get; set; } 
    }



    public class MenuType
    {
        public int MenuTypeID { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Menu> Menus { get; set; } 
    }
}
