using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Portal.Classes.Transfer
{
    public class EftDetails
    {
        public EftDetails(string accountName, string accountNumber, string bsb, string reference)
        {
            AccountName = accountName;
            AccountNumber = accountNumber;
            Bsb = bsb;
            Reference = reference;

        }

        public string AccountName { get; set; }

        public string AccountNumber { get; set; }

        public string Bsb { get; set; }

        public string Reference { get; set; }


    }
}