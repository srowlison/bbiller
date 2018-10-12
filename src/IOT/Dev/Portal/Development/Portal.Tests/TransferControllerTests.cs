using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DC.Data;
using System.Web.Mvc;

namespace Portal.Tests
{
    [TestClass]
    public class TransferControllerTests
    {
        [TestMethod]
        public void CardsListTest()
        {
            Portal.Controllers.TransferController c = new Controllers.TransferController();
            //inject value

            var cards = c.GetCustomerCards("2025");

            var result = cards.Count;

            Assert.IsTrue(result > 0);
        }

    }
}
