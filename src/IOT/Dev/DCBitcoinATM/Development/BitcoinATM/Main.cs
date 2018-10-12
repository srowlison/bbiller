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
using LibUsbDotNet;
using LibUsbDotNet.Main;
using LibUsbDotNet.LudnMonoLibUsb;
using DC.PrintingServices;

// TODO: Check for Paper.  If no paper, cannot BUY bitcoins.
// TODO: Check for Tags.  If no Tags cannot allow purchase
// TODO: Integrate Coin Dispensor
// TODO: Sell Bitcoins
// TODO: Send Status Messages on Empty Paper and Coins to Operator.
namespace BitcoinATM
{
    public partial class Main : Form
    {
        private ATM.AtmClient atmClient = new ATM.AtmClient();
        private DCCard.CardClient cardClient = new DCCard.CardClient();
        private DCDiagnostics.DiagnosticClient diagnosticClient = new DCDiagnostics.DiagnosticClient();
        
        public string HotWallet = "";
        public string IPAddress = "not resolved";

        private INFC nfc;

        public Int32 TerminalId { get { return Properties.Settings.Default.TerminalId; } }
        
        public Enums.State Operation; // The operation that we are performing

        public Models.ICrypto CryptoCurrency { get; set; }
        
        public Decimal Price { get; set; }
        public String PIN { get; set; }
        public String PublicKey { get; set; }
        public String PrivateKey { get; set; }
        public String Password { get; set; }
        public String TagId { get; set; }
        public Boolean NewTag {get;set;}

        //move to settings?
        public Int16 MinConfirmations { get { return 6; } }

        public DCExchange.Margin AtmMargin { get; private set; }

        public DCDiagnostics.TerminalSettings Settings { get; set; }

        public Main()
        {
            InitializeComponent();
            try
            {
                nfc = Factory.GetNFC();
                String hotWalletAddress = cardClient.GetHotWalletAddress();

                if (!String.IsNullOrEmpty(hotWalletAddress))
                {
                    // No Sale or Transfers
                    btnSell.Enabled = false;
                }

                this.Settings = diagnosticClient.GetSettings(this.TerminalId);
                this.CryptoCurrency = new Models.Bitcoin(this.Settings.DefaultFiatCurrency);
                using (DCExchange.ExchangeClient ExchangeClient = new DCExchange.ExchangeClient())
                {
                    this.AtmMargin = ExchangeClient.GetMargin(this.Settings.DefaultFiatCurrency, this.TerminalId);
                }
            }
            catch (Exception ex)
            {
                GeneralExceptions("Initialise", System.Diagnostics.TraceEventType.Critical, ex);
            }
        }

        #region MenuControl
        private void Main_Load(object sender, EventArgs e)
        {
            grpMainMenu.Location = new Point(0, 1413);
            grpBuyBitcoin.Location = new Point(0, 1413);
            grpBuyTag.Location = new Point(0, 1413);
            //grpTapTag.Location = new Point(0, 1413);
            tapTag1.Location = new Point(0, 1413);
            tapTag1.Visible = true;
            grpWarning.Location = new Point(0, 1413);
            grpTrade.Location = new Point(0, 1280 + 75);
            PicAdsapce1.Location = new Point(-300, 0);
            PicAdsapce1.Height = 1920 - 640;
            PicAdsapce1.Width = 1380;
            grpMainMenu.Visible = true;
            picAnnimation.Visible = false;
        }

        private void btnBalance_Click(object sender, EventArgs e)
        {
            // Get Balance of Tag
            Operation = Enums.State.Balance;
            tmrRead.Enabled = true;
            grpMainMenu.Visible = false;
            grpBuyBitcoin.Visible = false;
            //grpTapTag.Visible = true;
            tapTag1.Visible = true;
            tmrWarning.Enabled = true;
        }

        private void btnPrintBalance_Click(object sender, EventArgs e)
        {
            // Print Bitcoin Balance
            PrintBitcoinBalance();
            ReturnToMainMenu();
        }

        private void btnBuyBitcoinBack_Click(object sender, EventArgs e)
        {
            grpMainMenu.Visible = true;
            grpBuyBitcoin.Visible = false;
            tmrWarning.Enabled = false;
        }

        private void btnBuy_Click(object sender, EventArgs e)
        {
            grpMainMenu.Visible = false;
            grpBuyBitcoin.Visible = true;
            tmrWarning.Enabled = true;
        }

        private void btnBuyTagBack_Click(object sender, EventArgs e)
        {
            grpBuyTag.Visible = false;
            grpMainMenu.Visible = true;
            tmrWarning.Enabled = false;
        }

