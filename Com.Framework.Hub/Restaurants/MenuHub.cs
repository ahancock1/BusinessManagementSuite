using System;
using System.Collections.Generic;
using Com.Framework.Data.Restaurants.Menus;

namespace Com.Framework.Hubs.Restaurants
{
    public interface IMenuHub
    {
        Menu GetMenu(int menuID);

        IEnumerable<Menu> GetMenusByPremise(int premiseID);

        bool UpdateMenus(string name, params Menu[] menus);

        MenuItem GetMenuItem(int menuItemID);

        IEnumerable<MenuItem> GetMenuItemsByPremise(int premiseID);

        IEnumerable<MenuItem> GetMenuItemsByCategory(int menuItemCategoryID);

        bool UpdateMenuItems(string name, params MenuItem[] menuItems);
    }

    public interface IMenuContract
    {
        void UpdateMenus(params Menu[] menus);

        void UpdateMenuItems(params MenuItem[] menuItems);
    }

    public class MenuHub : ServiceHub<IMenuContract>, IMenuHub
    {
        public Menu GetMenu(int menuID)
        {
            return Service.Get<Menu>(m => m.MenuID == menuID);
        }

        public IEnumerable<Menu> GetMenusByPremise(int premiseID)
        {
            return Service.All<Menu>(m => m.PremiseID == premiseID);
        }

        public bool UpdateMenus(string name, params Menu[] menus)
        {
            if (menus.Length == 0) return false;

            Clients.Group(name).UpdateMenus(menus);

            return Service.Update(menus);
        }

        public MenuItem GetMenuItem(int menuItemID)
        {
            return Service.Get<MenuItem>(m => m.MenuItemID == menuItemID,
                m => m.Image, m => m.MenuItemDetails);
        }

        public IEnumerable<MenuItem> GetMenuItemsByPremise(int premiseID)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<MenuItem> GetMenuItemsByCategory(int menuItemCategoryID)
        {
            throw new NotImplementedException();
        }

        public bool UpdateMenuItems(string name, params MenuItem[] menuItems)
        {
            if (menuItems.Length == 0) return false;

            Clients.Group(name).UpdateMenuItems(menuItems);

            return Service.Update(menuItems);
        }

    }
}
