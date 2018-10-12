using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitcoinATM
{
    class btcnfcfunctions
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

        public bool WriteNFCTag(string publicuri, string encryptedprivatekey)
        {

            string temp = publicuri;
            string temp2 = encryptedprivatekey;

        
            publicuri = "bitcoin:1EjdexVvxgjRjMNfkEdouNESrHm7P6i5tc";

            encryptedprivatekey = ":tN1xTTz2VmiDFUw66xmCSpwBisio5UAmLGdBa88yB4Jiqq905n5eZFn0sZBxfOyYnh5CWxocDA2QUDMagaj0XA==";

            
            int indx;

            string uri;

            //TO DO ADD FILE:// TO KEY

            uri = publicuri;


           string sizeOfURI = String.Format("{0:X2}", Convert.ToInt32(publicuri.Length));


           string headerndef = "0103A0104403899101" + sizeOfURI + "5500";
            
            char[] values = uri.ToCharArray();
            string MessagePayload = "";
            foreach (char letter in values)
            {
                MessagePayload += String.Format("{0:X2}", Convert.ToInt32(letter));
            }


            string nDEF = headerndef + MessagePayload;

            encryptedprivatekey = "dc:" + encryptedprivatekey;

            string strfile = String.Format("{0:X2}", encryptedprivatekey);

            values = strfile.ToCharArray();
            MessagePayload = "";
            foreach (char letter in values)
            {
                MessagePayload += String.Format("{0:X2}", Convert.ToInt32(letter));
            }

            // 4D IS THE SIZE

            headerndef = "520256";

            nDEF += headerndef + MessagePayload; // + MessageTerminator;
            

            
            // Need to pad this out cause the mininmum write size is 4 bytes
            double value4 = Convert.ToDouble(nDEF.Length) / 8;
            double nrecords = Math.Ceiling(Convert.ToDouble(nDEF.Length) / 8);
            int i;
            double fraction = value4 - (int)value4;
            if (fraction > 0)
            {
                string padstring = "0";
                double qpaddings = 8 - ((value4 - (nrecords - 1)) * 8);
                for (i = 1; i <= qpaddings; i++)
                {
                    nDEF += padstring;
                }
            }

            indx = 1;
                

            for (indx = 1; indx <= nrecords; indx++)
            {

                int endstring = Convert.ToInt16(value4 - (nrecords - 1) * 8) + 7;
                if (endstring == 0)
                {
                    endstring = 8;
                }

                string strWrite = nDEF.Substring((indx * 8) - 8, 8);
                // string strWrite = nDEF.ToString();

                int NextIndex = indx + 3;

                Writeblock(NextIndex.ToString(), strWrite);
                }
            // Read Only
         //    Writeblock(2.ToString(), "3848FFFF");
           // Writeblock(3.ToString(), "E110120F");
            return true;

        }



        private void Writeblock(string BlockNo, string hexValues)
        {
            string tmpStr = "";
            string strlength;
            int indx;
            hexValues = hexValues.Trim();
            string hexval = "";
            int i;
            for (i = 0; i <= hexValues.Length - 1; i = i + 2)
            {

                hexval = hexValues.Substring(i, 2);
                // Convert the number expressed in base-16 to an integer. 
                int value = Convert.ToInt32(hexval, 16);
                char charValue = (char)value;
                tmpStr += charValue;
                int ui = tmpStr.Length;
            }

            strlength = Convert.ToString(tmpStr.Length);


            ClearBuffers();
            SendBuff[0] = 0xFF;                                     // CLA
            SendBuff[1] = 0xD6;                                     // INS
            SendBuff[2] = 0x00;                                     // P1
            SendBuff[3] = (byte)int.Parse(BlockNo);            // P2 : Starting Block No.
            SendBuff[4] = (byte)int.Parse(strlength);            // P3 : Data length

            for (indx = 0; indx <= (tmpStr).Length - 1; indx++)
            {

                SendBuff[indx + 5] = (byte)tmpStr[indx];

            }
            SendLen = SendBuff[4] + 5;
            RecvLen = 0x02;

            retCode = SendAPDUandDisplay(2);

            if (retCode != ModWinsCard.SCARD_S_SUCCESS)
            {

                return;

            }
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

            pioSendRequest.dwProtocol = Aprotocol;
            pioSendRequest.cbPciLength = 8;

            // Display Apdu In
            String tempString = "";
            for (indx = 0; indx <= SendLen - 1; indx++)
            {
                tempString += " " + string.Format("{0:X2}", SendBuff[indx]);
            }

            // displayOut(2, 0, tmpStr);
            retCode = ModWinsCard.SCardTransmit(hCard, ref pioSendRequest, SendBuff, SendLen, ref pioSendRequest, RecvBuff, ref RecvLen);

            if (retCode != ModWinsCard.SCARD_S_SUCCESS)
            {
                return retCode;
            }
            else
            {
                tempString = "";
                switch (reqType)
                {

                    case 0:
                        {
                            for (indx = (RecvLen - 2); indx <= (RecvLen - 1); indx++)
                            {
                                tempString = tempString + " " + string.Format("{0:X2}", RecvBuff[indx]);
                            }


                            if ((tempString).Trim() != "90 00")
                            {

                                //               displayOut(4, 0, "Return bytes are not acceptable.");

                            }

                            break;
                        }

                    case 1:
                        {
                            for (indx = (RecvLen - 2); indx <= (RecvLen - 1); indx++)
                            {

                                // tmpStr = tmpStr + string.Format("{0:X2}", RecvBuff[indx]);

                            }


                            if (tempString.Trim() != "90 00")
                            {

                                // tmpStr = tmpStr + " " + string.Format("{0:X2}", RecvBuff[indx]);
                            }

                            else
                            {

                                tempString = "ATR : ";
                                for (indx = 0; indx <= (RecvLen - 3); indx++)
                                {

                                    tempString = tempString + " " + string.Format("{0:X2}", RecvBuff[indx]);

                                }

                            }

                            break;
                        }

                    case 2:
                        {
                            for (indx = 0; indx <= (RecvLen - 1); indx++)

                                                       {

                           //     tmpStr = tmpStr + " " + string.Format("{0:X2}", RecvBuff[indx]);

                            }

                            break;
                        }

                }

                // displayOut(3, 0, tmpStr.Trim() + "\r\n");

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
                //             displayOut(0,0,"Successful connection to " + cbReader.Text);
                connActive = true;
                return true;
            }

            else
            {
                //               displayOut(0, 0, ModWinsCard.GetScardErrMsg(retCode));
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
            bool bnone = ReadBlocks("9", "16", ref PartKey);     // 9,10,11,12
            PublicKey += PartKey;


            bnone = ReadBlocks("13", "16", ref PartKey);        // 13,14,15,16
            PublicKey += PartKey;


            bnone = ReadBlocks("17", "4", ref PartKey);        // 17
            PublicKey += PartKey;


            bnone = ReadBlocks("6", "4", ref PartKey);
            string KeysizeLength = PartKey.Substring(3, 2);

            int KeySize = Convert.ToInt32(KeysizeLength, 16);

            PublicKey = PublicKey.Substring(0, KeySize);

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
            string strStart = "52025664633A";
            string strEnd = "00000000";

            int Start, End;
            if (PrivateKey.Contains(strStart) && PrivateKey.Contains(strEnd))
            {
                Start = PrivateKey.IndexOf(strStart, 0) + strStart.Length;
                End = PrivateKey.IndexOf(strEnd, Start);
                PrivateKey.Substring(Start, End - Start);
        
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
            if (ReadBlocks("0","8", ref TagId))
            {
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
    }
}