        private void btnNewWallet_Click(object sender, EventArgs e)
        {
            // Purchase New Wallet
            grpMainMenu.Visible = false;
            grpBuyBitcoin.Visible = false;
            grpBuyTag.Visible = true;
            tmrWarning.Enabled = true;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            grpBalance.Visible = false;
            grpTrade.Visible = false;
            //grpTapTag.Visible = false;
            tapTag1.Visible = false;
            grpMainMenu.Visible = true;

            if (Operation == Enums.State.Buy)
            {
                grpBuyBitcoin.Visible = true;
                grpMainMenu.Visible = false;
            }

            lblBTCBalance.Visible = false;
            lblBalance.Visible = false;
            tmrWarning.Enabled = false;
        }

        private void btnSell_Click(object sender, EventArgs e)
        {
            // Sell Bitcoins from existing Wallet
            Operation = Enums.State.Sell;
            tmrRead.Enabled = true;
            grpMainMenu.Visible = false;
            //grpTapTag.Visible = true;
            tapTag1.Visible = true;
            tmrWarning.Enabled = true;
        }

        private void btnTradeBack_Click(object sender, EventArgs e)
        {
            ResetTimer();
            grpTrade.Visible = false;

            if (Operation == Enums.State.Buy)
            {
                grpBuyBitcoin.Visible = true;
            }
            else if (Operation == Enums.State.Sell)
            {
                grpMainMenu.Visible = true;
            }
        }

        private void btnViewonScreen_Click(object sender, EventArgs e)
        {
            lblBalance.Visible = true;
            lblBTCBalance.Visible = true;
        }

        private void btnTopUp_Click(object sender, EventArgs e)
        {
            // TOPUP new or exisiting wallet
            Operation = Enums.State.Buy;
            tmrRead.Enabled = true;
            grpMainMenu.Visible = false;
            grpBuyBitcoin.Visible = false;
            //grpTapTag.Visible = true;
            tapTag1.Visible = true;
            tmrWarning.Enabled = true;
        }

        private void ReturnToMainMenu()
        {
            grpBuyBitcoin.Visible = false;
            grpBuyTag.Visible = false;
            //grpTapTag.Visible = false;
            tapTag1.Visible = false;
            grpTrade.Visible = false;
            grpMainMenu.Visible = true;
            tmrEncode.Enabled = false;
            tmrRead.Enabled = false;
            ClearAll();
        }

        private void ClearAll()
        {
            Operation = Enums.State.None;  // The operation that we are performing
            CryptoCurrency.Fiat = 0;
            CryptoCurrency.Amount = 0;
            
            Price = 0;
            PIN = "";
            PublicKey = "";
            Password = "";
            PrivateKey = "";

            lblBTCBalance.Text = "0";
            lblTagID.Text = "";
            lblStatusMessage.Text = "";
            TagId = "";
            NewTag = false;
        }

        #endregion MenuControl

        #region PrimaryFunctions
        private async void GetBalance(String publicKey)
        {
            try
            {
                //TODO: USE A REGEX
                if (!String.IsNullOrEmpty(publicKey))
                {
                    decimal value = await atmClient.GetBalanceAsync(publicKey, this.MinConfirmations);
                    lblBTCBalance.Text = value.ToString("0.000000 BTC");
                    lblBTCBalance.Visible = true;
                }
            }
            catch (Exception ex)
            {
                GeneralExceptions("GetBalance", System.Diagnostics.TraceEventType.Critical, ex);
                ReturnToMainMenu();
            }
        }

        private bool PlaceBuyOrder(string publicKey, decimal amount)
        {
            try
            {
                ATM.Order order = atmClient.CreateOrder(publicKey, amount);
                return true;
            }
            catch (Exception ex)
            {
                GeneralExceptions("PlaceBuyOrder", System.Diagnostics.TraceEventType.Critical, ex);
                ReturnToMainMenu();
            }   
            return false;
        }

        private bool PlaceSellOrder(string privatekey, string fromaddress, string toaddress, decimal amount)
        {
            try
            {
                if (amount > 0)
                {
                    //srAtms.Order order = client.Sell(PrivateKey, FromAddress, ToAddress, Amount)
                    String txn = atmClient.ReceiveCoins(privatekey, "", toaddress, amount);
                    return true;
                }
                else
                {
                    //todo:
                    return false;
                }
            }
            catch (Exception ex)
            {
                GeneralExceptions("PlaceSellOrder", System.Diagnostics.TraceEventType.Critical, ex);
                ReturnToMainMenu();
            }
            return false;
        }

        /// <summary>
        /// Get quote from exchange.  Make this own class
        /// </summary>
        private void GetQuote()
        {
            try
            {
                Int32 fiatAmount = Convert.ToInt32(txtFiat.Text);
                Models.Quote currentQuote = GetQuote(fiatAmount);

                //bind to view
                txtBitcoins.Text = currentQuote.Amount.ToString("0.000000");
                txtRate.Text = currentQuote.Rate.ToString("0.000000");
            }
            catch (Exception ex)
            {
                GeneralExceptions("GetQuote", System.Diagnostics.TraceEventType.Critical, ex);
                ReturnToMainMenu();
            }
        }

