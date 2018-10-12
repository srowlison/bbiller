using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Portal.Classes.Transfer
{
    public class CCDetails
    {
        public CCDetails(string cardType, string cardholderName, string cardNumber, string expiry, string code)
        {
            CardType = cardType;
            CardholderName = cardholderName;
            CardNumber = cardNumber;
            Expiry = expiry;
            Code = code;
        }

        public string CardType { get; set; }

        public string CardholderName { get; set; }

        public string CardNumber { get; set; }

        public string Expiry { get; set; }

        public string Code { get; set; }


    }
}