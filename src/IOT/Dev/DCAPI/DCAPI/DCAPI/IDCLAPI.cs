using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using DC.Common.Models;

namespace DCAPI
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IDCLAPI
    {

        [OperationContract]
        String SendBitcoins(String APIKEY, String FromCardId, String FromCardPublicAddress, String encryptedPrivateKey, String DestinationCardId, Decimal BitcoinAmount, Decimal FiatAmount, String Currency);

        [OperationContract]
        String PurchaseBitcoins(String APIKEY, String CardId, String FromCardPublicAddress, Decimal FiatAmount, String Currency);
        [OperationContract]
        Decimal GetSpotPrice(String APIKEY,String Currency, Decimal amount);

        [OperationContract]
        String ChkPINLimit(String APIKEY,String CardId, Decimal Fiatamount, String Currency);
        [OperationContract]
        String checkPin(String APIKEY, String CardId, String Pin);
        [OperationContract]
        Decimal GetBalance(String APIKEY, String PublicKey, int Confirmations);

        [OperationContract]
        DC.Common.Models.Keys CreatePublicEncryptedPrivateKey(String APIKEY);

        [OperationContract]

        String AddCardWithPinLimit(String APIKEY, String CardId, String PublicKey, String Password, String FirstName, String LastName, String Address, String City, String Zip, String State, String Country, String Telephone, String DOB, String EmailAddress, String CardHolderName, String CardNumber, String ExpiryMonth, String ExpiryYear, String CVC2, String PIN, String CurrencyCode, Decimal Limit, Boolean Topup);

        [OperationContract]
        Boolean IsCardOnFile(String APIKEY, String CardId);

        [OperationContract]
       String SendEmail(String APIKEY, String Email, String Subject, String Body);
        

        
    }

}