        /// <summary>
        /// Get quote off our exchange.  Note the exchange adds margin based on terminal id.
        /// </summary>
        /// <param name="fiatAmount"></param>
        /// <returns></returns>
        public Models.Quote GetQuote(Int32 fiatAmount)
        {
            if (fiatAmount > 0)
            {
                // CryptoCurrency.Amount = Convert.ToDecimal(txtFiat.Text);
                using (DCExchange.ExchangeClient ExchangeClient = new DCExchange.ExchangeClient())
                {
                    //This method gets the buy and sell prices off 1.0 unit.
                    DCExchange.Margin margin = ExchangeClient.GetMargin(this.Settings.DefaultFiatCurrency, TerminalId);

                    Decimal rate = 0.0M;
    
                    if (Operation == Enums.State.Buy)
                    {
                        rate = margin.Buy;
                        CryptoCurrency.Amount = Convert.ToDecimal(fiatAmount) * margin.Buy;
                        CryptoCurrency.Fiat = Convert.ToDecimal(fiatAmount);
                    }
                    else if (Operation == Enums.State.Sell)
                    {
                        rate = margin.Sell;
                        CryptoCurrency.Amount = Convert.ToDecimal(fiatAmount) * margin.Sell;
                        CryptoCurrency.Fiat = Convert.ToDecimal(fiatAmount);
                    }

                    Models.Quote currentQuote = new Models.Quote()
                    {
                        Amount = CryptoCurrency.Amount,
                        Rate = rate
                    };

                    return currentQuote;
                }
            }
            else
            {
                throw new ArgumentOutOfRangeException();
            }
        }

        private void txtFiat_TextChanged(object sender, EventArgs e)
        {
            GetQuote();
        }
        
        private void PrintBitcoinBalance()
        {
            // Get the text for the paper receipt.
            string receiptText = Environment.NewLine;
            receiptText += Environment.NewLine;
            receiptText += Environment.NewLine;
            receiptText += Environment.NewLine;
            receiptText += String.Format("DATE:{0}", DateTime.Now) + Environment.NewLine;
            receiptText += "TERMINAL:" + TerminalId + Environment.NewLine;
            receiptText += "TAG ID:" + TagId + Environment.NewLine;
            receiptText += "TRANS TYPE: BALANCE" + Environment.NewLine;
            receiptText += "BITCOINS:" + lblBTCBalance.Text + Environment.NewLine;
            receiptText += "http://diamondcircle.net";
            receiptText += Environment.NewLine;
            receiptText += Environment.NewLine;
            receiptText += Environment.NewLine;
            receiptText += Environment.NewLine;
            receiptText += Environment.NewLine;

            // Initialise the printer if required.
            if (!Factory.GetPrinter().Initialised)
            {
                try
                {
                    Factory.GetPrinter().Initialise();
                }
                catch (Exception ex)
                {
                   lblStatusMessage.Text = "Cannot Print Receipt. (init)";
                   GeneralExceptions("PrintBitcoinBalance - Initalise", System.Diagnostics.TraceEventType.Error, ex);
                   return;
                }
            }

            // Print the receipt.
            ErrorCode writeErrorCode = Factory.GetPrinter().PrintText(receiptText);
            if (writeErrorCode != ErrorCode.None)
            {
                lblStatusMessage.Text = "Cannot Print Receipt";
                throw new System.InvalidOperationException("PrintBitcoinBalance - Cannot Print Receipt");
            }
        }

