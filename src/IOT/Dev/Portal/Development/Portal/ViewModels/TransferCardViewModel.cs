using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Portal.ViewModels
{
    public class TransferCardViewModel
    {
        public string CardId { get; set; }
        public string PublicKey { get; set; }
        public string PrivateKey { get; set; }
        public string Password { get; set; }
        public string Status { get; set; }
        public string TempPublicKey { get; set; }
        public decimal CustomerId { get; set; }
        public DateTime DateIssued { get; set; }
        public string FormattedDateIssued
        {
            get
            {
                return DateIssued.ToString("yyyy-MM-dd HH:mm:ss");
            }
        }
        public Decimal BalanceBTC { get; set; }
        public Decimal BalanceAUD { get; set; }
    }
}