using System;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Generators;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Security;
using Org.BouncyCastle.Crypto.Signers;
using Org.BouncyCastle.Asn1.Sec;
using System.IO;
using Org.BouncyCastle.Asn1;
using System.Security;
using DC.Common;

namespace DC.Node.Providers
{
    public class BouncyCastle : IRandom, IPassword
    {
        /// <summary>
        /// Returns private key to create btc address, as per the documentation
        /// </summary>
        /// <returns></returns>
        public String CreatePrivateKey(Int32 keySize = 256)
        {
            AsymmetricCipherKeyPair key = GenerateKeys(keySize);

            //http://www.elanant.com/2010/01/using-bouncycastle-net-library-for.html
            //var publicKey = (ECPublicKeyParameters)(key.Public);
            var privateKey = (ECPrivateKeyParameters)(key.Private);

            //Org.BouncyCastle.Math.BigInteger x = publicKey.Q.X.ToBigInteger();
            //Org.BouncyCastle.Math.BigInteger y = publicKey.Q.Y.ToBigInteger();
            Org.BouncyCastle.Math.BigInteger d = privateKey.D;

            //use get encoded
            return StringHelper.ByteArrayToHexString(d.ToByteArray());

            //SecureString secureKey = new SecureString();
            //if (key.Length > 0)
            //{
            //    foreach (var c in strPassword.ToCharArray()) secureStr.AppendChar(c);
            //}
        }

        private static AsymmetricCipherKeyPair GenerateKeys(int keySize)
        {
            ECKeyPairGenerator gen = new ECKeyPairGenerator();
            SecureRandom secureRandom = new SecureRandom();
            KeyGenerationParameters keyGenParam = new KeyGenerationParameters(secureRandom, keySize);
            gen.Init(keyGenParam);
            return gen.GenerateKeyPair();
        }

        public byte[] CreatePassword()
        {
            SecureRandom random = new SecureRandom();
            Byte[] keyBytes = new Byte[16];
            random.NextBytes(keyBytes);
            return keyBytes;
        }

        /// <summary>
        /// Calculates an ECDSA signature in DER format for the given input hash. Note that the input is expected to be
        /// 32 bytes long.
        /// </summary>
        public byte[] Sign(byte[] input, Org.BouncyCastle.Math.BigInteger privateKey)
        {
            const string BITCOIN_CURVE = "secp256k1";
            ECDsaSigner signer = new ECDsaSigner();
            Org.BouncyCastle.Asn1.X9.X9ECParameters ecp = SecNamedCurves.GetByName(BITCOIN_CURVE);
            ECDomainParameters EcParameters = new ECDomainParameters(ecp.Curve, ecp.G, ecp.N, ecp.H);

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

        /// <summary>
        /// These constants are a part of a scriptSig signature on the inputs. They define the details of how a
        /// transaction can be redeemed, specifically, they control how the hash of the transaction is calculated.
        /// </summary>
        /// <remarks>
        /// In the official client, this enum also has another flag, SIGHASH_ANYONECANPAY. In this implementation,
        /// that's kept separate. Only SIGHASH_ALL is actually used in the official client today. The other flags
        /// exist to allow for distributed contracts.
        /// </remarks>
        public enum SigHash
        {
            All, // 1
            None, // 2
            Single, // 3
        }

        public const int OpPushData1 = 76;
        public const int OpPushData2 = 77;
        public const int OpPushData4 = 78;
        public const int OpDup = 118;
        public const int OpHash160 = 169;
        public const int OpEqualVerify = 136;
        public const int OpCheckSig = 172;
    }
}