using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitcoinATM.Fakes
{
    public class MockNFC : INFC
    {
        private Fakes.MockCard card = new MockCard();

        public bool ConnectReader()
        {
            return true;
        }

        public string hextotext(string strHex)
        {
            throw new NotImplementedException();
        }

        public bool InitReader()
        {
            return true;
        }

        public bool ReadBlocks(string blockid, string blocksize, ref string blockdata)
        {
            throw new NotImplementedException();
        }

        public bool readPrivateKey(ref string PrivateKey)
        {
            PrivateKey = card.EncryptedPrivateKey;
            return true;
        }

        public bool readPublicKey(ref string PublicKey)
        {
            PublicKey = card.PublicKey;
            return true;
        }

        public bool ReadTagID(ref string TagId)
        {
            TagId = card.CardId;
            return true;
        }

        public bool WriteNFCTag(string publicuri, string encryptedprivatekey)
        {
            return true;
        }
    }
}
