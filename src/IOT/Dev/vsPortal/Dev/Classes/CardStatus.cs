using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Portal.Classes
{
    public static class CardStatus
    {
        public const string ACTIVE = "ACTIVE";
        public const string CANCELLED = "CANCELLED";
        public const string PENDING = "PENDING";
        
        public static string MaskCardNumber(string cardNumber)
        {
            return String.Concat("xxxx xxxx xxxx ", cardNumber.Substring(cardNumber.Length - 5, cardNumber.Length));
        }

    }
}