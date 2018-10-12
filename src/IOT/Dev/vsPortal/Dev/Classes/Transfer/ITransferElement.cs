using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Classes
{
    public enum TransferAction
    {
        Credit,
        Debit
    }
 
    public interface ITransferElement
    {
        int Identifier { get; set; }

        decimal Amount { get; set;}

        decimal TransactionTotal { get; set; }

        int CurrencyId { get; set; }

        DateTime TransferDate { get; set; }

        string Reference { get; set; }

        TransferAction ActionType { get; set; }

        bool SufficientFunds();

        string Summary();

        void Commit();

        void Rollback();


    }
}
