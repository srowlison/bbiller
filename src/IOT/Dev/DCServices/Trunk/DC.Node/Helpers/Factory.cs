using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Numerics;
using System.Text;
using System.Configuration;
using DC.Node.Providers;
using DC.Common;

namespace DC.Node.Helpers
{
    public class Factory
    {
        public static DC.Providers.IExchange GetExchangeProvider()
        {
            DC.Providers.IExchange provider = new DC.Providers.CoinJar() { ApiKey = ConfigurationManager.AppSettings["coinjar_api_key"] };
            return provider;
        }

        public static Providers.IRandom GetRandomProvider()
        {
            return new Providers.BouncyCastle();
        }

        public static Providers.IPassword GetPasswordProvider()
        {
            return new Providers.BouncyCastle();
        }

        public static Providers.IWallet GetWallet()
        {
            Bitcoind wallet = new Bitcoind(
                   ConfigurationManager.AppSettings["rpc_host"],
                   ConfigurationManager.AppSettings["rpc_user"],
                   ConfigurationManager.AppSettings["rpc_pw"]);
               
            return wallet;
        }

        public static DC.Providers.IAddress GetAddressProvider()
        {
            return new DC.Providers.BlockExplorer();
        }

        public static DC.Providers.ITransaction GetTransactionProvider()
        {
            return new DC.Providers.BlockChainInfo();
        }
    }
}