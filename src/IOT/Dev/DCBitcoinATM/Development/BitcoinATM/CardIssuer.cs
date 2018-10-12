using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net.Sockets;

namespace BitcoinATM
{
    public class CardIssuer : BitcoinATM.ICardIssuer
    {
        public String Ip { get; set; }

        public void EjectCard() 
        {
            //TODO:  WHAT IS THIS IP?
            using (TcpClient client = new TcpClient(this.Ip, 80))
            {
                // Translate the passed message into ASCII and store it as a Byte array.
                string CrLf = Environment.NewLine;

                Byte[] data = System.Text.Encoding.ASCII.GetBytes("GET /state.xml?relay1State=2" + " HTTP/1.1" + CrLf + "Authorization: Basic bm9uZTp3ZWJyZWxheQ==" + CrLf + CrLf);

                // Get a client stream for reading and writing. 
                //  Stream stream = client.GetStream();
                using (NetworkStream stream = client.GetStream())
                {
                    // Send the message to the connected TcpServer. 
                    stream.Write(data, 0, data.Length);

                    // Buffer to store the response bytes.
                    data = new Byte[1024];

                    // Read the first batch of the TcpServer response bytes.
                    Int32 bytes = stream.Read(data, 0, data.Length);
                    String responseData = System.Text.Encoding.ASCII.GetString(data, 0, bytes);
                    Console.WriteLine("Received: {0}", responseData);

                    // Close everything.
                    stream.Close();
                    client.Close();
                    // position 210 contains value
                }
            }
        }
    }
}
