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
    
    public partial class OpenOrder
    {
        public decimal Id { get; set; }
        public decimal CustomerID { get; set; }
        public System.DateTime CreateDate { get; set; }
        public string OrderType { get; set; }
        public Nullable<System.DateTime> ValidTill { get; set; }
        public decimal Amount { get; set; }
        public decimal Price { get; set; }
        public string NumuratorCurrency { get; set; }
        public string DeominatorCurrency { get; set; }
    
        public virtual Customer Customer { get; set; }
    }
}
