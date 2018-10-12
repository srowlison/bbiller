using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DC.Providers.Tests
{
    [TestClass]
    public class BlockExplorerTest
    {
        [TestMethod]
        public void GetBalanceTest()
        {
            IAddress provider = new BlockExplorer();
            Decimal actual = provider.GetBalance("1CbHR646cj6jMKMav1VR66aW2NXuBFag4b", 6);

            Assert.AreEqual(actual, 0);
        }
    }
}
