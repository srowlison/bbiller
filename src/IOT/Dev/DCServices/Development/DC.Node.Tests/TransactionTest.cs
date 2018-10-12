using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dcweb.Tests
{
    [TestClass]
    [Ignore]
    public class TransactionTest
    {
        [TestMethod]
        public void TransactionConstructorTest()
        {
            IList<DC.Common.Models.UnspentOutput> outputsToSpend = new List<DC.Common.Models.UnspentOutput>();
            outputsToSpend.Add(new DC.Common.Models.UnspentOutput() { Value = 10000 });
            outputsToSpend.Add(new DC.Common.Models.UnspentOutput() { Value = 20000 });

            const String PRIVATE_KEY_AS_DEC2 = "56264673822963068407370790525340191907437491654303176136090258467429147271236";
            DC.Common.Models.Address source = new DC.Common.Models.Address(PRIVATE_KEY_AS_DEC2);
            DC.Node.Helpers.Transaction t = new DC.Node.Helpers.Transaction(outputsToSpend, source, "1DugongACGcyyvvgvcy8skYyezsx5jy3aV", "fakehash", 0.001M, 0.0001M);

            //CHANGE SHOULD BE 8000
            //Assert.AreEqual(t.Change, null);
            Assert.Inconclusive();
        }
    }
}
