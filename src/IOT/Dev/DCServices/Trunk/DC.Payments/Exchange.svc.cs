using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace DC.Payment
{
    public class Exchange : IExchange
    {
        public Decimal GetSpotPrice(String currencyCode, Decimal amount, Int32 terminalId)
        {
            if (amount > 0)
            {
                currencyCode = currencyCode.ToUpper();

                String apiKey = System.Configuration.ConfigurationManager.AppSettings["coinjar_api_key"];
                DC.Providers.IExchange provider = new Providers.CoinJar() { ApiKey = apiKey };
                return provider.GetSpotPrice(amount, currencyCode);
            }
            else
            {
                throw new ArgumentOutOfRangeException("Value must be greater than zero.");
            }
        }

        public Common.Models.Margin GetMargin(string currencyCode, Int32 terminalId)
        {
            currencyCode = currencyCode.ToUpper();
            String apiKey = System.Configuration.ConfigurationManager.AppSettings["coinjar_api_key"];
            DC.Providers.IExchange provider = new Providers.CoinJar() { ApiKey = apiKey };

            Decimal spot = provider.GetSpotPrice(1.0M, currencyCode);

            return new Common.Models.Margin()
            {
                Buy = spot * 1.075M,
                Sell = spot * 0.925M,
                Rate = spot,
            };
        }
    }
}
