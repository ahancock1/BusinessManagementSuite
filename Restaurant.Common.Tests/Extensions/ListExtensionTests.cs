using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Restaurant.Common.Extensions;

namespace Restaurant.Common.Tests.Extensions
{
    [TestClass]
    public class ListExtensionTests
    {
        [TestMethod]
        public void GetTypeTest()
        {
            List<object> items = new List<object>
            {
                "test",
                0,
                4f,
                4.0,
                5f,
                "test2"
            };

            Assert.AreEqual(2, items.GetTypes<string>().ToList().Count);
            Assert.AreEqual(1, items.GetTypes<int>().ToList().Count);
            Assert.AreEqual(2, items.GetTypes<float>().ToList().Count);
            Assert.AreEqual(1, items.GetTypes<double>().ToList().Count);
            Assert.AreEqual(6, items.Count);
        }
    }
}
