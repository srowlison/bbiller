using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DC.Data;
using DcPayment = DC.Payment;


namespace Portal.Tests
{
    [TestClass]
    public class CardControllerTests
    {
        [TestMethod]
        public void ActivateTest()
        {
            Portal.Controllers.CardController c = new Controllers.CardController();
            //inject value
            c.UserIdentity = "2025";
            
            var card = c.CreateCard("2025");
            c.Activate(card);
            c.DeleteCard(card);

        }

        [TestMethod]
        [Ignore]
        public void GetKeysTest()
        {
            Portal.Controllers.CardController c = new Controllers.CardController();

            var keys = c.GetKeys();

            Assert.IsFalse(string.IsNullOrEmpty(keys.PrivateKey));
            Assert.IsFalse(string.IsNullOrEmpty(keys.PublicKey));
            Assert.IsFalse(string.IsNullOrEmpty(keys.Password));
        }

        [TestMethod]
        public void AddCardTest()
        {
            var ran = new Random();
            var num = ran.Next(999);
            var cardId = "eeeee" + num.ToString();
            var cardSvc = new DcPayment.Card();

            cardSvc.AddCard(cardId, "testpublickey", "testPassword", "testFirstName", "testLastName", "123 First St", "TestCity", "90210", "CA", "Australia", "0789643569", "1/1/1990", "staylor@diamondcircle.net", "testCardHolderName", "1234567890123456", "06", "18", "087");
            var ccDetails = cardSvc.GetCustomerCC(cardId);
            Assert.IsNotNull(ccDetails);
        }
    }
}
