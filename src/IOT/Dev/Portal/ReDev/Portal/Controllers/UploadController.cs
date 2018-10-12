using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Portal.Models;
using System.IO;
using DotNetOpenAuth.AspNet;
using Microsoft.Web.WebPages.OAuth;
using WebMatrix.WebData;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Blob;
using DC.Data;
using System.Configuration;

namespace Portal.Controllers
{
    [HandleError]
     [Authorize]
    [RequireHttps]
    public class UploadController : Controller
    {
        private DiamondCircle_dbEntities db = new DiamondCircle_dbEntities();
        int UserID = WebSecurity.CurrentUserId;
        //
        // GET: /Upload/
       
        public ActionResult Index()
        {
            return View(db.UploadFiles.Where(s=>s.UserId==UserID).ToList());
        }

        
        //
        // GET: /Upload/Create
        
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Upload/Create

        private string Seq(int user_id)
        {
            string seq;
            int numberOffiles=db.UploadFiles.Where(s => s.UserId == user_id).Count();
            if (numberOffiles <10)
            {
                seq = "0" + numberOffiles.ToString();
            }
            else
            {
                seq =  numberOffiles.ToString();
            }
            return seq;
        }
        
        [HttpPost]
        public ActionResult Create(HttpPostedFileBase file)
        {
       
            if (ModelState.IsValid)
            {
                if (file.ContentLength >0)
                {
                    
               
                string RealfileName = UserID.ToString() + "_" + Seq(UserID) + Path.GetFileName(file.FileName);
              //  var path = Path.Combine(Server.MapPath( + "\\Files", fileName);
                // Retrieve storage account from connection string.
                CloudStorageAccount storageAccount = CloudStorageAccount.Parse(
                ConfigurationManager.ConnectionStrings["StorageConnection"].ConnectionString);

          
                CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();

             
                CloudBlobContainer container = blobClient.GetContainerReference("files");

                CloudBlockBlob blockBlob = container.GetBlockBlobReference(RealfileName);

               
             
                    blockBlob.UploadFromStream(file.InputStream);
               
        
                UploadFile newFile = new UploadFile();
                newFile.UserId = WebSecurity.CurrentUserId;
                newFile.FileRealName = RealfileName;
                newFile.FileName = Path.GetFileName(file.FileName);
                newFile.Createdate = DateTime.Now;
                db.UploadFiles.Add(newFile);
                db.SaveChanges();
                return RedirectToAction("Index");
                }
            }

            return View();
        }

        //
       
        public ActionResult Delete(int id = 0)
        {
            UploadFile uploadfile = db.UploadFiles.Find(id);
           

            if (uploadfile == null)
            {
                return HttpNotFound();
            }
            else
            {
                CloudStorageAccount storageAccount = CloudStorageAccount.Parse(
                ConfigurationManager.ConnectionStrings["StorageConnection"].ConnectionString);

           
                CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();

                CloudBlobContainer container = blobClient.GetContainerReference("files");
                
                CloudBlockBlob blockBlob = container.GetBlockBlobReference(uploadfile.FileRealName.Trim());

                blockBlob.Delete(); 
                 db.UploadFiles.Remove(uploadfile);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        
      
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            UploadFile uploadfile = db.UploadFiles.Find(id);
            db.UploadFiles.Remove(uploadfile);
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