        private void PrintTransaction(string OrderType)
        {
            try
            {
                int TransactionId = 0;
                string NumeratorCurrency = "BTC"; //TODO: make currencies classes, with code as properties. 
                string DenominatorCurrency = CryptoCurrency.FiatCode;
                string Reference = "";

                // Write transaction to database
                //change terminal id to int
                Decimal tx = cardClient.WriteTransaction(TagId, OrderType, TerminalId.ToString(), NumeratorCurrency, DenominatorCurrency, CryptoCurrency.Fiat, Price, Reference, TransactionId);
                if (tx > 0)
                {
                    // Get the text for the paper receipt.
                    string receiptText = Environment.NewLine;
                    receiptText += Environment.NewLine;
                    receiptText += Environment.NewLine;
                    receiptText += Environment.NewLine;

                    receiptText += String.Format("DATE:{0}", DateTime.Now) + Environment.NewLine;
                    receiptText += "TERMINAL:" + TerminalId + Environment.NewLine;
                    receiptText += "TRANS ID:" + TransactionId + Environment.NewLine;
                    receiptText += "TAG ID:" + TagId + Environment.NewLine;
                    receiptText += "TRANS TYPE:" + OrderType + Environment.NewLine;
                    receiptText += "COIN NAME:" + NumeratorCurrency + Environment.NewLine;
                    receiptText += "FIAT TYPE" + DenominatorCurrency + Environment.NewLine;
                    receiptText += "FIAT AMOUNT:" + CryptoCurrency.Fiat + Environment.NewLine;
                    receiptText += "COIN AMOUNT:" + CryptoCurrency.Amount + Environment.NewLine;
                    receiptText += "RATE:" + Price + Environment.NewLine;
                    receiptText += "http://diamondcircle.net";
                    receiptText += Environment.NewLine;
                    receiptText += Environment.NewLine;
                    receiptText += Environment.NewLine;
                    receiptText += Environment.NewLine;
                    receiptText += Environment.NewLine;

                    // Initialise the printer if required.
                    if (!Factory.GetPrinter().Initialised)
                    {
                        try
                        {
                            Factory.GetPrinter().Initialise();
                        }
                        catch (Exception ex)
                        {
                            lblStatusMessage.Text = "Cannot Print Receipt.";
                            GeneralExceptions("PrintTransaction - Initalise", System.Diagnostics.TraceEventType.Error, ex);
                            return;
                        }
                    }
                    // Print the receipt.
                    ErrorCode writeErrorCode = Factory.GetPrinter().PrintText(receiptText);
                    if (writeErrorCode != ErrorCode.None)
                    {
                        lblStatusMessage.Text = "Cannot Print Receipt";
                        throw new System.InvalidOperationException("PrintTransaction - Cannot Print Receipt");
                    }
                }
                else
                {
                    throw new System.InvalidOperationException("Could not Write Transaction to Database - System Error");
                }
            }
            catch (Exception ex)
            {
                lblStatusMessage.Text = "Cannot Print Receipt.";
                GeneralExceptions("PrintTransaction", System.Diagnostics.TraceEventType.Critical, ex);
                ReturnToMainMenu();
                return;
            }
        }

        private void btnAction_Click(object sender, EventArgs e)
        {
            try
            {
                // TODO SET LIMITS ON PURCHASE


                // ENSURE THEY CANNOT SELL MORE THAN THEY HAVE
                if (Operation == Enums.State.Buy)
                {
                    eftposManager.TransSubType = 0; // TRANTYPE_PURCHASE
                }
                else
                {
                    eftposManager.TransSubType = 3; //TRANTYPE_REFUND
                }

                eftposManager.OperatorDisplayType = 2;
                eftposManager.CustomerDisplayType = 0;
                eftposManager.PrinterType = 0;
                eftposManager.TransactionReference = "DIGITAL SIG";
                eftposManager.OperatorID = "diamondcircle";
                eftposManager.PurchaseAmount = Convert.ToInt32(Math.Round(CryptoCurrency.Fiat * 100)); 
                eftposManager.CashoutAmount = 0;
                long errorCode = eftposManager.StartTransaction();
                    
                if (errorCode != 0)
                {
                    EFTTradeStatus.Text = "Cannot Initialise EFTPOS";
                    throw new System.InvalidOperationException("Cannot Initialise EFTPOS");
                }
                else
                {
                    EFTTradeStatus.Text = "Follow Directions on EFTPOS";
                    //***********************************************************************************************
                    // TEMP Workaround - delete this when the EFTPOS Device Comes Back .
                    //   grpTapTag.Visible = true;
                    //   grpTrade.Visible = false;
                    //   tmrEncode.Enabled = true;
                    //***********************************************************************************************
                }
            }
            catch (Exception ex)
            {
                GeneralExceptions("Buy/Sell Action", System.Diagnostics.TraceEventType.Critical, ex);
                ReturnToMainMenu();
            }
        }

        private void btnViewonScreen_Click_1(object sender, EventArgs e)
        {
            lblBTCBalance.Visible = true;
            lblBalance.Visible = true;
        }

