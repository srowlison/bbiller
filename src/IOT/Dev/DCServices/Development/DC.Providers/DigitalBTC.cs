
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Xml;
using Newtonsoft.Json;



namespace DC.Providers
{


    public class DigitalBTC : IExchange
    {
        

        private String key = "UPhhiBaN58L3PA0pgWGKq4J80yISbQkIq6C970L1odM";
        private String secret = "rKwfUwVVF717aYTVAHEhut5V7N0JAf4hCI19Mheph5s";
        private String baseUrl = "https://direct.digitalx.com";

        public Decimal GetSpotPrice(Decimal value, string currencyCode)
        {
            // Not Implemented
            return 0;

        }
        public Decimal GetSpotRate(string currencyCode)
        {
            // Not Implemented
            return 0;

        }
        public PriceData GetSpotPrice2(Decimal value, string currencyCode)

        {

            // Some logic is reqired to handle differing currencycode - Digital BTC is USD only.

            TimeSpan t = DateTime.UtcNow - new DateTime(1970, 1, 1);
            int secondsSinceEpoch = (int)t.TotalSeconds;

            String json = "{\"nonce\": " + secondsSinceEpoch + ", \"method\": \"price\", \"side\": \"buy\"}";

            //Encode the json version of the parameters above
            var convertedParam = Convert.ToBase64String(Encoding.UTF8.GetBytes(json));

            //Encrypt the parameters with sha256 using the secret as the key
            System.Text.ASCIIEncoding encoding = new System.Text.ASCIIEncoding();
            byte[] keyByte = encoding.GetBytes(secret);
            HMACSHA256 hmacsha256 = new HMACSHA256(keyByte);
            byte[] messageBytes = encoding.GetBytes(convertedParam);
            byte[] hashmessage = hmacsha256.ComputeHash(messageBytes);

            //Create the signature, a hex output of the encrypted hash above
            StringBuilder stringBuilder = new StringBuilder();
            foreach (byte b in hashmessage)
            {
                stringBuilder.AppendFormat("{0:X2}", b);
            }
            string signature = stringBuilder.ToString().ToLower();


            String url = baseUrl + "/api/price";
            WebRequest theRequest = WebRequest.Create(url);
            theRequest.Method = "POST";

            theRequest.ContentType = "text/x-json";
            theRequest.ContentLength = json.Length;
            theRequest.Headers["X-DIGITALX-KEY"] = key;
            theRequest.Headers["X-DIGITALX-PARAMS"] = convertedParam;
            theRequest.Headers["X-DIGITALX-SIGNATURE"] = signature;
            Stream requestStream = theRequest.GetRequestStream();

            requestStream.Write(Encoding.ASCII.GetBytes(json), 0, json.Length);
            requestStream.Close();



            HttpWebResponse response = (HttpWebResponse)theRequest.GetResponse();

            Stream responseStream = response.GetResponseStream();

            StreamReader myStreamReader = new StreamReader(responseStream, Encoding.Default);

            string pageContent = myStreamReader.ReadToEnd();

            myStreamReader.Close();
            responseStream.Close();

            response.Close();

            
            var pricedata  = JsonConvert.DeserializeObject<PriceData>(pageContent);
            return pricedata;

            
            

        }
    





        public String getStatus()
        {

            TimeSpan t = DateTime.UtcNow - new DateTime(1970, 1, 1);
            int secondsSinceEpoch = (int)t.TotalSeconds;

            String json = "{\"nonce\": " + secondsSinceEpoch + ", \"method\": \"status\"}";

            //Encode the json version of the parameters above
            var convertedParam = Convert.ToBase64String(Encoding.UTF8.GetBytes(json));

            //Encrypt the parameters with sha256 using the secret as the key
            System.Text.ASCIIEncoding encoding = new System.Text.ASCIIEncoding();
            byte[] keyByte = encoding.GetBytes(secret);
            HMACSHA256 hmacsha256 = new HMACSHA256(keyByte);
            byte[] messageBytes = encoding.GetBytes(convertedParam);
            byte[] hashmessage = hmacsha256.ComputeHash(messageBytes);

            //Create the signature, a hex output of the encrypted hash above
            StringBuilder stringBuilder = new StringBuilder();
            foreach (byte b in hashmessage)
            {
                stringBuilder.AppendFormat("{0:X2}", b);
            }
            string signature = stringBuilder.ToString().ToLower();


            String url = baseUrl + "/api/status";
            WebRequest theRequest = WebRequest.Create(url);
            theRequest.Method = "POST";

            theRequest.ContentType = "text/x-json";
            theRequest.ContentLength = json.Length;
            theRequest.Headers["X-DIGITALX-KEY"] = key;
            theRequest.Headers["X-DIGITALX-PARAMS"] = convertedParam;
            theRequest.Headers["X-DIGITALX-SIGNATURE"] = signature;
            Stream requestStream = theRequest.GetRequestStream();

            requestStream.Write(Encoding.ASCII.GetBytes(json), 0, json.Length);
            requestStream.Close();

            HttpWebResponse response = (HttpWebResponse)theRequest.GetResponse();

            Stream responseStream = response.GetResponseStream();

            StreamReader myStreamReader = new StreamReader(responseStream, Encoding.Default);

            string pageContent = myStreamReader.ReadToEnd();

            myStreamReader.Close();
            responseStream.Close();

            response.Close();

            return pageContent;
        }

