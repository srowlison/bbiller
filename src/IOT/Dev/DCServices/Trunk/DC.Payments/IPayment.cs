using System;
using System.ServiceModel;

namespace DC.Payment
{
    [ServiceContract(Namespace = "https://payment.diamondcircle.net/v1")]
    interface IPayment
    {
        [OperationContract(IsOneWay = false)]
        Decimal WriteTransaction(string CardId, string TransType, string TerminalId, string NumuratorCurrency, string DenominatorCurrency, decimal Amount, decimal Price, string Reference, int TransactionID);

        [OperationContract]
        bool CreateaPayment(string PaymentProvider);
    }
}