using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Portal.Classes.Transfer
{
    public class CCElement : ITransferElement
    {
        CCDetails _cardDetails;
        string _cardId;

        public CCElement(CCDetails cardDetails, string cardId, decimal amount )
        {
            _cardDetails = cardDetails;
            _cardId = cardId;
            Amount = amount;

        }

        public int Identifier { get; set; }

        public decimal Amount { get; set; }

        public decimal TransactionTotal { get; set; }

        public int CurrencyId { get; set; }

        public DateTime TransferDate { get; set; }

        public string Reference { get; set; }

        public bool SufficientFunds()
        {
            throw new NotImplementedException();
        }

        public string Summary()
        {
            throw new NotImplementedException();
        }

        public TransferAction ActionType { get; set; }

        public void Commit()
        {

        }

        public void Rollback()
        {

        }
    }
}