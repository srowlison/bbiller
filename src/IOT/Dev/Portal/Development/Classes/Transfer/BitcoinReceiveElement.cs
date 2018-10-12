using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Portal.Classes.Transfer
{
    public class BtcReceiveElement : ITransferElement
    {
        private const int bitCoinCurrencyId = 1;
        
        public BtcReceiveElement(string destinationAddress)
        {
            PublicKey = destinationAddress;
        }

        /// <summary>
        /// Constructor for a receiver element for a transfer within a OneWallet card
        /// </summary>
        /// <param name="publicKey"></param>
        /// <param name="cardId"></param>
        public BtcReceiveElement(string publicKey, string cardId)
        {
            //This constructor being called means it is a Sender element
            ActionType = TransferAction.Credit;
        }

        public void DoSomething()
        {

        }

        public int Identifier { get; set; }

        public decimal Amount { get; set; }

        public decimal TransactionTotal { get; set; }

        public int CurrencyId 
        { 
            get { return bitCoinCurrencyId; } 
            set{ var val = value;} 
        }

        public DateTime TransferDate { get; set; }

        public string Reference { get; set; }

        public bool SufficientFunds()
        {
            throw new NotImplementedException();
        }

        public bool IsSendersCard { get; set; }

        public string Summary()
        {
            string summary;
            summary = "Transfer from to the bitcoin address: " + PublicKey + " <br/>Amount to receive: " + Amount.ToString();
            return summary;
        }
          

        public string PublicKey { get; set; }

        public string Address { get; set; }

        public TransferAction ActionType { get; set; }

        public void Commit()
        {
            var atmClient = new DC.AtmService.AtmClient();
            {
                //TODO: Find out the method for sending bitcoin to a public key
                //var order = atmClient.(PublicKey, Amount);
                //order.
                //Should we wait for confirmation of receipt of amount?
                var result = atmClient.GetBalance(PublicKey, 6);
            }
        }

        public void Rollback()
        {

        }



    }
}