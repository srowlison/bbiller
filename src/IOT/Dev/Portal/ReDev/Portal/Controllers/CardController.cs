using System;
using Portal.Filters;
using Portal.ViewModels;
using Portal.Classes;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMatrix.WebData;
using Portal.Models;
using DC.Data;

namespace Portal.Controllers
{
    [HandleError]
    [InitializeSimpleMembershipAttribute]
    [Authorize]
    [RequireHttps]
    public class CardController : Controller
    {
        private DiamondCircle_dbEntities db = new DiamondCircle_dbEntities();

        private String _userIdentity = "";
        public String UserIdentity
        {
            get 
            { 
                if (String.IsNullOrEmpty(_userIdentity))
                {
                    _userIdentity = WebSecurity.CurrentUserId.ToString(); 
                }

                return _userIdentity;
            }
            set { _userIdentity = value; }
        }

        //
        // GET: /Card/

        public ActionResult Index()
        {
            var cards = db.Cards.Where(c => c.Customer.UserId == UserIdentity && (c.Status == CardStatus.ACTIVE || c.Status == CardStatus.PENDING));
            return View(cards.ToList());
        }

        //
        // GET: /Card/Details/5

        public ActionResult Details(string id = null)
        {
            Card card = db.Cards.Find(id);
            if (card == null)
            {
                return HttpNotFound();
            }
            return View(card);
        }

        
        /// <summary>
        /// Lists the balances of each currency for the given card
        /// </summary>
        /// <param name="card"></param>
        /// <returns></returns>
        public ActionResult Balances(Card card)
        {
            if (card != null)
            {
                var balances = db.CardCurrencies.Include(f => f.CardId == card.CardId  );
                return View(balances.ToList()[0].Currency.CurrencyAbbrev);
            }
            else
            {
                ModelState.AddModelError("NoCard", "There was no wallet selected");
                return View();
            }
        }

        

        /// <summary>
        /// Lists the transaction history for the selected currency for the given card
        /// </summary>
        /// <param name="card"></param>
        /// <returns></returns>
        public ActionResult FiatHistory(int cardCurrencyId)
        {
            try
            {
                var balances = db.CardCurrencies.Where(f => f.CardCurrencyId == cardCurrencyId);
                return View(balances.ToList()[0].Currency.CurrencyAbbrev);
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("RecordsNotFound", "No records were found");
                return View();
            }
        }


        //
        // GET: /Card/Create

        public ActionResult Create()
        {
            ViewBag.CustomerID = new SelectList(db.Customers, "CustomerId", "UserId");
            return View();
        }


        //
        // GET: /Card/Edit/5

        public ActionResult Edit(string publicKey = null)
        {
            Card card = db.Cards.FirstOrDefault(c => c.PublicKey == publicKey);
            if (card == null)
            {
                return HttpNotFound();
            }
            ViewBag.CustomerID = new SelectList(db.Customers, "CustomerId", "UserId", card.CustomerID);
            return View(card);
        }

        //
        // POST: /Card/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Card card)
        {
            if (ModelState.IsValid)
            {
                db.Entry(card).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CustomerID = new SelectList(db.Customers, "CustomerId", "UserId", card.CustomerID);
            return View(card);
        }

        //
        // GET: /Card/Delete/5

        public ActionResult Delete(string id = null)
        {
            Card card = db.Cards.Find(id);
            if (card == null)
            {
                return HttpNotFound();
            }
            return View(card);
        }

        //
        // POST: /Card/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Card card = db.Cards.Find(id);
            db.Cards.Remove(card);
            db.SaveChanges();
            return RedirectToAction("Index");
        }



        // GET: /Card/Activate
        public ActionResult Activate()
        {
            var card = new Card();
            return View(card);
        }


