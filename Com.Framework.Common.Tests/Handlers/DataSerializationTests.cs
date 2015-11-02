using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Runtime.Serialization;
using Com.Framework.Common.Serialisation;

namespace Com.Framework.Common.Tests.Serialization
{
    [TestClass]
    public class DataSerializationTests
    {
        [DataContract(Name = "Customer")]
        private class DataContractTestClass
        {
            [DataMember(Name = "Name")]
            public string TestString = "This is a test string";
        }

        [TestMethod]
        public void WriteToFileTestsDataContract()
        {
            Assert.IsTrue(new DataContractTestClass().WriteToFile(".\\Test files\\DataContractTestFile"));

        }
    }
}
