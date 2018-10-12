using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using DotNetOpenAuth.AspNet;
using Microsoft.Web.WebPages.OAuth;
using WebMatrix.WebData;
using Portal.Filters;
using Portal.Models;
using Portal.Classes;
using System.Data.Entity;
using System.Data.Entity.Validation;
using DC.Data;

namespace Portal.Controllers
{
    [HandleError]
    [InitializeSimpleMembershipAttribute]
    [RequireHttps]
    public class SellBitcoinController : Controller
    {
        private DiamondCircle_dbEntities db = new DiamondCircle_dbEntities();
        string UserID = WebSecurity.CurrentUserId.ToString();

        [Authorize]
        public ActionResult Index()
        {
            return View(GetCards());
        }

        [Authorize]
        public ActionResult Transfer(string encryptedPrivateKey, string toAddress, Decimal amount)
        {
            DC.AtmService.AtmClient client = new DC.AtmService.AtmClient();
            //client.SendBitcoins(encryptedPrivateKey)
            //var atm = new AtmService.AtmClient();
            //var result = atm.Sell(privateKey, fromAddress, toAddress, amount);

            return View(GetCards());
        }

        [Authorize]
        public ActionResult Sell(decimal amount, string bitcoinAddress)
        {
            //AtmService.IAtm balance = new AtmService.AtmClient();
            //var result = balance.SendBitcoins(amount, bitcoinAddress);
            return View(GetCards());
        }

        private List<Card> GetCards()
        {
            //decimal CustomerId = db.Customers.Where(s => s.UserId == UserID).FirstOrDefault().CustomerId;
            //var cards = db.Cards.Where(c => c.CustomerID == CustomerId);
            var cards = new List<Card>();
            return cards.ToList();
        }
    }
}
