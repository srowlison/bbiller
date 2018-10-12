using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Portal.Classes.Transfer
{
    public class FiatFiatTransfer : ITransfer
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
            return new TransferSummary();
        }

        public void DoTransfer()
        {

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