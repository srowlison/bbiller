using System;

namespace DCPOS

{
    interface INFC
    {
        bool ConnectReader();
        string hextotext(string strHex);
        bool InitReader();
        bool ReadBlocks(string blockid, string blocksize, ref string blockdata);
        bool readPrivateKey(ref string PrivateKey);
        bool readPublicKey(ref string PublicKey);
        bool ReadTagID(ref string TagId);
        bool WriteNFCTag(string publicuri, string encryptedprivatekey);

        
    }
}


