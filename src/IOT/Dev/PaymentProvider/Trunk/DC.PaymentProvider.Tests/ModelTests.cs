using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DC.PaymentProvider.Tests
{
    [TestClass]
    public class ModelTests
    {
        [TestMethod]    
        public void ClientInfoToStringTest()
        {
            DC.PaymentProvider.DTO.WalPay.ClientInfo model = new DTO.WalPay.ClientInfo();

            model.AccountNumber = "1234";

            String actual = model.ToString();
            String expected = "<ClientInfo><AccountNumber>hr385645</AccountNumber><Name>Bob</Name><Surname>Smith</Surname><Address>17 Main Street</Address><City>New York</City><State>NY</State><Zip>10348</Zip><Country>US</Country><Telephone>2122101938</Telephone><Email>bob.smith@test.com</Email><DOB>1986-08-12</DOB><ClientIP>215.45.81.1</ClientIP></ClientInfo>";

            Assert.AreSame(actual, expected);
        }

        //String.Format("", this.PAN, this.ExpiryDate);
        [TestMethod]
        public void PaymentInfoToStringTest()
        {
            DC.PaymentProvider.DTO.WalPay.PaymentInfo model = new DTO.WalPay.PaymentInfo();
            model.PAN = "123";
            model.ExpiryDate = new DateTime(2016, 7, 1);
            String actual = model.ToString();
            String expected = "<PaymentInfo><PAN>123</PAN><ExpiryDate>2016-07</ExpiryDate><CardHolderName>B Smith</CardHolderName><CVC2>123</CVC2><StartDate/><IssueNumber/></PaymentInfo>";
           
            Assert.AreEqual(actual, expected);
        }
    }
}
