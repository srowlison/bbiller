using Org.BouncyCastle.Math;
using System.Text;
using System;

namespace DC.Common
{
    public class Base58
    {
        private static readonly string ALPHABET = "123456789ABCDEFGHJKLMNPQRSTUVWXYZabcdefghijkmnopqrstuvwxyz";
        private static readonly BigInteger Base = BigInteger.ValueOf(58);

        /// <exception cref="AddressFormatException" />
        public static byte[] Decode(string input)
        {
            var bytes = DecodeToBigInteger(input).ToByteArray();
            // We may have got one more byte than we wanted, if the high bit of the next-to-last byte was not zero. This
            // is because BigIntegers are represented with twos-compliment notation, thus if the high bit of the last
            // byte happens to be 1 another 8 zero bits will be added to ensure the number parses as positive. Detect
            // that case here and chop it off.
            var stripSignByte = bytes.Length > 1 && bytes[0] == 0 && bytes[1] >= 0x80;
            // Count the leading zeros, if any.
            var leadingZeros = 0;
            for (var i = 0; input[i] == ALPHABET[0]; i++)
            {
                leadingZeros++;
            }
            // Now cut/pad correctly. Java 6 has a convenience for this, but Android can't use it.
            var temp = new byte[bytes.Length - (stripSignByte ? 1 : 0) + leadingZeros];
            Array.Copy(bytes, stripSignByte ? 1 : 0, temp, leadingZeros, temp.Length - leadingZeros);
            return temp;
        }

        /// <exception cref="AddressFormatException" />
        public static BigInteger DecodeToBigInteger(string input)
        {
            var bigInteger = BigInteger.ValueOf(0);
            // Work backwards through the string.
            for (var i = input.Length - 1; i >= 0; i--)
            {
                var alphaIndex = ALPHABET.IndexOf(input[i]);
                if (alphaIndex == -1)
                {
                    throw new ArgumentException("Illegal character " + input[i] + " at " + i);
                }
                bigInteger = bigInteger.Add(BigInteger.ValueOf(alphaIndex).Multiply(Base.Pow(input.Length - 1 - i)));
            }
            return bigInteger;
        }
    }
}