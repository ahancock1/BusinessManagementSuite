using System;
using Com.Framework.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Com.Framwork.DataAccess.Tests
{
    public class TestItem : Entity
    {
    }

    [TestClass]
    public class EntityStateTests
    {
        [TestMethod]
        public void EntityStateUnchangedTest()
        {
            TestItem item = new TestItem
            {
                EntityState = EntityState.Unchanged
            };

            Assert.AreEqual(2, (int)item.EntityState);
            Assert.AreNotEqual(EntityState.Modified, item.EntityState);
            Assert.AreEqual(EntityState.Unchanged, item.EntityState);
        }

        [TestMethod]
        public void EntityStateAddedTest()
        {
            TestItem item = new TestItem
            {
                EntityState = EntityState.Added
            };

            Assert.AreEqual(1, (int)item.EntityState);
            Assert.AreEqual(EntityState.Added, item.EntityState);
        }

        [TestMethod]
        public void EntityStateModifiedTest()
        {
            TestItem item = new TestItem
            {
                EntityState = EntityState.Modified
            };

            Assert.AreEqual(0, (int)item.EntityState);
            Assert.AreEqual(EntityState.Modified, item.EntityState);
            Assert.AreNotEqual(EntityState.Unchanged, item.EntityState);
        }

        [TestMethod]
        public void EntityStateDeletedTest()
        {
            TestItem item = new TestItem
            {
                EntityState = EntityState.Deleted
            };

            Assert.AreEqual(-1, (int)item.EntityState);
            Assert.AreEqual(EntityState.Deleted, item.EntityState);
        }
    }
}
