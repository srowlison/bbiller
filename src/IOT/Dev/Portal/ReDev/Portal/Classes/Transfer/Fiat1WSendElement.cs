using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DC.Data;
using WebMatrix.WebData;

namespace Portal.Classes.Transfer
{
    public class Fiat1WSendElement : ITransferElement
    {
        string _cardId;
        decimal? _balance;
        Currency _currencyType;

        /// <summary>
        /// Receiver element constructor
        /// </summary>
        /// <param name="cardId"></param>
        /// <param name="currencyId"></param>
        public Fiat1WSendElement(string cardId, int currencyId)
        {
            CurrencyId = currencyId;
            
            _cardId = cardId;
            ActionType = TransferAction.Credit;
        }

        /// <summary>
        /// Sender element constructor
        /// </summary>
        /// <param name="cardId"></param>
        /// <param name="currencyId"></param>
        /// <param name="amount"></param>
        public Fiat1WSendElement(string cardId, int currencyId, decimal amount)
        {
            _cardId = cardId;
            CurrencyId = currencyId;
            Amount = amount;
            ActionType = TransferAction.Debit;
        }

        public int Identifier { get; set; }

        public decimal Amount { get; set; }

        public decimal TransactionTotal { get; set; }

        public int CurrencyId { get; set; }

        public Currency CurrencyType 
        { 
            get 
            { 
                if(_currencyType == null)
                {
                    using(var db = new DiamondCircle_dbEntities())
                    {
                        _currencyType = db.Currencies.Where(c => c.CurrencyId == CurrencyId).First();
                    }
                }
                return _currencyType; 
            }
            set { _currencyType = value; } 
        }

        public DateTime TransferDate {
            get { return DateTime.UtcNow; }
            set { TransferDate = value; }
        }

        public string Reference { get; set; }

        public TransferAction ActionType { get; set; }

        public bool SufficientFunds()
        {            
            return GetBalance() > Amount;
        }


        public string Summary()
        {
            string summary;
            if (SufficientFunds())
            {
                summary = "Transfer from your OneWallet account: " + _currencyType.CurrencyAbbrev + Amount.ToString();
            }
            else
            {
                summary = "There are insufficient funds to transfer " + _currencyType.CurrencyAbbrev + Amount.ToString()
                        + "<br/> You have " + _currencyType.CurrencyAbbrev + GetBalance().ToString() + " available";
            }
            return summary;
        }


        public void Commit()
        {
            var newBalance = GetBalance() - Amount;
            using (var db = new DiamondCircle_dbEntities())
            {
                var card = db.Cards.Where(c => c.CardId == _cardId).First();
                card.CardCurrencies.Where(b => b.FiatCurrencyId == CurrencyId).First().Balance = (decimal) newBalance;
                db.SaveChanges();
            }
        }



        public void Rollback()
        {
            //Add the amount back to the new balance if a database transaction can't be done.
            //We should probably persist the full transaction details in case there is a system failure during transaction
        }


        private decimal? GetBalance()
        {
            if (_balance == null)
            {
                using (var db = new DiamondCircle_dbEntities())
                {
                    var card = db.Cards.Where(c => c.CardId == _cardId).SingleOrDefault();
                    return card.CardCurrencies.Where(b => b.FiatCurrencyId == CurrencyId).First().Balance;
                }
            }
            else
            {
                return _balance;
            }

        }

    }
}