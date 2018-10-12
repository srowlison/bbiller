using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Web.Security;
using WebMatrix.WebData;
using DCPaymentService;
using DC.Payment;
using DC.Common.Models;
using Microsoft.Practices.EnterpriseLibrary.Logging;

namespace DCPaymentService
{
    public class DCPaymentServiceModel
    {
        private DCPaymentServiceDataContext _dc;

        private string _dbconn;
        private string _dbconn_name;

        public DCPaymentServiceModel()
        {
            _dbconn_name = "DiamondCircle_dbConnectionString";
            _dbconn = ConfigurationManager.ConnectionStrings[_dbconn_name].ConnectionString;
            _dc = new DCPaymentServiceDataContext(_dbconn);
        }

        [Obsolete]
        public OnlineAccount CreateOnlineAccount()
        {
            //NOTE: this call is on hold. The ATM will not call this method.  
            OnlineAccount ret = new OnlineAccount();
            ret.Password = Guid.NewGuid().ToString();
            ret.UserName = Guid.NewGuid().ToString();

            string result = "ERROR";

            try
            {
                WebSecurity.InitializeDatabaseConnection(_dbconn_name, "UserProfile", "UserId", "UserName", false);

                result = WebSecurity.CreateUserAndAccount(ret.UserName, ret.Password, null, true);//

                ret.ConfirmToken = result;
                ret.Success = true;
            }
            catch (Exception ex)
            {
                //TODO log somewhere . ...
                result = "ERROR_RUNTIME";
                ret.Success = false;

            }
            return (ret);
        }

        public bool AddCard(string cardID, string publicKey, string PIN , string password, DateTime dateIssued)
        {
            bool ret = false; //default fail return.                  
            var result = _dc.addCard(cardID, publicKey, PIN, password, dateIssued);

            if (result == 1) {

                ret = true;
            
            }
            return ret;
        }

        public bool IsCardOnFile(string card) 
        {
            bool ret = false; //default fail return.
            string cardID = "";

            try
            {
                var result = _dc.getCard(card);
                foreach (var item in result)
                {
                    //should only be ONE record . 
                    cardID = item.CardId;
                }

                if (!string.IsNullOrWhiteSpace(cardID))
                {
                    ret = true;
                }
            }
            catch (Exception ex)
            {
                Logger.Write(ex.Message);
                ret = false; //re-set just in case.
            }

            return (ret);
        }


        public int AddTransaction(string CardID, string transType, string terminalID, string numuratorCurrency, 
            string denominatorCurrency, decimal amount, decimal price, string reference) 
        {
                DateTime createDate = DateTime.MinValue;
                int transID = -1;
                int rowCount = -1; 

            //bool WriteTransaction(string CardId, string TransType, string TerminalId, string NumuratorCurrency, 
            //string DenominatorCurrency, float Amount, float Price);

            DateTime dateCreated = DateTime.UtcNow; //TODO: Review if necessary, could just rely on getdate() insert in DB.

            try
            {

                var result = _dc.addTransaction(dateCreated, CardID, transType, terminalID, numuratorCurrency, denominatorCurrency, amount, price, reference);
                //Should ONLY be ONE record returned.
                foreach (var item in result)
                {
                    createDate = item.CreateDate.HasValue ? item.CreateDate.Value : DateTime.MinValue;
                    transID = item.TransactionID;
                    rowCount = item.InsertRowCount;
                }
            }
            catch (Exception ex) 
            {
                Logger.Write(ex.Message);
                transID = -100; //TODO , not necessary, but could test against certain negative value for error code.
            }

            return (transID);

        }
    }
}