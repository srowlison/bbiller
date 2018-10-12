using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using System.Runtime.Serialization.Json;

namespace DC.Node.Providers
{
    public class BlockChainInfo : IWallet
    {
        private const Int64 SATOSHI = 100000000;

        public String MerchantId { get; set; }

        public String FromAddress { get; set; }

        public String Password { get; set; }

        public IWebProxy Proxy { get; set; }

        #region IPayment Members

        public string Send(string toAddress, decimal amount)
        {
            try
            {
                Int64 amountInSatoshi = Convert.ToInt64(amount * SATOSHI);
                Int32 feeInSatoshi = Convert.ToInt32(0.00005 * SATOSHI);
                String transferUrl = String.Empty;

                if (!String.IsNullOrEmpty(this.FromAddress))
                {
                    transferUrl = String.Format("https://blockchain.info/merchant/{3}/payment?password={4}&to={0}&from={5}&amount={1}&shared=false&note={2}&fee={6}", toAddress, amountInSatoshi, "Diamond Circle", this.MerchantId, this.Password, this.FromAddress, feeInSatoshi);
                }
                else
                {
                    transferUrl = String.Format("https://blockchain.info/merchant/{3}/payment?password={4}&to={0}&amount={1}&shared=false&note={2}&fee={5}", toAddress, amountInSatoshi, "Diamond Circle", this.MerchantId, this.Password, feeInSatoshi);
                }

                WebRequest request = WebRequest.Create(transferUrl);
                using (Stream objStream = request.GetResponse().GetResponseStream())
                {
                    if (objStream != null)
                    {
                        DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(typeof(DC.Common.Models.BlockChainInfo.TransferResponse));
                        DC.Common.Models.BlockChainInfo.TransferResponse response = (DC.Common.Models.BlockChainInfo.TransferResponse)jsonSerializer.ReadObject(objStream);
                        return response.TxHash;
                    }
                    else
                    {
                        return "error";
                    }
                }
            }
            catch (Exception ex)
            {
                return String.Format("error {0}", ex.Message);
            }
        }

        #endregion

        public decimal GetBalance(string address)
        {
            throw new NotImplementedException();
        }

        public string SendRawTransaction(string txn)
        {
            try { 
            WebRequest request = WebRequest.Create("https://blockchain.info/pushtx");
            // Set the Method property of the request to POST.
            request.Method = "POST";
            // Create POST data and convert it to a byte array.
            string postData = String.Format("tx={0}", txn);
            byte[] byteArray = Encoding.UTF8.GetBytes(postData);
            // Set the ContentType property of the WebRequest.
            request.ContentType = "application/x-www-form-urlencoded";
            // Set the ContentLength property of the WebRequest.
            request.ContentLength = byteArray.Length;
            // Get the request stream.
            Stream dataStream = request.GetRequestStream();
            // Write the data to the request stream.
            dataStream.Write(byteArray, 0, byteArray.Length);
            // Close the Stream object.
            dataStream.Close();
            // Get the response.
            WebResponse response = request.GetResponse();
            // Get the stream containing content returned by the server.
            dataStream = response.GetResponseStream();
            // Open the stream using a StreamReader for easy access.
            StreamReader reader = new StreamReader(dataStream);
            // Read the content.
            string responseFromServer = reader.ReadToEnd();

            // Display the content.
            Console.WriteLine(responseFromServer);

            // Clean up the streams.
            //CHANGE TO USINGS
            reader.Close();
            dataStream.Close();
            response.Close();
            return (responseFromServer);


                }

            catch (Exception ex)
            {
                return String.Format("error {0}", ex.Message);
            }
        }

        public string CreateAddress()
        {
            throw new NotImplementedException();
        }
    }
}
