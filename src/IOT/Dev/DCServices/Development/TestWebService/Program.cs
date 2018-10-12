using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DC.Providers;
using DC.Cards;

using IndependentReserve.DotNetClientApi.Data;



namespace TestWebService
{
    class Program
    {
        static void Main(string[] args)
        {

            using (var client = Client.CreatePublic("https://api.independentreserve.com"))
            
            {
                var orderBook = client.GetOrderBook(CurrencyCode.Xbt, CurrencyCode.Usd);
                BankOrder bankOrder = client.PlaceMarketOrder(CurrencyCode.Xbt, CurrencyCode.Usd, OrderType.MarketBid, 0.01m);


                
            }

            //DC.Providers.Stripe cc = new DC.Providers.Stripe();
            //cc.DoPayment("4645790048147002", 100, "Stephen", "Rowlison", "8/23 Gordon St", "Labrador", "4215", "QLD", "Australia", "0400826669", "04031964", "srowlison@diamondcircle.net", "Stephen Rowlison", "07", "17", "171", "AUD");

        //    DC.Providers.DigitalBTC dbtc = new DC.Providers.DigitalBTC();
//
        //    dbtc.GetSpotPrice(1, "USD");

            //float price = 1;
            // float amount = 1;
        //     dbtc.Order(price, amount);


                       
            




            //node.AtmClient atm = new node.AtmClient();
            //atm.CreateOrder("1PmQQ6dUvbWDkrUHgSDobSTZjm8CYL9SA3", 0.001m);

        }
    }
}
