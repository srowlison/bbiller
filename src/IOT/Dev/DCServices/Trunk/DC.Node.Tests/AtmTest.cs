using DC.Common.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DcPayment = DC.Payment;

namespace DC.Node.Tests
{
    [TestClass()]
    public class AtmTest
    {
        [TestMethod()]
        [Ignore()]
        public void SignAndTransferTest()
        {
            //7c64ad461b06168990ea5902eb2e054b3a1324be28d7335f05ab7cebca7ce044 key in hex
            //1GKMJp7NGBv9a8eY8nuK31yXgoe6e8DDAz

            //1GKMJp7NGBv9a8eY8nuK31yXgoe6e8DDAz
            //5Jm53JsNg72iix4PdChqyxvDuQXMfGuMsALY98VdeQWCsDikxYn
            const String PRIVATE_KEY_AS_DEC2 = "56264673822963068407370790525340191907437491654303176136090258467429147271236";
            DC.Node.atm atm = new atm();
            //String txn = atm.SignAndTransfer(PRIVATE_KEY_AS_DEC2, "1DugongACGcyyvvgvcy8skYyezsx5jy3aV", 0.0005046M);

            //Assert.IsFalse(String.IsNullOrEmpty(txn));
        }

        [TestMethod()]
        //[Ignore()]
        public void SignAndTransfer_DoubleSpend_Test()
        {
            //04a479d39cabab4454d98c410306188bda9ce494452b98eacd6f1c726269b544 key in hex
            //1Mc1ABCVr4A8duDiQGnRjKTgJnPiB64pH4

            const String PRIVATE_KEY_AS_DEC2 = "2099855129312767045997633640821152469995996877318518352763986073205651125572";
            DC.Node.atm atm = new atm();

            //1hwFSZuJZ9ZeLJV3nD9smCaZjBseTTaCM
            //String txn = atm.SignAndTransfer(PRIVATE_KEY_AS_DEC2, "1HioFY2SXF2uhuvrxRPhCdfZrXhjfCu9XL", 0.0999M);
            //String txn = atm.SignAndTransfer(PRIVATE_KEY_AS_DEC2, "1C3QzD1QYAr33qKQGKwe38d5yA6PcTveyy", 0.0999M);

            //Assert.IsFalse(String.IsNullOrEmpty(txn));
        }

        [TestMethod()]
        public void CreatePublicEncryptedPrivateKeyTest()
        {
            DC.Node.atm atm = new atm();
            Common.Models.Keys actual = atm.CreatePublicEncryptedPrivateKey();
            Assert.IsNotNull(actual);

            Byte[] password = actual.Password;
            Byte[] cipher = Convert.FromBase64String(actual.PrivateKey);
            String privateKey = DC.Common.Security.DecryptStringFromBytes_Aes(cipher, password);

            Assert.IsTrue(privateKey.StartsWith("5") || privateKey.StartsWith("K"));

            //use brainwallet.org to verify private key yeilds public key
            //1As4KMx5U2GSve2FbcaenoL2sj4VxFGfTw
            //5J5dwHGRbwHgryR4DZ862tjeRwhrNCCwNT1Fct6HqgkCp5hCGzW
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

        [TestMethod]
        public void AddCardRemoteTest()
        {
            var ran = new Random();
            var num = ran.Next(999);
            var cardId = "eeeee" + num.ToString();
            var cardSvc = new dcweb.Tests.CardTest.CardClient();


            cardSvc.AddCard(cardId, "testpublickey", "testPassword", "testFirstName", "testLastName", "123 First St", "TestCity", "90210", "CA", "Australia", "0789643569", "1/1/1990", "staylor@diamondcircle.net", "testCardHolderName", "1234567890123456", "06", "18", "087");
            var ccDetails = cardSvc.GetCustomerCC(cardId);
            Assert.IsNotNull(ccDetails);
        }

        [TestMethod]
        public void SendCoinTest()
        {
            var atmsvc = new Node.atm();
            // This code passed.
            var order = atmsvc.CreateOrder("1MR8RpE2v2yq6ZS6s9x79HTrxdzZZumt3B", 0.01M);




            Assert.IsNotNull(order);
        }


        [TestMethod]
        public void SendBitcoinsCoinTest()
        {
            var atmsvc = new Node.atm();
            //var atmsvc = new dcweb.Tests.NodeTest.AtmClient();
            var result = atmsvc.SendBitcoins("xe6LdFKXUaZpOy3cbX8Bh8gFMwWQSTMKhoO9mcFdcBz2CA4Wy2I2Y3uEJ480Onwed5uTUZJBibzOvrVEvPkFJw==", "hh67+bZBgWY/4MFEBGgs9Q==", "1DA8Jp3GmdmEJirRQoCu28wMMpEHk9cmbr", 0.0001M);
            Assert.IsTrue(result.Length > 0);
        }

        [TestMethod]
        public void GetBalanceTest()
        {
            var atmsvc = new Node.atm();
            var result = atmsvc.GetBalance("1D45JxNkyhCyxC7LFwA6hwH2ssLkZhExij");
            Assert.AreEqual(result, 0.001M);
        }

        [TestMethod]
        public void ResolvePrivateKeyTest()
        {
            var atmsvc = new Node.atm();

            var result = atmsvc.ResolvePrivateKey("xe6LdFKXUaZpOy3cbX8Bh8gFMwWQSTMKhoO9mcFdcBz2CA4Wy2I2Y3uEJ480Onwed5uTUZJBibzOvrVEvPkFJw==", "hh67+bZBgWY/4MFEBGgs9Q==");
            //var result = atmsvc.ResolvePrivateKey("DoYNH6IrB72s5fJqNM280mQ4zs2HNQkz5vMk9tTIo40hLpCYhXucRfovAQbDEmmMs+XhZRsmkzCyyxFUzeszXg==", "hh67+bZBgWY/4MFEBGgs9Q==");

            Assert.AreEqual("1MR8RpE2v2yq6ZS6s9x79HTrxdzZZumt3B", result);
        }

        [TestMethod]
        public void GetConfirmationsTest()
        {
            var atmsvc = new Node.atm();
            bool result = false;

            if (atmsvc.GetConfirmations("1MR8RpE2v2yq6ZS6s9x79HTrxdzZZumt3B") > 0)
            {
                result = true;
            }

            Assert.IsTrue(result);
        }



        [TestMethod]
        public void SendCoinRemoteTest()
        {
            var atmsvc = new dcweb.Tests.NodeTest.AtmClient();
            // This code fails when called.  
            var order = atmsvc.CreateOrder("1DfquucVVRpZWLpYBAZnCisQVfdJSkZxqU", 0.001M);




            Assert.IsNotNull(order);
        }

        
    }
}
