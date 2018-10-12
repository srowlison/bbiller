using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DCPOS
{
    class DCCommon
    {
        public string SendBitcoins(String FromCardId, String FromCardPublicAddress, String encryptedPrivateKey, String DestinationCardId, Decimal BitcoinAmount, Decimal FiatAmount, String Currency)
        {

            // For the FromCardId, Obtain the password.
            String Password = "hyFHtsO7Q9kao1gPHq/0iQ==";

            // Check that the FromCardPublicAddress = what is in the cards table for this cardID
            String DBCardPublicAddress = FromCardPublicAddress;

            Boolean AutoTopUp = true;

            // For the DesintationCardId, obtain the DestinationAddress from the Cards Table
            String DestinationAddress = "1QJQMFhgyoiLLUZXpr913T2TaEaX7pNFaF";

            if (DBCardPublicAddress == DestinationAddress)
            {

                Card.CardClient card = new Card.CardClient();
                ATM.AtmClient atm = new ATM.AtmClient();
                Decimal CardBalance = atm.GetBalance(FromCardPublicAddress, 1);
                Decimal MinersFee = 0.0001M;
                if (CardBalance >= (BitcoinAmount + MinersFee))
                {
                    String result = atm.SendBitcoins(encryptedPrivateKey, Password, DestinationAddress, BitcoinAmount);
                    return result;
                }
                else
                {
                    if (AutoTopUp)
                    {

                        // Purchase more coins to cover the difference




                        DCExchange.ExchangeClient ExchangeClient = new DCExchange.ExchangeClient();
                        DCExchange.Margin margin = ExchangeClient.GetMargin(Currency, 0);
                        Decimal PurchaseBitcoinsAmount = FiatAmount * margin.Buy;

                        // PurchaseFiatAmount = PurchaseBitcoinsAmount; 

                        PurchaseBitcoins(FromCardId, DestinationAddress, FiatAmount, Currency);


                        //  Empty the wallet
                        String result = atm.SendBitcoins(encryptedPrivateKey, Password, DestinationAddress, CardBalance);

                        return "";

                    }
                    else
                    {
                        return "Refer to DD/CC Issuer";
                    }

                }
            }
            else
            {
                return "Invalid Card - Public Address does not match entry in Database.  Card may have been tampered with";
            }
            
        }
       public String PurchaseBitcoins(String CardId, String FromCardPublicAddress, Decimal FiatAmount, String Currency)
       {

           // Check that the FromCardPublicAddress = what is in the cards table for this cardID
           String DBCardPublicAddress = FromCardPublicAddress;

           if (DBCardPublicAddress == FromCardPublicAddress)
           {

               DCExchange.ExchangeClient ExchangeClient = new DCExchange.ExchangeClient();
               DCExchange.Margin margin = ExchangeClient.GetMargin(Currency, 0);
               Decimal PurchaseBitcoinsAmount = FiatAmount * margin.Buy;
               // Purchase Bitcoins from the CC card on file.
               Boolean PurchaseSuccess = true;
               if (PurchaseSuccess)
               {
                   ATM.AtmClient atm = new ATM.AtmClient();
                   atm.CreateOrder(FromCardPublicAddress, PurchaseBitcoinsAmount);
                   return "Approved";
               }
               return "Declined";
           }
           else
           {
               return "Invalid Card - Public Address does not match entry in Database.  Card may have been tampered with";
           }
       }

    }
}
