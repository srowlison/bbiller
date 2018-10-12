using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using DC.Data;
using DC.Common.Models;




namespace DCAPI
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class DCLAPI : IDCLAPI
    {
        public DC.Common.Models.Keys CreatePublicEncryptedPrivateKey(String APIKEY)

        {
            
            
          ATM.AtmClient atm = new ATM.AtmClient();
        
          DC.Common.Models.Keys Key = new Keys();
          
            // Key = atm.CreatePublicEncryptedPrivateKey();
          //  DC.Common.Models.Keys key =  atm.CreatePublicEncryptedPrivateKey();



          return (Key);
        }
        public Decimal GetSpotPrice(String APIKEY, String Currency, Decimal amount)
        {
            // This function includes the margin.  Add GetSpotPriceNoMargin
            Exchange.ExchangeClient ExchangeClient = new Exchange.ExchangeClient();
            decimal bitcoins = ExchangeClient.GetSpotPrice(Currency, amount, 0);
            return (bitcoins);

        }

        public String ChkPINLimit(String APIKEY, String CardId, Decimal Fiatamount, String Currency)
        {

            // Query Card table for DBCardLimit and for the cards default Fiat Currency

            Decimal DBCardLimit = 100;
            if (Fiatamount > DBCardLimit)
            {

                return "01"; // Pin Required.
            }
            else
            {
                return "00"; // 00 - Pin Not required.
            }

            // 03 - Unknown Error
        }

        public string checkPin(String APIKey, String CardId, String Pin)
        {
            // For the FromCardId, Obtain the Pin.
            String DBPin = Pin;

            if (Pin == DBPin)
            {
                return "00"; // PIN Valid

            }
            return "01";//Invalid
        }

        public Decimal GetBalance(String APIKEY, String PublicKey, Int32 Confirmations)
        {
            
            ATM.AtmClient atm = new ATM.AtmClient();

            return(atm.GetBalance(PublicKey, 1));
            
        }

        public string SendBitcoins(String APIKEY, String FromCardId, String FromCardPublicAddress, String encryptedPrivateKey, String DestinationCardId, Decimal BitcoinAmount, Decimal FiatAmount, String Currency)

        {
          //  using (DC.Data.DiamondCircle_dbEntities db = new DC.Data.DiamondCircle_dbEntities())
          //  {

          //  }

            

            
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


                        Exchange.ExchangeClient ExchangeClient = new Exchange.ExchangeClient();
                        Exchange.Margin margin = ExchangeClient.GetMargin(Currency, 0);
                        Decimal PurchaseBitcoinsAmount = FiatAmount * margin.Buy;

                        // PurchaseFiatAmount = PurchaseBitcoinsAmount; 

                        PurchaseBitcoins(APIKEY, FromCardId, DestinationAddress, FiatAmount, Currency);


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
        public String PurchaseBitcoins(String APIKEY, String CardId, String FromCardPublicAddress, Decimal FiatAmount, String Currency)
       {

           // Check that the FromCardPublicAddress = what is in the cards table for this cardID
           String DBCardPublicAddress = FromCardPublicAddress;

           if (DBCardPublicAddress == FromCardPublicAddress)
           {

               Exchange.ExchangeClient ExchangeClient = new Exchange.ExchangeClient();
               Exchange.Margin margin = ExchangeClient.GetMargin(Currency, 0);
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
        public Boolean IsCardOnFile(String APIKEY,String CardId)
        {
            Card.CardClient card = new Card.CardClient();
            return (card.IsCardOnFile(CardId));

        }
        public String AddCardWithPinLimit(String APIKEY, String CardId, String PublicKey, String Password, String FirstName, String LastName, String Address, String City, String Zip, String State, String Country, String Telephone, String DOB, String EmailAddress, String CardHolderName, String CardNumber, String ExpiryMonth, String ExpiryYear, String CVC2, String PIN, String CurrencyCode, Decimal Limit, Boolean Topup)
    {
        Card.CardClient card = new Card.CardClient();

        // AddCardWithPINL(string CardId, string PublicKey, string Password, string PIN, string CurrencyCode, decimal Limit, bool Topup);

        // card.AddCardWithPINLimit()
      

        return "";

    }
        public String SendEmail(String APIKEY, String Email, String Subject, String Body)
        {
            ATM.AtmClient atm = new ATM.AtmClient();
            atm.SendEmailAsync(Email, Subject, Body);
            return "ok";
        }
        
    }
}
