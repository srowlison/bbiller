using System;

namespace DC.Node.Providers
{
    public class MockRandom : IRandom, IPassword
    {
        public String CreatePrivateKey(Int32 keySize)
        {
            //In Bitcoin, a private key is a 256-bit number, which can be represented one of several ways. Here is a private key in hexadecimal - 256 bits in hexadecimal is 32 bytes, or 64 characters in the range 0-9 or A-F.
            return "0450863AD64A87AE8A2FE83C1AF1A8403CB53F53E486D8511DAD8A04887E5B23522CD470243453A299FA9E77237716103ABC11A1DF38855ED6F2EE187E9C582BA6";
        }

        public byte[] CreatePassword()
        {
            //ABCDEFGH12345678ABCDEFGH
            //numbers are in hex, so 0x41 = 65, ascii 65 = A
            return new byte[] { 0x41, 0x42, 0x43, 0x44, 0x45, 0x46, 0x47, 0x48, 0x31, 0x32, 0x33, 0x34, 0x35, 0x36, 0x37, 0x38, 0x41, 0x42, 0x43, 0x44, 0x45, 0x46, 0x47, 0x48 };
        }
    }
}