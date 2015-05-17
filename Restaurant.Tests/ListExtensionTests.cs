using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Restaurant.Common.Extensions;

namespace Restaurant.Tests
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

            Assert.AreEqual(2, items.GetType<string>().ToList().Count);
            Assert.AreEqual(1, items.GetType<int>().ToList().Count);
            Assert.AreEqual(2, items.GetType<float>().ToList().Count);
            Assert.AreEqual(1, items.GetType<double>().ToList().Count);
            Assert.AreEqual(6, items.Count);
        }
    }
}
