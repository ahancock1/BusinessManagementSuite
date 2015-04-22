using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace RestaurantServer.Tests.Network
{
    [TestClass]
    public class ServerTests
    {
        [TestMethod]
        public void ServerTest()
        {
            RestaurantServer server = new RestaurantServer(80001);
            server.Start();
            
            Assert.AreEqual(true, server.Running);
        }
    }
}
