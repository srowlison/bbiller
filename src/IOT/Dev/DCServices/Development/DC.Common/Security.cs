using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Math.EC;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Web;

namespace DC.Common
{
    public class Security
    {
        public const string CURVENAME = "secp256k1";

        /// <summary>
        /// Create the bitcoin ECSDA public key from private key
        /// </summary>
        /// <param name="d"></param>
        /// <returns></returns>
        public static String ConvertPrivateKeyToPublicKeyHexString(Org.BouncyCastle.Math.BigInteger d)
        {
            //Bitcoin public private key uses this named curve
            Org.BouncyCastle.Asn1.X9.X9ECParameters ecp = Org.BouncyCastle.Asn1.Sec.SecNamedCurves.GetByName(CURVENAME);
            ECDomainParameters ecDomainParams = new ECDomainParameters(ecp.Curve, ecp.G, ecp.N, ecp.H);

            ECPoint point = ecp.G.Multiply(d);
            byte[] output = point.GetEncoded();

            //Console.WriteLine("Result x " + result.X.ToBigInteger());
            //Console.WriteLine("Result y " + result.Y.ToBigInteger());

            String publicKeyHexString = StringHelper.ByteArrayToHexString(output);
            return publicKeyHexString;
        }

        /// <summary>
        /// Create the bitcoin ECSDA public key from private key
        /// </summary>
        /// <param name="d"></param>
        /// <returns></returns>
        public static Byte[] ConvertPrivateKeyToPublicKeyAsBytes(Org.BouncyCastle.Math.BigInteger d)
        {
            //Bitcoin public private key uses this named curve
            Org.BouncyCastle.Asn1.X9.X9ECParameters ecp = Org.BouncyCastle.Asn1.Sec.SecNamedCurves.GetByName(CURVENAME);
            ECDomainParameters ecDomainParams = new ECDomainParameters(ecp.Curve, ecp.G, ecp.N, ecp.H);

            ECPoint point = ecp.G.Multiply(d);
            return point.GetEncoded();
        }

        /// <summary>
        /// Create the bitcoin ECSDA public key from private key
        /// </summary>
        /// <param name="privateKey">Hexadecimal private key</param>
        /// <returns></returns>
        public static String ConvertPrivateKeyToPublicKey(String privateKey)
        {
            Byte[] key = StringHelper.HexStringToByte(privateKey);
            Org.BouncyCastle.Math.BigInteger d = new Org.BouncyCastle.Math.BigInteger(1, key);
            return ConvertPrivateKeyToPublicKeyHexString(d);
        }

        public static byte[] EncryptStringToBytes_Aes(string plainText, byte[] Key, byte[] IV, CipherMode mode = CipherMode.ECB)
        {
            // Check arguments. 
            if (plainText == null || plainText.Length <= 0)
                throw new ArgumentNullException("plainText");
            if (Key == null || Key.Length <= 0)
                throw new ArgumentNullException("Key");
            //if (IV == null || IV.Length <= 0)
            //    throw new ArgumentNullException("IV");
            byte[] encrypted;
            // Create an AesCryptoServiceProvider object 
            // with the specified key and IV. 
            using (AesCryptoServiceProvider aesAlg = new AesCryptoServiceProvider())
            {
                aesAlg.Key = Key;

                if (mode == CipherMode.CBC)
                {
                    aesAlg.IV = IV;
                }

                aesAlg.Mode = mode;

                // Create a decrytor to perform the stream transform.
                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                // Create the streams used for encryption. 
                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {

                            //Write all data to the stream.
                            swEncrypt.Write(plainText);
                        }
                        encrypted = msEncrypt.ToArray();
                    }
                }
            }

            // Return the encrypted bytes from the memory stream. 
            return encrypted;
        }

        public static string DecryptStringFromBytes_Aes(byte[] cipherText, byte[] Key)
        {
            // Check arguments. 
            if (cipherText == null || cipherText.Length <= 0)
                throw new ArgumentNullException("cipherText");
            if (Key == null || Key.Length <= 0)
                throw new ArgumentNullException("Key");
            //dont use, use ecb codebook
            //if (IV == null || IV.Length <= 0)
            //    throw new ArgumentNullException("IV");

            // Declare the string used to hold 
            // the decrypted text. 
            string plaintext = null;

            // Create an AesCryptoServiceProvider object 
            // with the specified key and IV. 
            using (AesCryptoServiceProvider aesAlg = new AesCryptoServiceProvider())
            {
                aesAlg.Key = Key;
                //aesAlg.IV = IV;
                aesAlg.Mode = CipherMode.ECB;

                // Create a decrytor to perform the stream transform.
                ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

                // Create the streams used for decryption. 
                using (MemoryStream msDecrypt = new MemoryStream(cipherText))
                {
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                        {

                            // Read the decrypted bytes from the decrypting stream 
                            // and place them in a string.
                            plaintext = srDecrypt.ReadToEnd();
                        }
                    }
                }

            }

            return plaintext;

        }
    }
}