using System;

namespace BitcoinATM.Models
{
    public class Bitcoin : ICrypto
    {
        public Decimal Fiat { get; set; }
        public Decimal Amount { get; set; }
        public String FiatCode { get; private set; }

        public String Pair 
        { 
            get { return String.Format("BTC{0}", this.FiatCode); } 
        }

        public Bitcoin(String fiatCode)
        {
            this.FiatCode = fiatCode;
        }
    }
}
