using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitcoinATM.Fakes
{
    public class MockCard
    {
        public String CardId { get { return "1e204488"; } }

        public String EncryptedPrivateKey { get { return "g8PVJAWTgoNkozYZceqld7CwI7iFZmCFfdy7lbdyCeygZLsV9/BE7JRZ8fTNGsro74hnSTzlBuXX868a/UXURQ=="; } }

        public String PublicKey { get { return "1NUmfRN9LF7SyrSCnoAURsxYsVzkBfwGKG"; } }
    }
}
