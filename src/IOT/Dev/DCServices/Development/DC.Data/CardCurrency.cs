//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DC.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class CardCurrency
    {
        public CardCurrency()
        {
            this.CardCurrencyHistories = new HashSet<CardCurrencyHistory>();
        }
    
        public int CardCurrencyId { get; set; }
        public string CardId { get; set; }
        public int FiatCurrencyId { get; set; }
        public decimal Balance { get; set; }
        public System.DateTime LastModifiedDate { get; set; }
        public string LastModifiedUser { get; set; }
    
        public virtual Currency Currency { get; set; }
        public virtual ICollection<CardCurrencyHistory> CardCurrencyHistories { get; set; }
        public virtual Card Card { get; set; }
    }
}
