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
        Menu GetMenu(int id);

        [OperationContract]
        IEnumerable<Menu> GetMenusByPremise(int id);

        [OperationContract]
        IEnumerable<MenuCategory> GetMenuCategoriesByPremise(int id);

        [OperationContract]
        bool UpdateMenus(Menu[] menus);

        [OperationContract]
        bool UpdateMenuCategories(MenuCategory[] menuCategories);
    }

    public class MenuService : BaseService, IMenuService
    {
        public Menu GetMenu(int id)
        {
            return Service.Get<Menu>(m => m.Id == id,
                m => m.Hours, m => m.MenuCategories);
        }

        public IEnumerable<Menu> GetMenusByPremise(int id)
        {
            return Service.All<Menu>(m => m.PremiseID == id,
                m => m.Hours, m => m.MenuCategories);
        }

        public IEnumerable<MenuCategory> GetMenuCategoriesByPremise(int id)
        {
            return Service.Get<Premise>(p => p.Id == id, m => m.MenuCategories).MenuCategories;
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
