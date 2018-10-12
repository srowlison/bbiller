using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DC.Common.Tests
{
    [TestClass]
    public class BitcoinHelperTests
    {
        [TestMethod]
        public void IsValidAddressTest()
        {
            String address = "1ygyJfeRLHjuxpk3vJFHb5eNjCeLF9iwV";
            Boolean actual = DC.Common.BitcoinHelper.IsValidAddress(address);

            Assert.IsTrue(actual == true);
        }

        [TestMethod()]
        public void EncodeWifTest()
        {
            //https://en.bitcoin.it/wiki/Wallet_import_format
            string HexHash = "0C28FCA386C7A227600B2FE50B7CAE11EC86D3BF1FBE471BE89827E19D72AA1D";
            string expected = "5HueCGU8rMjxEXxiPuD5BDku4MkFqeZyd4dZ1jvhTVqvbTLvyTJ";
            string actual;
            actual = DC.Common.BitcoinHelper.EncodeWif(HexHash);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for CreateAddress
        ///</summary>
        [TestMethod()]
        public void CreateAddressTest()
        {
            //https://en.bitcoin.it/wiki/Technical_background_of_version_1_Bitcoin_addresses
            string HexHash = "0450863AD64A87AE8A2FE83C1AF1A8403CB53F53E486D8511DAD8A04887E5B23522CD470243453A299FA9E77237716103ABC11A1DF38855ED6F2EE187E9C582BA6";
            string expected = "16UwLL9Risc3QfPqBUvKofHmBQ7wMtjvM";
            Byte[] publicKey = StringHelper.HexStringToByte(HexHash);
            string actual;
            actual = DC.Common.BitcoinHelper.CreateAddress(publicKey);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void MakeAddressFromBase58PrivateKey()
        {
            //value from brainwallet
            //String wifPrivateKey = "5KYZdUEo39z3FPrtuX2QbbwGnNP5zTd7yyr2SC1j299sBCnWjss";
            string wifPrivateKey = "5HueCGU8rMjxEXxiPuD5BDku4MkFqeZyd4dZ1jvhTVqvbTLvyTJ"; //from wiki
            //Org.BouncyCastle.Math.BigInteger key = Base58.DecodeToBigInteger(wifPrivateKey);

            byte[] key = Base58.Decode(wifPrivateKey);

            String privateKeyAsHex = StringHelper.ByteArrayToHexString(key);
            Assert.AreEqual("800C28FCA386C7A227600B2FE50B7CAE11EC86D3BF1FBE471BE89827E19D72AA1D507A5B8D", privateKeyAsHex);
            //800C28FCA386C7A227600B2FE50B7CAE11EC86D3BF1FBE471BE89827E19D72AA1D507A5B8D

            privateKeyAsHex = privateKeyAsHex.Substring(0, privateKeyAsHex.Length - 8);
            Assert.AreEqual("800C28FCA386C7A227600B2FE50B7CAE11EC86D3BF1FBE471BE89827E19D72AA1D", privateKeyAsHex);

            privateKeyAsHex = privateKeyAsHex.Substring(2);
            Assert.AreEqual("0C28FCA386C7A227600B2FE50B7CAE11EC86D3BF1FBE471BE89827E19D72AA1D", privateKeyAsHex);

            String publicKey = DC.Common.Security.ConvertPrivateKeyToPublicKey(privateKeyAsHex);

            Assert.AreEqual(publicKey.ToLower(), "04d0de0aaeaefad02b8bdc8a01a1b8b11c696bd3d66a2c5f10780d95b7df42645cd85228a6fb29940e858e7e55842ae2bd115d1ed7cc0e82d934e929c97648cb0a");

            Byte[] pKey = DC.Common.StringHelper.HexStringToByte(publicKey);
            String acutal = DC.Common.BitcoinHelper.CreateAddress(pKey);
            String expected = "1GAehh7TsJAHuUAeKZcXf5CnwuGuGgyX2S";

            Assert.AreEqual(expected, acutal);
        }

        [TestMethod]
        public void DecodeWifTest()
        {
            //https://en.bitcoin.it/wiki/Wallet_import_format
            Org.BouncyCastle.Math.BigInteger actual = BitcoinHelper.DecodeWif("5HueCGU8rMjxEXxiPuD5BDku4MkFqeZyd4dZ1jvhTVqvbTLvyTJ");
            //Assert.IsTrue(actual.ToString() == "0C28FCA386C7A227600B2FE50B7CAE11EC86D3BF1FBE471BE89827E19D72AA1D");
            Assert.IsTrue(actual.ToString() == "5500171714335001507730457227127633683517613019341760098818554179534751705629");
        }
    }
}
