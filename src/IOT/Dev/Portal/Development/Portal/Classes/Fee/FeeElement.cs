using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Portal.Classes.Fee
{
    /// <summary>
    /// The TransferElement in a Transfer that contains information about the fees for a particular transaction
    /// </summary>
    public class FeeElement : ITransferElement
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

        public List<FeeElement> Beneficiaries { get; set; }

        public decimal CalculateFee()
        {
            decimal totalFee = 0;

            foreach (var beneficiary in Beneficiaries)
            {
                totalFee += beneficiary.CalculateFee();
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