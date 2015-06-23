using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Restaurant.Data.Management.Menus;

namespace Restaurant.DataModels.Tests.Management.Menu
{
    [TestClass]
    public class MenuItemTest
    {
        private MenuItem menuItem;

        [TestInitialize]
        public void Init()
        {
            menuItem = new MenuItem
            {
                MenuItemPortions = new List<MenuItemPortion>
                {
                    
                }
            };
        }

        [TestMethod]
        public void MenuItemCostTest()
        {
        }
    }
}
