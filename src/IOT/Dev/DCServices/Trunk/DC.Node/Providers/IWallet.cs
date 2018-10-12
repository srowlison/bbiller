using System;

namespace DC.Node.Providers
{
    public interface IWallet
    {
        decimal GetBalance(string address);
        string Send(string toAddress, decimal amount);
        String SendRawTransaction(String hash);
        String CreateAddress();
    }
}