        /// <summary>
        /// Handles the activation of both an ATM issued card, or a TempPublicKey issued card
        /// </summary>
        /// <param name="card"></param>
        /// <returns></returns>
        [HttpPost, ActionName("Activate")]
        [ValidateAntiForgeryToken]
        public ActionResult Activate(Card card)
        {
            try
            {
                Card cardResult = db.Cards.FirstOrDefault(c => c.CardId == card.CardId);
                
                if (cardResult != null)
                {
                    var userId = this.UserIdentity;

                    var customer = db.Customers.Where(s => s.UserId == userId).SingleOrDefault();

                    if (customer != null)
                    {
                        if (cardResult.CustomerID == null)
                        {
                            cardResult.CustomerID = customer.CustomerId;

                            if (cardResult.TempPublicKey != null)
                            {
                                //If the card has a temporary public key, we need to do a special activation
                                var keys = GetKeys();
                                cardResult.Password = keys.Password;
                                cardResult.PublicKey = keys.PublicKey;
                                cardResult.Status = CardStatus.PENDING;
                                db.SaveChanges();
                                SendConfirmationEmail(cardResult, keys.PrivateKey);
                            }
                            else
                            {
                                //This is a standard activation for an ATM issued card. Simply attach a customerId to the card
                                db.SaveChanges();
                                TempData["Msg"] = "Your card has been successfully activated.";
                            }
                        }
                        else
                        {
                            ModelState.AddModelError("Error", "This card has already been activated. If you have another card that needs activation, please enter the ID.");
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("Error", "Customer not found.");
                    }
                }
                else
                {
                    ModelState.AddModelError("Error", "The card  with this ID could not be found. Please check and try again.");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Error", "Activation failed due to a problem with our servers. We are dealing with the issue. Please try again later.");
            }

            return View(card);
        }

        /// <summary>
        /// Generates the keys necessary to create an active card
        /// </summary>
        /// <returns></returns>
        public TransferCardViewModel GetKeys()
        {
            TransferCardViewModel viewModelCard = new TransferCardViewModel();

            using (var atmClient = new DC.AtmService.AtmClient())
            {
                var cardClient = new DC.CardService.CardClient();
                var keys = atmClient.CreatePublicEncryptedPrivateKey();
                
                viewModelCard.Password = Convert.ToBase64String(keys.Password);
                viewModelCard.PublicKey = keys.PublicKey;
                viewModelCard.DateIssued = DateTime.Now;
                viewModelCard.PrivateKey = Convert.ToBase64String(keys.EncryptedWIFPrivateKey);

                return viewModelCard;
            }
        }

        /// <summary>
        /// A confirmation email is sent with the private key. We need to ensure that they
        /// get it, otherwise the private key is lost. So they need to click a link in the email 
        /// before it is fully activated
        /// </summary>
        /// <param name="card"></param>
        /// <param name="privateKey"></param>
        private void SendConfirmationEmail(Card card, string privateKey)
        {
            var userId = int.Parse(WebSecurity.CurrentUserId.ToString());

            var user = db.UserProfiles.Where(s => s.UserId == userId).SingleOrDefault();
            var userDetail = db.UserDetails.Where(s => s.UserId == userId).SingleOrDefault();

            //Store a token to relate the link back to the correct card.
            //It doesn't have to be particularly secure. They are just confirming that the email was sent to them.
            var confirmationToken = CreateRandomToken();
            var token = new Token();
            token.TokenKey = card.CardId;
            token.TokenValue = confirmationToken;
            db.Tokens.Add(token);
            db.SaveChanges();

            //Send cofirmation email
            string emailtxt = "Dear " + user.UserName
                    + ",\n\r Your card number is :  "
                    + card.CardId
                    + ",\n\r Your Bitcoin address is :  "
                    + card.PublicKey
                    + "\n\r Your Private Key is :  "
                    + privateKey
                    + "\n\r PLEASE NOTE THAT WE DO NOT STORE YOUR PRIVATE KEY. PLEASE KEEP THIS PRIVATE KEY SAFE. You will need it to access your OneWallet. \n\r  "
                    + "\n\r Copy the link below into your browser address bar and press Enter to follow the link to complete the activation of your OneWallet \n\r  "
                    
            + string.Format("{0}://{1}{2}", Request.Url.Scheme, Request.Url.Authority, Url.Content("~")) + "Card/ConfirmCard/?str=" + confirmationToken + " \n\r \n\r  Regards," + " \n\r \n\r  The Diamond Circle team"; 

            SendEmail.Send("Diamond Circle", userDetail.Email, "Diamond Circle card activation", emailtxt);

            TempData["Msg"] = "A card activation confirmation has been sent to your email address. Please follow the link in the email to confirm that you have received your private key and complete the activation.";

        }

        private string CreateRandomToken()
        {
            string token;

            using (var atmClient = new DC.AtmService.AtmClient())
            {
                var keys = atmClient.CreatePublicEncryptedPrivateKey();
                token = keys.PublicKey;
            }

            return  token;
        }

        [AllowAnonymous]
        public ActionResult ConfirmCard(string str)
        {
            try
            {                
                var confirmationToken = str;
                //make sure user has logged in
                var cardToken = db.Tokens.FirstOrDefault(c => c.TokenValue == confirmationToken);
                var card = db.Cards.FirstOrDefault(c => c.CardId == cardToken.TokenKey);

                card.Status = CardStatus.ACTIVE;
                db.SaveChanges();

                if (WebSecurity.IsAuthenticated)
                {
                    TempData["Msg"] = "Your card has been activated. You may now begin using your card.";
                }
                else
                {
                    TempData["Msg"] = "Your card has been activated. Please log in to begin using your card.";
                }
            }
            catch (Exception)
            {

                TempData["Msg"] = "Your Account can not be activated. Please check details and try again.";
            }

            return View();
        }

 
        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }

        
    }
}