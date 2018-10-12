using System;
using System.Collections.Generic;
using System.Security.Cryptography;

namespace DC.Node.Providers
{
    public class ElipticCurve : IRandom
    {
        public string CreatePrivateKey(Int32 keySize)
        {
            byte[] publicKey;

            using (ECDiffieHellmanCng provider = new ECDiffieHellmanCng(keySize))
            {
                provider.KeyDerivationFunction = ECDiffieHellmanKeyDerivationFunction.Hash;
                provider.HashAlgorithm = CngAlgorithm.Sha256;
                publicKey = provider.PublicKey.ToByteArray();

                String hex = "";
                for (Int32 i = 0; i < publicKey.Length; i++)
                {
                    hex += String.Format("{0:X}", publicKey[i]);
                }

                return hex;
            }
        }
    }
}