using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Restaurant.DataModels.Management.Menus;

namespace Restaurant.Tests.DataModelsTests.ManagementTests.MenuTests
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
