using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DC.Providers
{
    public class BlockExplorer : IAddress
    {
        public Decimal GetBalance(String bitcoinAddress, Int16 confirmations = 6)
        {
            //Change to a provider interface.
            Uri url = new Uri(String.Format("https://blockexplorer.com/q/addressbalance/{0}/{1}", bitcoinAddress, confirmations));
            WebRequest request = WebRequest.Create(url);

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            Console.WriteLine(response.StatusDescription);

            // Get the stream containing content returned by the server.
            using (Stream dataStream = response.GetResponseStream())
            {
                // Open the stream using a StreamReader for easy access.
                using (StreamReader reader = new StreamReader(dataStream))
                {
                    String responseFromServer = reader.ReadToEnd();
                    return Convert.ToDecimal(responseFromServer);
                }
            }
        }


        public string GetHash160(string address)
        {
            throw new NotImplementedException();
        }
    }
}
