using Microsoft.VisualStudio.TestTools.UnitTesting;
using Restaurant.Common.Handlers;
using System.Runtime.Serialization;

namespace Restaurant.Common.Tests.Handlers  
{
    [TestClass]
    public class DataSerializationTests
    {
        [DataContract(Name = "Customer")]
        private class DataContractTestClass
        {
            [DataMember(Name = "Name")] public string TestString = "This is a test string";
        }

        [TestMethod]
        public void WriteToFileTestsDataContract()
        {
            Assert.IsTrue(new DataContractTestClass().WriteToFile(".\\Test files\\DataContractTestFile"));

        }
    }
}
