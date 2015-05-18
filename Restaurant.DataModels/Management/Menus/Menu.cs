using System.Collections.Generic;
using System.Linq;

namespace Restaurant.DataModels.Management.Menus
{
    public class Menu
    {
        public int MenuID { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public List<MenuItem> Items { get; set; }

        public MenuType MenuType { get; set; }


        public IList<T> GetItems<T>()
        {
            return Items.Where(i => i.GetType() == typeof (T)).Cast<T>().ToList();
        } 
    }
}
