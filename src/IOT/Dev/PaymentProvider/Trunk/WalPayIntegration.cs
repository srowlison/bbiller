using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DC.PaymentProvider
{
    public class WalPayIntegration : IPaymentGateway
    {
        public String Url { get { return "https://int.cc-gw-wal.com/U00A4_0100/Authorise/KG/Asynchronous"; } }

        public DTO.WalPay.MerchantRequest Request { get; set; }

        public Boolean Process()
        {
            WebRequest request = WebRequest.Create(this.Url);

            // Set the Method property of the request to POST.
            request.Method = "POST";

            //Helper<DTO.WalPay.MerchantRequest> helper = new Helper<DTO.WalPay.MerchantRequest>();
            //String requestToSend = helper.SerializeAsXMLString(this.Request);

            //DTO.WalPay.Secure3D secure3D = new DTO.WalPay.Secure3D();

            Guid id = new Guid();
            id = Guid.NewGuid();

            String requestToSend = String.Format(@"<MerchantRequest Simulate=""CardAuthoriseSuccess,RiskEvaluateSuccess""><MerchantInfo><MerchantName>diamondcircle_eur</MerchantName><MerchantPIN>wXO!OrzyAc?5BTrY2J@F</MerchantPIN><NotificationURL>https://diamondcircle.net/IPN.aspx</NotificationURL><RedirectURL>https://diamondcircle.net</RedirectURL></MerchantInfo><TransactionInfo><OrderID>{0}</OrderID><OrderDescription>WorldBooks order 1234</OrderDescription><Amount>10000</Amount><CurrencyCode>978</CurrencyCode><MerchantDateTime>{1:yyyy-MM-dd HH:mm:ss}</MerchantDateTime></TransactionInfo><ClientInfo><AccountNumber>hr385645</AccountNumber><Name>Bob</Name><Surname>Smith</Surname><Address>17 Main Street</Address><City>New York</City><State>NY</State><Zip>10348</Zip><Country>US</Country><Telephone>2122101938</Telephone><Email>bob.smith@test.com</Email><DOB>1986-08-12</DOB><ClientIP>215.45.81.1</ClientIP></ClientInfo><PaymentInfo><PAN>4444333322221111</PAN><ExpiryDate>07-2016</ExpiryDate><CardHolderName>B Smith</CardHolderName><CVC2>123</CVC2><StartDate/><IssueNumber/></PaymentInfo></MerchantRequest>", id, DateTime.UtcNow);

            // Create POST data and convert it to a byte array.
            string postData = String.Format("strRequest={0}", requestToSend);
            byte[] byteArray = Encoding.UTF8.GetBytes(postData);

            // Set the ContentType property of the WebRequest.
            request.ContentType = "application/x-www-form-urlencoded";
            // Set the ContentLength property of the WebRequest.
            request.ContentLength = byteArray.Length;
            
            // Get the request stream.
            using (Stream dataStream = request.GetRequestStream())
            {
                // Write the data to the request stream.
                dataStream.Write(byteArray, 0, byteArray.Length);
                // Close the Stream object.
                dataStream.Close();
            }
            
            // Get the response.
            using (WebResponse response = request.GetResponse())
            {
                // Display the status.
                Console.WriteLine(((HttpWebResponse)response).StatusDescription);

                // Get the stream containing content returned by the server.
                using (Stream dataStream = response.GetResponseStream())
                {
                    // Open the stream using a StreamReader for easy access.
                    using (StreamReader reader = new StreamReader(dataStream))
                    {
                        // Read the content.
                        string responseFromServer = reader.ReadToEnd();

                        // Display the content.
                        // Console.WriteLine(responseFromServer);
                        // Clean up the streams.
                        reader.Close();
                        dataStream.Close();

                        return true;
                    }
                }
            }
        }
    }
}
