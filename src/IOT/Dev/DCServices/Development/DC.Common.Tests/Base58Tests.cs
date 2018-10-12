using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DC.Common.Tests
{
    [TestClass]
    public class Base58Tests
    {
        //https://en.bitcoin.it/wiki/Base58Check_encoding
        [TestMethod]
        public void DecodeToIntTest()
        {
            Org.BouncyCastle.Math.BigInteger actual = Base58.DecodeToBigInteger("h");
            Assert.IsTrue(actual.ToString() == "40");
        }

        //https://en.bitcoin.it/wiki/Base58Check_encoding
        [TestMethod]
        public void DecodeToIntTest2()
        {
            Org.BouncyCastle.Math.BigInteger actual = Base58.DecodeToBigInteger("6e31iZ");
            Assert.IsTrue(actual.ToString() == "3700886826");
        }

        [TestMethod]
        [Ignore]
        public void DecodeToIntTest3()
        {
            Byte[] actual = Base58.Decode("5KJvsngHeMpm884wtkJNzQGaCErckhHJBGFsvd3VyK5qMZXj3hS");
            Assert.IsTrue(actual.ToString() == "64039562443405445021834385063894439756182707384881530984731033533981978373339621888055009");
        }
    }
}
