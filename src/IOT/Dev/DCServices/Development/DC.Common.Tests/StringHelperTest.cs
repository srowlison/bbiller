using DC.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting.Web;

namespace DC.Common.Test
{
    
    
    /// <summary>
    ///This is a test class for StringHelperTest and is intended
    ///to contain all StringHelperTest Unit Tests
    ///</summary>
    [TestClass()]
    public class StringHelperTest
    {


        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        /// <summary>
        ///A test for HexStringToByte
        ///</summary>
        [TestMethod()]
        public void HexStringToByteTest()
        {
            string value = "0450863A";
            byte[] expected = new byte[4] { 4, 80, 134, 58 };
            byte[] actual;
            actual = StringHelper.HexStringToByte(value);
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void ByteArrayToStringTest()
        {
            string expected = "0450863a";
            byte[] value = new byte[4] { 4, 80, 134, 58 };
            String actual;
            actual = StringHelper.ByteArrayToString(value);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void ByteArrayToHexStringTest()
        {
            string expected = "0450863A";
            byte[] value = new byte[4] { 4, 80, 134, 58 };
            String actual;
            actual = StringHelper.ByteArrayToHexString(value);
            Assert.AreEqual(expected, actual);
        }
    }
}
