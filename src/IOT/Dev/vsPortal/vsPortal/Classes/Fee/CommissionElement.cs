using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Portal.Classes.Transfer;

namespace Portal.Classes.Fee
{
    /// <summary>
    /// The TransferElement in a Transfer that contains information about the commission charges for a particular transaction
    /// </summary>
    public class CommissionElement : ITransferElement
    {
        
        public int Identifier { get; set; }

        public decimal Amount { get; set; }

        public decimal TransactionTotal { get; set; }

        public int CurrencyId { get; set; }

        public DateTime TransferDate { get; set; }

        public string Reference { get; set; }

        public bool SufficientFunds()
        {
            return true;
        }

        public List<CommissionElement> Beneficiaries { get; set; }

        public decimal Calculate()
        {
            decimal totalFee = 0;

            foreach (var beneficiary in Beneficiaries)
            {
                totalFee += beneficiary.Calculate();
            }

            return totalFee;
        }

        public string Summary()
        {
            throw new NotImplementedException();
        }
          

        public TransferAction ActionType { get; set; }

        public void Commit()
        {

        }

        public void Rollback()
        {

        }
    }
}