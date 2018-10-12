﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net.Sockets;

namespace BitcoinATM
{
    public class CardIssuer : BitcoinATM.ICardIssuer
    {
        
       public void EjectCard()
        {
           if (Properties.Settings.Default.RelayInstalled)
           {

           
            // Push card out of Dispenser
            String WebRelayIP = Properties.Settings.Default.WebRelayIP; 
            using (TcpClient client = new TcpClient(WebRelayIP, 80))
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
                    // position 210 contains value if you want to read it back.  No need.
                }
            }
           
           
           }
        }

        public bool Read_IsResetJamSignalOn()
        {

            // Pins 9 (Blue) and 10 (Yellow) of Card Dispenser - Hardware map to Web Relay - Optocoupler Output #1. <input1state>0</input1state> - 5VDC.
            // Normally 0 
            // Otherwise 1
            //TODO:   Wire Interface in Prod and test. - Not tested in DEV.
            if (Properties.Settings.Default.RelayInstalled)
            {
                String WebRelayIP = Properties.Settings.Default.WebRelayIP;
                using (TcpClient client = new TcpClient(WebRelayIP, 80))
                {
                    // Translate the passed message into ASCII and store it as a Byte array.
                    string CrLf = Environment.NewLine;

                    Byte[] data = System.Text.Encoding.ASCII.GetBytes("GET /state.xml?noReply=0 HTTP/1.1" + CrLf + "Authorization: Basic bm9uZTp3ZWJyZWxheQ==" + CrLf + CrLf);

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

                        // Found at position 154.
                        String strstate = responseData.Substring(154, 1);


                        // Close everything.
                        stream.Close();
                        client.Close();

                        if (strstate == "0")
                        {
                            return true;
                        }
                        return false;




                    }
                
            }
            }
            else
            {
                return true;
            }
        }




    }
}
