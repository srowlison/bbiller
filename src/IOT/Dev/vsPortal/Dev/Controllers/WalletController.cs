using System;
using System.Collections.Generic;
using System.Linq;
//using System.Transactions;
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
//using Portal.AtmService;
using System.IO;
//using Gma.QrCodeNet.Encoding;
//using Gma.QrCodeNet.Encoding.Windows.Render;
using System.Drawing;
using System.Drawing.Imaging;
using DC.Data;

namespace Portal.Controllers
{
    [HandleError]
    [InitializeSimpleMembershipAttribute]
    [RequireHttps]
    public class WalletController : Controller
    {
        private DiamondCircle_dbEntities db = new DiamondCircle_dbEntities();
        string UserID = WebSecurity.CurrentUserId.ToString();
       
        [Authorize]
        public ActionResult Index()
        {

            decimal Totalbalance=0;
            //AtmService.IAtm atm = new AtmService.AtmClient();
            //ServiceReference1.IAtm atm = new ServiceReference1.AtmClient();
         
            //Portal.AtmService.Keys key=   balance.CreatePublicEncryptedPrivateKey();
            //  ViewBag.Message = "Your Wallet Balance is :" + key.PublicKey;


            decimal CustomerId = db.Customers.Where(s => s.UserId == UserID).First().CustomerId;
            var cards = db.Cards.Where(c => c.CustomerID == CustomerId);
            foreach (var item in cards)
            {
                //Totalbalance += atm.GetBalance(item.PublicKey, 4);
             
            }
            ViewBag.Message =  Totalbalance;
            return View(cards.ToList());
        }

        [Authorize]
        public ActionResult IndexOld()
        {

            decimal Totalbalance = 0;
            //AtmService.IAtm balance = new AtmService.AtmClient();
            //Totalbalance += balance.GetBalance(item.PublicKey, 4);
             
            //Portal.AtmService.Keys key=   balance.CreatePublicEncryptedPrivateKey();
            //ViewBag.Message = "Your Wallet Balance is :" + balance.GetBalance("1ygyJfeRLHjuxpk3vJFHb5eNjCeLF9iwV", 4);
            decimal CustomerId = db.Customers.Where(s => s.UserId == UserID).First().CustomerId;
            var cards = db.Cards.Where(c => c.CustomerID == CustomerId);
            //foreach (var item in cards)
            //{
            //    Totalbalance += balance.GetBalance(item.PublicKey, 4);

            //}
            ViewBag.Message = Totalbalance;
            return View(cards.ToList());
        }
        //public ActionResult BarcodeImage(String barcodeText)
        //{
        //    // generating a barcode here. Code is taken from QrCode.Net library
        //    QrEncoder qrEncoder = new QrEncoder(ErrorCorrectionLevel.H);
        //    QrCode qrCode = new QrCode();
        //    qrEncoder.TryEncode(barcodeText, out qrCode);
        //    GraphicsRenderer renderer = new GraphicsRenderer(new FixedModuleSize(4, QuietZoneModules.Four), Brushes.Black, Brushes.White);

        //    Stream memoryStream = new MemoryStream();
        //    renderer.WriteToStream(qrCode.Matrix, ImageFormat.Png, memoryStream);

        //    // very important to reset memory stream to a starting position, otherwise you would get 0 bytes returned
        //    memoryStream.Position = 0;

        //    var resultStream = new FileStreamResult(memoryStream, "image/png");
        //    resultStream.FileDownloadName = String.Format("{0}.png", barcodeText);

        //    return resultStream;
        //}

        //
        // GET: /Wallet/Details/5

