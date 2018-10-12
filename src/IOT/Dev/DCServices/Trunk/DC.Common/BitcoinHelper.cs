using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Math.EC;

namespace DC.Common
{
    public class BitcoinHelper
    {
        public static Boolean IsValidAddress(String bitcoinAddress)
        {
            Regex validAddress = new Regex("^[13][1-9A-Za-z][^OIl]{20,40}");
            return validAddress.IsMatch(bitcoinAddress);
        }

        public static String GetHash160(Byte[] publicKey)
        {
            Byte[] PublicKeySha = Crypto.SingleSHA256(publicKey);
            Byte[] PubKeyShaRIPE = Crypto.SingleRIPEMD160(PublicKeySha);

            return StringHelper.ByteArrayToHexString(PubKeyShaRIPE);
        }

        [Obsolete("Use encode")]
        /// <summary>
        /// Create a wallet import format of the ECSDA private key
        /// </summary>
        /// <param name="key">Private key as HEX, normally an ECSDA private key</param>
        /// <returns></returns>
        public static String CreateWif(String privateKeyAsHex)
        {
            if (DC.Common.Math.IsHexNumber(privateKeyAsHex))
            {
                //Step 2
                privateKeyAsHex = String.Concat("80", privateKeyAsHex);
                Byte[] Key = DC.Common.StringHelper.HexStringToByte(privateKeyAsHex);

                //Step 3 & 4
                Byte[] DoubleKeySha = Crypto.DoubleSHA256(Key);
                //test = ByteArrayToHexString(DoubleKeySha);

                //Step 5
                Byte[] Checksum = new Byte[4];
                Array.Copy(DoubleKeySha, Checksum, 4);
                //test = ByteArrayToHexString(Checksum);

                Byte[] Final = new Byte[Key.Length + 4];
                Array.Copy(Key, Final, Key.Length);
                //test = ByteArrayToHexString(Final);

                Array.Copy(Checksum, 0, Final, Key.Length, 4);
                //test = ByteArrayToHexString(Final);

                String wif = DC.Common.StringHelper.Base58Encode(Final);
                return wif;
            }
            else
            {
                throw new ArgumentException("Hex characters only");
            }
        }

        /// <summary>
        /// Create a wallet import format of the ECSDA private key
        /// </summary>
        /// <param name="key">Private key as HEX, normally an ECSDA private key</param>
        /// <returns></returns>
        public static String EncodeWif(String privateKeyAsHex)
        {
            if (DC.Common.Math.IsHexNumber(privateKeyAsHex))
            {
                //Step 2
                privateKeyAsHex = String.Concat("80", privateKeyAsHex);
                Byte[] Key = DC.Common.StringHelper.HexStringToByte(privateKeyAsHex);

                //Step 3 & 4
                Byte[] DoubleKeySha = Crypto.DoubleSHA256(Key);
                //test = ByteArrayToHexString(DoubleKeySha);

                //Step 5
                Byte[] Checksum = new Byte[4];
                Array.Copy(DoubleKeySha, Checksum, 4);
                //test = ByteArrayToHexString(Checksum);

                Byte[] Final = new Byte[Key.Length + 4];
                Array.Copy(Key, Final, Key.Length);
                //test = ByteArrayToHexString(Final);

                Array.Copy(Checksum, 0, Final, Key.Length, 4);
                //test = ByteArrayToHexString(Final);

                String wif = DC.Common.StringHelper.Base58Encode(Final);
                return wif;
            }
            else
            {
                throw new ArgumentException("Hex characters only");
            }
        }


