using System;

namespace DC.Providers
{
    public interface IAddress
    {
        decimal GetBalance(string bitcoinAddress, short confirmations = 6);

        String GetHash160(String address);
    }
}
