using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DC.Common.Models.Tests
{
    [TestClass]
    public class UnspentOutput
    {
        [TestMethod]
        public void Index_1_AsByteTest()
        {
            Models.UnspentOutput o = new Models.UnspentOutput();
            o.TxOutputN = 1;

            Assert.AreEqual(4, o.OutputIndexAsBytes.Length);
            Assert.AreEqual(1, o.OutputIndexAsBytes[0]);
            Assert.AreEqual(0, o.OutputIndexAsBytes[1]);
            Assert.AreEqual(0, o.OutputIndexAsBytes[2]);
            Assert.AreEqual(0, o.OutputIndexAsBytes[3]);
        }

        [TestMethod]
        public void Index_16_AsByteTest()
        {
            Models.UnspentOutput o = new Models.UnspentOutput();
            o.TxOutputN = 16;

            Assert.AreEqual(4, o.OutputIndexAsBytes.Length);
            Assert.AreEqual(16, o.OutputIndexAsBytes[0]);
            Assert.AreEqual(0, o.OutputIndexAsBytes[1]);
            Assert.AreEqual(0, o.OutputIndexAsBytes[2]);
            Assert.AreEqual(0, o.OutputIndexAsBytes[3]);
        }

        [TestMethod]
        [Ignore]
        public void Index_17_AsByteTest()
        {
            Models.UnspentOutput o = new Models.UnspentOutput();
            o.TxOutputN = 17;

            Assert.AreEqual(4, o.OutputIndexAsBytes.Length);
            Assert.AreEqual(17, o.OutputIndexAsBytes[0]);
            Assert.AreEqual(0, o.OutputIndexAsBytes[1]);
            Assert.AreEqual(0, o.OutputIndexAsBytes[2]);
            Assert.AreEqual(0, o.OutputIndexAsBytes[3]);
        }
    }
}