        public static Org.BouncyCastle.Math.BigInteger DecodeWif(String wif)
        {
            //check range as governed by the ec curve

            Byte[] privateKeyTemp = DC.Common.Base58.Decode(wif);
            Byte[] privateKey = new Byte[privateKeyTemp.Length - 5];

            if (privateKeyTemp[0] == 128) //80 in decimal
            {
                Array.Copy(privateKeyTemp, 1, privateKey, 0, privateKeyTemp.Length - 5);
            }

            Org.BouncyCastle.Math.BigInteger key = new Org.BouncyCastle.Math.BigInteger(privateKey);
            return key;

            //Step 2
            //privateKeyAsHex = String.Concat("80", privateKeyAsHex);
            //Byte[] Key = DC.Common.StringHelper.HexStringToByte(privateKeyAsHex);

            ////Step 3 & 4
            //Byte[] DoubleKeySha = Crypto.DoubleSHA256(Key);
            ////test = ByteArrayToHexString(DoubleKeySha);

            ////Step 5
            //Byte[] Checksum = new Byte[4];
            //Array.Copy(DoubleKeySha, Checksum, 4);
            ////test = ByteArrayToHexString(Checksum);

            //Byte[] Final = new Byte[Key.Length + 4];
            //Array.Copy(Key, Final, Key.Length);
            ////test = ByteArrayToHexString(Final);

            //Array.Copy(Checksum, 0, Final, Key.Length, 4);
            ////test = ByteArrayToHexString(Final);

            //String wif = DC.Common.StringHelper.Base58Encode(Final);
            //return wif;
        }

        public static String CreateAddress(Byte[] publicKey)
        {
            //https://en.bitcoin.it/wiki/Technical_background_of_Bitcoin_addresses

            //1 - Take the corresponding public key generated with it (65 bytes, 1 byte 0x04, 32 bytes corresponding to X coordinate, 32 bytes corresponding to Y coordinate) 
            //"18E14A7B6A307F426A94F8114701E7C8E774E7F9A47E2C2035DB29A206321725";
            //String HexHash = "0450863AD64A87AE8A2FE83C1AF1A8403CB53F53E486D8511DAD8A04887E5B23522CD470243453A299FA9E77237716103ABC11A1DF38855ED6F2EE187E9C582BA6";  

            Byte[] PublicKeySha = Crypto.SingleSHA256(publicKey);
            Byte[] PubKeyShaRIPE = Crypto.SingleRIPEMD160(PublicKeySha);
            byte[] PreHashWNetwork = AppendBitcoinNetwork(PubKeyShaRIPE, 0);
            //byte[] PublicHash = Crypto.SingleSHA256();
            byte[] PublicHashHash = Crypto.DoubleSHA256(PreHashWNetwork);

            Byte[] First4 = new Byte[4];
            Array.Copy(PublicHashHash, First4, 4);

            Byte[] Address = new Byte[PreHashWNetwork.Length + 4];
            PreHashWNetwork.CopyTo(Address, 0);
            First4.CopyTo(Address, PreHashWNetwork.Length);

            String address = DC.Common.StringHelper.Base58Encode(Address);

            return address;
        }

        private static byte[] AppendBitcoinNetwork(Byte[] ripeHash, Byte network)
        {
            Byte[] extended = new byte[ripeHash.Length + 1];
            extended[0] = (byte)network;
            Array.Copy(ripeHash, 0, extended, 1, ripeHash.Length);
            return extended;
        }

        ///// <summary>
        ///// Create the bitcoin ECSDA public key from private key
        ///// </summary>
        ///// <param name="d"></param>
        ///// <returns></returns>
        //public static String ConvertPrivateKeyToPublicKeyHexString(Org.BouncyCastle.Math.BigInteger d)
        //{
        //    byte[] output = ConvertPrivateKeyToPublicKey(d);

        //    //Console.WriteLine("Result x " + result.X.ToBigInteger());
        //    //Console.WriteLine("Result y " + result.Y.ToBigInteger());

        //    String publicKeyHexString = StringHelper.ByteArrayToHexString(output);
        //    return publicKeyHexString;
        //}

        ///// <summary>
        ///// Create the bitcoin ECSDA public key from private key
        ///// </summary>
        ///// <param name="d"></param>
        ///// <returns></returns>
        //public static Byte[] ConvertPrivateKeyToPublicKey(Org.BouncyCastle.Math.BigInteger d)
        //{
        //    //Bitcoin public private key uses this named curve
        //    Org.BouncyCastle.Asn1.X9.X9ECParameters ecp = Org.BouncyCastle.Asn1.Sec.SecNamedCurves.GetByName(DC.Common.Crypto.CURVE_NAME);
        //    ECDomainParameters ecDomainParams = new ECDomainParameters(ecp.Curve, ecp.G, ecp.N, ecp.H);

        //    ECPoint point = ecp.G.Multiply(d);
        //    return point.GetEncoded();
        //}
    }
}
