using Portal.Classes;
using Portal.Filters;
using Portal.Models;
using Portal.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using WebMatrix.WebData;
using DC.Data;
using DC.Providers;
using DC.Common.Models;
using DC.Node;



namespace Portal.Controllers
{
    [HandleError]
    [InitializeSimpleMembershipAttribute]
    [Authorize]
    [RequireHttps]
    public class TransferController : Controller
    {
        //
        // GET: /Transfer/
        public ActionResult Index()
        {
            var userId = WebSecurity.CurrentUserId.ToString();
            var cards = GetCustomerCards(userId);

            return View(cards);
        }

        public List<TransferCardViewModel> GetCustomerCards(string userId)
        {
            var cards = new List<TransferCardViewModel>();

            using (var db = new DiamondCircle_dbEntities())
            {
                var customer = db.Customers.Where(s => s.UserId == userId).SingleOrDefault();

                cards = db.Cards.Where(c => c.CustomerID == customer.CustomerId && (c.Status == CardStatus.ACTIVE || c.Status == CardStatus.PENDING))
                                .Select(c => new TransferCardViewModel() 
                                                    { CardId = c.CardId, DateIssued = c.DateIssued, PublicKey = c.PublicKey, Status = c.Status, BalanceAUD = 0, BalanceBTC = 0 }).ToList();
                
                using (var atmClient = new DC.AtmService.AtmClient())
                {
                    foreach (var card in cards)
                    {
                        try
                        {
                            if (!string.IsNullOrEmpty(card.PublicKey))
                            {
                                card.BalanceBTC = atmClient.GetBalance(card.PublicKey, 6);
                            }
                        }
                        catch (Exception ex)
                        {

                        }
                    }
                }
            }

            return cards;
        }

        public ActionResult TransferBalance(string cardId)
        {
            var model = new TransferModel();
            model.CardId = cardId;

            return View(model);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult TransferBalance(TransferModel model)
        {
            if (ModelState.IsValid)
            {
                using (var atmClient = new DC.AtmService.AtmClient())
                {
                    try
                    {
                        string password;
                        Card card;

                        using (var db = new DiamondCircle_dbEntities())
                        {
                            card = db.Cards.Where(c => c.CardId == model.CardId).First();
                            password = card.Password;
                        }

                        var transactionHash = atmClient.SendBitcoins(model.PrivateKey.Trim(), password.Trim(), model.DestinationAddress, model.AmountToTransferInBtc);
                        //var atmObj = new atm();
                        //var transactionHash = atmObj.SendBitcoins(model.PrivateKey.Trim(), password.Trim(), model.DestinationAddress, model.AmountToTransferInBtc);

                        //Store the transaction
                        //using (var db = new DiamondCircle_dbEntities())
                        //{
                        //    var sendAction = new SendBitcoin();
                        //    sendAction.CardId = model.CardId;
                        //    sendAction.Sender = card.PublicKey;
                        //    sendAction.Receiver = model.DestinationAddress;
                        //    sendAction.BTCAmount = model.AmountToTransferInBtc;
                        //    sendAction.Created = DateTime.UtcNow;
                        //    db.SendBitcoins.Add(sendAction);
                        //    db.SaveChanges();
                        //}

                        return RedirectToAction("TransferSuccessful", new { receipt = transactionHash }); 
                    }
                    catch (ArgumentException argEx)
                    {
                        ModelState.AddModelError(string.Empty, argEx.Message);
                    }
                    catch (Exception ex)
                    {
                        ModelState.AddModelError(string.Empty, "An unknown error occurred");
                    }
                }
            }   

            return View(model);
        }

        public ActionResult TransferSuccessful(string receipt)
        {
            ViewBag.Receipt = receipt;
            return View();
        }

        public ActionResult TransferHistory(TransferCardViewModel cardViewModel)
        {
            var transactionHistory = new List<Transaction>();
            var verified = false;
            using (var db = new DiamondCircle_dbEntities())
            {
                var userId = WebSecurity.CurrentUserId.ToString();
                var cards = db.Cards.Where(s => s.Customer.UserId == userId).ToList<Card>();
                foreach (var card in cards)
                {
                    if (card.CardId == cardViewModel.CardId)
                    {
                        verified = true;
                        break;
                    }
                }

                if (verified)
                {
                    transactionHistory = db.Transactions.Where(c => c.CardId == cardViewModel.CardId).OrderByDescending(t => t.DateTime).ToList();

                    return View(transactionHistory);

                }
            }
            return View();

        }

        private SingleAddressResponse GetBlockChainHistory(string address)
        {
            throw new NotImplementedException();
            //var blockChainInfo = new BlockChainInfo();
            //var response = blockChainInfo.GetAddressHistory(address);
            //return response;
        }

        [Obsolete]
        public void CreateCard()
        {
            using (var atmClient = new DC.AtmService.AtmClient())
            {
                using (var cardClient = new DC.CardService.CardClient())
                {
                    var keys = atmClient.CreatePublicEncryptedPrivateKey();
                    
                    var card = new Card();
                    card.CardId = "eeeee111";
                    var privateKey = Convert.ToBase64String(keys.EncryptedWIFPrivateKey);
                    //card.Password = Convert.ToBase64String(keys.Password);
                    card.TempPublicKey = keys.PublicKey;
                    card.DateIssued = DateTime.Now;

                    using (var db = new DiamondCircle_dbEntities())
                    {
                        var userId = WebSecurity.CurrentUserId.ToString();
                        //card.CustomerID = db.Customers.Where(s => s.UserId == userId).SingleOrDefault().CustomerId;

                        db.Cards.Add(card);
                        db.SaveChanges();
                    }
                }
            }
        }
    }
}
