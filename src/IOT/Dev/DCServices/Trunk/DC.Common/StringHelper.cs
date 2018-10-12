using System;
using System.Globalization;
using System.Numerics;
using System.Text;

namespace DC.Common
{
    public class StringHelper
    {
        private const string ALPHABET = "123456789ABCDEFGHJKLMNPQRSTUVWXYZabcdefghijkmnopqrstuvwxyz";

        [Obsolete("Use base58 class")]
        /// <summary>
        /// https://en.bitcoin.it/wiki/Base58Check_encoding
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static String Base58Encode(Byte[] value)
        {
            String result = String.Empty;
            BigInteger size = ALPHABET.Length;
            BigInteger arrayToInt = 0;

            for (Int32 i = 0; i < value.Length; i++)
            {
                arrayToInt = arrayToInt * 256 + value[i];
            }

            while (arrayToInt > 0)
            {
                Int32 rem = (Int32)(arrayToInt % size);
                arrayToInt /= size;
                result = ALPHABET[rem] + result;
            }

            for (Int32 i = 0; i < value.Length && value[i] == 0; i++)
            {
                result = ALPHABET[0] + result;
            }

            return result;
        }

        public static Byte[] HexStringToByte(String value)
        {
            if (value.Length % 2 != 0)
            {
                throw new ArgumentException();
            }

            Byte[] retArray = new Byte[value.Length / 2];
            for (Int32 i = 0; i < retArray.Length; i++)
            {
                retArray[i] = Byte.Parse(value.Substring(i * 2, 2), NumberStyles.HexNumber, CultureInfo.InvariantCulture);
            }

            return retArray;
        }

        [Obsolete]
        public static string ByteArrayToString(byte[] value)
        {
            StringBuilder hex = new StringBuilder(value.Length * 2);
            foreach (byte b in value)
                hex.AppendFormat("{0:x2}", b);
            return hex.ToString();
        }

        public static String ByteArrayToHexString(byte[] value)
        {
            String hexString = "";
            for (Int32 i = 0; i < value.Length; i++)
            {
                hexString += String.Format("{0:X2}", value[i]);
            }
            return hexString;
        }
    }
}