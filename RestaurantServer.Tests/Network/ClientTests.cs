using System;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestaurantServer.Data.Network;

namespace RestaurantServer.Tests.Network
{
    [TestClass]
    public class ClientTests : Listener
    {
//        ManualResetEvent testResetEvent = new ManualResetEvent(false);
//
//        const string HostName = "localhost";
//        const int Port = 7777;
//
//        readonly Server server = new Server(Port);
//        private Client client;
//
//        [TestInitialize]
//        public void Init()
//        {
//            new Thread(server.Start).Start();
//           
//            client = new Client { Listener = this, Name = "TestClient"};
//        }
//
//        [TestMethod]
//        public void ConnectTest()
//        {
//            client.Connect(HostName, Port);
//
//            Assert.AreEqual(true, client.Connected);
//        }
//
//        [TestMethod]
//        public void SendPacketTest()
//        {
//            client.Connect(HostName, Port);
//
//            client.Send(new NetPing { PingID = 0 });
//            
//            testResetEvent.WaitOne();
//        }
//
//        [TestCleanup]
//        public void Cleanup()
//        {
//            client.Close();
//            server.Stop();
//        }
//
//        public override void Received(Connection connection, object o)
//        {
//            if (o is INetMessage)
//            {
//                if (o is NetPing)
//                {
//                    NetPing ping = (NetPing) o;
//                    if (ping.IsReply)
//                    {
//                        Assert.AreEqual(0, ping.PingID);
//                        testResetEvent.Set();
//                    }
//                }
//            }
//
//        }
    }
}
