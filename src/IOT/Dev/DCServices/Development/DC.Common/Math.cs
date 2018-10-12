using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DC.Common
{
    public class Math
    {
        public const Int64 SATOSHI = 100000000;

        public static Byte[] GetValueAsBytes(Decimal value)
        {
            value = value * SATOSHI;
            String valueAsString = value.ToString("0");

            Org.BouncyCastle.Math.BigInteger v = new Org.BouncyCastle.Math.BigInteger(valueAsString);

            Byte[] x = new Byte[8];
            Byte[] y = v.ToByteArray();
            Array.Reverse(y);
            Array.Copy(y, x, y.Length);

            //string forDebug = v.ToHexNumberString();
            return x;
        }

        public static Byte[] GetValueAsBytes(Int64 value)
        {
            String valueAsString = value.ToString("0");

            Org.BouncyCastle.Math.BigInteger v = new Org.BouncyCastle.Math.BigInteger(valueAsString);

            Byte[] x = new Byte[8];
            Byte[] y = v.ToByteArray();
            Array.Reverse(y);
            Array.Copy(y, x, y.Length);

            string forDebug = v.ToHexNumberString();
            return x;
        }

        public static Boolean IsHexNumber(String input)
        {
            Regex hexOnly = new Regex("^[0-9A-F]+$");
            return hexOnly.IsMatch(input.ToUpper());
        }

        public static Boolean IsDecimalNumber(String input)
        {
            Regex numbersOnly = new Regex("^[0-9]+$");
            return numbersOnly.IsMatch(input.ToUpper());
        }
    }
}
