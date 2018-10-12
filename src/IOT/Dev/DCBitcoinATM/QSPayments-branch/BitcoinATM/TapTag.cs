using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ServiceModel;
using System.ServiceModel.Channels;

namespace BitcoinATM
{
    public partial class TapTag : Form
    {


        private srAtm.AtmClient client = new srAtm.AtmClient();
        private DCPaymentService.Service2Client DCPaymentService = new DCPaymentService.Service2Client();

        private btcnfcfunctions btcnfc = new btcnfcfunctions();

        // The operation that we are performing
        public string Operation = "";
        public TapTag()
        {
            InitializeComponent();
            timer1.Enabled = true;
            try
            {
                // This really should be a certificate!!

                //HTTPS PROXY
                //srAtms.AtmClient client = new srAtms.AtmClient();
                srAtm.AtmClient client = new srAtm.AtmClient();
                //client.ClientCredentials.Windows.ClientCredential.UserName = "atm-1";
                //client.ClientCredentials.Windows.ClientCredential.Password = "NjhsD5lvkv";
                //client.ClientCredentials.Windows.ClientCredential.Domain = "dcnode-1";

            }
            catch (Exception ex)
            {

            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            switch (Operation)
            {

                case "Topup":
                    // Add Fiat to Crypto Wallet (NFC Tag)
                    // Check to see if Wallet is initialised

                    if (btcnfc.InitReader())
                    {
                        lblStatusMessage.Text = "Tap Wallet on Reader";
                        if (btcnfc.ConnectReader())
                        {
                            lblStatusMessage.Text = "Thank You";
                            timer1.Enabled = false;

                            string TagId = "";
                            if (btcnfc.ReadTagID(ref TagId))
                            {
                                lblTagID.Text = TagId;
                            }

                            string publickey = "";
                            if (btcnfc.readPublicKey(ref publickey))
                            {
                                lblPublic.Text = publickey;
                            }
                            string privatekey = "";

                            if (btcnfc.readPrivateKey(ref privatekey))
                            {
                                lblPrivateKey.Text = privatekey;
                            }

                            //Query Database for Tag ID
                            Trade AddCreditForm = new Trade();
                            AddCreditForm.BUYorSELL = "BUY";


                            if (!DCPaymentService.isCardOnFile(TagId))
                            {

                                srAtm.Keys key = client.CreatePublicEncryptedPrivateKey();


                                AddCreditForm.NewTag = true;

                                // Error Handle This because if it fails then there is no need to continue
                                // TODO: Capture Pinnumber, and its confirmation (entered twice)

                                // encodeTag(TagId, key.PublicKey, key.PrivateKey, AddCreditForm.PINNumber, key.Password);

                                lblPublic.Text = key.PublicKey.ToString();
                                lblPrivateKey.Text = key.PrivateKey.ToString();
                                publickey = key.PublicKey;
                                privatekey = key.PrivateKey;
                            }

                            AddCreditForm.ShowDialog(this);

                            if (PlaceBuyOrder(publickey, AddCreditForm.BitcoinAmount))
                            {

                                string Reference = "";

                                if (DCPaymentService.WriteTransaction(TagId, "BUY", "001", "BTC", "AUD", AddCreditForm.FiatAmount, AddCreditForm.Price, Reference))
                                {

                                    this.Dispose();
                                }
                            }
                        }
                        else
                        {

                            lblStatusMessage.Text = "Tap Tag to Reader";
                        }
                    }
                    else
                    {
                        lblStatusMessage.Text = "Cannot Initialise";
                    }

                    break;

                case "Sell":
                    if (btcnfc.InitReader())
                    {
                        lblStatusMessage.Text = "Tap Wallet on Reader";

                        if (btcnfc.ConnectReader())
                        {
                            lblStatusMessage.Text = "Thank you";


                            string TagId = "";
                            if (btcnfc.ReadTagID(ref TagId))
                            {
                                lblTagID.Text = TagId;
                            }

                            string publickey = "";

                            if (btcnfc.readPublicKey(ref publickey))
                            {
                                lblPublic.Text = publickey;
                            }
                            string privatekey = "";
                            if (btcnfc.readPrivateKey(ref privatekey))
                            {
                                lblPrivateKey.Text = privatekey;
                            }

                            timer1.Enabled = false;

                            Trade AddCreditForm = new Trade();
                            AddCreditForm.BUYorSELL = "SELL";


                            AddCreditForm.ShowDialog(this);

                            // **********************************************************************************
                            //TODO:  Send bitcoins to hotwallet
                            // **********************************************************************************


                            string Reference = "";

                            DCPaymentService.WriteTransaction(TagId, "SEL", "001", "BTC", "AUD", AddCreditForm.FiatAmount, AddCreditForm.Price, Reference);

                            // Print Receipt

                            this.Dispose();

                        }
                        else
                        {
                            lblStatusMessage.Text = "Tap Tag to Reader";
                        }
                    }
                    else
                    {
                        lblStatusMessage.Text = "Cannot Initialise";
                    }
                    break;

                case "Balance":

                    // Check Balance of Tag -  Read off the Block Chain
                    if (btcnfc.InitReader())
                    {
                        lblStatusMessage.Text = "Tap Wallet on Reader";

                        if (btcnfc.ConnectReader())
                        {
                            string TagId = "";
                            if (btcnfc.ReadTagID(ref TagId))
                            {
                                lblTagID.Text = TagId;
                            }

                            string publickey = "";
                            if (btcnfc.readPublicKey(ref publickey))
                            {
                                lblPublic.Text = publickey;
                            }

                            timer1.Enabled = false;

                            GetBalance(publickey);

                            // Print Receipt?

                        }
                        else
                        {

                            lblStatusMessage.Text = "Tap Tag to Reader";
                        }
                    }
                    else
                    {
                        lblStatusMessage.Text = "Cannot Initialise";
                    }
                    break;
            }
        }
        private async void GetBalance(string publickey)
        {
            short confirmations = 0;

            string lessuripublickey = publickey.Substring(10, publickey.Length - 10);
            Double value = await client.GetBalanceAsync(lessuripublickey, confirmations);
            lblBTCBalance.Text = value.ToString();
        }

        private bool PlaceBuyOrder(string PublicKey, decimal btc)
        {
            try
            {
                srAtm.Order order = client.CreateOrder(PublicKey, btc);
                return true;
            }
            catch (FaultException ex)
            {
                string msg = "FaultException: " + ex.Message;
                MessageFault fault = ex.CreateMessageFault();
                if (fault.HasDetail == true)
                {
                    System.Xml.XmlReader reader = fault.GetReaderAtDetailContents();
                    if (reader.Name == "ExceptionDetail")
                    {
                        ExceptionDetail detail = fault.GetDetail<ExceptionDetail>();
                        msg += "\n\nStack Trace: " + detail.StackTrace;
                    }
                }
                MessageBox.Show(msg);
            }
            return false;
        }
    }
}
