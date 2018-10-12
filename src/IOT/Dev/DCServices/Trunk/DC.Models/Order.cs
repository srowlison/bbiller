using System;

namespace DC.Common.Models
{
    [Serializable]
    public class Order
    {
        public Guid Id { get; set; }
        [Obsolete]
        public String PrivateKey { get; set; }
        public Byte[] PrivateKeyAsByteArray { get; set; }
        public String PrivateKeyAsBase64 { get; set; }
        public String Address { get; set; }
        public Decimal BTC { get; set; }
        public String Txn { get; set; }
    }
}