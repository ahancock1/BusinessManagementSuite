using System.Collections.Generic;
using Com.Framework.Data.Restaurants.Menus;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Com.Framework.Data.Tests.Management.Menu
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
                //MenuItemPortions = new List<MenuItemPortion>
                //{

                //}
            };
        }

        [TestMethod]
        public void MenuItemCostTest()
        {
        }
    }
}
