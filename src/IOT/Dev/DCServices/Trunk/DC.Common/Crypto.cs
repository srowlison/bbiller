using Org.BouncyCastle.Asn1;
using Org.BouncyCastle.Crypto.Digests;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Crypto.Signers;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DC.Common
{
    public static class Crypto
    {
        public const string CURVE_NAME = "secp256k1";

        private static readonly ThreadLocal<SHA256Managed> _sha256 = new ThreadLocal<SHA256Managed>();
        private static SHA256Managed sha256 { get { return _sha256.IsValueCreated ? _sha256.Value : new SHA256Managed(); } }

        private static readonly ThreadLocal<RIPEMD160Managed> _ripemd160 = new ThreadLocal<RIPEMD160Managed>();

        public static RIPEMD160Managed ripemd160 { get { return _ripemd160.IsValueCreated ? _ripemd160.Value : new RIPEMD160Managed(); } }

        public static byte[] DoubleSHA256(byte[] buffer)
        {
            return sha256.ComputeHash(sha256.ComputeHash(buffer));
        }

        public static byte[] SingleSHA256(byte[] buffer)
        {
            return sha256.ComputeHash(buffer);
        }

        public static byte[] SingleRIPEMD160(byte[] buffer)
        {
            return ripemd160.ComputeHash(buffer);
        }

        public static ECDomainParameters GetDomainParams()
        {
            //CREATE BTC ECURVE
            //http://stackoverflow.com/questions/19665491/how-do-i-get-an-ecdsa-public-key-from-just-a-bitcoin-signature-sec1-4-1-6-k
            Org.BouncyCastle.Asn1.X9.X9ECParameters ecp = Org.BouncyCastle.Asn1.Sec.SecNamedCurves.GetByName(CURVE_NAME);
            ECDomainParameters ecDomainParams = new ECDomainParameters(ecp.Curve, ecp.G, ecp.N, ecp.H);

            return ecDomainParams;
        }

        public static byte[] Sign(byte[] input, Org.BouncyCastle.Math.BigInteger privateKey, ECDomainParameters EcParameters)
        {
            var signer = new ECDsaSigner();
            var privateKeyParameters = new ECPrivateKeyParameters(privateKey, EcParameters);
            signer.Init(true, privateKeyParameters);
            var signatures = signer.GenerateSignature(input);

            // What we get back from the signer are the two components of a signature, r and s. To get a flat byte stream
            // of the type used by BitCoin we have to encode them using DER encoding, which is just a way to pack the two
            // components into a structure.
            using (var byteOutputStream = new MemoryStream())
            {
                var derSequenceGenerator = new DerSequenceGenerator(byteOutputStream);
                derSequenceGenerator.AddObject(new DerInteger(signatures[0]));
                derSequenceGenerator.AddObject(new DerInteger(signatures[1]));
                derSequenceGenerator.Close();
                return byteOutputStream.ToArray();
            }
        }
    }
}
