using System;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DC.Payment.Fakes;


namespace DC.Payment.Tests
{
    [TestClass]
    public class PaymentTests
    {
        protected static IDisposable _shimContext { get; set; }

        [TestInitialize]
        public void TestInitialize()
        {
            // Create ShimsContext
            _shimContext = ShimsContext.Create();

            // TODO: Additional setup
        }

        [TestCleanup]
        public void TestCleanup()
        {
            _shimContext.Dispose();
            _shimContext = null;
        }

        [TestMethod]
        public void MakeFiatPaymentTest()
        {


            var shimCard = new Fakes.ShimCard();
            shimCard.MakeFiatPaymentStringStringDecimalInt32 = (c, cu, a, t) => true;

            var card = new Card();

            var result = card.MakeFiatPayment("sgf", "sdg", 2.4M, 3);

            Assert.IsTrue(result);

        }

        [TestMethod]
        public void PayForAndBuyBitcoinTest()
        {


            var shimCard = new Fakes.ShimCard();
            shimCard.MakeFiatPaymentStringStringDecimalInt32 = (c, cu, a, t) => true;

            ICard card = new Card();

            var result = card.PayForAndBuyBitcoin("sgf", 3.5M, "sdg", 2.4M, 3);

            Assert.IsTrue(result);

        }
    }
}
