using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Portal.Classes.Fee;

namespace Portal.Classes.Transfer
{
    public class BtcBtcTransfer : ITransfer
    {
        private BitcoinSendElement _sender;
        private BitcoinSendElement _receiver;
        private FeeElement _fee;

        public ITransferElement Sender { get; set;}

        public ITransferElement Receiver { get; set; }

        public ITransferElement Fee { get; set; }

        public bool Transfer()
        {
            throw new NotImplementedException();
        }

        public void DoTransfer()
        {
            using (var atmClient = new DC.AtmService.AtmClient())
            {
                var result = atmClient.ReceiveCoins(_sender.PrivateKey, _sender.Password, _receiver.PublicKey, _receiver.Amount);
            }
        }

        public bool Transfer(ITransferElement sender, ITransferElement receiver, ITransferElement fee, int transactionType, int terminalId)
        {
            _sender = (BitcoinSendElement)sender;
            _receiver = (BitcoinSendElement)receiver;
            _fee = (FeeElement)fee;

            var btcSender = sender as BitcoinSendElement;
            return false;
        }

        public void CompileTransaction()
        {
            var feeFactory = new FeeFactory(_fee);


            _fee.CalculateFee();
        }

        public TransferSummary GetTransferSummary()
        {
            throw new NotImplementedException();
        }

        private void TransferFee()
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