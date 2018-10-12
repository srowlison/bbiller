using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using DC.Providers;
using DC.Common.Models;


namespace Portal.ViewModels
{
    public class TransactionHistoryViewModel : ITransaction
    {

        public int TransactionId { get; set; }
        public string CardId { get; set; }
        public string TransType { get; set; }
        public string Sender { get; set; }
        public string Receiver { get; set; }
        public string Status { get; set; }
        public int CustomerId { get; set; }
        public decimal NumeratorCurrency { get; set; }
        public decimal DenominatorCurrency { get; set; }
        public DateTime DateIssued { get; set; }
        public string FormattedDateIssued
        {
            get
            {
                return DateIssued.ToString("yyyy-MM-dd HH:mm:ss");
            }
        }
        public Decimal Amount { get; set; }
        public Decimal Price { get; set; }
        public string Reference { get; set; }


        public UnspentResponse GetUnspentTxns(string address)
        {
            throw new NotImplementedException();
        }
    }
}