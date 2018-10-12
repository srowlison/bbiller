using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DC.Data;
using Portal.ViewModels;
using Portal.Filters;
using Portal.Classes;
using DCPayment = DC.Payment;


namespace Portal.Controllers
{
    [HandleError]
    [InitializeSimpleMembershipAttribute]
    [Authorize]
    [RequireHttps]
    public class BuyBitcoinController : Controller
    {
        
        [HttpGet]
        public ActionResult BuyBitcoin(string cardId)
        {
            if(string.IsNullOrEmpty(cardId))
            {
                return RedirectToAction("Index", "Transfer");
            }

            //Get the card for the passed cardId
            Card card;
            using (var db = new DiamondCircle_dbEntities())
            {
                card = db.Cards.Where(c => c.CardId == cardId).FirstOrDefault();
                if(card == null)
                {
                    return RedirectToAction("Index", "Transfer");
                }
            }
            
            //Check whether there is a credit card for that card set up
            if(!card.CreditCardId.HasValue)
            {
                //Redirect to set up a credit card
                return RedirectToAction("Create", "CreditCard", new { CardId = cardId, redirectUrl = "BuyBitcoin,BuyBitcoin" });
            }

            var model = new BuyBitcoinViewModel() { CardId = cardId, CreditCardMask = CardStatus.MaskCardNumber(card.CreditCard.CardNumber) };
            return View();
        }
        

        [HttpPost]
        public ActionResult BuyBitcoin(BuyBitcoinViewModel model)
        {
            //Get a quote of the fiat price for the given bitcoin amount
            var exchange = new DCPayment.Exchange();

            if (ModelState.IsValid)
            {
                var price = exchange.GetSpotPrice(model.Currency, model.BitcoinAmount, 1);
                model.Price = price;

                return RedirectToAction("ConfirmBuyBitcoin", model);

            }

            return View(model);
        }


        [HttpGet]
        [ActionName("ConfirmBuyBitcoin")]
        public ActionResult ConfirmBuyBitcoin_Get(BuyBitcoinViewModel model)
        {
            //Show buy summary
            return View(model);
        }

        [HttpPost]
        [ActionName("ConfirmBuyBitcoin")]
        public ActionResult ConfirmBuyBitcoin_Buy(BuyBitcoinViewModel model)
        {
            string publicKey;
            CreditCard creditCard;

            using (var db = new DiamondCircle_dbEntities())
            {
                var customerId = Helpers.GetLoggedInCustomerId(db);
                //Get the card
                var card = db.Cards.Where(c => (c.CardId == model.CardId && c.CustomerID == customerId)).First();
                publicKey = card.PublicKey;

                //Get the creditCard for this card
                creditCard = db.CreditCards.Where(c => c.CreditCardId == card.CreditCardId).First();

            }
            //TODO: Change to service reference when published
            //using (var atmClient = new DC.AtmService.AtmClient())
            var atmClient = new DCPayment.Card();
            {

                atmClient.PayForAndBuyBitcoin(model.CardId, model.BitcoinAmount, model.Currency, model.Price, 1);
            }
            return View();
        }


        [HttpGet]
        [ActionName("ConfirmBuyBitcoin")]
        public ActionResult BuyBitcoinSuccessful_Get(BuyBitcoinViewModel model)
        {
            //Display purchase summary
            return View();
        }

        [HttpPost]
        [ActionName("ConfirmBuyBitcoin")]
        public ActionResult BuyBitcoinSuccessful_Post(BuyBitcoinViewModel model)
        {
            //Redirect to Card list summary page
            return RedirectToAction("Index", "Transfer");
        }
        
    }
}