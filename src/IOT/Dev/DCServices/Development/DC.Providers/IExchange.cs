using System;
using Newtonsoft.Json;


namespace DC.Providers
{
    public interface IExchange
    {
        Decimal GetSpotPrice(Decimal value, String currencyCode);

        PriceData GetSpotPrice2(Decimal value, String currencyCode);
        
        Decimal GetSpotRate(String currencyCode);
  
        OrderData Order(float price, float amount);

    }

    public class PriceData
    {
        /// <summary>

        /// </summary>
        [JsonProperty("errors")]
        public string Errors { get; set; }

        /// <summary>

        /// </summary>
        [JsonProperty("Price")]
        public decimal Price { get; set; }

        /// <summary>

        /// </summary>
        [JsonProperty("Tmestamp")]
        public string Timestamp { get; set; }

        [JsonProperty("Side")]
        public String Side { get; set; } //Todo.


    }
  

     public class OrderData
    {
        /// <summary>

        /// </summary>
        [JsonProperty("errors")]
        public string Errors { get; set; }

        /// <summary>

        /// </summary>
        [JsonProperty("Price")]
        public decimal Price { get; set; }

        /// <summary>

        /// </summary>
        [JsonProperty("Tmestamp")]
        public string Timestamp { get; set; }

        [JsonProperty("Amount")]
        public decimal Side { get; set; } //Todo.

         [JsonProperty("Id")]
        public string Id { get; set; } //Todo.

         [JsonProperty("Address")]
        public string Address { get; set; } //Todo.

    }





}
