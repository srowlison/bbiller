using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DCPOS


{
    internal class btcnfcfunctions : DCPOS.INFC
    {
        public IntPtr hContext, hCard;
        int retCode, Protocol;
        public bool connActive = false;
        public bool autoDet;
        public byte[] SendBuff = new byte[263];
        public byte[] RecvBuff = new byte[263];
        public int SendLen, RecvLen, nBytesRet, reqType, Aprotocol, dwProtocol, cbPciLength;
        public ModWinsCard.SCARD_READERSTATE RdrState;
        public ModWinsCard.SCARD_IO_REQUEST pioSendRequest;
        public string cbReaderText = "ACS ACR1251 1S CL Reader PICC 0";

        private void writeDCData(string publicuri, string encryptedprivatekey)

         {
            // From Block 1 on an Mifare 1K Classic
            // Write Version number
             string version = "100";

            

             string StringWrite = version + encryptedprivatekey + publicuri ;

             string padding = new String('0', 128 - StringWrite.Length);

             string datastream = StringWrite +  padding;


            // version Size =               03     03
            // encryptedprivatekey - Size = 88     91 
            // publicuri                  = 27-34  118-125
            // Terminate with = 48DEC 30HEX is a zero.  1   119-126
            // 128/16 = 8


             double nrecords = 8;

            int i = 0;
            int nrecord = 1;

             for (Int32 indx = 1; indx <= nrecords; indx += 1)
             {

                 string strWrite = datastream.Substring(i,16);

                 
                 Writeblock(nrecord.ToString(), strWrite);
                 i = i + 16;
                 nrecord = nrecord + 1;

             }

        }

        public bool WriteNFCTag(string publicuri, string encryptedprivatekey)
        {

         //    publicuri = "bitcoin:1D45JxNkyhCyxC7LFwA6hwH2ssLkZhExij";
         //    encryptedprivatekey = "K4ChanJIxe7JsZq/eu5VFIxVYN82lr7ub/EpWCLEImtW+MUasJP+uAxz9CPnE1WvFSUTnF4OkrMOGYMQ1p2PjA==";
            
            

            string uri = publicuri;


            string sizeOfURI = String.Format("{0:X2}", Convert.ToInt32(publicuri.Length+1));
            string headerndef = "038C9101" + sizeOfURI + "5500";
            
            char[] values = uri.ToCharArray();
            string MessagePayload = "";
            foreach (char letter in values)
            {
                MessagePayload += String.Format("{0:X2}", Convert.ToInt32(letter));
            }


            string nDEF = headerndef + MessagePayload;

            encryptedprivatekey = "b:" + encryptedprivatekey;

            string strfile = String.Format("{0:X2}", encryptedprivatekey);

            values = strfile.ToCharArray();
            MessagePayload = "";
            foreach (char letter in values)
            {
                MessagePayload += String.Format("{0:X2}", Convert.ToInt32(letter));
            }

            // 52: 02+88

            headerndef = "520258";

            string MessageTerminator = "FE";

            nDEF += headerndef + MessagePayload + MessageTerminator;
            
            
            // Need to pad this out cause the mininmum write size is 4 bytes
            double value4 = Convert.ToDouble(nDEF.Length) / 4;
            double nrecords = Math.Ceiling(Convert.ToDouble(nDEF.Length) / 4);

            double fraction = value4 - (int)value4;
            if (fraction > 0)
            {
                string padstring = "0";
                double qpaddings = 4 - ((value4 - (nrecords - 1)) * 4);
                for (Int32 i = 1; i <= qpaddings; i++)
                {
                    nDEF += padstring;
                }
            }



            string txtvalues = hextotext(nDEF.ToString());
            
            int BlockNo = 4;
            
            for (Int32 indx = 0; indx <=txtvalues.Length - 1; indx+=4) {
                string writevalues = txtvalues.Substring(indx, 4);
                if (Writeblock(BlockNo.ToString(), writevalues))
                {
                BlockNo = BlockNo + 1;
                }
                    else
                {
                return false;
                }
            }
        

           
            return true;
        }


        private bool Writeblock(string BlockNo, string stringValues)
        {
            
            string strlength = Convert.ToString(stringValues.Length);

            ClearBuffers();
            SendBuff[0] = 0xFF;                                     // CLA
            SendBuff[1] = 0xD6;                                     // INS
            SendBuff[2] = 0x00;                                     // P1
            SendBuff[3] = (byte)int.Parse(BlockNo);            // P2 : Starting Block No.
            SendBuff[4] = (byte)int.Parse(strlength);            // P3 : Data length

            for (int indx = 0; indx <= (stringValues).Length - 1; indx++)
            {

                SendBuff[indx + 5] = (byte)stringValues[indx];
                

            }
            SendLen = SendBuff[4] + 5;
            RecvLen = 0x02;




            retCode = SendAPDUandDisplay(2);

            if (retCode != ModWinsCard.SCARD_S_SUCCESS)
            {
                return false;
            }
            return true;
        }

        private void ClearBuffers()
        {
            for (Int64 indx = 0; indx <= 262; indx++)
            {
                RecvBuff[indx] = 0;
                SendBuff[indx] = 0;
            }
        }

        private int SendAPDUandDisplay(int reqType)
        {

            int indx;
            string tmpStr;

            pioSendRequest.dwProtocol = Aprotocol;
            pioSendRequest.cbPciLength = 8;

            // Display Apdu In
            tmpStr = "";
            for (indx = 0; indx <= SendLen - 1; indx++)
            {

                tmpStr = tmpStr + " " + string.Format("{0:X2}", SendBuff[indx]);

            }

     //        displayOut(2, 0, tmpStr);
            retCode = ModWinsCard.SCardTransmit(hCard, ref pioSendRequest, SendBuff, SendLen, ref pioSendRequest, RecvBuff, ref RecvLen);

            if (retCode != ModWinsCard.SCARD_S_SUCCESS)
            {

            //     displayOut(1, retCode, "");
                return retCode;


            }

            else
            {

                tmpStr = "";
                switch (reqType)
                {

                    case 0:
                        {
                            for (indx = (RecvLen - 2); indx <= (RecvLen - 1); indx++)
                            {

                                tmpStr = tmpStr + " " + string.Format("{0:X2}", RecvBuff[indx]);

                            }


                            if ((tmpStr).Trim() != "90 00")
                            {

                    //             displayOut(4, 0, "Return bytes are not acceptable.");

                            }

                            break;
                        }

                    case 1:
                        {
                            for (indx = (RecvLen - 2); indx <= (RecvLen - 1); indx++)
                            {

                                tmpStr = tmpStr + string.Format("{0:X2}", RecvBuff[indx]);

                            }


                            if (tmpStr.Trim() != "90 00")
                            {

                                tmpStr = tmpStr + " " + string.Format("{0:X2}", RecvBuff[indx]);
                            }

                            else
                            {

                                tmpStr = "ATR : ";
                                for (indx = 0; indx <= (RecvLen - 3); indx++)
                                {

                                    tmpStr = tmpStr + " " + string.Format("{0:X2}", RecvBuff[indx]);

                                }

                            }

                            break;
                        }

                    case 2:
                        {
                            for (indx = 0; indx <= (RecvLen - 1); indx++)
                            {

                                tmpStr = tmpStr + " " + string.Format("{0:X2}", RecvBuff[indx]);
                               
                            }

                            break;
                        }

                }

               //  displayOut(3, 0, tmpStr.Trim() + "\r\n");

            }
            return retCode;


        }


        public bool InitReader()
        {
            string ReaderList = "" + Convert.ToChar(0);
            int indx;
            int pcchReaders = 0;
            string rName = "";

            // 1. Establish Context
            retCode = ModWinsCard.SCardEstablishContext(ModWinsCard.SCARD_SCOPE_USER, 0, 0, ref hContext);

            if (retCode != ModWinsCard.SCARD_S_SUCCESS)
            {

                //               displayOut(1, retCode, "");

                return false;
            }

            // 2. List PC/SC card readers installed in the system
            retCode = ModWinsCard.SCardListReaders(this.hContext, null, null, ref pcchReaders);

            if (retCode != ModWinsCard.SCARD_S_SUCCESS)
            {
                //             displayOut(1, retCode, "");

                return false;
            }

            byte[] ReadersList = new byte[pcchReaders];

            // Fill reader list
            retCode = ModWinsCard.SCardListReaders(this.hContext, null, ReadersList, ref pcchReaders);

            if (retCode != ModWinsCard.SCARD_S_SUCCESS)
            {
                //          displayOut(0, 0, "SCardListReaders Error: " + ModWinsCard.GetScardErrMsg(retCode));
                return false;
            }
            else
            {
                //       displayOut(0, 0, " ");
            }

            rName = "";
            indx = 0;

            // Convert reader buffer to string
            while (ReadersList[indx] != 0)
            {
                while (ReadersList[indx] != 0)
                {
                    rName = rName + (char)ReadersList[indx];
                    indx = indx + 1;
                }

                // Add reader name to list
                if (rName == cbReaderText)
                {
                    return true;
                }
            }
            return false;
        }
 
        public bool ConnectReader()
        {
           // Connect to selected reader using hContext handle and obtain hCard handle
           if (connActive)
           {
               retCode = ModWinsCard.SCardDisconnect(hCard, ModWinsCard.SCARD_UNPOWER_CARD);
           }

            // Shared Connection
            

            retCode = ModWinsCard.SCardConnect(hContext, cbReaderText, ModWinsCard.SCARD_SHARE_EXCLUSIVE, ModWinsCard.SCARD_PROTOCOL_T1, ref hCard, ref Protocol);
            if (retCode == ModWinsCard.SCARD_S_SUCCESS)
            {
                // displayOut(0,0,"Successful connection to " + cbReader.Text);
                connActive = true;
                return true;
            }
            else
            {
                // displayOut(0, 0, ModWinsCard.GetScardErrMsg(retCode));
                connActive = false;
                return false;
            }
        }

        
        public string hextotext(string strHex)
        {
            string hexval = "";
            string tmpStr = "";
            int i;
            for (i = 0; i <= strHex.Length - 1; i = i + 2)
            {
                hexval = strHex.Substring(i, 2);
                // Convert the number expressed in base-16 to an integer. 
                int value = Convert.ToInt32(hexval, 16);
                char charValue = (char)value;
                tmpStr += charValue;
            }
            return tmpStr;
        }

        public bool readPublicKey(ref string PublicKey)
        {
            string PartKey = "";
            bool bnone = ReadBlocks("7", "16", ref PartKey);     // 7,8,9,10
            PublicKey += PartKey;

            bnone = ReadBlocks("11", "16", ref PartKey);        // 11,12,13,14
            PublicKey += PartKey;

            bnone = ReadBlocks("15", "12", ref PartKey);        // 15,16,17
            PublicKey += PartKey;

            // Remove the first 3 
            PublicKey = PublicKey.Substring(6);


            int index = PublicKey.IndexOf("520258");


            PublicKey = PublicKey.Substring(0, index);

            
            PublicKey = hextotext(PublicKey);

            return true;
        }

        public bool readPrivateKey(ref string PrivateKey)
        {
            // Read all blocks starting at 16 look for header 520256 + "DC:"  - Get string to length of 88 bytes
            int i;
            for (i = 16; i < 41; i = i + 1)
            {
                string PartKey = "";
                bool bnone = ReadBlocks(i.ToString(), "4", ref PartKey);        
                PrivateKey += PartKey;
            }
            // dc:

            string strStart = "520258623A";
            string strEnd = "FE0000000000";


            int Start, End;
            if (PrivateKey.Contains(strStart) && PrivateKey.Contains(strEnd))
            {
                Start = PrivateKey.IndexOf(strStart, 0) + strStart.Length;
                End = PrivateKey.IndexOf(strEnd, Start);
               PrivateKey =  PrivateKey.Substring(Start, End - Start );

        
                PrivateKey = hextotext(PrivateKey);

                
                





                return true;
            }
            else
            {
                return false;
            }
        }
    
        public bool ReadTagID(ref string TagId) 

        {
                   
            if (ReadBlocks("0","7", ref TagId))
            {
                TagId = TagId.Substring(0, 7);
           
                return true;
            }
            return false;
        }


        public bool ReadBlocks(string blockid, string blocksize, ref string blockdata)
        {
            string tmpStr;
            int indx;

            ClearBuffers();
            SendBuff[0] = 0xFF;
            SendBuff[1] = 0xB0;
            SendBuff[2] = 0x00;
            SendBuff[3] = (byte)int.Parse(blockid);
            SendBuff[4] = (byte)int.Parse(blocksize);

            SendLen = 5;
            RecvLen = SendBuff[4] + 2;
            retCode = SendAPDUandDisplay(2);

            if (retCode == ModWinsCard.SCARD_S_SUCCESS)
            {
                // Display data in text format
                tmpStr = "";

                for (indx = 0; indx <= RecvLen - 3; indx++)
                {
                    tmpStr = tmpStr + string.Format("{0:X2}",RecvBuff[indx]);
                }

                blockdata = tmpStr;
                return true;

            }
            return false;
        }

    

        private bool LoadKey()
        {

            ClearBuffers();
            SendBuff[0] = 0xFF;                      // CLA
            SendBuff[1] = 0x82;                      // INS
            SendBuff[2] = 0x00;                 // P1 : volatile memory
            SendBuff[3] = byte.Parse("01", System.Globalization.NumberStyles.HexNumber);   // P2 : Memory location
            SendBuff[4] = 0x06;                     // P3
            SendBuff[5] = byte.Parse("FF", System.Globalization.NumberStyles.HexNumber);        // Key 1 value
            SendBuff[6] = byte.Parse("FF", System.Globalization.NumberStyles.HexNumber);        // Key 2 value
            SendBuff[7] = byte.Parse("FF", System.Globalization.NumberStyles.HexNumber);        // Key 3 value
            SendBuff[8] = byte.Parse("FF", System.Globalization.NumberStyles.HexNumber);        // Key 4 value
            SendBuff[9] = byte.Parse("FF", System.Globalization.NumberStyles.HexNumber);        // Key 5 value
            SendBuff[10] = byte.Parse("FF", System.Globalization.NumberStyles.HexNumber);       // Key 6 value
            SendLen = 11;
            RecvLen = 2;
            retCode = SendAPDUandDisplay(0);
            if (retCode == ModWinsCard.SCARD_S_SUCCESS)
            {
                return true;
            }
            return false;
        }
        //Apdu apdu = new Apdu();
        //    apdu.lengthExpected = 21;
        //    apdu.data = new byte[5];

        //    apdu.data[0] = 0xE0;
        //    apdu.data[1] = 0x00;
        //    apdu.data[2] = 0x00;
        //    apdu.data[3] = 0x33;
        //    apdu.data[4] = 0x00;

        //    apduCommand = apdu;
        //    sendCardControl();


           //public string readReaderSerialNumber()
           //{
           // string tmpStr = "";
           // int indx;

           // ClearBuffers();
           // SendBuff[0] = 0xE0;                                       // CLA
           // SendBuff[1] = 0x00;                                       // P1: same for all source types
           // SendBuff[2] = 0x00;                                       // INS: for stored key input
           // SendBuff[3] = 0x33;                                       // P2: for stored key input
           // SendBuff[4] = 0x00;                                       // P3: for stored key input
            

            
           // SendLen = 5;
           // RecvLen = SendBuff[4] + 21;
           // retCode = SendAPDUandDisplay(0);
            
           // if (retCode == ModWinsCard.SCARD_S_SUCCESS)
           // {
           //     // Display data in text format
                

           //     for (indx = 0; indx <= RecvLen - 3; indx++)
           //     {
           //         tmpStr = tmpStr + string.Format("{0:X2}", RecvBuff[indx]);
           //     }

               
            

           // }
           // return (tmpStr);
           //}

        


        private bool Authenticate()
        {

            ClearBuffers();
            SendBuff[0] = 0xFF;                                       // CLA
            SendBuff[2] = 0x00;                                       // P1: same for all source types
            SendBuff[1] = 0x86;                                       // INS: for stored key input
            SendBuff[3] = 0x00;                                       // P2: for stored key input
            SendBuff[4] = 0x05;                                       // P3: for stored key input
            SendBuff[5] = 0x01;                                       // Byte 1: version number
            SendBuff[6] = 0x00;                                       // Byte 2
            SendBuff[7] = (byte)int.Parse("00");               // Byte 3: sectore no. for stored key input
            SendBuff[8] = 0x60;                                // Byte 4 : Key A for stored key input
            SendBuff[9] = byte.Parse("00", System.Globalization.NumberStyles.HexNumber, null);       // Byte 5 : Session key for volatile memory

            SendLen = 0x0A;
            RecvLen = 0x02;

            retCode = SendAPDUandDisplay(0);

            if (retCode == ModWinsCard.SCARD_S_SUCCESS)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
