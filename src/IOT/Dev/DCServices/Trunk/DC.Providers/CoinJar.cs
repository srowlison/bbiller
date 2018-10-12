using DC.Common.Models;
using System;
using System.IO;
using System.Net;
using System.Runtime.Serialization.Json;

namespace DC.Providers
{
    public class CoinJar : IExchange
    {
        public String ApiKey { get; set; }

        /// <summary>
        /// Converts local currency value into coinjar spot rate.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="currencyCode">AUD</param>
        /// <returns></returns>
        public Decimal GetSpotPrice(Decimal value, string currencyCode)
        {
            Uri url = new Uri(String.Format("https://api.coinjar.io/v1/fair_rate/{0}.json", currencyCode));

            WebRequest request = WebRequest.Create(url);
            request.Credentials = new NetworkCredential(this.ApiKey, "");
            using (Stream objStream = request.GetResponse().GetResponseStream())
            {
                if (objStream != null)
                {
                    DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(typeof(FairRateResponse));
                    FairRateResponse response = (FairRateResponse)jsonSerializer.ReadObject(objStream);
                    return value / response.Spot;
                }
                else
                {
                    throw new NullReferenceException();
                }
            }
        }
    }
}