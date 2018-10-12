using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Portal.Classes.Transfer
{
    public class EftElement : ITransferElement
    {
        EftDetails _eftDetails;

        public EftElement(EftDetails eftDetails, int currencyId, decimal amount)
        {
            _eftDetails = eftDetails;
            CurrencyId = currencyId;
            Amount = amount;
        }

        public int Identifier { get; set; }

        public decimal Amount { get; set; }

        public decimal TransactionTotal { get; set; }

        public int CurrencyId { get; set; }

        public DateTime TransferDate { get; set; }

        public string Reference { get; set; }

        public TransferAction ActionType { get; set; }

        public void Commit()
        {

        }

        public void Rollback()
        {

        }
    }
}