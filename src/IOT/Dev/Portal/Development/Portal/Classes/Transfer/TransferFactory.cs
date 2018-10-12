using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Portal.Classes.Fee;

namespace Portal.Classes.Transfer
{
    /// <summary>
    /// Creates the appropriate Transfer object based on the passed parameters
    /// </summary>
    public class TransferFactory
    {
        private ITransfer _transfer;


        #region AssembleTransaction overloads

        /// <summary>
        /// BTC to BTC transfer
        /// </summary>
        /// <param name="privateKey"></param>
        /// <param name="cardId"></param>
        /// <param name="destinationAddress"></param>
        /// <param name="amount"></param>
        /// <returns></returns>
        public TransferSummary AssembleTransaction(string privateKey, string cardId, string destinationAddress, decimal amount)
        {
            _transfer = new BtcBtcTransfer();

            _transfer.Sender = new BitcoinSendElement(privateKey, cardId, amount);
            _transfer.Receiver = new BitcoinSendElement(destinationAddress);
            _transfer.Fee = new FeeElement();

            var transferSummary = _transfer.GetTransferSummary();

            return transferSummary;
        }

        /// <summary>
        /// Fiat CC to Fiat OneWallet transfer
        /// </summary>
        /// <param name="privateKey"></param>
        /// <param name="cardId"></param>
        /// <param name="destinationAddress"></param>
        /// <param name="amount"></param>
        /// <returns></returns>
        public TransferSummary AssembleTransaction(CCDetails cardDetails, string cardId, int currencyId, decimal amount)
        {
            var _transfer = new FiatFiatTransfer();

            _transfer.Sender = new CCElement(cardDetails, cardId, amount);
            _transfer.Receiver = new Fiat1WSendElement(cardId, currencyId);
            _transfer.Fee = new FeeElement();

            var transferSummary = _transfer.GetTransferSummary();

            return transferSummary;
        }

        /// <summary>
        /// Fiat to Bitcoin within OneWallet transfer
        /// </summary>
        /// <param name="cardId"></param>
        /// <param name="currencyId"></param>
        /// <param name="amount"></param>
        /// <param name="receiverPublicKey"></param>
        /// <returns></returns>
        public TransferSummary AssembleTransaction(string cardId, int currencyId, decimal amount, string receiverPublicKey)
        {
            var _transfer = new BtcFiatTransfer();

            _transfer.Sender = new Fiat1WSendElement(cardId, currencyId, amount);
            _transfer.Receiver = new BitcoinSendElement(receiverPublicKey, cardId);
            _transfer.Fee = new FeeElement();

            var transferSummary = _transfer.GetTransferSummary();

            return transferSummary;
        }

        #endregion

        public void DoTransfer()
        {

            _transfer.DoTransfer();
        }
    }
}