        private void encodeTag()
        {
            try
            { 
                if (nfc.InitReader())
                {
                    lblStatusMessage.Text = Comments.TapWallet;
                    if (nfc.ConnectReader())
                    {
                        tmrEncode.Enabled = false;
                        lblStatusMessage.Text = "Writing";

                        if (NewTag)
                        {
                          //  ATM.Keys key = atmClient.CreatePublicEncryptedPrivateKey();
                          //  Password = key.Password.ToString();
                         //   PrivateKey = key.PrivateKey;
                         //   PublicKey = key.PublicKey;
                        //    String modifiedpublicuri = String.Format("bitcoin:{0}", PublicKey);
                         //   if (btcnfc.WriteNFCTag(modifiedpublicuri, PrivateKey))
                            {
                                lblStatusMessage.Text = "Written";

                                // Write TagID to Database.
                                //  cardClient.AddCard(TagId, modifiedpublicuri, Password);

                                PrintPaperBackup(); 
                                PrintTransaction("BUY");
                                // Push bitcoins to address
                                if (PlaceBuyOrder(PublicKey, CryptoCurrency.Amount))
                                {
                                    // Order Successful -  All Done
                                    // Display Success Message and go back to main menu
                                    ReturnToMainMenu();
                                }
                                else
                                {
                                    // Order failed - Log to errors table -  User did not get their coins
                                    lblStatusMessage.Text = "Contact Diamond Circle Support";
                                    throw new System.InvalidOperationException("EncodeTag Order failed - Log to errors table -  User did not get their coins");
                                }
                            }
                       //     else
                      //      {
                          //      lblStatusMessage.Text = "Cannot Write Tag Data to Tag: System Error";
                          //      throw new System.InvalidOperationException("EncodeTag Cannot Write Tag Data to Tag: System Error");
                       //     }
                        }
                        else
                        {
                            PrintTransaction("BUY");
                            // Push bitcoins to address
                            if (PlaceBuyOrder(PublicKey, CryptoCurrency.Amount))
                            {
                                // Order Successful -  All Done
                                ReturnToMainMenu();
                            }
                            else
                            {
                                lblStatusMessage.Text = "Contact Diamond Circle Support";
                                throw new System.InvalidOperationException("EncodeTag Order failed - Log to errors table -  User did not get their coins");
                            }
                        }
                    }
                    else
                    {
                        lblStatusMessage.Text = Comments.TapTag;
                    }
                }
                else
                {
                    lblStatusMessage.Text = "Cannot Initialise: System Error";
                    throw new System.InvalidOperationException("EncodeTag Cannot Initialise: System Error");
                }   
            }
            catch (Exception ex)
            {
                GeneralExceptions("Encode Tag", System.Diagnostics.TraceEventType.Critical, ex);
                ReturnToMainMenu();
            }
        }

        #endregion PrimaryFunctions

        #region TagPurchase

        private void eftposManager_TransactionResponseEvent(object sender, AxPosEftLib._DPosEftEvents_TransactionResponseEventEvent e)
        {
            String code = e.errorCode;
            String text = e.errorText;
            long status = e.status;

            if (code == "00")
            {
                switch (Operation)
                {
                    case Enums.State.Tag:

                        PurchaseTag();
                        break;

                    case Enums.State.Buy:

                        // Purchase Bitcoins!
                        //grpTapTag.Visible = true;
                        tapTag1.Visible = true;
                        grpTrade.Visible = false;
                        tmrEncode.Enabled = true;
                        break;

                    case Enums.State.Sell:
                        // SELL Order
                        // NONE OF THIS HAS EVER BEEN TESTED
                        if (PlaceSellOrder(PrivateKey, PublicKey, HotWallet, CryptoCurrency.Amount))
                        {
                            PrintTransaction("SELL");
                        }
                        break;
                }
            }
        }
        

        #region Eftpos Manager - Display Data
        private void eftposManager_DisplayDataEvent(object sender, AxPosEftLib._DPosEftEvents_DisplayDataEventEvent e)
        {
            // txtTransactionStatus.Text = e.displayData;
        }
        #endregion

        #region Cancel Transaction Button - Clicked

        private void btnCancelTransaction_Click(object sender, EventArgs e)
        {
            eftposManager.CancelTransaction();
            ReturnToMainMenu();
        }
        #endregion


        private void PurchaseTag()
        {

            try
            {
                ResetTimer();
                PurchaseTagStatus.Text = Comments.TagFromHopper;
                // Print Purchase Receipt for Tag.
                string receiptText = Environment.NewLine;
                receiptText += Environment.NewLine;
                receiptText += Environment.NewLine;
                receiptText += Environment.NewLine;
                receiptText += "DATE:" + DateTime.Now.ToString() + Environment.NewLine;

                receiptText += "TERMINAL:" + TerminalId + Environment.NewLine;
                receiptText += "NFC DEVICE: NTAG203" + Environment.NewLine;
                receiptText += "PRICE: 10.00 EUR" + Environment.NewLine; //NOTE, EURO USES COMMA
                receiptText += "http://diamondcircle.net";
                receiptText += Environment.NewLine;
                receiptText += Environment.NewLine;
                receiptText += Environment.NewLine;
                receiptText += Environment.NewLine;
                receiptText += Environment.NewLine;
                receiptText += Environment.NewLine;
                receiptText += Environment.NewLine;
                receiptText += Environment.NewLine;
                receiptText += Environment.NewLine;
                receiptText += Environment.NewLine;
                receiptText += Environment.NewLine;
                receiptText += Environment.NewLine;
                receiptText += Environment.NewLine;
                receiptText += Environment.NewLine;
                receiptText += Environment.NewLine;
                receiptText += Environment.NewLine;
                receiptText += Environment.NewLine;
                receiptText += Environment.NewLine;
                receiptText += Environment.NewLine;
                receiptText += Environment.NewLine;


                ICardIssuer issue = Factory.GetCardIssuer();
                issue.EjectCard();


                // Initialise the printer if required.
                if (!Factory.GetPrinter().Initialised)
                {
                    try
                    {
                        Factory.GetPrinter().Initialise();
                    }
                    catch (Exception ex)
                    {
                        PurchaseTagStatus.Text = Comments.CannotPintReceipt;
                        throw new System.InvalidOperationException("PurchaseTag: Cannot Print Receipt (Init)");
                    }
                }

                // Print the receipt.
                ErrorCode writeErrorCode = Factory.GetPrinter().PrintText(receiptText);
                if (writeErrorCode != ErrorCode.None)
                {
                    PurchaseTagStatus.Text = Comments.CannotPintReceipt;
                    throw new System.InvalidOperationException("PurchaseTag: Cannot Print Receipt");
                }
                else
                {
                    ReturnToMainMenu();
                }
            }
            catch (Exception ex)
            {
                GeneralExceptions("PurchaseTag", System.Diagnostics.TraceEventType.Critical, ex);
                ReturnToMainMenu();
            }
        }

