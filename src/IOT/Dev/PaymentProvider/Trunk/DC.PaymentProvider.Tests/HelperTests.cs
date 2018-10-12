using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DC.PaymentProvider.Tests
{
    [TestClass]
    public class HelperTests
    {
        [TestMethod]
        public void ClientInfoObjectToXMLTest()
        {
            Helper<DTO.WalPay.ClientInfo> helper = new Helper<DTO.WalPay.ClientInfo>();

            DTO.WalPay.ClientInfo model = new DTO.WalPay.ClientInfo();
            model.Surname = "Cullen";

            System.Xml.XmlDocument result = helper.Serialize(model);

            Assert.Inconclusive();
        }

        [TestMethod]
        public void PaymentInfoObjectToXMLTest()
        {
            Helper<DTO.WalPay.PaymentInfo> helper = new Helper<DTO.WalPay.PaymentInfo>();

            DTO.WalPay.PaymentInfo model = new DTO.WalPay.PaymentInfo();
            model.PAN = "123";

            System.Xml.XmlDocument result = helper.Serialize(model);

            Assert.Inconclusive();
        }

        [TestMethod]
        public void MerchantRequestObjectToXMLTest()
        {
            Helper<DTO.WalPay.MerchantRequest> helper = new Helper<DTO.WalPay.MerchantRequest>();

            DTO.WalPay.MerchantRequest model = new DTO.WalPay.MerchantRequest();
            model.MerchantInfo = new DTO.WalPay.DiamondCircleEuro();

            System.Xml.XmlDocument result = helper.Serialize(model);

            Assert.Inconclusive();
        }
    }
}