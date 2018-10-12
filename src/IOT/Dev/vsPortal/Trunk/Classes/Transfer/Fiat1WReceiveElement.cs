using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DC.Data;
using WebMatrix.WebData;

namespace Portal.Classes.Transfer
{
    public class Fiat1WReceiveElement : ITransferElement
    {
        string _cardId;
        decimal? _balance;
        Currency _currencyType;

        /// <summary>
        /// Receiver element constructor
        /// </summary>
        /// <param name="cardId"></param>
        /// <param name="currencyId"></param>
        public Fiat1WReceiveElement(string cardId, int currencyId)
        {
            CurrencyId = currencyId;
            
            _cardId = cardId;
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

        public DateTime TransferDate { get; set; }

        public string Reference { get; set; }

        public TransferAction ActionType { get; set; }

        public bool SufficientFunds()
        {            
            return GetBalance() > Amount;
        }


        public string Summary()
        {
            string summary = "";
            return summary;
        }


        public virtual void Commit()
        {
        }

        public void Rollback()
        {

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