        private void btnPurchase_Click(object sender, EventArgs e)
        {
            try 
            {
                ResetTimer();
                Operation = Enums.State.Tag;
                PurchaseTagStatus.Text = "";
                double transactionAmount = 10;
                eftposManager.OperatorDisplayType = 2;  // POTENTIALLY THIS IS THE FIELD FOR PRE-AUTH - CHECK TAG EJECTED THEN BILL - SLIGHTLY DIFFERENT WORKFLOW
                eftposManager.CustomerDisplayType = 0;
                eftposManager.PrinterType = 0;
                eftposManager.TransactionReference = "PREPAY";
                eftposManager.OperatorID = "diamondcircle";
                eftposManager.TransSubType = 0;
                eftposManager.PurchaseAmount = Convert.ToInt32(Math.Round(transactionAmount * 100));
                eftposManager.CashoutAmount = 0;

                long errorCode = eftposManager.StartTransaction();

                if (errorCode != 0)
                {
                    PurchaseTagStatus.Text = "Cannot Initialise EFTPOS";
                    throw new System.InvalidOperationException("PurchaseTag: Cannot Initialise EFTPOS");
                }
                else
                {
                    PurchaseTagStatus.Text = "Insert/Swipe/Tap Credit/Debit Card";
                }
            }
            catch (Exception ex)
            {
                GeneralExceptions("PurchaseTagClick", System.Diagnostics.TraceEventType.Critical, ex);
                ReturnToMainMenu();
            }
        }
        #endregion TagPurchase

        #region Printing




        private void PrintPaperBackup()
        {

            //TODO: THIS NEEDS TO BE RE-TESTED
            try
            {
                string numeratorCurrency = "BTC";
                // Get the text for the paper backup.
                string receiptText = Environment.NewLine;
                receiptText += Environment.NewLine;
                receiptText += Environment.NewLine;
                receiptText += Environment.NewLine;
                receiptText += "DATE:" + DateTime.Now.ToString() + Environment.NewLine;
                receiptText += "TERMINAL:" + TerminalId + Environment.NewLine;
                receiptText += "TAG ID:" + TagId + Environment.NewLine;
                receiptText += "COIN NAME:" + numeratorCurrency + Environment.NewLine;
                receiptText += "===============================" + Environment.NewLine;
                receiptText += "STORE IN A SAFE PLACE - DO NOT LOSE THESE NUMBERS" + Environment.NewLine;
                receiptText += "PUBLIC ACCOUNT NUMBER: " + Environment.NewLine;
                receiptText += PublicKey + Environment.NewLine;
                
                receiptText += "";
                int indx = 0;
                int sep = 0;
                int linebreak = 0;
                string output = "";
                for (indx = 0; indx <= PrivateKey.Length - 1; indx++)
                {
                    if (sep == 4)
                    {
                        output += " ";
                        sep = 0;
                        linebreak += 1;
                    }
                    if (linebreak == 4)
                    {
                        output += Environment.NewLine;
                        linebreak = 0;
                    }
                    output += PrivateKey.Substring(indx, 1);
                    sep++;
                }

                receiptText += "===============================" + Environment.NewLine;
                receiptText += "PRIVATE ACCOUNT NUMBER: " + Environment.NewLine;
                receiptText += output + Environment.NewLine;
                receiptText += "===============================" + Environment.NewLine;
                receiptText += "http://diamondcircle.net";
                receiptText += Environment.NewLine;
                receiptText += Environment.NewLine;
                receiptText += Environment.NewLine;
                receiptText += Environment.NewLine;
                receiptText += Environment.NewLine;

                // Initialise the printer if required.
                if (!Factory.GetPrinter().Initialised)
                {
                    try
                    {
                        Factory.GetPrinter().Initialise();
                    }
                    catch (Exception ex)
                    {
                        lblStatusMessage.Text = "Cannot Print Paper Backup.";
                        throw new System.InvalidOperationException("PrintPaperBackup: Cannot Print Paper Backup");
                    }
                }
                // Print the paper backup.
                ErrorCode writeErrorCode = Factory.GetPrinter().PrintText(receiptText);
                if (writeErrorCode != ErrorCode.None)
                {
                    lblStatusMessage.Text = "Cannot Print Paper Backup.";
                    throw new System.InvalidOperationException("PrintPaperBackup: Cannot Print Paper Backup");
                }
            }
            catch (Exception ex)
            {
                GeneralExceptions("PrintPaperBackup", System.Diagnostics.TraceEventType.Critical, ex);
                ReturnToMainMenu();
            }
        }
    
