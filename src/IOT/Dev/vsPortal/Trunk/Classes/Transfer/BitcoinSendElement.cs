using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Portal.Classes.Transfer
{
    public class BitcoinSendElement : ITransferElement
    {

        private const int bitCoinCurrencyId = 1;
        
        public BitcoinSendElement(string privateKey, string password, decimal amount)
        {
            //This constructor being called means it is a Sender element
            ActionType = TransferAction.Debit;

        }

        public BitcoinSendElement(string destinationAddress)
        {
            //This constructor being called means it is a Receiver element
            ActionType = TransferAction.Credit;
        }

        /// <summary>
        /// Constructor for a receiver element for a transfer within a OneWallet card
        /// </summary>
        /// <param name="publicKey"></param>
        /// <param name="cardId"></param>
        public BitcoinSendElement(string publicKey, string cardId)
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

        public string Summary()
        {
            throw new NotImplementedException();
        }
          

        public string PublicKey { get; set; }

        public string PrivateKey { get; set; }

        public string Password { get; set; }

        public string Address { get; set; }

        public TransferAction ActionType { get; set; }

        public void Commit()
        {

        }

        public void Rollback()
        {

        }



    }
}