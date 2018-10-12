using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DC.Data;
using Portal.ViewModels;

namespace Portal.Controllers
{
    [HandleError]
    public class BuyBitcoinController : Controller
    {
        //
        // GET: /BuyBitcoin/

        public ActionResult Index()
        {
            ViewModels.BuyBitcoinViewModel buyViewModel = new ViewModels.BuyBitcoinViewModel();
            buyViewModel.FiatBalance = 100;
            buyViewModel.Price = 660;

            return View(buyViewModel);
        }

        [HttpGet]
        public ActionResult BuyBitcoin(string cardId)
        {
            //Get the card for the passed cardId
            Card card;
            using (var db = new DiamondCircle_dbEntities())
            {
                card = db.Cards.Where(c => c.CardId == cardId).First();
            }
            
            //Check whether there is a credit card for that card set up
            if(!card.CreditCardId.HasValue)
            {
                //Redirect to set up a credit card
                return RedirectToAction("Create", "CreditCard", new { CardId = cardId, buy = true});
            }

            return View();
        }

        [HttpPost]
        public ActionResult BuyBitcoin(BuyBitcoinViewModel model)
        {
            string publicKey;
            CreditCard creditCard;

            using (var db = new DiamondCircle_dbEntities())
            {
                //Get the card
                var card = db.Cards.Where(c => c.CardId == model.CardId).First();
                publicKey = card.PublicKey;

                //Get the creditCard for this card
                creditCard = db.CreditCards.Where(c => c.CreditCardId == card.CreditCardId).First();

            }
            using (var atmClient = new DC.AtmService.AtmClient())
            {
                //TODO: Deduct credit card by converted fiat amount
               // var result = PinPaymentsCharge(creditCard)
                atmClient.CreateOrder(publicKey, model.Price);
            }
            return View();
        }

    //    private string PinPaymentsCharge(CreditCard creditCard)
    //    {
    //        // initialise PIN by passing your API Key
    //        // See:  https://pin.net.au/docs/api#keys
    //        PinPayments.PinService ps = new PinPayments.PinService(System.Configuration.ConfigurationManager.AppSettings["Secret_API"].ToString());
    //        // https://pin.net.au/docs/api/test-cards
    //        // 5520000000000000 - Test Mastercard
    //        // 4200000000000000 - Test Visa
    //        var card = new Card();
    //        card.CardNumber = CardNumber;
    //        card.CVC = CVC;
    //        card.ExpiryMonth = ExpiryMonth;
    //        card.ExpiryYear = ExpiryYear;
    //        card.Name = FirstName + " " + LastName;
    //        card.Address1 = Address1;
    //        card.Address2 = null;
    //        card.City = City;
    //        card.Postcode = Postcode;
    //        card.State = State;
    //        card.Country = Country;
    //        // TODO - iF THEY DON'T ENCODE THE CARD - ISSUE A REFUND
    //        try
    //        {
    //            Currency = "AUD"; // lblCurrency.Text;
    //            RefundAmount = Amount;
    //            var response = ps.Charge(new PostCharge { Amount = Amount, Card = card, Currency = Currency, Description = Desc, Email = "accounts@diamondcircle.net", IPAddress = Properties.Settings.Default.IPAddress });
    //            if (response.Charge.Status == "Success")
    //            {
    //                TransactionId = response.Charge.Token;

    //                return "Approved";
    //            }
    //            else
    //            {
    //                return "Fail";
    //            }


    //        }
    //        catch (Exception ex)
    //        {
    //            PrintErrorMessage("Error Charge your Card - Try again");
    //            return "Fail";

    //        }
    //    }

    }
}