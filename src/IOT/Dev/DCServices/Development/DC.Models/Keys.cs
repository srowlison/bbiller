using System;

namespace DC.Common.Models
{
    public class Keys
    {
        public String PublicKey { get; set; }
        public String PrivateKey { get; set; }
        public Byte[] EncryptedWIFPrivateKey { get; set; }
        public Byte[] Password { get; set; }
    }
}