        public OrderData Order(float price, float amount)
        {
            

            TimeSpan t = DateTime.UtcNow - new DateTime(1970, 1, 1);
            int secondsSinceEpoch = (int)t.TotalSeconds;

            String json = "{\"nonce\": " + secondsSinceEpoch + ", \"method\": \"order\", \"price\": " + price + ", \"amount\": " + amount + ", \"side\": \"buy\"}";

            //Encode the json version of the parameters above
            var convertedParam = Convert.ToBase64String(Encoding.UTF8.GetBytes(json));

            //Encrypt the parameters with sha256 using the secret as the key
            System.Text.ASCIIEncoding encoding = new System.Text.ASCIIEncoding();
            byte[] keyByte = encoding.GetBytes(secret);
            HMACSHA256 hmacsha256 = new HMACSHA256(keyByte);
            byte[] messageBytes = encoding.GetBytes(convertedParam);
            byte[] hashmessage = hmacsha256.ComputeHash(messageBytes);

            //Create the signature, a hex output of the encrypted hash above
            StringBuilder stringBuilder = new StringBuilder();
            foreach (byte b in hashmessage)
            {
                stringBuilder.AppendFormat("{0:X2}", b);
            }
            string signature = stringBuilder.ToString().ToLower();

            String url = baseUrl + "/api/order";
            WebRequest theRequest = WebRequest.Create(url);
            theRequest.Method = "POST";

            theRequest.ContentType = "text/x-json";
            theRequest.ContentLength = json.Length;
            theRequest.Headers["X-DIGITALX-KEY"] = key;
            theRequest.Headers["X-DIGITALX-PARAMS"] = convertedParam;
            theRequest.Headers["X-DIGITALX-SIGNATURE"] = signature;
            Stream requestStream = theRequest.GetRequestStream();

            requestStream.Write(Encoding.ASCII.GetBytes(json), 0, json.Length);
            requestStream.Close();

            HttpWebResponse response = (HttpWebResponse)theRequest.GetResponse();

            Stream responseStream = response.GetResponseStream();

            StreamReader myStreamReader = new StreamReader(responseStream, Encoding.Default);

            string pageContent = myStreamReader.ReadToEnd();

            myStreamReader.Close();
            responseStream.Close();

            response.Close();

            var orderdata = JsonConvert.DeserializeObject<OrderData>(pageContent);
            return orderdata;
        }

        public String getInvoice()
        {
            TimeSpan t = DateTime.UtcNow - new DateTime(1970, 1, 1);
            int secondsSinceEpoch = (int)t.TotalSeconds;

            String json = "{\"nonce\": " + secondsSinceEpoch + ", \"method\": \"invoice\"}";

            //Encode the json version of the parameters above
            var convertedParam = Convert.ToBase64String(Encoding.UTF8.GetBytes(json));

            //Encrypt the parameters with sha256 using the secret as the key
            System.Text.ASCIIEncoding encoding = new System.Text.ASCIIEncoding();
            byte[] keyByte = encoding.GetBytes(secret);
            HMACSHA256 hmacsha256 = new HMACSHA256(keyByte);
            byte[] messageBytes = encoding.GetBytes(convertedParam);
            byte[] hashmessage = hmacsha256.ComputeHash(messageBytes);

            //Create the signature, a hex output of the encrypted hash above
            StringBuilder stringBuilder = new StringBuilder();
            foreach (byte b in hashmessage)
            {
                stringBuilder.AppendFormat("{0:X2}", b);
            }
            string signature = stringBuilder.ToString().ToLower();


            String url = baseUrl + "/api/invoice";
            WebRequest theRequest = WebRequest.Create(url);
            theRequest.Method = "POST";

            theRequest.ContentType = "text/x-json";
            theRequest.ContentLength = json.Length;
            theRequest.Headers["X-DIGITALX-KEY"] = key;
            theRequest.Headers["X-DIGITALX-PARAMS"] = convertedParam;
            theRequest.Headers["X-DIGITALX-SIGNATURE"] = signature;
            Stream requestStream = theRequest.GetRequestStream();

            requestStream.Write(Encoding.ASCII.GetBytes(json), 0, json.Length);
            requestStream.Close();

            HttpWebResponse response = (HttpWebResponse)theRequest.GetResponse();

            Stream responseStream = response.GetResponseStream();

            StreamReader myStreamReader = new StreamReader(responseStream, Encoding.Default);

            string pageContent = myStreamReader.ReadToEnd();

            myStreamReader.Close();
            responseStream.Close();

            response.Close();

            return pageContent;
        }

        //decimal IExchange.GetSpotPrice(decimal value, string currencyCode)
        //{
        //    throw new NotImplementedException();
        //}
    }
}

