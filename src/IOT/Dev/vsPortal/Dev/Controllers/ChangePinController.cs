using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DotNetOpenAuth.AspNet;
using Microsoft.Web.WebPages.OAuth;
using WebMatrix.WebData;
using DC.Data;

namespace Portal.Controllers
{
    [HandleError]
    [RequireHttps]
    public class ChangePinController : Controller
    {
        private DiamondCircle_dbEntities db = new DiamondCircle_dbEntities();
        string UserID = WebSecurity.CurrentUserId.ToString();
        decimal CustomerId;
        //
        // GET: /ChangePin/

        public ActionResult Index()
        {
            if (db.Customers.Where(s => s.UserId == UserID).Count() == 0)
            {
                TempData["Msg"] = "To Insert Address you should register a Tag";


                return RedirectToAction("Message", "Home");
            }
            CustomerId = db.Customers.Where(s => s.UserId == UserID).First().CustomerId;
            var cards = db.Cards.Where(s=>s.CustomerID==CustomerId);
            return View(cards.ToList());
        }

   

      

      
        //
        // GET: /ChangePin/Edit/5

        public ActionResult Edit(string id = null)
        {
            Card card = db.Cards.Find(id);
            if (card == null)
            {
                return HttpNotFound();
            }
            ViewBag.CustomerID = new SelectList(db.Customers, "CustomerId", "UserId", card.CustomerID);
            return View(card);
        }

        //
        // POST: /ChangePin/Edit/5

        [HttpPost]
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

      

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}