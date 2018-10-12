﻿using DC.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Portal.Controllers
{
    public class CreditCardController : Controller
    {
        private DiamondCircle_dbEntities db = new DiamondCircle_dbEntities();

        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /CreditCard/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /CreditCard/Create

        public ActionResult Create(string cardId, bool buy)
        {
            ViewBag.Buy = buy;
            var model = new CreditCard();
            model.Cards.Add(new Card(){CardId = cardId});

            return View(model);
        }


        [HttpPost]
        public ActionResult Create(CreditCard model, bool buy)
        {
            if (ModelState.IsValid)
            {
                using (var atmClient = new DC.CardService.CardClient())
                {
                    try
                    {
                        string cardId;
                        
                        using (var db = new DiamondCircle_dbEntities())
                        {
                            var savedCard = db.CreditCards.Add(model);
                            db.SaveChanges();                                                       

                            //Get the DC card for this user
                            cardId = model.Cards.First().CardId;
                            var card = db.Cards.Where(c => c.CardId == cardId).First();
                            card.CreditCardId = savedCard.CreditCardId;
                            db.SaveChanges();

                        }

                        if (buy)
                        {
                            return RedirectToAction("BuyBitcoin", "BuyBitcoin", new { CardId = cardId });
                        }
                        else
                        {
                            return RedirectToAction("AddCardSuccessful", new { abbrevCardNum = MaskCardNumber(model.CardNumber) });
                        }
                    }
                    catch (ArgumentException argEx)
                    {
                        ModelState.AddModelError(string.Empty, argEx.Message);
                    }
                    catch (Exception ex)
                    {
                        ModelState.AddModelError(string.Empty, ex.Message);
                    }
                }
            }

            return View(model);
        }

        private string MaskCardNumber(string cardNumber)
        {
            return String.Concat("xxxx xxxx xxxx ", cardNumber.Substring(cardNumber.Length - 5, cardNumber.Length));
        }

        //
        // GET: /CreditCard/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /CreditCard/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /CreditCard/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /CreditCard/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
