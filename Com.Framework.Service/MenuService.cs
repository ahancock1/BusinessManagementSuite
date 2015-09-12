using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Com.Framework.Data.Restaurants.Menus;
using Com.Framework.DataAccess.Services;

namespace Com.Framework.Service
{
    public interface IMenuService
    {
        IList<Menu> GetMenus(int restaurantID);

        IList<MenuCategory> GetMenuCategories(int menuID);

        IList<MenuItem> GetMenuItems(int restaurantID);

        bool AddMenu(params Menu[] menus);

        bool AddMenuCategory(params MenuCategory[] menuCategories);

        bool AddMenuItem(params MenuItem[] menuItems);
    }

    public class MenuService : IMenuService
    {

        private readonly IGenericService service = new GenericService();


        public IList<Menu> GetMenus(int restaurantID)
        {
            //            service.Get<Menu>(m => m.Restaurant.Where(r => r.RestaurantID == restaurantID), m => m.MenuCategories, m)
            throw new NotImplementedException();
        }

        public IList<MenuCategory> GetMenuCategories(int menuID)
        {
            throw new NotImplementedException();
        }

        public IList<MenuItem> GetMenuItems(int restaurantID)
        {
            throw new NotImplementedException();
        }

        public bool AddMenu(params Menu[] menus)
        {
            throw new NotImplementedException();
        }

        public bool AddMenuCategory(params MenuCategory[] menuCategories)
        {
            throw new NotImplementedException();
        }

        public bool AddMenuItem(params MenuItem[] menuItems)
        {
            throw new NotImplementedException();
        }
    }
}
