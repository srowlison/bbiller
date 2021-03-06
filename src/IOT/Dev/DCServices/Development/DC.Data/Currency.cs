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
    
    public partial class Currency
    {
        public Currency()
        {
            this.CardCurrencies = new HashSet<CardCurrency>();
            this.CommissionCharges = new HashSet<CommissionCharge>();
            this.CreditCardCharges = new HashSet<CreditCardCharge>();
            this.FiatBalances = new HashSet<FiatBalance>();
        }
    
        public int CurrencyId { get; set; }
        public string CurrencyAbbrev { get; set; }
        public string CurrencyDescription { get; set; }
        public System.DateTime LastModifiedDate { get; set; }
        public string LastModifiedUser { get; set; }
        public string Status { get; set; }
        public int CountryId { get; set; }
    
        public virtual ICollection<CardCurrency> CardCurrencies { get; set; }
        public virtual country country { get; set; }
        public virtual ICollection<CommissionCharge> CommissionCharges { get; set; }
        public virtual ICollection<CreditCardCharge> CreditCardCharges { get; set; }
        public virtual ICollection<FiatBalance> FiatBalances { get; set; }
    }
}
