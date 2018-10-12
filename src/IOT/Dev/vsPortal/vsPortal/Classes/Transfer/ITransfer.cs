using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Classes.Transfer
{
    public enum TransferType
    {
        BtcToBtc,
        BtcToCC,
        BtcToEft,
        BtcToCash,
        CCTo
    }

    public interface ITransfer
    {
        ITransferElement Sender { get; set; }

        ITransferElement Receiver { get; set; }

        ITransferElement Fee { get; set; }

        bool Transfer();

        bool Transfer(ITransferElement sender, ITransferElement receiver, ITransferElement fee, int transactionType, int terminalId );

        TransferSummary GetTransferSummary();

        void DoTransfer();

        void Rollback();

        void Commit();

    }
}
