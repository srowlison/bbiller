using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using BigIntegerBouncy = Org.BouncyCastle.Math.BigInteger;

namespace DC.Common
{
    public static class ExtensionMethods
    {
        private static readonly Random random = new Random();

        public static byte[] Concat(this byte[] first, byte[] second)
        {
            var buffer = new byte[first.Length + second.Length];
            Buffer.BlockCopy(first, 0, buffer, 0, first.Length);
            Buffer.BlockCopy(second, 0, buffer, first.Length, second.Length);
            return buffer;
        }

        public static byte[] Concat(this byte[] first, byte second)
        {
            var buffer = new byte[first.Length + 1];
            Buffer.BlockCopy(first, 0, buffer, 0, first.Length);
            buffer[buffer.Length - 1] = second;
            return buffer;
        }

        public static IEnumerable<T> Concat<T>(this IEnumerable<T> first, T second)
        {
            foreach (var item in first)
                yield return item;

            yield return second;
        }

        // ToHexNumberString    prints out hex bytes in reverse order, as they are internally little-endian but big-endian is what people use:
        //                      bytes 0xEE,0xFF would represent what a person would write down as 0xFFEE

        // ToHexNumberData      prints out hex bytes in order

        public static string ToHexNumberString(this byte[] value)
        {
            return string.Format("0x{0}", Bits.ToString(value.Reverse().ToArray()).Replace("-", "").ToLower());
        }

        public static string ToHexNumberString(this IEnumerable<byte> value)
        {
            return ToHexNumberString(value.ToArray());
        }

        public static string ToHexNumberString(this UInt256 value)
        {
            return ToHexNumberString(value.ToByteArray());
        }

        public static string ToHexNumberString(this BigInteger value)
        {
            return ToHexNumberString(value.ToByteArray());
        }

        public static string ToHexNumberString(this BigIntegerBouncy value)
        {
            return value.ToByteArray().Reverse().ToHexNumberString();
        }

        public static string ToHexNumberStringUnsigned(this BigIntegerBouncy value)
        {
            return value.ToByteArrayUnsigned().Reverse().ToHexNumberString();
        }

        public static string ToHexDataString(this byte[] value)
        {
            return string.Format("[{0}]", Bits.ToString(value).Replace("-", ",").ToLower());
        }

        public static string ToHexDataString(this IEnumerable<byte> value)
        {
            return ToHexDataString(value.ToArray());
        }

        public static string ToHexDataString(this UInt256 value)
        {
            return ToHexDataString(value.ToByteArray());
        }

        public static string ToHexDataString(this BigInteger value)
        {
            return ToHexDataString(value.ToByteArray());
        }

        public static string ToHexDataString(this BigIntegerBouncy value)
        {
            return value.ToByteArray().Reverse().ToHexDataString();
        }

        public static string ToHexDataStringUnsigned(this BigIntegerBouncy value)
        {
            return value.ToByteArrayUnsigned().Reverse().ToHexDataString();
        }

        private static readonly DateTime unixEpoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
        public static UInt32 ToUnixTime(this DateTime value)
        {
            return (UInt32)((value - unixEpoch).TotalSeconds);
        }

        public static DateTime UnixTimeToDateTime(this UInt32 value)
        {
            return unixEpoch.AddSeconds(value);
        }

        public static MemoryStream ToMemoryStream(this byte[] bytes)
        {
            return new MemoryStream(bytes);
        }

        public static UInt32 NextUInt32(this Random random)
        {
            // purposefully left unchecked to get full range of UInt32
            return (UInt32)random.Next();
        }

        public static int ToIntChecked(this UInt32 value)
        {
            checked
            {
                return (int)value;
            }
        }

        public static int ToIntChecked(this UInt64 value)
        {
            checked
            {
                return (int)value;
            }
        }
    }
}
