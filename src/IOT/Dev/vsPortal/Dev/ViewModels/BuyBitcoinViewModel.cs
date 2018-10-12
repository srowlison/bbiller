using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Portal.ViewModels
{
    public class BuyBitcoinViewModel
    {
        [Display(Name = "Price")]
        public Decimal Price { get; set; }

        public string CardId { get; set; }

        public int CustomerId { get; set; }

        [Display(Name = "Bitcoin amount to purchase")]
        public Decimal BitcoinAmount { get; set; }

        [Display(Name = "Currency")]
        public string Currency { get; set; }

        [Display(Name = "Credit card number")]
        public string CreditCardMask { get; set; }

        



    }
}