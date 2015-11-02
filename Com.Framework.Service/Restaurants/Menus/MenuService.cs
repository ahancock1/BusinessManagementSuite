using System.Collections.Generic;
using System.ServiceModel;
using Com.Framework.Data;
using Com.Framework.Data.Restaurants.Menus;

namespace Com.Framework.Service
{
    [ServiceContract]
    public interface IMenuService : IService
    {
        [OperationContract]
        Menu GetMenu(int menuID);

        [OperationContract]
        IEnumerable<Menu> GetMenusByPremise(int premiseID);

        [OperationContract]
        IEnumerable<MenuCategory> GetMenuCategoriesByPremise(int premiseID);

        [OperationContract]
        bool UpdateMenus(Menu[] menus);

        [OperationContract]
        bool UpdateMenuCategories(MenuCategory[] menuCategories);
    }

    public class MenuService : BaseService, IMenuService
    {
        public Menu GetMenu(int menuID)
        {
            return Service.Get<Menu>(m => m.MenuID == menuID,
                m => m.Hours, m => m.MenuCategories);
        }

        public IEnumerable<Menu> GetMenusByPremise(int premiseID)
        {
            return Service.All<Menu>(m => m.PremiseID == premiseID,
                m => m.Hours, m => m.MenuCategories);
        }

        public IEnumerable<MenuCategory> GetMenuCategoriesByPremise(int premiseID)
        {
            return Service.Get<Premise>(p => p.PremiseID == premiseID, m => m.MenuCategories).MenuCategories;
        }

        public bool UpdateMenus(Menu[] menus)
        {
            return Service.Update(menus);
        }

        public bool UpdateMenuCategories(MenuCategory[] menuCategories)
        {
            return Service.Update(menuCategories);
        }
    }
}
