using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestaurantServer.Common;

namespace RestaurantServer.Tests.Common
{
    [TestClass]
    public class ServerTests
    {
        private Server server;

        [TestInitialize]
        public void Initialise()
        {
            server = new Server();
        }
        
        [TestMethod]
        public void StartTest()
        {
            
        }

        [TestMethod]
        public void StopTest()
        {
            
        }


    }
}
