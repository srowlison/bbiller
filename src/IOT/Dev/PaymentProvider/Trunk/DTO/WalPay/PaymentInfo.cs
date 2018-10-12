using System;
using System.ComponentModel.DataAnnotations;

namespace DC.PaymentProvider.DTO.WalPay
{
    [Serializable]
    public class PaymentInfo
    {
        [Required]
        public String PAN { get; set; }

        [Required]
        public DateTime ExpiryDate { get; set; }

        public String CardHolderName { get; set; }

        [Required]
        [RegularExpression("^[0-9]{1,6}")]
        public String CVC2 { get; set; }

        public DateTime StartDate { get; set; }

        public Int16 IssueNumber { get; set; }

        public override string ToString()
        {
            return String.Format("<PaymentInfo><PAN>{0}</PAN><ExpiryDate>{1:yyyy-MM}</ExpiryDate><CardHolderName>B Smith</CardHolderName><CVC2>123</CVC2><StartDate/><IssueNumber/></PaymentInfo>", this.PAN, this.ExpiryDate);
        }
    }
}
