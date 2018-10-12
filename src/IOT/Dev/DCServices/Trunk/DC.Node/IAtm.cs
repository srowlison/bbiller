using System;
using System.ServiceModel;
using DC.Common.Models;

namespace DC.Node
{
    [ServiceContract(Namespace="http://schema.diamondcircle.net/v1")]
    public interface IAtm
    {
        [OperationContract]
        Keys CreatePublicEncryptedPrivateKey();

        [OperationContract]
        Order CreateOrder(String publicKey, Decimal amount);

        [OperationContract]
        String TransferCoinsToBuyer(String cardId, Decimal amount);

        [OperationContract]
        String ReceiveCoins(String encryptedPrivateKey, String cardId, String destinationAddress, Decimal amount);

        [OperationContract]
        Decimal GetBalance(String address, Int16 confirmations = 6);

        [OperationContract]
        int GetConfirmations(String publicKey);

        [OperationContract]
        String ResolvePrivateKey(String encryptedPrivateKey, String password);

        [OperationContract]
        String SendBitcoins(String encryptedPrivateKey, String password, String destinationAddress, Decimal amount);

        [OperationContract]
        void SendEmail(String toAddress, String subject, String body);       
    }
}

