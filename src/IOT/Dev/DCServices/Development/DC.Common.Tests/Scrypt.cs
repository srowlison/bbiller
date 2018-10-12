using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DC.Common.Tests
{
    [TestClass]
    public class Scrypt
    {
        [TestMethod]
        public void PubScryptTest()
        {
            //1KKKK6N21XKo48zWKuQKXdvSsCf95ibHFa
            //c8e90996c7c6080ee06284600c684ed904d14c5c
            Byte[] actual = DC.Common.Script.CreateScriptPubKey("c8e90996c7c6080ee06284600c684ed904d14c5c");

            Byte[] expected = new Byte[] {0x76, 0xa9, 0x14, 0xc8, 0xe9, 0x09, 0x96, 0xc7, 0xc6, 0x08, 0x0e, 0xe0, 0x62, 0x84, 0x60, 0x0c, 0x68, 0x4e, 0xd9, 0x04, 0xd1, 0x4c, 0x5c, 0x88, 0xac};
            CollectionAssert.AreEqual(expected, actual);
        }
    }
}