        #endregion Printing

        #region TimerManagement
        private void tmrRead_Tick(object sender, EventArgs e)
        {
            try 
            { 
            switch (Operation)
            {
                case Enums.State.Buy:
                    if (nfc.InitReader())
                    {
                        lblStatusMessage.Text = Comments.TapWallet;
                        if (nfc.ConnectReader())
                        {
                            tmrRead.Enabled = false;
                            string tagid = "";
                            if (nfc.ReadTagID(ref tagid))
                            {
                                lblStatusMessage.Text = "";
                                lblTagID.Text = TagId;
                                TagId = tagid;
                                //grpTapTag.Visible = false;
                                tapTag1.Visible = false;
                                grpTrade.Visible = true;
                                
                                GetQuote();
                                
                                btnAction.Text = Operation.ToString();
                                lblSellorBuy.Text = Operation.ToString();

                                // Is there already a record of this Tag in the Database?
                                //  if (!cardClient.IsCardOnFile(TagId))
                                {
                                    NewTag = true;
                                }

                                //else
                                //{
                                //    string publickey = "";
                                //    if (btcnfc.readPublicKey(ref publickey))
                                //    {
                                //        lblPublic.Text = publickey;
                                //        PublicKey = publickey.Substring(10);
                                //    }
                                //    string privatekey = "";
                                //    if (btcnfc.readPrivateKey(ref privatekey))
                                //    {
                                //        PrivateKey = privatekey;
                                //    }
                                //    // Should check to see if keys are the same as recorded in the cards table.  The tags are read only and the ID's are unique.
                                //}
                            }
                        }
                        else
                        {
                            lblStatusMessage.Text = Comments.TapTag;
                        }
                    }
                    else
                    {
                         lblStatusMessage.Text = "Cannot Initialise";
                        throw new System.InvalidOperationException("tmrRead_Tick: Cannot Initialise");
                    }
                    break;

                case Enums.State.Sell:
                    if (nfc.InitReader())
                    {
                        lblStatusMessage.Text = Comments.TapWallet;

                        if (nfc.ConnectReader())
                        {
                            lblStatusMessage.Text = "Reading";

                            tmrRead.Enabled = false;
                            string tagid = "";

                            if (nfc.ReadTagID(ref tagid))
                            {
                                lblTagID.Text = tagid;
                                TagId = tagid;
                            }
                            if (cardClient.IsCardOnFile(TagId))
                            {
                                string publickey = "";
                                if (nfc.readPublicKey(ref publickey))
                                {
                                    lblPublic.Text = publickey;
                                    PublicKey = publickey.Substring(10);
                                }

                                string privatekey = "";

                                if (nfc.readPrivateKey(ref privatekey))
                                {
                                    PrivateKey = privatekey;
                                }

                                grpTrade.Visible = true;
                                //grpTapTag.Visible = false;
                                tapTag1.Visible = false;

                                btnAction.Text = Operation.ToString();
                                lblSellorBuy.Text = Operation.ToString();
                            }
                            else
                            {
                                lblStatusMessage.Text = "Tag not Registered - goto: http://diamondcircle.net";
                            }
                        }
                        else
                        {
                            lblStatusMessage.Text = Comments.TapTag;
                        }
                    }
                    else
                    {
                        lblStatusMessage.Text = "Cannot Initialise";
                        throw new System.InvalidOperationException("tmrRead_Tick: Cannot Initialise");
                    }
                    break;
                case Enums.State.Balance:
                    // Check Balance of Tag -  Read off the Block Chain
                    if (nfc.InitReader())
                    {
                        lblStatusMessage.Text = Comments.TapWallet;
                        if (nfc.ConnectReader())
                        {
                            tmrRead.Enabled = false;
                            lblStatusMessage.Text = "Reading";

                            string TagId = "";
                            if (nfc.ReadTagID(ref TagId))
                            {
                                lblTagID.Text = TagId;
                            }

                            //if (cardClient.IsCardOnFile(TagId))
                            //{
                                //DONT NEED PRIVATE KEY HERE
                                //string privatekey = "";
                                //if (nfc.readPrivateKey(ref privatekey))
                                //{
                                //    PrivateKey = privatekey;
                                //}

                                string publickey = "";
                                if (nfc.readPublicKey(ref publickey))
                                {
                                    lblPublic.Text = publickey;
                                    grpBalance.Visible = true;
                                    GetBalance(publickey);
                                }
                            //}
                            //else
                            //{
                            //    lblStatusMessage.Text = "Tag not Registered - goto: http://diamondcircle.net";
                            //}
                        }
                        else
                        {
                            lblStatusMessage.Text = Comments.TapTag;
                        }
                    }
                    else
                    {
                        lblStatusMessage.Text = "Cannot Initialise";
                        throw new System.InvalidOperationException("tmrRead_Tick: Cannot Initialise");
                    }
                    break;
                }
            }
            catch (Exception ex)
            {
                GeneralExceptions("tmrRead_Tick", System.Diagnostics.TraceEventType.Critical, ex);
                ReturnToMainMenu();
            }
        }

