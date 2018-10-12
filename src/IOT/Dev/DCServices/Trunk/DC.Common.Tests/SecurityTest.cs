using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DC.Common.Tests
{
    [TestClass]
    public class SecurityTest
    {
        [TestMethod]
        public void EncryptTest()
        {
            //You can verify this method at aes.online-domain-tools.com
            //ABCDEFGH12345678ABCDEFGH
            //numbers are in hex, so 0x41 = 65, ascii 65 = A
            Byte[] key = new byte[] { 0x41, 0x42, 0x43, 0x44, 0x45, 0x46, 0x47, 0x48, 0x31, 0x32, 0x33, 0x34, 0x35, 0x36, 0x37, 0x38, 0x41, 0x42, 0x43, 0x44, 0x45, 0x46, 0x47, 0x48 };
            Byte[] encrypted = Security.EncryptStringToBytes_Aes("Dugong", key, null, System.Security.Cryptography.CipherMode.ECB);

            //32, d2, 3f, 31, ca, 30, a2, 0b, 3c, 7d, d5, 0e, f1, 30, 4d, 9a
            Assert.IsTrue(encrypted[0] == 50); //32 in hex
            Assert.IsTrue(encrypted[1] == 210); //d2 in hex
        }

        [TestMethod]
        public void Encrypt_Private_Key_Test()
        {
            //You can verify this method at aes.online-domain-tools.com
            //ABCDEFGH12345678ABCDEFGH
            //numbers are in hex, so 0x41 = 65, ascii 65 = A
            Byte[] key = new byte[] { 0x41, 0x42, 0x43, 0x44, 0x45, 0x46, 0x47, 0x48, 0x31, 0x32, 0x33, 0x34, 0x35, 0x36, 0x37, 0x38, 0x41, 0x42, 0x43, 0x44, 0x45, 0x46, 0x47, 0x48 };
            Byte[] encrypted = Security.EncryptStringToBytes_Aes("5KJvsngHeMpm884wtkJNzQGaCErckhHJBGFsvd3VyK5qMZXj3hS", key, null, System.Security.Cryptography.CipherMode.ECB);

            //ed 66 13 54 c8 4a 0c 35 86 da 08 8d dc b2 cb 63 
            Assert.IsTrue(encrypted[0] == 237); //ed
        }

        //[TestMethod]
        //public void Encrypt_Private_Key_With_Random_Key_Test()
        //{
        //    //You can verify this method at aes.online-domain-tools.com
        //    dcweb.Providers.BouncyCastle provider = new Providers.BouncyCastle();
        //    Byte[] key = provider.CreatePassword();

        //    Byte[] encrypted = Security.EncryptStringToBytes_Aes("5KJvsngHeMpm884wtkJNzQGaCErckhHJBGFsvd3VyK5qMZXj3hS", key, null, System.Security.Cryptography.CipherMode.ECB);

        //    //32, d2, 3f, 31, ca, 30, a2, 0b, 3c, 7d, d5, 0e, f1, 30, 4d, 9a
        //    Assert.AreEqual(64, encrypted.Length);
        //}

        [TestMethod]
        public void DecryptTest()
        {
            //You can verify this method at aes.online-domain-tools.com
            //ABCDEFGH12345678ABCDEFGH
            //numbers are in hex, so 0x41 = 65, ascii 65 = A
            Byte[] key = new byte[] { 0x41, 0x42, 0x43, 0x44, 0x45, 0x46, 0x47, 0x48, 0x31, 0x32, 0x33, 0x34, 0x35, 0x36, 0x37, 0x38, 0x41, 0x42, 0x43, 0x44, 0x45, 0x46, 0x47, 0x48 };
            Byte[] encrypted = new byte[] { 0x32, 0xd2, 0x3f, 0x31, 0xca, 0x30, 0xa2, 0x0b, 0x3c, 0x7d, 0xd5, 0x0e, 0xf1, 0x30, 0x4d, 0x9a };

            String cipher = Security.DecryptStringFromBytes_Aes(encrypted, key);
            Assert.IsTrue(cipher == "Dugong");
        }

        [TestMethod]
        public void DecryptBase64Test()
        {
            Byte[] encryptedPrivateKeyAsBytes = Convert.FromBase64String("Rf9UVCHicH+w/QJfoqoE0K9HPy5tbdkjA5SEh4be+X5l6ei8Y334tX9DUewk5ktTLjs9ZlQMSuuF9Whez228AQ==");
            Byte[] password = Convert.FromBase64String("kC3c8tO+mVOKhr6QnOXXmA==");
            String wif = DC.Common.Security.DecryptStringFromBytes_Aes(encryptedPrivateKeyAsBytes, password);

            Assert.IsNotNull(wif);

            String publicKey = "1LCidC7e3w5TwcEqaCNDhp2NV9eHtfti3W";

            //todo, convert wif back to public key and assert on above address
        }

        [TestMethod]
        public void ConvertPrivateKeyToPublicKeyTest()
        {
            //https://en.bitcoin.it/wiki/Technical_background_of_version_1_Bitcoin_addresses
            String publicKey = Security.ConvertPrivateKeyToPublicKey("18E14A7B6A307F426A94F8114701E7C8E774E7F9A47E2C2035DB29A206321725");
            Assert.AreEqual(publicKey, "0450863AD64A87AE8A2FE83C1AF1A8403CB53F53E486D8511DAD8A04887E5B23522CD470243453A299FA9E77237716103ABC11A1DF38855ED6F2EE187E9C582BA6");
        }
    }
}
