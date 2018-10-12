using System;
using System.Xml.Serialization;

namespace DC.PaymentProvider.DTO.WalPay
{
    [Serializable]
    public class MerchantRequest
    {
        //[XmlElement(ElementName = "MerchantInfo")]
        public IMerchantInfo MerchantInfo { get; set; }

        public TransactionInfo TransactionInfo { get; set; }

        public ClientInfo ClientInfo { get; set; }

        public PaymentInfo PaymentInfo { get; set; }

        public Secure3D Secure3D { get; set; }

        public override string ToString()
        {
            return String.Format(@"<MerchantRequest Simulate=""CardAuthoriseSuccess,RiskEvaluateSuccess"">{0}</MerchantRequest>", this.MerchantInfo);
        }
    }
}