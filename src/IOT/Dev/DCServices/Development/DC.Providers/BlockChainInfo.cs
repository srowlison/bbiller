using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace DC.Providers
{
    public class BlockChainInfo : ITransaction, IAddress
    {
        public DC.Common.Models.UnspentResponse GetUnspentTxns(String address)
        {
            String url = String.Format("https://blockchain.info/unspent?active={0}", address);

            WebRequest request = WebRequest.Create(url);
            //request.UseDefaultCredentials = true;

            try
            {
                using (Stream objStream = request.GetResponse().GetResponseStream())
                {
                    if (objStream != null)
                    {
                        DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(typeof(DC.Common.Models.UnspentResponse));
                        DC.Common.Models.UnspentResponse response = (DC.Common.Models.UnspentResponse)jsonSerializer.ReadObject(objStream);

                        //TODO, ORDER BY
                        return response;
                    }
                    else
                    {
                        return null;
                    }
                }
            }
            catch(Exception ex)
            {
                //An internal server error is thrown here usually because there are no free outputs to spend 
                throw new InvalidOperationException("There are insufficient cleared funds for this transaction. Please try again later", ex);
            }
        }

        public String GetHash160(String address)
        {
            //https://blockchain.info/q/addresstohash
            String url = String.Format("https://blockchain.info/q/addresstohash/{0}", address);

            WebRequest request = WebRequest.Create(url);

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            // Get the stream containing content returned by the server.
            using (Stream dataStream = response.GetResponseStream())
            {
                // Open the stream using a StreamReader for easy access.
                using (StreamReader reader = new StreamReader(dataStream))
                {
                    String responseFromServer = reader.ReadToEnd();
                    return responseFromServer;
                }
            }
        }

        public decimal GetBalance(string bitcoinAddress, short confirmations = 6)
        {
            throw new NotImplementedException();
        }
    }
}