        private void tmrEncode_Tick(object sender, EventArgs e)
        {
            encodeTag();
        }

        private void tmrAbort_Tick(object sender, EventArgs e)
        {
            // The warning was ignored, return to the main menu
            tmrAbort.Enabled = false;
            grpWarning.Visible = false;
            ReturnToMainMenu();
        }

        private void tmrWarning_Tick(object sender, EventArgs e)
        {
            // After 15,000 miliseconds (15 seconds), there has been no activity in a sub menu
            //  Prompt the user with both audio and visual that unless there is activity, the system is about to return to the main menu

            //1. Stop this Timer
            tmrWarning.Enabled = false;

            //2. Start a five second timer
            tmrAbort.Enabled = true;

            //3. Prompt the User
            grpWarning.Visible = true;
        }

        private void btnContinue_Click(object sender, EventArgs e)
        {

            // Disable the Abort Timer
            tmrAbort.Enabled = false;

            // Hide the Warning
            grpWarning.Visible = false;

            // Re-enable the Warning Timer (in case it happens again) 
            tmrWarning.Enabled = true;

            // User is now back to where they where
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            // The user cancelled the transaction

            // Disable the Abort Timer
            tmrAbort.Enabled = false;

            // Hide the Warning
            grpWarning.Visible = false;

            // return to the main menu
            ReturnToMainMenu();
        }

        public void ResetTimer()
        {
            tmrWarning.Stop();
            tmrWarning.Start();
        }


        #endregion TimerManagement

        #region KeyPadButtons
        private void Btn1_Click(object sender, EventArgs e)
        {
            txtFiat.Text += "1";
        }

        private void Btn2_Click(object sender, EventArgs e)
        {
            txtFiat.Text += "2";
        }

        private void Btn3_Click(object sender, EventArgs e)
        {
            txtFiat.Text += "3";
        }

        private void Btn4_Click(object sender, EventArgs e)
        {
            txtFiat.Text += "4";
        }

        private void Btn5_Click(object sender, EventArgs e)
        {
            txtFiat.Text += "5";
        }

        private void Btn6_Click(object sender, EventArgs e)
        {
            txtFiat.Text += "6";
        }

        private void Btn7_Click(object sender, EventArgs e)
        {
            txtFiat.Text += "7";
        }

        private void Btn8_Click(object sender, EventArgs e)
        {
            txtFiat.Text += "8";
        }

        private void Btn9_Click(object sender, EventArgs e)
        {
            txtFiat.Text += "9";
        }

        private void Btn0_Click(object sender, EventArgs e)
        {
            txtFiat.Text += "0";
        }

        private void BtnPoint_Click(object sender, EventArgs e)
        {
            txtFiat.Text += ".";
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            txtFiat.Text = "";
             
        }

        #endregion KeyPadButtons

        private void txtFiat_TextChanged_1(object sender, EventArgs e)
        {
            ResetTimer();
            txtRate.Text = "";
            txtBitcoins.Text = "";

            GetQuote();
        }

        private void tmrHeartBeat_Tick(object sender, EventArgs e)
        {  
            try
            {
                //diagnosticClient.HeartBeat(this.TerminalId, "");
            }
            catch (Exception ex)
            {
                Microsoft.Practices.EnterpriseLibrary.Logging.LogEntry log = new Microsoft.Practices.EnterpriseLibrary.Logging.LogEntry()
                {
                    Title = "GeneralExceptions",
                    Message = ex.Message
                };

                Microsoft.Practices.EnterpriseLibrary.Logging.Logger.ShouldLog(log);
            }
        }

        public void GeneralExceptions(string Category, System.Diagnostics.TraceEventType Severity, Exception ErrorCondition)
        {
            try
            {
                diagnosticClient.ServiceError(TerminalId, Category, Severity, ErrorCondition.Message);
            }
            // Damage Control Damaged
            catch (FaultException ex)
            {
                Microsoft.Practices.EnterpriseLibrary.Logging.LogEntry log = new Microsoft.Practices.EnterpriseLibrary.Logging.LogEntry()
                {
                    Title = "GeneralExceptions",
                    Message = ex.Message
                };

                //Microsoft.Practices.EnterpriseLibrary.Logging.Logger.ShouldLog(log);
            }
        }
    }
}

