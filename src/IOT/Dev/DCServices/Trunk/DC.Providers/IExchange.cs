using System;

namespace DC.Providers
{
    public interface IExchange
    {
        Decimal GetSpotPrice(Decimal value, String currencyCode);
    }
}
