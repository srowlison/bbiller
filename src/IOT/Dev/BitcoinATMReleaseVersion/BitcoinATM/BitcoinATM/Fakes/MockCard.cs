using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitcoinATM.Fakes
{
    public class MockCard
    {
        public String CardId { get { return "7e41201e"; } }

        public String EncryptedPrivateKey { get { return "K4ChanJIxe7JsZq/eu5VFIxVYN82lr7ub/EpWCLEImtW+MUasJP+uAxz9CPnE1WvFSUTnF4OkrMOGYMQ1p2PjA=="; } }

        public String PublicKey { get { return "1D45JxNkyhCyxC7LFwA6hwH2ssLkZhExij"; } }
    }
}
