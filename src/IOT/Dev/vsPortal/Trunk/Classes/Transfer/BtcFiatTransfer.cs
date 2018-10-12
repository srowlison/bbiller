using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Portal.Classes.Transfer
{
    public class BtcFiatTransfer : ITransfer
    {
        public ITransferElement Sender { get; set; }

        public ITransferElement Receiver { get; set; }

        public ITransferElement Fee { get; set; }

        public bool Transfer()
        {
            return false;
        }

        public bool Transfer(ITransferElement sender, ITransferElement receiver, ITransferElement fee, int transactionType, int terminalId)
        {
            return false;
        }

        public TransferSummary GetTransferSummary()
        {

            TransferSummary summary;
            if (this.Sender.GetType() == typeof(Fiat1WSendElement))
            {
                //This is fiat to Btc
                summary = CreateFiatToBtcTransfer();
            }
            else
            {
                summary = CreateBtcToFiatTransfer();
            }

            return summary;
        }

        private TransferSummary CreateBtcToFiatTransfer()
        {
            throw new NotImplementedException();
        }

        private TransferSummary CreateFiatToBtcTransfer()
        {
            TransferSummary summary = new TransferSummary();

            //Check for sufficient funds
            if (Sender.SufficientFunds())
            { 
                //Set sender properties
                summary.SendSummary = Sender.Summary();
                summary.FeesSummary = Fee.Summary();
                summary.ReceiveSummary = Receiver.Summary(); 

            }
            else
            {
                summary.SendSummary = Sender.Summary();
            }

            return summary;

        }

        public void DoTransfer()
        {

        }

        public string FormatSummary()
        {
            var summary = "<li>" + Sender.Summary()
                        + "<li>" + Receiver.Summary();

            return summary;
        }

        public void Rollback()
        {
            Sender.Rollback();
            Receiver.Rollback();
            Fee.Rollback();
        }

        public void Commit()
        {
            Sender.Commit();
            Receiver.Commit();
            Fee.Commit();
            
        }
    }
}