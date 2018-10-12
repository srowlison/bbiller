using DC.Common.Models;
using System;
using System.ServiceModel;


namespace DC.Payment
{
    [ServiceContract(Namespace="https://payment.diamondcircle.net/v1")]
    public interface ICard
    {
        [OperationContract] 
        void AddCardWithPIN(string CardId, string PublicKey, string Password, string PIN);

        [OperationContract]
        void AddCard(string CardId, string PublicKey, string Password, string FirstName, string LastName, string Address, string City, string Zip, string State, string Country, string Telephone, string DOB, string EmailAddress, string CardHolderName, string CardNumber, string ExpiryMonth, string ExpiryYear, string CVC2);

        [OperationContract]
        CCInfo GetCustomerCC(string CardId);

        [OperationContract]
        bool IsCardOnFile(string CardId);

        [OperationContract(IsOneWay = false)]
        String GetHotWalletAddress();

        [OperationContract]
        Common.Models.OnlineAccount AddOnlineAccount();

        [OperationContract(IsOneWay = false)]
        Decimal WriteTransaction(string CardId, string TransType, Int32 TerminalId, string NumuratorCurrency, string DenominatorCurrency, decimal Amount, decimal Price, string Reference, int TransactionID);

        [OperationContract]
        bool CreateaPayment(string PaymentProvider);
    }
}
