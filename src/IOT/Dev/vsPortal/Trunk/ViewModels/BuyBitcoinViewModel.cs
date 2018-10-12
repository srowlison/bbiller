using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Portal.ViewModels
{
    public class BuyBitcoinViewModel
    {
        public Decimal Price { get; set; }

        public Decimal FiatBalance { get; set; }

        public string CardId { get; set; }


    }
}