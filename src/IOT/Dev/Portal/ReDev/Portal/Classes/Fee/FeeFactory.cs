using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Portal.Classes.Fee
{
    /// <summary>
    /// Creates the appropriate fee handler for the type of transfer
    /// </summary>
    public class FeeFactory
    {
        private FeeElement _feeElement;

        public FeeFactory(FeeElement feeElement)
        {
            _feeElement = feeElement;
        }

        public decimal TotalFeeCharge { get; set; }

        
        public decimal GetFees()
        {

            return TotalFeeCharge;

        }
    }
}