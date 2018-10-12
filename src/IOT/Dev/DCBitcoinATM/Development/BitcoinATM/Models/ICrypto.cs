using System;

namespace BitcoinATM.Models
{
    public interface ICrypto
    {
        decimal Amount { get; set; }
        decimal Fiat { get; set; }
        string Pair { get; }
        String FiatCode { get; }
    }
}
