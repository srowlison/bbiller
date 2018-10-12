using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DC.Common.Tests
{
    [TestClass]
    public class MathTest
    {
        [TestMethod]
        public void GetValueAsHexBytesTest()
        {
            Byte[] actual = DC.Common.Math.GetValueAsBytes(0.00091234M);
            //Byte[] actual = ConsoleApplication1.Program.GetValueAsBytes(0.0001);

            Byte[] expected = new Byte[8] { 0x62, 0x64, 0x01, 0x00, 0x00, 0x00, 0x00, 0x00 };
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void IsHexNumberTest()
        {
            Boolean actual = DC.Common.Math.IsHexNumber("abd123");
            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void IsNotHexNumberTest()
        {
            Boolean actual = DC.Common.Math.IsHexNumber("fgd123");
            Assert.IsFalse(actual);
        }

        [TestMethod]
        public void SathosihTest()
        {
            Decimal actual = 0.00000001M;
            Decimal expected = 1;

            Assert.AreEqual(expected, actual * DC.Common.Math.SATOSHI);
        }
    }
}
