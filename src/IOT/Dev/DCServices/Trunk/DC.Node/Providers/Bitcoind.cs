using BitcoinRpcSharp;
using Org.BouncyCastle.Asn1;
using Org.BouncyCastle.Asn1.Sec;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Crypto.Signers;
using System;
using System.IO;

namespace DC.Node.Providers
{
    public class Bitcoind : IWallet
    {
        private BitcoinWallet _wallet;

        public Bitcoind(String host, String user, String password)
        {
            _wallet = new BitcoinWallet(host, user, password, true);
        }

        public Decimal GetBalance(String account)
        {
            return _wallet.GetBalance(account);
        }

        public String Send(String toAddress, Decimal amount)
        {
            String txn = _wallet.SendToAddress(toAddress, amount, "From diamond circle", "From diamond circle");
            return txn;
        }

        public String SendRawTransaction(String hash)
        {
            // Sent the signed transaction
            String txn = _wallet.SendRawTransaction(hash);
            return txn;
        }


        public string CreateAddress()
        {
            return _wallet.GetNewAddress();
        }
    }
}