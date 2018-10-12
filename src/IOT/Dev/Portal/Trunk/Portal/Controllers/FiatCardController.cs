//using System;
//using System.Collections.Generic;
//using System.Data;
//using System.Data.Entity;
//using System.Linq;
//using System.Web;
//using System.Web.Mvc;

//namespace Portal.Controllers
//{
//    public class FiatCardController : Controller
//    {
//        private DiamondCircle_dbEntities db = new DiamondCircle_dbEntities();

//        //
//        // GET: /FiatCard/

//        public ActionResult Index()
//        {
//            var fiatCards = db.FiatCards.Include(c => c.Customer);
//            return View(fiatCards.ToList());
//        }

//        //
//        // GET: /FiatCard/Details/5

//        public ActionResult Details(string id = null)
//        {
//            FiatCard card = db.FiatCards.Find(id);
//            if (card == null)
//            {
//                return HttpNotFound();
//            }
//            return View(card);
//        }

//        //
//        // GET: /FiatCard/Create

//        public ActionResult Create()
//        {
//            ViewBag.CustomerID = new SelectList(db.Customers, "CustomerId", "UserId");
//            return View();
//        }

//        //
//        // POST: /FiatCard/Create

//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public ActionResult Create(FiatCard card)
//        {
//            if (ModelState.IsValid)
//            {
//                db.FiatCards.Add(card);
//                db.SaveChanges();
//                return RedirectToAction("Index");
//            }

//            ViewBag.CustomerID = new SelectList(db.Customers, "CustomerId", "UserId", card.CustomerId);
//            return View(card);
//        }

//        //
//        // GET: /FiatCard/Edit/5

//        public ActionResult Edit(string id = null)
//        {
//            FiatCard card = db.FiatCards.Find(id);
//            if (card == null)
//            {
//                return HttpNotFound();
//            }
//            ViewBag.CustomerID = new SelectList(db.Customers, "CustomerId", "UserId", card.CustomerId);
//            return View(card);
//        }

//        //
//        // POST: /FiatCard/Edit/5

//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public ActionResult Edit(FiatCard fiatCard)
//        {
//            if (ModelState.IsValid)
//            {
//                db.Entry(fiatCard).State = EntityState.Modified;
//                db.SaveChanges();
//                return RedirectToAction("Index");
//            }
//            ViewBag.CustomerID = new SelectList(db.Customers, "CustomerId", "UserId", fiatCard.CustomerId);
//            return View(fiatCard);
//        }

//        //
//        // GET: /FiatCard/Delete/5

//        public ActionResult Delete(string id = null)
//        {
//            FiatCard fiatCard = db.FiatCards.Find(id);
//            if (fiatCard == null)
//            {
//                return HttpNotFound();
//            }
//            return View(fiatCard);
//        }

//        //
//        // POST: /FiatCard/Delete/5

//        [HttpPost, ActionName("Delete")]
//        [ValidateAntiForgeryToken]
//        public ActionResult DeleteConfirmed(string id)
//        {
//            FiatCard fiatCard = db.FiatCards.Find(id);
//            db.FiatCards.Remove(fiatCard);
//            db.SaveChanges();
//            return RedirectToAction("Index");
//        }

//        protected override void Dispose(bool disposing)
//        {
//            db.Dispose();
//            base.Dispose(disposing);
//        }
//    }
//}