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
    
    public partial class Terminal
    {
        public int Id { get; set; }
        public string Location { get; set; }
        public Nullable<decimal> Longitude { get; set; }
        public Nullable<decimal> Latitude { get; set; }
        public string Description { get; set; }
        public bool Enabled { get; set; }
        public string Version { get; set; }
        public System.DateTime Created { get; set; }
        public string SerialNumber { get; set; }
        public string DefaultFiatCurrency { get; set; }
        public string DefaultCryptoCurrency { get; set; }
    }
}
