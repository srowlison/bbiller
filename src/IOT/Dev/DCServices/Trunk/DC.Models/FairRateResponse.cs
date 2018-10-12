using System;
using System.Runtime.Serialization;

namespace DC.Common.Models
{
    [DataContract]
    public class FairRateResponse
    {
        [DataMember(Name = "bit")]
        public Decimal Bit { get; set; }

        [DataMember(Name = "ask")]
        public Decimal Ask { get; set; }

        [DataMember(Name = "spot")]
        public Decimal Spot { get; set; }
    }
}