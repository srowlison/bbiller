using DC.Providers;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace DC.Payment
{
    public class Exchange : IExchange


    {
        public PriceData GetSpotPrice2(String currencyCode, Decimal amount, Int32 terminalId)
        {
            if (amount > 0)
            {
                currencyCode = currencyCode.ToUpper();


                DC.Providers.IExchange provider = new Providers.DigitalBTC();
                return provider.GetSpotPrice2(amount, currencyCode);

            }
            else
            {
                throw new ArgumentOutOfRangeException("Value must be greater than zero.");
            }

        }

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

        public Decimal GetSpotRate(String currencyCode)
        {
            
            {
                currencyCode = currencyCode.ToUpper();

                String apiKey = System.Configuration.ConfigurationManager.AppSettings["coinjar_api_key"];
                DC.Providers.IExchange provider = new Providers.CoinJar() { ApiKey = apiKey };
                return provider.GetSpotRate(currencyCode);

            }
           
        }
        public Common.Models.Margin GetMargin(string currencyCode, Int32 terminalId)
        {
            currencyCode = currencyCode.ToUpper();
            String apiKey = System.Configuration.ConfigurationManager.AppSettings["coinjar_api_key"];
            DC.Providers.IExchange provider = new Providers.CoinJar() { ApiKey = apiKey };

            var spot = provider.GetSpotPrice(1.0M, currencyCode);

            return new Common.Models.Margin()
            {
                Buy = spot * 0.925M,
                Sell = spot * 1.09M,
                Rate = spot,
            };
        }
     


    }
}
