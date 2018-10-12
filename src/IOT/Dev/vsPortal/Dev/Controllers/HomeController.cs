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
    //[RequireHttps]
    public class HomeController : Controller
    {
        private DiamondCircle_dbEntities db = new DiamondCircle_dbEntities();

        //[InitializeSimpleMembershipAttribute]
        public ActionResult Index()
        {
            return View();
        }

        [Authorize]
        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        [AllowAnonymous]
        public ActionResult Message()
        {
            return View();
        }

        [Authorize]
        public ActionResult Tag()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public ActionResult Tag(TagModel tag)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    //Check Portal User has CustomerID
                    Customer customer = new Customer();
                    customer.UserId = WebSecurity.CurrentUserId.ToString();
                    string UserID=WebSecurity.CurrentUserId.ToString();
                    
                    if (db.Customers.Where(s => s.UserId == UserID).Count() == 0) 
                    {
                        //Add new Record to Customer Table
                        customer.CreateDate = DateTime.UtcNow;
                        db.Customers.Add(customer);
                        db.SaveChanges();

                        //Update customerID for card table 

                        Card card = db.Cards.Where(s => s.CardId == tag.CardId).First();
                        card.CustomerID = customer.CustomerId;
                        db.SaveChanges();
                    }
                    else
                    {
                        //Update customerID for card table 
                        Card card = (from  s in db.Cards 
                                    where s.CardId == tag.CardId
                                    select s).First();

                       card.CustomerID = db.Customers.Where(s => s.UserId == UserID).First().CustomerId;
                       db.SaveChanges();
                    }

                    TempData["Msg"] = "Tag Added.";

                    return RedirectToAction("Message", "Home");
                }
                catch (Exception)
                {

                    throw;
                }
            }

            return View(tag);
        }

        [Authorize]
        public ActionResult TagLost()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public ActionResult TagLost(TagModel tag)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Card card = (from s in db.Cards
                                 where s.CardId == tag.CardId
                                 select s).First();
                    card.Status = "Lost";
                    db.SaveChanges();
                 
                    TempData["Msg"] = "Done.";

                    return RedirectToAction("Message", "Home");
                }
                catch (Exception)
                {
                    throw;
                }
            }

            return View(tag);
        }


        [Authorize]
         public ActionResult Address()
        {
            Address adress=new Address();
            string UserID = WebSecurity.CurrentUserId.ToString();
            decimal CustomerId = db.Customers.Where(s => s.UserId == UserID).First().CustomerId;

            if (db.Addresses.Where(s => s.CustomerId == CustomerId).Count() > 0)
            {
               adress = db.Addresses.Where(s => s.CustomerId == CustomerId).First();
            }

            else
            {
               adress = new Address();
            }
            return View(adress);
        }

        [Authorize]
        [HttpPost]
        public ActionResult Address( Address adress)
        {
           
            string UserID = WebSecurity.CurrentUserId.ToString();
            decimal CustomerId = db.Customers.Where(s => s.UserId == UserID).First().CustomerId;
            //if (db.Addresses.Where(s => s.CustomerId == CustomerId).Count() > 0)
            //{
            //    adress = db.Addresses.Where(s => s.CustomerId == CustomerId).First();
            //}

            //else
            //{
            //    adress = new Address();
            //}
          
            adress.CustomerId = CustomerId;
            db.Addresses.Add(adress);
            db.SaveChanges();

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

    }
}
