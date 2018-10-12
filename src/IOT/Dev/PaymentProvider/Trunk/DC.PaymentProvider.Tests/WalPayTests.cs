using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DC.PaymentProvider.Tests
{
    [TestClass]
    public class WalPayTests
    {
        [TestMethod]
        public void ProcessTest()
        {
            WalPayIntegration walpay = new WalPayIntegration();
            DTO.WalPay.MerchantRequest merchant = new DTO.WalPay.MerchantRequest();

            merchant.PaymentInfo = new DTO.WalPay.PaymentInfo();
            merchant.TransactionInfo = new DTO.WalPay.TransactionInfo();

            walpay.Request = merchant;

            walpay.Process();
        }
    }
}
