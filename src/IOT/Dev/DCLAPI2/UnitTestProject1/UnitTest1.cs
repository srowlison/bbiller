using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DCAPI;


namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var atm = new DCAPI.ATM.AtmClient();
            DCAPI.Card.CardClient card = new DCAPI.Card.CardClient();
            DCAPI.Exchange.ExchangeClient exchange = new DCAPI.Exchange.ExchangeClient();

            atm.GetBalance("dhadfhkgf", 6);








            
        }
    }
}
