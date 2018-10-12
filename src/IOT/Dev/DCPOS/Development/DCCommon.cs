using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using DC.Common.Models;


namespace DCPOS
{
    class DCCommon

    {
        private dclapi.IDCLAPI dcl = new dclapi.DCLAPIClient();
     //   private Localdclapi.IDCLAPI dcl = new Localdclapi.DCLAPIClient();
        


        public DCPOS.INFC nfc = DCPOS.Factory.GetNFC();
        
  



        public Decimal getbalance(String PublicKey, Int32 Confirmations)
        {
            
            return (dcl.GetBalance("",PublicKey,Confirmations));
            
        }
        public Decimal getquote(Decimal amount, String Currency)
        {
            return (dcl.GetSpotPrice("", Currency, amount));
       
        }

        public String ChkPINLimit(String CardId, Decimal Fiatamount, String Currency)
        {
            return (dcl.ChkPINLimit("", CardId, Fiatamount, Currency));
        }
        public string checkPin(String CardId, String Pin)
        {
            return(dcl.checkPin("",CardId, Pin));
        }

        public Decimal getspotprice(String Currency, Decimal Amount)
        {
            return (dcl.GetSpotPrice("", Currency, Amount));
        }

        public string SendBitcoins(String FromCardId, String FromCardPublicAddress, String encryptedPrivateKey, String DestinationCardId, Decimal BitcoinAmount, Decimal FiatAmount, String Currency)
        {
            return (dcl.SendBitcoins("", FromCardId, FromCardPublicAddress, encryptedPrivateKey, DestinationCardId, BitcoinAmount, FiatAmount, Currency));
        }
       public String PurchaseBitcoins(String CardId, String FromCardPublicAddress, Decimal FiatAmount, Decimal BitcoinAmount, String Currency)
       {
           return (dcl.PurchaseBitcoins("", CardId, FromCardPublicAddress, FiatAmount, BitcoinAmount, Currency));
       }

   //    public Localdclapi.Keys CreatePublicEncryptedPrivateKey()
    //   {
    //       return (dcl.CreatePublicEncryptedPrivateKey(""));

    //   }


        public dclapi.Keys CreatePublicEncryptedPrivateKey()
        {
           return (dcl.CreatePublicEncryptedPrivateKey(""));

       }

     public Boolean IsCardOnFile(String CardId)
       {
         return (dcl.IsCardOnFile("", CardId));

       }

     public String AddCardWithPinLimit(String CardId, String PublicKey, String Password, String FirstName, String LastName, String Address, String City, String Zip, String State, String Country, String Telephone, String DOB, String EmailAddress, String CardHolderName, String CardNumber, String ExpiryMonth, String ExpiryYear, String CVC2, String PIN, String CurrencyCode, Decimal Limit, Boolean Topup, Decimal TopUpAmount)
    {
        return (dcl.AddCardWithPinLimit("", CardId, PublicKey, Password, FirstName, LastName, Address, City, Zip, State, Country, Telephone, DOB, EmailAddress, CardHolderName, CardNumber, ExpiryMonth, ExpiryYear, CVC2, PIN, CurrencyCode, Limit, Topup, TopUpAmount));

    }
     public String SendEmail( String Email, String Subject, String Body)
     {
         return (dcl.SendEmail("", Email, Subject, Body));

     }



    }
}
