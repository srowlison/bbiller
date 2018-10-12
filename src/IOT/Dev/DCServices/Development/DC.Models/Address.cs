using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Math.EC;
using System;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Text.RegularExpressions;

namespace DC.Common.Models
{
    public class Address
    {
        //private const string CURVE_NAME = "secp256k1";

        public Org.BouncyCastle.Math.BigInteger d { get; private set; }
        public String PrivateKeyAsHex { get; private set; }

        public String WifPrivateKey { get; private set; }

        public String BTCAddress { get; private set; }

        public String PublicKeyAsHex { get; private set; }

        public String PublicKeyHash160 { get; private set; }

        public Address(Org.BouncyCastle.Math.BigInteger privateKey)
        {
            this.d = privateKey;
            this.PrivateKeyAsHex = DC.Common.StringHelper.ByteArrayToHexString(d.ToByteArray()).ToLower();
            this.WifPrivateKey = DC.Common.BitcoinHelper.EncodeWif(PrivateKeyAsHex);
            this.PublicKeyAsHex = DC.Common.Security.ConvertPrivateKeyToPublicKeyHexString(d);
            Byte[] publicKey = DC.Common.Security.ConvertPrivateKeyToPublicKeyAsBytes(d);
            this.PublicKeyHash160 = DC.Common.BitcoinHelper.GetHash160(publicKey);
            this.BTCAddress = DC.Common.BitcoinHelper.CreateAddress(publicKey);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="privateKeyAsDecimal"></param>
        public Address(String privateKeyAsDecimal)
        {
            Regex numbersOnly = new Regex("^[0-9]+$");
            if (numbersOnly.IsMatch(privateKeyAsDecimal))
            {
                this.d = new Org.BouncyCastle.Math.BigInteger(privateKeyAsDecimal);
                this.PrivateKeyAsHex = DC.Common.StringHelper.ByteArrayToHexString(d.ToByteArray()).ToLower();
                this.WifPrivateKey = DC.Common.BitcoinHelper.EncodeWif(PrivateKeyAsHex);

                this.PublicKeyAsHex = DC.Common.Security.ConvertPrivateKeyToPublicKeyHexString(d);
                Byte[] publicKey = DC.Common.Security.ConvertPrivateKeyToPublicKeyAsBytes(d);
                this.PublicKeyHash160 = DC.Common.BitcoinHelper.GetHash160(publicKey);
                this.BTCAddress = DC.Common.BitcoinHelper.CreateAddress(publicKey);
            }
            else
            {
                throw new ArgumentException("Private key must be decimal string");
            }
        }

        public override string ToString()
        {
            return String.Format("{0},{1},{2},{3}", BTCAddress, d, WifPrivateKey, PublicKeyAsHex);
        }
    }
}
