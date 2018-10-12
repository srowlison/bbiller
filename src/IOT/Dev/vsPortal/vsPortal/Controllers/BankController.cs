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
    public class BankController : Controller
    {
        private DiamondCircle_dbEntities db = new DiamondCircle_dbEntities();
        string UserID = WebSecurity.CurrentUserId.ToString();
        decimal CustomerId;

        [Authorize]
        public ActionResult Index()
        {
            //var bankdetail = new List<CustomerBank>();
            if (db.Customers.Where(s => s.UserId == UserID).Count() == 0)
            {
                TempData["Msg"] = "To Insert Bank detail you should register a Tag";


                return RedirectToAction("Message", "Home");
            }
            CustomerId = db.Customers.Where(s => s.UserId == UserID).First().CustomerId;
            if (CustomerId != 0)
            {
                //bankdetail = db.CustomerBanks.Where(s => s.CustomerId == CustomerId).ToList();
            }


            return View();//bankdetail);
        }


         [Authorize]
        public ActionResult Create()
        {
            ViewBag.CustomerId = new SelectList(db.Customers, "CustomerId", "UserId");
            return View();
        }

        //
        // POST: /Bank/Create
         [Authorize]
         [HttpPost]
        public ActionResult Create(CustomerBank customerbank)
        {
            if (ModelState.IsValid)
            {
                customerbank.CustomerId = db.Customers.Where(s => s.UserId == UserID).First().CustomerId;
                db.CustomerBanks.Add(customerbank);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

           return View(customerbank);
        }

        //
        // GET: /Bank/Edit/5

        public ActionResult Edit(int id = 0)
        {
            CustomerBank customerbank = db.CustomerBanks.Find(id);
            if (customerbank == null)
            {
                return HttpNotFound();
            }
            ViewBag.CustomerId = new SelectList(db.Customers, "CustomerId", "UserId", customerbank.CustomerId);
            return View(customerbank);
        }

        //
        // POST: /Bank/Edit/5

        [HttpPost]
        public ActionResult Edit(CustomerBank customerbank)
        {
            if (ModelState.IsValid)
            {
                db.Entry(customerbank).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CustomerId = new SelectList(db.Customers, "CustomerId", "UserId", customerbank.CustomerId);
            return View(customerbank);
        }

        //
        // GET: /Bank/Delete/5

        public ActionResult Delete(int id = 0)
        {
            CustomerBank customerbank = db.CustomerBanks.Find(id);
            if (customerbank == null)
            {
                return HttpNotFound();
            }
            return View(customerbank);
        }

        //
        // POST: /Bank/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            CustomerBank customerbank = db.CustomerBanks.Find(id);
            db.CustomerBanks.Remove(customerbank);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}