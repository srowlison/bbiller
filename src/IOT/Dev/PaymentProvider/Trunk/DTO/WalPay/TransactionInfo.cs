using System;

namespace DC.PaymentProvider.DTO.WalPay
{
    [Serializable]
    public class TransactionInfo
    {
        public String OrderID { get; set; }

        public String OrderDescription { get; set; }

        public Decimal Amount { get; set; }

        public Int16 CurrencyCode { get; set; }

        public DateTime MerchantDateTime { get; set; }

        public override string ToString()
        {
            return String.Format("<TransactionInfo><OrderID>{0}</OrderID><OrderDescription>{1}</OrderDescription><Amount>{2}</Amount><CurrencyCode>978</CurrencyCode><MerchantDateTime>{3:yyyy-MM-dd HH:mm:ss}</MerchantDateTime></TransactionInfo>", this.OrderID, this.OrderDescription, this.Amount, this.MerchantDateTime);
        }
    }
}
