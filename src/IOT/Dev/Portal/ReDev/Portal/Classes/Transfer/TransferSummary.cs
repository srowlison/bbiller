using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace Portal.Classes.Transfer
{
       
    /// <summary>
    /// Builds a Name/Value paired model for displaying a summary of the requested transfer to the
    /// user before confirming the transfer
    /// </summary>
    public class TransferSummary
    {

        public TransferSummary()
        {


        }

        public string GetSummary()
        {
            var sb = new StringBuilder();

            sb.Append("Your transfer is as follows: <br/>");
            sb.Append(SendSummary);
            sb.Append("<br/>");
            sb.Append(FeesSummary);
            sb.Append("<br/>");
            sb.Append(ReceiveSummary);
            sb.Append("<br/> Please confirm");

            return sb.ToString();

        }

        public string SendSummary{ get; set; }
        
        public string FeesSummary{ get; set; }
        
        public string ReceiveSummary{ get; set; }
        
    }
}