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
    public class AddressController : Controller
    {
        private DiamondCircle_dbEntities db = new DiamondCircle_dbEntities();
        string UserID = WebSecurity.CurrentUserId.ToString();
        decimal CustomerId;
        //
        // GET: /Address/
        [Authorize]
        public ActionResult Index()
        {
            var addresses = new List<Address>();
            if (db.Customers.Where(s => s.UserId == UserID).Count()==0)
            {
                 TempData["Msg"] = "To Insert Address you should register a Tag";


                return RedirectToAction("Message", "Home");  
            }
           CustomerId= db.Customers.Where(s => s.UserId == UserID).First().CustomerId;
           if (CustomerId != 0)
           {
               addresses = db.Addresses.Where(s => s.CustomerId == CustomerId).ToList();
           }
        
              
            return View(addresses);
        }

    

        //
        // GET: /Address/Create
        [Authorize]
        public ActionResult Create()
        {


            ViewBag.CountryId = new SelectList(db.countries, "Id", "name");
            return View();
        }

        //
        // POST: /Address/Create
         [Authorize]
        [HttpPost]
        public ActionResult Create(Address address)
        {

            if (ModelState.IsValid)
            {
                address.CustomerId = db.Customers.Where(s => s.UserId == UserID).First().CustomerId;
                db.Addresses.Add(address);
                
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CountryId = new SelectList(db.countries, "Id", "name", address.CountryId);
            return View(address);
        }

        //
        // GET: /Address/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Address address = db.Addresses.Find(id);
            if (address == null)
            {
                return HttpNotFound();
            }
            ViewBag.CountryId = new SelectList(db.countries, "Id", "name", address.CountryId);
            return View(address);
        }

        //
        // POST: /Address/Edit/5

        [HttpPost]
        public ActionResult Edit(Address address)
        {
            if (ModelState.IsValid)
            {
                db.Entry(address).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CustomerId = new SelectList(db.Customers, "CustomerId", "UserId", address.CustomerId);
            return View(address);
        }

        //
        // GET: /Address/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Address address = db.Addresses.Find(id);
            if (address == null)
            {
                return HttpNotFound();
            }
            return View(address);
        }

        //
        // POST: /Address/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Address address = db.Addresses.Find(id);
            db.Addresses.Remove(address);
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