        public string ShowBalance(string address, short con)
        {
             
             //return "Balance: " + balance.GetBalance(address, con).ToString();
            return "not complete";
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
                    string UserID = WebSecurity.CurrentUserId.ToString();
                    if (db.Customers.Where(s => s.UserId == UserID).Count() == 0)
                    {

                        //Add new Record to Customer Table


                        customer.CreateDate = DateTime.Now;
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
                        Card card = (from s in db.Cards
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
        public ActionResult Transaction(Transaction searchParams)
        {
            var query = db.Transactions.Where(x => x.TerminalId == x.TerminalId);

            //if (isOperatorRole && isTerminalSearch)
            if (searchParams.TerminalId != null)
            {
                query = query.Where(x => x.TerminalId == searchParams.TerminalId);
            }

            if (searchParams.Card.CustomerID != null)
            {
                query = query.Where(x => x.Card.CustomerID == searchParams.Card.CustomerID);
            }

 
            //var lstJobs = query.ToList();

            //decimal CustomerId = db.Customers.Where(s => s.UserId == UserID).First().CustomerId;
            //var cards =(from p in db.Cards
            //           where  p.CustomerID == CustomerId
            //           select p.CardId).ToList();
            // var transactions = from s in db.Transactions
            //                where cards.Contains(s.CardId)
            //               select s;



            return View(query.ToList());
        }
        public ActionResult Send(string Aid)
        {
   
            SendModel Send = new SendModel();
            Send.sender = Aid;
            //To do:Get real Amount
            Send.CurrentAmount = 2.5M;
            return View(Send);
        }
          [HttpPost]
        public ActionResult Send(SendModel sendtrans)
        {
        
            if (ModelState.IsValid)
            {

                //AtmService.IAtm balance = new AtmService.AtmClient();
                //sendtrans.CurrentAmount = balance.GetBalance(sendtrans.sender, 4);
                //sendtrans.BitAmount = balance.GetBitcoinAmount(sendtrans.AUDAmount, "AUD");
                if (sendtrans.BitAmount <= sendtrans.CurrentAmount & sendtrans.BitAmount!=0)
                {
                    
              
                   decimal CustomerId = db.Customers.Where(s => s.UserId == UserID).First().CustomerId;

                   sendtrans.CustomerId = CustomerId;
                   sendtrans.date = DateTime.Now;
                          sendtrans.reciver = sendtrans.reciver;
                   sendtrans.sender = sendtrans.sender;

                   bool? idn = db.Customers.Where(s => s.CustomerId == CustomerId).First().Identified;
                   if (idn == true)
                   {
                       sendtrans.status = "CONFIRM";
                       sendtrans.confirm = true;
                      
                   }
                   else
                   {
                       if (sendtrans.AUDAmount > 1000)
                       {

                           sendtrans.status = "PENDING";
                           sendtrans.confirm = false;
                           TempData["Msg"] = "To should upload document to verfiy ....";

                       }
                       else
                       {
                           sendtrans.status = "CONFIRM";
                           sendtrans.confirm = true;


                       }

                   }
                  
                    return RedirectToAction("ConFirm", sendtrans);
                }
                else
                {
                    ViewBag.message = "Bitcoin Aoumt shoud be greater than  0 and less than " + sendtrans.CurrentAmount.ToString();
                      return View(sendtrans);
                }

            } 
            return View(sendtrans);
        }
          //public ActionResult Confirm(SendModel ConSend)
          //{

          //    //send NewSend = new send();
          //    //NewSend.Amount = ConSend.AUDAmount;
          //    //NewSend.BTCAmount = Math.Round(ConSend.BitAmount,2);
          //    //NewSend.CustomerId = ConSend.CustomerId;
          //    //NewSend.Created = ConSend.date;
          //    //NewSend.Receiver = ConSend.reciver;
          //    //NewSend.Sender = ConSend.sender;
          //    //NewSend.Status = ConSend.status;
          //    var tuple = new Tuple<send, bool>(NewSend, ConSend.confirm);
          //    return View(tuple);
          //}

          //[HttpPost]
          //public ActionResult Confirm(send ConSend,bool confirm)
          //{
          //    //ConSend.BTCAmount = Math.Round(ConSend.BTCAmount, 2);
              //decimal CustomerId = db.Customers.Where(s => s.UserId == UserID).First().CustomerId;
              //bool ?idn=db.Customers.Where(s=>s.CustomerId==CustomerId).First().Identified;
              //Portal.Transaction trn = new Portal.Transaction();
              //trn.DateTime = ConSend.Created;
              //trn.CardId = db.Cards.Where(s => s.PublicKey == ConSend.Sender).First().CardId;
              //trn.TransType = "SND";
              //trn.Price = ConSend.Amount;
              //trn.Amount = ConSend.BTCAmount;
              //trn.DeominatorCurrency = "AUD";
              //trn.NumuratorCurrency = "AUD";
              //db.Transactions.Add(trn);
              
              //if (confirm == true)
              //{
              //    ConSend.Status = "CONFIRM";
              //    db.sends.Add(ConSend);
                
              //}
              //else             
              //      {
              //          if (ConSend.Amount >1000)
              //          {
                                     
              //          ConSend.Status="PENDING";
              //          db.sends.Add(ConSend);
              //          string emailtxt = "Dear Admin, " + "\n\r CustomerID:" + CustomerId.ToString() + " Should be identified.\n\r  "
              //                             + "\n\r \n\r  Regards,"; ;
              //          SendEmail.Send("Diamond Circle", "admin@diamondcircle.net", "Confirm Transaction", emailtxt);

           
              //          }
              //          else
              //          {
              //              ConSend.Status = "CONFIRM";
              //              db.sends.Add(ConSend);
                           

              //          }
                    
              //      }
              //db.SaveChanges();
              ////AtmService.IAtm send = new AtmService.AtmClient();
              ////send.SendBitcoins(ConSend.BitAmount, ConSend.reciver);

          //    return View("Index","Home");
          //}





          //[HttpGet]
          //public PartialViewResult Show(decimal amount)
          //{
          //    send Send = new send();
          //    //AtmService.IAtm balance = new AtmService.AtmClient();
          //    //Send.AUDAmount =  balance.GetBitcoinAmount(amount, "AUD");
          //    //Send.AUDAmount = amount*500;
          //    return PartialView("rate", Send);
          //}
        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}