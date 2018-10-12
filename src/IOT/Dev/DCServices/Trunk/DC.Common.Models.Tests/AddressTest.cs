using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DC.Common.Models.Tests
{
    [TestClass]
    public class AddressTest
    {
        [TestMethod]
        public void CreateAddressTest()
        {
            //values came form brainwallet.org.  use that to confirm
            const String PRIVATE_KEY_AS_DEC2 = "56264673822963068407370790525340191907437491654303176136090258467429147271236";
            const String SOURCE_ADDRESS_2 = "1GKMJp7NGBv9a8eY8nuK31yXgoe6e8DDAz";
            const String PRIVATE_KEY_AS_HEX2 = "7c64ad461b06168990ea5902eb2e054b3a1324be28d7335f05ab7cebca7ce044";
            const String WIF_2 = "5Jm53JsNg72iix4PdChqyxvDuQXMfGuMsALY98VdeQWCsDikxYn";

            DC.Common.Models.Address source = new DC.Common.Models.Address(PRIVATE_KEY_AS_DEC2);

            Assert.IsTrue(source.BTCAddress == SOURCE_ADDRESS_2);
            Assert.IsTrue(source.PrivateKeyAsHex == PRIVATE_KEY_AS_HEX2);
            Assert.IsTrue(source.WifPrivateKey == WIF_2);
        }
    }
}
