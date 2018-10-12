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

// TODO: Sell Bitcoins
// TODO: Send Status Messages on Empty Paper and Coins to Operator.
namespace BitcoinATM
{

    
    public partial class Main : Form
    {
        private ATM.AtmClient atmClient = new ATM.AtmClient();
        private DCCard.CardClient cardClient = new DCCard.CardClient();
        private DCDiagnostics.DiagnosticClient diagnosticClient = new DCDiagnostics.DiagnosticClient();

        public string hotWalletAddress { get; set; }

        public string IPAddress = "not resolved";

        private INFC nfc;
        
        public string TransactionId = "0";
        public int RefundAmount = 0;
        public Int32 TerminalId { get { return Properties.Settings.Default.TerminalId; } }

        public Enums.State Operation; // The operation that we are performing

        public Models.ICrypto CryptoCurrency { get; set; }

        public Decimal Price { get; set; }
        public String PIN { get; set; }
        public String PublicKey { get; set; }
        public String PrivateKey { get; set; }
        public String Password { get; set; }
        public String TagId { get; set; }
        
        public Boolean SaveCCData { get; set; }

        public TextBox ActiveControl;
        public String chrBuffer;


        //move to settings?
        public Int16 MinConfirmations { get { return 1; } }

        public DCExchange.Margin AtmMargin { get; private set; }

        public DCDiagnostics.TerminalSettings Settings { get; set; }

        
        public String CardNumber  { get; set; }
        public String CardHolderName { get; set; }
        public String CVC  { get; set; }
        public String ExpiryMM { get; set; }
        public String ExpiryYY  { get; set; }
        public String FirstName  { get; set; }
        public String LastName { get; set; }
        public String Address1  { get; set; }
        public String City  { get; set; }
        public String State { get; set; }
        public String Postcode { get; set; }
        public String Country { get; set; }
        public String Currency { get; set; }
        public String Product { get; set; }
        public String EmailAddress { get; set; }
        public String Telephone { get; set; }
        public String DOB { get; set; }
        public String Reference { get; set; }

        // 0 - Numeric, 1 - Char, 2 - Both/either
        public String[,] FieldDataTypes = new String[,] { { "txtFiat", "0" }, { "txtFirstName", "1" }, { "txtLastName", "1" }, { "txtAddress", "2" },
            { "txtState", "2" }, { "txtCity", "2" }, { "txtZip", "2" }, { "txtTelephone", "0" }, {"txtDOB","0"},{"txtEmail","2"},{"txtCVC2","0"},
            {"txtCCNumber","0"}, {"txtExpiryDateYY","0"}, {"txtExpiryDateMM","0"}};
            

        public Main()
        {

            
 
            InitializeComponent();
            btnSell.Enabled = false;  // Feature Disabled - Release 1.0
            btnSell.Visible = false;
            LoadCountries();

            
            
        }

        #region MenuControl
        private void Main_Load(object sender, EventArgs e)
        {
            //  this.Location = new Point(1080, 1920);


            grpMainMenu.Location = new Point(0, 1413);
            grpBuyBitcoin.Location = new Point(0, 1413);
            grpBuyTag.Location = new Point(0, 1413);


            grpTapTag.Location = new Point(0, 1413);
            grpTapTag.Visible = false;

            grpBuyTag.Location = new Point(0, 1413);
            grpBuyTag.Visible = false;

            grpBuyBitcoin.Location = new Point(0, 1413);

            tmrWarning.Enabled = false;

            grpWarning.Location = new Point(0, 300);
            grpWait.Location = new Point(200, 300);

            
            PicAdsapce1.Location = new Point(0, 0);
            PicAdsapce1.Height = 1920 - 640;
            PicAdsapce1.Width = 1380;
            grpMainMenu.Visible = true;
            

            lblBalance.Visible = false;
            lblBTCBalance.Visible = false;
            grpBalance.Visible = false;
            GrpBoxWalPay.Location = new Point(1,400);
            GrpBoxWalPay.Height=1466;
            GrpBoxWalPay.Width = 1097;
            if (!startup())
            {
                grpWait.Visible = true;
                grpWait.BringToFront();

            }


        }
        private bool startup()
        {

            this.Refresh();
            try
            {
                nfc = Factory.GetNFC();
                //                String hotWalletAddress = cardClient.GetHotWalletAddress();
                //              if (String.IsNullOrEmpty(hotWalletAddress))
                //{
                // No Sale or Transfers
                btnSell.Enabled = false;
                //            }
               

                this.Settings = diagnosticClient.GetSettings(this.TerminalId);
                this.CryptoCurrency = new Models.Bitcoin(this.Settings.DefaultFiatCurrency);
                using (DCExchange.ExchangeClient ExchangeClient = new DCExchange.ExchangeClient())
                {
                    this.AtmMargin = ExchangeClient.GetMargin(this.Settings.DefaultFiatCurrency, this.TerminalId);
                }
                lblCurrency.Text = this.Settings.DefaultFiatCurrency;
                lblCurrency2.Text = this.Settings.DefaultFiatCurrency;
                Currency = this.Settings.DefaultFiatCurrency;
                btnBalance.Enabled = true;
                btnBuy.Enabled = true;

                return true;
            }
            catch (Exception ex)
            {

                btnBalance.Enabled = false;
                btnBuy.Enabled = false;

                return false;

                
            }


        }


        private void btnBalance_Click(object sender, EventArgs e)
        {
            // Get Balance of Tag
            Operation = Enums.State.Balance;
            tmrRead.Enabled = true;
            grpMainMenu.Visible = false;
            grpBuyBitcoin.Visible = false;

            grpTapTag.BackColor = System.Drawing.Color.Red;
            grpTapTag.Visible = true;
            tmrWarning.Enabled = true;
            tmrWarning.Interval = 20000;

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
            ReturnToMainMenu();
        }

        private void btnBuy_Click(object sender, EventArgs e)
        {
            lblSellorBuy.Text = "Buy";
            grpMainMenu.Visible = false;
            grpBuyBitcoin.Visible = true;
            tmrWarning.Enabled = true;
            tmrWarning.Interval = 90000;
        }

        private void btnBuyTagBack_Click(object sender, EventArgs e)
        {
            
            ReturnToMainMenu();
        }

        private void btnNewWallet_Click(object sender, EventArgs e)
        {
            // Purchase New Wallet
            lblSellorBuy.Text = "Buy";
            grpMainMenu.Visible = false;
            grpBuyBitcoin.Visible = false;
            grpBuyTag.Visible = true;
            btnAction.Enabled = true;
            btnAction.Text = "Buy";
            tmrWarning.Enabled = true;
            
            tmrWarning.Interval = 90000;
            

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            ReturnToMainMenu();
        }

        private void btnSell_Click(object sender, EventArgs e)
        {
            // Sell Bitcoins from existing Wallet
            //lblSellorBuy.Text = "Sell";
            //Operation = Enums.State.Sell;
            //tmrRead.Enabled = true;
            //grpMainMenu.Visible = false;
            //grpTapTag.BackColor = System.Drawing.Color.Red;

            //grpTapTag.Visible = true;
            //tmrWarning.Enabled = true;
            //string encryptedprivatekey = "";
            

            //nfc.InitReader();
            //nfc.ConnectReader();

            //string lPublicKey = "";
            //bool ret = false;

            //string lPrivateKey = "";

            //ret = nfc.readPrivateKey(ref lPrivateKey);


            //ret = nfc.readPublicKey(ref lPublicKey);



            // nfc.WriteNFCTag(PublicKey, encryptedprivatekey);

        }


        private void btnViewonScreen_Click(object sender, EventArgs e)
        {
            ResetTimer();
            if (lblBalance.Visible)
            {
                lblBalance.Visible = false;
                lblBTCBalance.Visible = false;
            }
            else
            {
                lblBalance.Visible = true;
                lblBTCBalance.Visible = true;
            }
        }

        private void btnTopUp_Click(object sender, EventArgs e)
        {
            // TOPUP new or exisiting wallet
            SetTopup();
        }
        private void SetTopup()
        {
            Operation = Enums.State.Buy;
            tmrRead.Enabled = true;
            grpMainMenu.Visible = false;
            grpBuyBitcoin.Visible = false;
            grpTapTag.Visible = true;
            tmrWarning.Enabled = true;
            // btnAction.Enabled = HotWalletFull();
            btnAction.Text = "Buy";


        }

        private void ReturnToMainMenu()
        {

            tmrWarning.Stop();
            picAnnimation.Visible = true;
            grpBuyBitcoin.Visible = false;
            grpBuyTag.Visible = false;
            grpBalance.Visible = false;
            grpTapTag.Visible = false;
            GrpBoxWalPay.Visible = false;
            grpMainMenu.Visible = true;
            tmrEncode.Enabled = false;
            tmrRead.Enabled = false;
            tmrAbort.Enabled = false;
            tmrWarning.Enabled = false;
            lblBalance.Visible = false;
            lblBTCBalance.Visible = false;
            btnAction.Enabled = true;
            btnBalance.Enabled = true;
            btnBuy.Enabled = true;


            ClearAll();
            PicAdsapce1.BringToFront();

            
        }

        private void ClearAll()
        {
            
            try
            { 
            Operation = Enums.State.None;  // The operation that we are performing
            CryptoCurrency.Fiat = 0;
            CryptoCurrency.Amount = 0;

            Price = 0;
            PIN = "";
            PublicKey = "";
            Password = "";
            PrivateKey = "";
            txtBitcoins.Text = "";
            lblBTCBalance.Text = "";
            lblTagID.Text = "";
            lblStatusMessage.Text = "";
            TagId = "";
            txtFiat.Text = "20";
            lblProductItem.Text = "";
            SaveCCData = false;

            txtFirstName.Text = "";
            txtLastName.Text = "";
            txtAddress.Text = "";
            txtState.Text = "";
            txtCity.Text = "";
            txtCVC2.Text = "";
            txtCCNumber.Text = "";
            txtEmail.Text = "";
            txtZip.Text = "";
            txtTelephone.Text = "";
            txtDOB.Text = "";

         
            String Country = Properties.Settings.Default.Country;
            int index = cboCountry.FindString(Country);
            cboCountry.SelectedIndex = index;

            txtExpiryDateMM.Text = "";
            txtExpiryDateYY.Text = "";

            btnPurchase.Text = "Purchase";
            btnPurchase.Enabled = true;
                }
            catch (Exception ex)
            {
             

            }


        }

        #endregion MenuControl

        #region PrimaryFunctions

        private bool HotWalletFull()
        {
            try
            {
                //TODO: USE A REGEX
                String hotWalletAddress = cardClient.GetHotWalletAddress();
                if (!String.IsNullOrEmpty(hotWalletAddress))
                {
                    decimal value = atmClient.GetBalance(hotWalletAddress, this.MinConfirmations);
                    
                    if (value > 0.001M)
                    {
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                GeneralExceptions("HotWalletFull", System.Diagnostics.TraceEventType.Critical, ex);
            }
            return false;
        }

        private async void GetBalance(String publicKey)
        {
            try
            {
                //TODO: USE A REGEX
                if (!String.IsNullOrEmpty(publicKey))
                {
                    decimal value = await atmClient.GetBalanceAsync(publicKey, this.MinConfirmations);
                    

                    lblBTCBalance.Text = value.ToString("0.000000 BTC");

                }
            }
            catch (Exception ex)
            {
                GeneralExceptions("GetBalance", System.Diagnostics.TraceEventType.Critical, ex);
                PrintErrorMessage("Error Cannot Print Balance");
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
                //GeneralExceptions("PlaceBuyOrder", System.Diagnostics.TraceEventType.Critical, ex);
                //PrintErrorMessage("Error Place Buy Order");
                //ReturnToMainMenu();
                String body = publicKey + " "+ amount.ToString();
                atmClient.SendEmailAsync("support@diamondcircle.net","No Bitcoins: CardId:" + TagId, body);
                
                return true;

            }
            
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
                    ReturnToMainMenu();
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
                if (txtFiat.Text != "" && Convert.ToInt32(txtFiat.Text) > 0)
                {
                    Int32 fiatAmount = Convert.ToInt32(txtFiat.Text);
                    Models.Quote currentQuote = GetQuote(fiatAmount);

                    //bind to view
                    txtBitcoins.Text = currentQuote.Amount.ToString("0.000000");
                    txtRate.Text = currentQuote.Rate.ToString("0.000000");
                
                }
                else
                {
                    txtBitcoins.Text = "0.000000";
                    txtRate.Text = "0.000000";
                }


            }
            catch (Exception ex)
            {
                GeneralExceptions("GetQuote", System.Diagnostics.TraceEventType.Critical, ex);
                PrintErrorMessage("Error Cannot Get a Quote");
                ReturnToMainMenu();
            }
        }

        /// <summary>
        /// Get quote off our exchange.  Note the exchange adds margin based on terminal id.
        /// </summary>
        /// <param name="fiatAmount"></param>
        /// <returns></returns>CryptoCurrency.Fiat
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

                    if (Operation == Enums.State.Buy || Operation == Enums.State.TagPlusBuy)
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

        

        
        private void btnAction_Click(object sender, EventArgs e)
        {
            try
            {
                // TODO: Load Customer Payment Record if Found. - Then when the Buy order happens, we already have their card details

                if (ValidateWalPay())
                {
                        String FullName = "";
                        FirstName = txtFirstName.Text.ToString();
                        LastName = txtLastName.Text.ToString();
                        CardNumber = txtCCNumber.Text.ToString();
                        CVC = txtCVC2.Text.ToString();
                        ExpiryMM = txtExpiryDateMM.Text.ToString();
                        ExpiryYY = txtExpiryDateYY.Text.ToString();
                        CardHolderName  = txtFirstName.Text.ToString() + " " + txtLastName.Text.ToString();
                        Address1 = txtAddress.Text.ToString();
                        City = txtCity.Text.ToString();
                        State = txtState.Text.ToString();
                        Postcode = txtZip.Text.ToString();
                        Country = cboCountry.SelectedItem.ToString();
                        Currency = lblCurrency.Text.ToString();
                        Product = "NFC Card";
                        EmailAddress = txtEmail.Text.ToString();
                        Telephone = txtTelephone.Text.ToString();
                        DOB = txtDOB.Text.ToString();
                        
                    String ReasonCode = "";
                    int OrderTotal = 0;
                    Int32 fiatAmount = Convert.ToInt32(txtFiat.Text+"00");

                    GrpBoxWalPay.Visible = false;
                    grpWait.Visible = true;
                    grpWait.BringToFront();
                    

                    this.Refresh();


                    {
                        switch (Operation)
                        {
                            case Enums.State.TagPlusBuy:

                                OrderTotal = fiatAmount + 550;
                                ICardIssuer issue = Factory.GetCardIssuer();
                                if (issue.Read_IsResetJamSignalOn())
                                {
                                    ReasonCode = ChargeCard(CardNumber, CVC, ExpiryMM, ExpiryYY, CardHolderName, Address1, City, State, Postcode, Country, OrderTotal, Currency, Product, EmailAddress);
                                    if (ReasonCode == "Approved")
                                    {
                                        issue.EjectCard();
                                        grpWait.Visible = false;
                                        PrintTagReceipt();

                                        // Order Total + Card Price of 5 EUR.
                                        grpTapTag.Visible = true;
                                        tmrEncode.Enabled = true;
                                    }
                                    else
                                    {
                                        // Payment Failed
                                       PrintErrorMessage(ReasonCode);
                                    }
                                }
                                else
                                {

                                PrintErrorMessage("Error Eject a Card - Jam or Empty");
                                // IssueRefund();
            
                                }
                                grpWait.Visible = false;
                                break;

                            case Enums.State.Buy:

                                   // Purchase Bitcoins!
                                    OrderTotal = fiatAmount;
                                    ReasonCode = ChargeCard(CardNumber, CVC, ExpiryMM, ExpiryYY, FullName, Address1, City, State, Postcode, Country, OrderTotal, Currency, Product, EmailAddress);
                                    if (ReasonCode == "Approved")
                                    {
                                     // Perform Delivery
                                        grpTapTag.Visible = true;
                                        tmrEncode.Enabled = true;
                                    }
                                    else
                                    {
                                        // Payment Failed
                                      PrintErrorMessage(ReasonCode);
                                    }

                                grpWait.Visible = false;
                                break;

                            case Enums.State.Sell:
                                // WalPay:
                                String hotWalletAddress = cardClient.GetHotWalletAddress();
                                if (PlaceSellOrder(PrivateKey, PublicKey, hotWalletAddress, CryptoCurrency.Amount))
                                {
                                    PrintTransaction("SELL");
                                }
                                ReturnToMainMenu();
                                break;
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                GeneralExceptions("Buy/Sell Action", System.Diagnostics.TraceEventType.Critical, ex);
                PrintErrorMessage("Error Buy/Sell Action Failed");
                grpWait.Visible = false;
                ReturnToMainMenu();
            }
        }

        
        private void encodeTag()
        {
            try
            {
                grpTapTag.BackColor = System.Drawing.Color.Red;
                if (nfc.InitReader())
                {
                    lblStatusMessage.Text = Comments.TapWallet;
                    if (nfc.ConnectReader())
                    {
                        
                        
                        string tagid = "";
                        if (nfc.ReadTagID(ref tagid))
                        {

                            lblStatusMessage.Text = "";
                            lblTagID.Text = TagId;
                            TagId = tagid;


                            if (!cardClient.IsCardOnFile(TagId))
                            {
                                ATM.Keys key = atmClient.CreatePublicEncryptedPrivateKey();
                                
                                Password = key.Password.ToString();
                                PrivateKey = key.PrivateKey;
                                PublicKey = key.PublicKey;
                                String modifiedpublicuri = String.Format("bitcoin:{0}", PublicKey);
                                lblStatusMessage.Text = "Writing..Wait - Hold Card on Reader";
                                this.Refresh();

                                if (nfc.WriteNFCTag(modifiedpublicuri, PrivateKey))
                                {
                                    lblStatusMessage.Text = "Written";
                                    Random rnd1 = new Random();
                                    PIN = rnd1.Next(1000, 9999).ToString();
                                    PrintPaperBackup();
                                    SendKeyReceipt(TagId, PublicKey, PrivateKey);

                                    // Write TagID to Database.
                                    Password = Convert.ToBase64String(key.Password);
                                    

                                    cardClient.AddCardWithPinLimit(TagId, PublicKey, Password, FirstName, LastName, Address1, City, Postcode, State, Country, Telephone, DOB, EmailAddress, CardHolderName, CardNumber, ExpiryMM, ExpiryYY, CVC, PIN, Currency, 100M, true, 50M);
                                    CryptoCurrency.Amount = Convert.ToDecimal(txtBitcoins.Text);
    
                                    // Push bitcoins to address
                                    if (PlaceBuyOrder(PublicKey, CryptoCurrency.Amount))
                                    {
                                        PrintTransaction("BUY");
                                    
                                        ReturnToMainMenu();
                                    }
                                    else
                                    {
                                        // Display Success Message and go back to main menu
                                        PrintErrorMessage("Error Cannot Place Buy Order");
                                    
                                        ReturnToMainMenu();
                                    }
                                }
                                else
                                {
                                    lblStatusMessage.Text = "Hold card to reader";
                                    // throw new System.InvalidOperationException("EncodeTag Cannot Write Tag Data to Tag: System Error");
                                    
                                }
                            }
                            else
                            {
                                grpTapTag.BackColor = System.Drawing.Color.Red;
                                lblStatusMessage.Text = "Hold Card on Reader.. Wait..";
                                this.Refresh();

                                
                                // Push bitcoins to address
                                if (SaveCCData)
                                {

                                    cardClient.AddCard(TagId, PublicKey, Password, FirstName, LastName, Address1, City, Postcode, State, Country, Telephone, DOB, EmailAddress, CardHolderName, CardNumber, ExpiryMM, ExpiryYY, CVC);
                                }
                                
                                CryptoCurrency.Amount = Convert.ToDecimal(txtBitcoins.Text);
                                if (PlaceBuyOrder(PublicKey, CryptoCurrency.Amount))
                                {
                                    // Order Successful -  All Done
                                    PrintTransaction("BUY");
                                    
                                    ReturnToMainMenu();
                                }
                                else
                                {
                                    
                                    throw new System.InvalidOperationException("EncodeTag Order failed - Log to errors table -  User did not get their coins");
                                }
                            }
                        }
                        else
                        {
                            lblStatusMessage.Text = "Hold Card on Reader";
                            this.Refresh();
                        }

                    }
                    else
                                                                                     {
                    lblStatusMessage.Text = "Hold Card on Reader"; // - No Card Present
                    this.Refresh();
                    //    throw new System.InvalidOperationException("EncodeTag Cannot Read Card: System Error");
                                                                                         
                    }

                }
                else
                {
                    lblStatusMessage.Text = "Cannot Initialise: System Error";
                    this.Refresh();
                    throw new System.InvalidOperationException("EncodeTag Cannot Initialise: System Error");
                }
            }
            catch (Exception ex)
            {
                
                GeneralExceptions("Encode Tag", System.Diagnostics.TraceEventType.Critical, ex);
                
                PrintErrorMessage("Error encode Card");
                
                ReturnToMainMenu();
            }
        }



        


        private void btnViewonScreen_Click_1(object sender, EventArgs e)
        {
            lblBTCBalance.Visible = true;
            lblBalance.Visible = true;
        }



        
        private void loadWallPay()
        {
            
            txtFiat.Text = "100";
            
            GetQuote();
            GrpBoxWalPay.Visible = true;
            PicAdsapce1.SendToBack();
            txtFiat.Focus();
            UpdatePrice();

            btnPurchase.Text = "Purchase";
            btnPurchase.Enabled = true;

        }

        private void btnPurchase_Click(object sender, EventArgs e)
        {
            try
            {
                ResetTimer();
                btnPurchase.Enabled = false;
                btnPurchase.Text = "WAIT";
                Operation = Enums.State.TagPlusBuy;
                grpBuyTag.Visible = false;

                loadWallPay();
                PurchaseTagStatus.Text = "";

            }
            catch (Exception ex)
            {
                GeneralExceptions("PurchaseTagClick", System.Diagnostics.TraceEventType.Critical, ex);
                PrintErrorMessage("Error Cannot Perform Purchase");
                ReturnToMainMenu();
            }
        }

        #endregion PrimaryFunctions

        #region Printing
        private void PrintBitcoinBalance()
        {
            // Get the text for the paper receipt.
            string receiptText = Environment.NewLine;
            receiptText += Environment.NewLine;
            receiptText += Environment.NewLine;
            receiptText += Environment.NewLine;
            receiptText += String.Format("DATE:{0}", DateTime.Now) + Environment.NewLine;
            receiptText += "TERMINAL:" + TerminalId + Environment.NewLine;
            receiptText += "CARD ID:" + TagId + Environment.NewLine;
            receiptText += "TRANS TYPE: BALANCE" + Environment.NewLine;
            receiptText += "BITCOINS:" + lblBTCBalance.Text + Environment.NewLine;
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
                
                string NumeratorCurrency = "BTC"; //TODO: make currencies classes, with code as properties. 
                string DenominatorCurrency = CryptoCurrency.FiatCode;

                // Write transaction to database
                
                decimal price = Convert.ToDecimal(txtRate.Text);

                decimal fiat = Convert.ToDecimal(txtFiat.Text);

                

                Decimal tx = cardClient.WriteTransaction(TagId, OrderType, TerminalId, NumeratorCurrency, DenominatorCurrency, fiat, price, TransactionId, 0);


                 if (tx > 0)
                {
                    // Get the text for the paper receipt.
                    string receiptText = Environment.NewLine;
                    receiptText += Environment.NewLine;
                    receiptText += Environment.NewLine;
                    receiptText += Environment.NewLine;

                    receiptText += String.Format("DATE:{0}", DateTime.Now) + Environment.NewLine;
                    receiptText += "TERMINAL:" + TerminalId + Environment.NewLine;
                    receiptText += "CC CARD TRANS ID:" + TransactionId + Environment.NewLine;
                    receiptText += "DD TRANS ID:" + tx + Environment.NewLine;
                    receiptText += "CARD ID:" + TagId + Environment.NewLine;
                    receiptText += "https://blockchain.info/address/" + PublicKey + Environment.NewLine;
                    receiptText += "TRANS TYPE:" + OrderType + Environment.NewLine;
                    receiptText += "COIN NAME:" + NumeratorCurrency + Environment.NewLine;
                    receiptText += "FIAT TYPE:" + DenominatorCurrency + Environment.NewLine;
                    receiptText += "FIAT AMOUNT:" + fiat + Environment.NewLine;
                    receiptText += "COIN AMOUNT:" + CryptoCurrency.Amount.ToString("0.000000 BTC") + Environment.NewLine;
                    // receiptText += "RATE:" + Price + Environment.NewLine;
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
                    

                    atmClient.SendEmailAsync(EmailAddress, "Order. CardId:" + TagId, receiptText);
                    atmClient.SendEmailAsync("accounts@diamondcircle.net", "Sales Order. CardId:" + TagId, receiptText);

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
               // ReturnToMainMenu();
                return;
            }
        }

        private bool PrintTagReceipt()

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
            receiptText += "PRODUCT: DEBIT CARD" + Environment.NewLine;
            
            if (Properties.Settings.Default.DefaultCurrency  == "AUD") {
                receiptText += "INCLUDES 10% GST ON CARD PURCHASE" + Environment.NewLine;
                receiptText += "PRICE: $5.50 " + Properties.Settings.Default.DefaultCurrency + Environment.NewLine; //NOTE, EURO USES COMMA
            }
            else
            {
                receiptText += "PRICE: 5.00 " + Properties.Settings.Default.DefaultCurrency + Environment.NewLine; //NOTE, EURO USES COMMA
            }
                
            receiptText += Environment.NewLine;
            // Initialise the printer if required.
            if (!Factory.GetPrinter().Initialised)
            {
                try
                {
                    Factory.GetPrinter().Initialise();
                    // Print the receipt.
                    ErrorCode writeErrorCode = Factory.GetPrinter().PrintText(receiptText);
                    if (writeErrorCode != ErrorCode.None)
                    {
                        PurchaseTagStatus.Text = Comments.CannotPintReceipt;
                        throw new System.InvalidOperationException("PurchaseTag: Cannot Print Receipt");
                    }
                    
                }
                catch (Exception ex)
                {
                    PurchaseTagStatus.Text = Comments.CannotPintReceipt;
                    throw new System.InvalidOperationException("PurchaseTag: Cannot Print Receipt (Init)");
                }
            }


            return true;

        }

        private void PrintErrorMessage(string errorMessage)
        {
            // Get the text for the paper receipt.
            string receiptText = Environment.NewLine;
            receiptText += Environment.NewLine;
            receiptText += Environment.NewLine;
            receiptText += Environment.NewLine;
            receiptText += String.Format("DATE:{0}", DateTime.Now) + Environment.NewLine;
            receiptText += "TERMINAL:" + TerminalId + Environment.NewLine;
            receiptText += "CARD ID:" + TagId + Environment.NewLine;
            receiptText += "THE FOLLOWING ERROR MESSAGE WAS RECORDED" + Environment.NewLine;
            receiptText += Environment.NewLine + errorMessage + Environment.NewLine;
            receiptText += Environment.NewLine + "Contact:" + Environment.NewLine;
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
                    GeneralExceptions("PrintErrorMessage - Initialse", System.Diagnostics.TraceEventType.Error, ex);
                    return;
                }
            }

            // Print the receipt.
            ErrorCode writeErrorCode = Factory.GetPrinter().PrintText(receiptText);
            if (writeErrorCode != ErrorCode.None)
            {
                lblStatusMessage.Text = "Cannot Print Notification Receipt";
                throw new System.InvalidOperationException("PrintErrorMessage - Cannot Print Notification Receipt");
            }
        }


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
                receiptText += "CARD ID:" + TagId + Environment.NewLine;
                receiptText += "COIN NAME:" + numeratorCurrency + Environment.NewLine;
                receiptText += "===============================" + Environment.NewLine;
                receiptText += "STORE IN A SAFE PLACE - DO NOT LOSE THESE NUMBERS" + Environment.NewLine;
                receiptText += "PUBLIC ACCOUNT NUMBER: " + Environment.NewLine;
                receiptText += "https://blockchain.info/address/" + PublicKey + Environment.NewLine;

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
                receiptText += "You must register and activate your card" + Environment.NewLine;
                receiptText += Environment.NewLine;
                receiptText += "CARD ID:" + TagId + Environment.NewLine;
                receiptText += Environment.NewLine;
                receiptText += "PIN:" + PIN;
                receiptText += Environment.NewLine;
                receiptText += "Goto to:" + Environment.NewLine;
                receiptText += "http://diamondcircle.net" + Environment.NewLine; ;
                receiptText += "Choose Step 2" + Environment.NewLine;
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
                            lblStatusMessage.Text = "Hold Card on Reader";
                            grpTapTag.BackColor = System.Drawing.Color.Red;
                            this.Refresh();

                            if (nfc.ConnectReader())
                            {
                                
                                string tagid = "";
                                if (nfc.ReadTagID(ref tagid))
                                {

                                    string publickey = "";
                                    if (nfc.readPublicKey(ref publickey))
                                    {
                                        PublicKey = publickey;

                                        tmrRead.Enabled = false;

                                        lblStatusMessage.Text = "";
                                        lblTagID.Text = TagId;
                                        TagId = tagid;

                                        grpTapTag.Visible = false;
                                    
                                        RetrieveCC(TagId);
                                    
                                        lblSellorBuy.Text = Operation.ToString();

                                        loadWallPay();
                                    
                                        // Should check to see if keys are the same as recorded in the cards table.  The tags are read only and the ID's are unique.
                                    }

                                }
                            }
                            else
                            {
                                lblStatusMessage.Text = "Hold Card on Reader";
                                this.Refresh();

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

                                    grpTapTag.BackColor = System.Drawing.Color.Green;
                                    grpTapTag.Visible = false;

                                    loadWallPay();

                                    
                                    GetQuote();
                                    ChkFunds();

                                }
                                else
                                {
                                    lblStatusMessage.Text = "Tag not Registered - goto: http://diamondcircle.net";
                                    this.Refresh();
                                }
                            }
                            else
                            {
                                lblStatusMessage.Text = "Hold Card to Reader";
                                this.Refresh();
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
                            lblStatusMessage.Text = "Hold Card to Reader";
                            this.Refresh();
                            if (nfc.ConnectReader())
                            {
                                lblStatusMessage.Text = "Reading";
                                this.Refresh();
                                string tagid = "";
                                
                                if (nfc.ReadTagID(ref tagid))
                                    
                                {
                                    tmrRead.Enabled = false;
                                    picAnnimation.Visible = false;
                                    this.Refresh();

                                    TagId = tagid;
                                    lblTagID.Text = TagId;

                                    string publickey = "";
                                    if (nfc.readPublicKey(ref publickey))
                                    {
                                        lblPublic.Text = publickey;
                                        grpBalance.Visible = true;
                                        GetBalance(publickey);
                                        lblStatusMessage.Text = "";
                                        grpTapTag.BackColor = System.Drawing.Color.Green;
                                        this.Refresh();
                                        
                                        
                                    }
                                }
                            }
                            else
                            {
                                lblStatusMessage.Text = "Hold Card to Reader";
                                this.Refresh();
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
                PrintErrorMessage("Error Cannot Read Card");
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
            grpWarning.BringToFront();

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
        private void tmrConnect_Tick(object sender, EventArgs e)
        {
            if (!startup()) 
            {
                grpWait.Visible = true;
                grpWait.BringToFront();
            }
            else
            {
                grpWait.Visible = false;
            }
            

        }


        #endregion TimerManagement

        #region KeyPadButtons

        private void txtFiat_TextChanged(object sender, EventArgs e)
        {

            UpdatePrice();
          

        }
        private void UpdatePrice()
        {

            ResetTimer();
            txtRate.Text = "";
            txtBitcoins.Text = "";
            if (!String.IsNullOrEmpty(txtFiat.Text))
            {
                btnAction.Enabled = true;
                GetQuote();
                ChkFunds();
                Int32 fiatAmount = Convert.ToInt32(txtFiat.Text);
                double OrderTotal = fiatAmount;

                if (Operation == Enums.State.TagPlusBuy)
                {

                    if (Properties.Settings.Default.DefaultCurrency == "AUD")
                    {
                        OrderTotal = OrderTotal + 5.50;
                        lblProductItem.Text = "Debit Card $5.50 " + Properties.Settings.Default.DefaultCurrency + " " + txtFiat.Text + " = BITCOINS " + txtBitcoins.Text + " TOTAL PURCHASE:" + String.Format("{0:N}", OrderTotal) + " " + Properties.Settings.Default.DefaultCurrency;
                    }
                    else
                    {
                        OrderTotal = OrderTotal + 5;
                        lblProductItem.Text = "Debit Card 5.00 " + Properties.Settings.Default.DefaultCurrency + " " + txtFiat.Text + " = BITCOINS " + txtBitcoins.Text + " TOTAL PURCHASE:" + String.Format("{0:N}", OrderTotal) + " " + Properties.Settings.Default.DefaultCurrency;
                    }



                }

                if (Operation == Enums.State.Buy)
                {

                    lblProductItem.Text = "TOTAL PURCHASE:" + String.Format("{0:N}", OrderTotal) + " " + Properties.Settings.Default.DefaultCurrency;
                }
            }
            else
            {
                btnAction.Enabled = false;
                lblProductItem.Text = "";

            }

        }

        private void press(string letter)
        {
            ResetTimer();
            if (letter == "")
            {
                ActiveControl.Text = "";
            }
            else
                {

                 string FieldType = "";   
                 for (int i = 0; i < (FieldDataTypes.Length)/2; i++) {
            
                     if (FieldDataTypes[i,0] == ActiveControl.Name)
                     {
                         FieldType = FieldDataTypes[i,1];
                             break;
                     }

                 }
                if (FieldType == "0" && char.IsDigit(Convert.ToChar(letter)))
                {
                    ActiveControl.Text += letter;
                }

                else if (FieldType == "1" && (char.IsLetter(Convert.ToChar(letter)) || letter.Contains(" ") || letter.Contains("@") || letter.Contains(".")))
                {
                    ActiveControl.Text += letter;
                }

                else if (FieldType == "2")

                    if (char.IsDigit(Convert.ToChar(letter)) || (char.IsLetter(Convert.ToChar(letter)) || letter.Contains(" ") || letter.Contains("@") || letter.Contains(".")))
                    {
                            ActiveControl.Text += letter;
                }
        
            }
        }


        private void BtnAClear_Click(object sender, EventArgs e)
        {
            press("");
        }

        private void btnA_Click(object sender, EventArgs e)
        {
            press("A");
        }

        private void btnB_Click(object sender, EventArgs e)
        {
            press("B");
        }

        private void btnC_Click(object sender, EventArgs e)
        {
            press("C");
        }

        private void btnD_Click(object sender, EventArgs e)
        {
            press("D");
        }

        private void btnE_Click(object sender, EventArgs e)
        {
            press("E");
        }

        private void btnF_Click(object sender, EventArgs e)
        {
            press("F");
        }

        private void btnG_Click(object sender, EventArgs e)
        {
            press("G");
        }
        private void btnH_Click(object sender, EventArgs e)
        {
            press("H");
        }
        private void btnI_Click(object sender, EventArgs e)
        {
            press("I");
        }
        private void btnJ_Click(object sender, EventArgs e)
        {
            press("J");
        }
        private void btnK_Click(object sender, EventArgs e)
        {
            press("K");
        }
        private void btnL_Click(object sender, EventArgs e)
        {
            press("L");
        }
        private void btnM_Click(object sender, EventArgs e)
        {
            press("M");
        }
        private void btnN_Click(object sender, EventArgs e)
        {
            press("N");
        }
        private void btnO_Click(object sender, EventArgs e)
        {
            press("O");
        }
        private void btnP_Click(object sender, EventArgs e)
        {
            press("P");
        }
        private void btnQ_Click(object sender, EventArgs e)
        {
            press("Q");
        }
        private void btnR_Click(object sender, EventArgs e)
        {
            press("R");
        }
        private void btnS_Click(object sender, EventArgs e)
        {
            press("S");
        }
        private void btnT_Click(object sender, EventArgs e)
        {
            press("T");
        }

        private void btnU_Click(object sender, EventArgs e)
        {
            press("U");
        }

        private void btnV_Click(object sender, EventArgs e)
        {
            press("V");
        }

        private void btnW_Click(object sender, EventArgs e)
        {
            press("W");
        }

        private void btnX_Click(object sender, EventArgs e)
        {
            press("X");
        }

        private void btnY_Click(object sender, EventArgs e)
        {
            press("Y");
        }

        private void btnZ_Click(object sender, EventArgs e)
        {
            press("Z");
        }

        private void btnSpace_Click(object sender, EventArgs e)
        {
            press(" ");
        }

        private void btnAt_Click(object sender, EventArgs e)
        {
            press("@");
        }

        private void BtnDot_Click(object sender, EventArgs e)
        {
            press(".");
        }

        private void txtExpiryDateMM_Enter(object sender, EventArgs e)
        {
            SetWhite();
            ActiveControl = txtExpiryDateMM;
            txtExpiryDateMM.BackColor = System.Drawing.Color.Green;
        }


        private void txtExpiryDateYY_Enter(object sender, EventArgs e)
        {
            SetWhite();
            ActiveControl = txtExpiryDateYY;
            txtExpiryDateYY.BackColor = System.Drawing.Color.Green;
        }

        private void cboCountry_Enter(object sender, EventArgs e)
        {
            SetWhite();
            cboCountry.BackColor = System.Drawing.Color.Green;
        }

        private void SetWhite()
        {
            ActiveControl.BackColor = System.Drawing.Color.White;
            

            cboCountry.BackColor = System.Drawing.Color.White;

        }

        private void txtFiat_Enter(object sender, EventArgs e)
        {
            SetWhite();
            ActiveControl = txtFiat;
            ActiveControl.BackColor = System.Drawing.Color.Green;
        }


        private void txtFirstName_Enter(object sender, EventArgs e)
        {
            SetWhite();
            ActiveControl = txtFirstName;
            ActiveControl.BackColor = System.Drawing.Color.Green;
        }

        private void txtLastName_Enter(object sender, EventArgs e)
        {
            SetWhite();
            ActiveControl = txtLastName;
            ActiveControl.BackColor = System.Drawing.Color.Green;

        }

        private void txtAddress_Enter(object sender, EventArgs e)
        {
            SetWhite();
            ActiveControl = txtAddress;
            ActiveControl.BackColor = System.Drawing.Color.Green;

        }

        private void txtCity_Enter(object sender, EventArgs e)
        {
            SetWhite();
            ActiveControl = txtCity;
            ActiveControl.BackColor = System.Drawing.Color.Green;

        }

        private void txtZip_Enter(object sender, EventArgs e)
        {
            SetWhite();
            ActiveControl = txtZip;
            ActiveControl.BackColor = System.Drawing.Color.Green;
        }

        private void txtState_Enter(object sender, EventArgs e)
        {
            SetWhite();
            ActiveControl = txtState;
            ActiveControl.BackColor = System.Drawing.Color.Green;
        }
        private void txtCCNumber_Enter(object sender, EventArgs e)
        {

            SetWhite();
            ActiveControl = txtCCNumber;
            ActiveControl.BackColor = System.Drawing.Color.Green;
        }

        private void txtTelephone_Enter(object sender, EventArgs e)
        {

            SetWhite();
            ActiveControl = txtTelephone;
            ActiveControl.BackColor = System.Drawing.Color.Green;
        }

        private void txtEmail_Enter(object sender, EventArgs e)
        {
            SetWhite();
            ActiveControl = txtEmail;
            ActiveControl.BackColor = System.Drawing.Color.Green;
        }

        private void txtCVC2_Enter(object sender, EventArgs e)
        {
            SetWhite();
            ActiveControl = txtCVC2;
            ActiveControl.BackColor = System.Drawing.Color.Green;
        }

        private void txtDOB_Enter(object sender, EventArgs e)
        {
            SetWhite();
            ActiveControl = txtDOB;
            ActiveControl.BackColor = System.Drawing.Color.Green;
        }

        private void btnEnter_Click(object sender, EventArgs e)
        {
            // Increment the tab index and set focus

        }

    
        private void Btn1_Click(object sender, EventArgs e)
        {
            press("1");

        }

        private void Btn2_Click(object sender, EventArgs e)
        {
            press("2");
        }

        private void Btn3_Click(object sender, EventArgs e)
        {
            press("3");
        }

        private void Btn4_Click(object sender, EventArgs e)
        {
            press("4");
        }

        private void Btn5_Click(object sender, EventArgs e)
        {
            press("5");
        }

        private void Btn6_Click(object sender, EventArgs e)
        {
            press("6");
        }

        private void Btn7_Click(object sender, EventArgs e)
        {
            press("7");
        }

        private void Btn8_Click(object sender, EventArgs e)
        {
            press("8");
        }

        private void Btn9_Click(object sender, EventArgs e)
        {
            press("9");
        }

        private void Btn0_Click(object sender, EventArgs e)
        {
            press("0");
        }


        private void BtnClear_Click(object sender, EventArgs e)
        {
            press("");

        }

        #endregion KeyPadButtons

       
        #region ErrorManagement
        
        private void tmrHeartBeat_Tick(object sender, EventArgs e)
        {
            try
            {
                diagnosticClient.HeartBeat(this.TerminalId, "");


            }
            catch (Exception ex)
            {
                Microsoft.Practices.EnterpriseLibrary.Logging.LogEntry log = new Microsoft.Practices.EnterpriseLibrary.Logging.LogEntry()
                {
                    Title = "GeneralExceptions",
                    Message = ex.Message
                };

               // Microsoft.Practices.EnterpriseLibrary.Logging.Logger.ShouldLog(log);
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
        #endregion ErrorManagement

        #region FieldValidation
        


        private bool ValidateWalPay()
        {
            if (txtFiat.Text == "")
            {
                txtFiat.BackColor = ActiveControl.BackColor = System.Drawing.Color.Red;
                return false;
            }

            
            if (txtFirstName.Text == "")
            {
                txtFirstName.BackColor = ActiveControl.BackColor = System.Drawing.Color.Red;
                return false;
            }

            if (txtLastName.Text == "")
            {
                txtLastName.BackColor = ActiveControl.BackColor = System.Drawing.Color.Red;
                return false;
            }

            if (txtDOB.Text == "")
            {
                txtDOB.BackColor = ActiveControl.BackColor = System.Drawing.Color.Red;
                return false;
            }

            if (txtAddress.Text == "")
            {
                txtAddress.BackColor = ActiveControl.BackColor = System.Drawing.Color.Red;
                return false;
            }

            if (txtCity.Text == "")
            {
                txtCity.BackColor = ActiveControl.BackColor = System.Drawing.Color.Red;
                return false;
            }
            if (txtState.Text == "")
            {
                txtState.BackColor = ActiveControl.BackColor = System.Drawing.Color.Red;
                return false;
            }

            if (txtZip.Text == "")
            {
                txtZip.BackColor = ActiveControl.BackColor = System.Drawing.Color.Red;
                return false;
            }

            if (txtTelephone.Text == "")
            {
                txtTelephone.BackColor = ActiveControl.BackColor = System.Drawing.Color.Red;
                return false;
            }

            if (txtEmail.Text == "")
            {
                txtEmail.BackColor = ActiveControl.BackColor = System.Drawing.Color.Red;
                return false;
            }

            if (txtCVC2.Text == "")
            {
                txtCVC2.BackColor = ActiveControl.BackColor = System.Drawing.Color.Red;
                return false;
            }

            if (txtCCNumber.Text == "")
            {
                txtCCNumber.BackColor = ActiveControl.BackColor = System.Drawing.Color.Red;
                return false;
            }

            if (txtExpiryDateMM.Text == "")
            {
                txtExpiryDateMM.BackColor = ActiveControl.BackColor = System.Drawing.Color.Red;
                return false;
            }

            if (txtExpiryDateYY.Text == "")
            {
                txtExpiryDateYY.BackColor = ActiveControl.BackColor = System.Drawing.Color.Red;
                return false;
            }

            return true;


        }
        #endregion FieldValidation

        #region  LoadCountry
        private void LoadCountries()
        {

            ActiveControl = txtFiat;
            ActiveControl.Focus();
            press("");


            cboCountry.Items.Add(new CountryList { Name = "Åland Islands", Value = "AX" });
            cboCountry.Items.Add(new CountryList { Name = "Albania", Value = "AL" });
            cboCountry.Items.Add(new CountryList { Name = "Algeria", Value = "DZ" });
            cboCountry.Items.Add(new CountryList { Name = "American Samoa", Value = "AS" });
            cboCountry.Items.Add(new CountryList { Name = "Andorra", Value = "AD" });
            cboCountry.Items.Add(new CountryList { Name = "Angola", Value = "AO" });
            cboCountry.Items.Add(new CountryList { Name = "Anguilla", Value = "AI" });
            cboCountry.Items.Add(new CountryList { Name = "Antarctica", Value = "AQ" });
            cboCountry.Items.Add(new CountryList { Name = "Antigua and Barbuda", Value = "AG" });
            cboCountry.Items.Add(new CountryList { Name = "Argentina", Value = "AR" });
            cboCountry.Items.Add(new CountryList { Name = "Armenia", Value = "AM" });
            cboCountry.Items.Add(new CountryList { Name = "Aruba", Value = "AW" });
            cboCountry.Items.Add(new CountryList { Name = "Australia", Value = "AU" });
            cboCountry.Items.Add(new CountryList { Name = "Austria", Value = "AT" });
            cboCountry.Items.Add(new CountryList { Name = "Azerbaijan", Value = "AZ" });
            cboCountry.Items.Add(new CountryList { Name = "Bahamas", Value = "BS" });
            cboCountry.Items.Add(new CountryList { Name = "Bahrain", Value = "BH" });
            cboCountry.Items.Add(new CountryList { Name = "Bangladesh", Value = "BD" });
            cboCountry.Items.Add(new CountryList { Name = "Barbados", Value = "BB" });
            cboCountry.Items.Add(new CountryList { Name = "Belarus", Value = "BY" });
            cboCountry.Items.Add(new CountryList { Name = "Belgium", Value = "BE" });
            cboCountry.Items.Add(new CountryList { Name = "Belize", Value = "BZ" });
            cboCountry.Items.Add(new CountryList { Name = "Benin", Value = "BJ" });
            cboCountry.Items.Add(new CountryList { Name = "Bermuda", Value = "BM" });
            cboCountry.Items.Add(new CountryList { Name = "Bhutan", Value = "BT" });
            cboCountry.Items.Add(new CountryList { Name = "Bolivia", Value = "BO" });
            cboCountry.Items.Add(new CountryList { Name = "Bosnia and Herzegovina", Value = "BA" });
            cboCountry.Items.Add(new CountryList { Name = "Botswana", Value = "BW" });
            cboCountry.Items.Add(new CountryList { Name = "Bouvet Island", Value = "BV" });
            cboCountry.Items.Add(new CountryList { Name = "Brazil", Value = "BR" });
            cboCountry.Items.Add(new CountryList { Name = "British Indian Ocean Territory", Value = "IO" });
            cboCountry.Items.Add(new CountryList { Name = "Brunei Darussalam", Value = "BN" });
            cboCountry.Items.Add(new CountryList { Name = "Bulgaria", Value = "BG" });
            cboCountry.Items.Add(new CountryList { Name = "Burkina Faso", Value = "BF" });
            cboCountry.Items.Add(new CountryList { Name = "Burundi", Value = "BI" });
            cboCountry.Items.Add(new CountryList { Name = "Cambodia", Value = "KH" });
            cboCountry.Items.Add(new CountryList { Name = "Cameroon", Value = "CM" });
            cboCountry.Items.Add(new CountryList { Name = "Canada", Value = "CA" });
            cboCountry.Items.Add(new CountryList { Name = "Cape Verde", Value = "CV" });
            cboCountry.Items.Add(new CountryList { Name = "Cayman Islands", Value = "KY" });
            cboCountry.Items.Add(new CountryList { Name = "Central African Republic", Value = "CF" });
            cboCountry.Items.Add(new CountryList { Name = "Chad", Value = "TD" });
            cboCountry.Items.Add(new CountryList { Name = "Chile", Value = "CL" });
            cboCountry.Items.Add(new CountryList { Name = "China", Value = "CN" });
            cboCountry.Items.Add(new CountryList { Name = "Christmas Island", Value = "CX" });
            cboCountry.Items.Add(new CountryList { Name = "Cocos (Keeling) Islands", Value = "CC" });
            cboCountry.Items.Add(new CountryList { Name = "Colombia", Value = "CO" });
            cboCountry.Items.Add(new CountryList { Name = "Comoros", Value = "KM" });
            cboCountry.Items.Add(new CountryList { Name = "Congo", Value = "CG" });
            cboCountry.Items.Add(new CountryList { Name = "Congo, The Democratic Republic of The", Value = "CD" });
            cboCountry.Items.Add(new CountryList { Name = "Cook Islands", Value = "CK" });
            cboCountry.Items.Add(new CountryList { Name = "Costa Rica", Value = "CR" });
            cboCountry.Items.Add(new CountryList { Name = "Cote D'ivoire", Value = "CI" });
            cboCountry.Items.Add(new CountryList { Name = "Croatia", Value = "HR" });
            cboCountry.Items.Add(new CountryList { Name = "Cuba", Value = "CU" });
            cboCountry.Items.Add(new CountryList { Name = "Cyprus", Value = "CY" });
            cboCountry.Items.Add(new CountryList { Name = "Czech Republic", Value = "CZ" });
            cboCountry.Items.Add(new CountryList { Name = "Denmark", Value = "DK" });
            cboCountry.Items.Add(new CountryList { Name = "Djibouti", Value = "DJ" });
            cboCountry.Items.Add(new CountryList { Name = "Dominica", Value = "DM" });
            cboCountry.Items.Add(new CountryList { Name = "Dominican Republic", Value = "DO" });
            cboCountry.Items.Add(new CountryList { Name = "Ecuador", Value = "EC" });
            cboCountry.Items.Add(new CountryList { Name = "Egypt", Value = "EG" });
            cboCountry.Items.Add(new CountryList { Name = "El Salvador", Value = "SV" });
            cboCountry.Items.Add(new CountryList { Name = "Equatorial Guinea", Value = "GQ" });
            cboCountry.Items.Add(new CountryList { Name = "Eritrea", Value = "ER" });
            cboCountry.Items.Add(new CountryList { Name = "Estonia", Value = "EE" });
            cboCountry.Items.Add(new CountryList { Name = "Ethiopia", Value = "ET" });
            cboCountry.Items.Add(new CountryList { Name = "Falkland Islands (Malvinas)", Value = "FK" });
            cboCountry.Items.Add(new CountryList { Name = "Faroe Islands", Value = "FO" });
            cboCountry.Items.Add(new CountryList { Name = "Fiji", Value = "FJ" });
            cboCountry.Items.Add(new CountryList { Name = "Finland", Value = "FI" });
            cboCountry.Items.Add(new CountryList { Name = "France", Value = "FR" });
            cboCountry.Items.Add(new CountryList { Name = "French Guiana", Value = "GF" });
            cboCountry.Items.Add(new CountryList { Name = "French Polynesia", Value = "PF" });
            cboCountry.Items.Add(new CountryList { Name = "French Southern Territories", Value = "TF" });
            cboCountry.Items.Add(new CountryList { Name = "Gabon", Value = "GA" });
            cboCountry.Items.Add(new CountryList { Name = "Gambia", Value = "GM" });
            cboCountry.Items.Add(new CountryList { Name = "Georgia", Value = "GE" });
            cboCountry.Items.Add(new CountryList { Name = "Germany", Value = "DE" });
            cboCountry.Items.Add(new CountryList { Name = "Ghana", Value = "GH" });
            cboCountry.Items.Add(new CountryList { Name = "Gibraltar", Value = "GI" });
            cboCountry.Items.Add(new CountryList { Name = "Greece", Value = "GR" });
            cboCountry.Items.Add(new CountryList { Name = "Greenland", Value = "GL" });
            cboCountry.Items.Add(new CountryList { Name = "Grenada", Value = "GD" });
            cboCountry.Items.Add(new CountryList { Name = "Guadeloupe", Value = "GP" });
            cboCountry.Items.Add(new CountryList { Name = "Guam", Value = "GU" });
            cboCountry.Items.Add(new CountryList { Name = "Guatemala", Value = "GT" });
            cboCountry.Items.Add(new CountryList { Name = "Guernsey", Value = "GG" });
            cboCountry.Items.Add(new CountryList { Name = "Guinea", Value = "GN" });
            cboCountry.Items.Add(new CountryList { Name = "Guinea-bissau", Value = "GW" });
            cboCountry.Items.Add(new CountryList { Name = "Guyana", Value = "GY" });
            cboCountry.Items.Add(new CountryList { Name = "Haiti", Value = "HT" });
            cboCountry.Items.Add(new CountryList { Name = "Heard Island and Mcdonald Islands", Value = "HM" });
            cboCountry.Items.Add(new CountryList { Name = "Holy See (Vatican City State)", Value = "VA" });
            cboCountry.Items.Add(new CountryList { Name = "Honduras", Value = "HN" });
            cboCountry.Items.Add(new CountryList { Name = "Hong Kong", Value = "HK" });
            cboCountry.Items.Add(new CountryList { Name = "Hungary", Value = "HU" });
            cboCountry.Items.Add(new CountryList { Name = "Iceland", Value = "IS" });
            cboCountry.Items.Add(new CountryList { Name = "India", Value = "IN" });
            cboCountry.Items.Add(new CountryList { Name = "Indonesia", Value = "ID" });
            cboCountry.Items.Add(new CountryList { Name = "Iran, Islamic Republic of", Value = "IR" });
            cboCountry.Items.Add(new CountryList { Name = "Iraq", Value = "IQ" });
            cboCountry.Items.Add(new CountryList { Name = "Ireland", Value = "IE" });
            cboCountry.Items.Add(new CountryList { Name = "Isle of Man", Value = "IM" });
            cboCountry.Items.Add(new CountryList { Name = "Israel", Value = "IL" });
            cboCountry.Items.Add(new CountryList { Name = "Italy", Value = "IT" });
            cboCountry.Items.Add(new CountryList { Name = "Jamaica", Value = "JM" });
            cboCountry.Items.Add(new CountryList { Name = "Japan", Value = "JP" });
            cboCountry.Items.Add(new CountryList { Name = "Jersey", Value = "JE" });
            cboCountry.Items.Add(new CountryList { Name = "Jordan", Value = "JO" });
            cboCountry.Items.Add(new CountryList { Name = "Kazakhstan", Value = "KZ" });
            cboCountry.Items.Add(new CountryList { Name = "Kenya", Value = "KE" });
            cboCountry.Items.Add(new CountryList { Name = "Kiribati", Value = "KI" });
            cboCountry.Items.Add(new CountryList { Name = "Korea, Democratic People's Republic of", Value = "KP" });
            cboCountry.Items.Add(new CountryList { Name = "Korea, Republic of", Value = "KR" });
            cboCountry.Items.Add(new CountryList { Name = "Kuwait", Value = "KW" });
            cboCountry.Items.Add(new CountryList { Name = "Kyrgyzstan", Value = "KG" });
            cboCountry.Items.Add(new CountryList { Name = "Lao People's Democratic Republic", Value = "LA" });
            cboCountry.Items.Add(new CountryList { Name = "Latvia", Value = "LV" });
            cboCountry.Items.Add(new CountryList { Name = "Lebanon", Value = "LB" });
            cboCountry.Items.Add(new CountryList { Name = "Lesotho", Value = "LS" });
            cboCountry.Items.Add(new CountryList { Name = "Liberia", Value = "LR" });
            cboCountry.Items.Add(new CountryList { Name = "Libyan Arab Jamahiriya", Value = "LY" });
            cboCountry.Items.Add(new CountryList { Name = "Liechtenstein", Value = "LI" });
            cboCountry.Items.Add(new CountryList { Name = "Lithuania", Value = "LT" });
            cboCountry.Items.Add(new CountryList { Name = "Luxembourg", Value = "LU" });
            cboCountry.Items.Add(new CountryList { Name = "Macao", Value = "MO" });
            cboCountry.Items.Add(new CountryList { Name = "Macedonia, The Former Yugoslav Republic ", Value = "MK" });
            cboCountry.Items.Add(new CountryList { Name = "Madagascar", Value = "MG" });
            cboCountry.Items.Add(new CountryList { Name = "Malawi", Value = "MW" });
            cboCountry.Items.Add(new CountryList { Name = "Malaysia", Value = "MY" });
            cboCountry.Items.Add(new CountryList { Name = "Maldives", Value = "MV" });
            cboCountry.Items.Add(new CountryList { Name = "Mali", Value = "ML" });
            cboCountry.Items.Add(new CountryList { Name = "Malta", Value = "MT" });
            cboCountry.Items.Add(new CountryList { Name = "Marshall Islands", Value = "MH" });
            cboCountry.Items.Add(new CountryList { Name = "Martinique", Value = "MQ" });
            cboCountry.Items.Add(new CountryList { Name = "Mauritania", Value = "MR" });
            cboCountry.Items.Add(new CountryList { Name = "Mauritius", Value = "MU" });
            cboCountry.Items.Add(new CountryList { Name = "Mayotte", Value = "YT" });
            cboCountry.Items.Add(new CountryList { Name = "Mexico", Value = "MX" });
            cboCountry.Items.Add(new CountryList { Name = "Micronesia, Federated States of", Value = "FM" });
            cboCountry.Items.Add(new CountryList { Name = "Moldova, Republic of", Value = "MD" });
            cboCountry.Items.Add(new CountryList { Name = "Monaco", Value = "MC" });
            cboCountry.Items.Add(new CountryList { Name = "Mongolia", Value = "MN" });
            cboCountry.Items.Add(new CountryList { Name = "Montenegro", Value = "ME" });
            cboCountry.Items.Add(new CountryList { Name = "Montserrat", Value = "MS" });
            cboCountry.Items.Add(new CountryList { Name = "Morocco", Value = "MA" });
            cboCountry.Items.Add(new CountryList { Name = "Mozambique", Value = "MZ" });
            cboCountry.Items.Add(new CountryList { Name = "Myanmar", Value = "MM" });
            cboCountry.Items.Add(new CountryList { Name = "Namibia", Value = "NA" });
            cboCountry.Items.Add(new CountryList { Name = "Nauru", Value = "NR" });
            cboCountry.Items.Add(new CountryList { Name = "Nepal", Value = "NP" });
            cboCountry.Items.Add(new CountryList { Name = "Netherlands", Value = "NL" });
            cboCountry.Items.Add(new CountryList { Name = "Netherlands Antilles", Value = "AN" });
            cboCountry.Items.Add(new CountryList { Name = "New Caledonia", Value = "NC" });
            cboCountry.Items.Add(new CountryList { Name = "New Zealand", Value = "NZ" });
            cboCountry.Items.Add(new CountryList { Name = "Nicaragua", Value = "NI" });
            cboCountry.Items.Add(new CountryList { Name = "Niger", Value = "NE" });
            cboCountry.Items.Add(new CountryList { Name = "Nigeria", Value = "NG" });
            cboCountry.Items.Add(new CountryList { Name = "Niue", Value = "NU" });
            cboCountry.Items.Add(new CountryList { Name = "Norfolk Island", Value = "NF" });
            cboCountry.Items.Add(new CountryList { Name = "Northern Mariana Islands", Value = "MP" });
            cboCountry.Items.Add(new CountryList { Name = "Norway", Value = "NO" });
            cboCountry.Items.Add(new CountryList { Name = "Oman", Value = "OM" });
            cboCountry.Items.Add(new CountryList { Name = "Pakistan", Value = "PK" });
            cboCountry.Items.Add(new CountryList { Name = "Palau", Value = "PW" });
            cboCountry.Items.Add(new CountryList { Name = "Palestinian Territory, Occupied", Value = "PS" });
            cboCountry.Items.Add(new CountryList { Name = "Panama", Value = "PA" });
            cboCountry.Items.Add(new CountryList { Name = "Papua New Guinea", Value = "PG" });
            cboCountry.Items.Add(new CountryList { Name = "Paraguay", Value = "PY" });
            cboCountry.Items.Add(new CountryList { Name = "Peru", Value = "PE" });
            cboCountry.Items.Add(new CountryList { Name = "Philippines", Value = "PH" });
            cboCountry.Items.Add(new CountryList { Name = "Pitcairn", Value = "PN" });
            cboCountry.Items.Add(new CountryList { Name = "Poland", Value = "PL" });
            cboCountry.Items.Add(new CountryList { Name = "Portugal", Value = "PT" });
            cboCountry.Items.Add(new CountryList { Name = "Puerto Rico", Value = "PR" });
            cboCountry.Items.Add(new CountryList { Name = "Qatar", Value = "QA" });
            cboCountry.Items.Add(new CountryList { Name = "Reunion", Value = "RE" });
            cboCountry.Items.Add(new CountryList { Name = "Romania", Value = "RO" });
            cboCountry.Items.Add(new CountryList { Name = "Russian Federation", Value = "RU" });
            cboCountry.Items.Add(new CountryList { Name = "Rwanda", Value = "RW" });
            cboCountry.Items.Add(new CountryList { Name = "Saint Helena", Value = "SH" });
            cboCountry.Items.Add(new CountryList { Name = "Saint Kitts and Nevis", Value = "KN" });
            cboCountry.Items.Add(new CountryList { Name = "Saint Lucia", Value = "LC" });
            cboCountry.Items.Add(new CountryList { Name = "Saint Pierre and Miquelon", Value = "PM" });
            cboCountry.Items.Add(new CountryList { Name = "Saint Vincent and The Grenadines", Value = "VC" });
            cboCountry.Items.Add(new CountryList { Name = "Samoa", Value = "WS" });
            cboCountry.Items.Add(new CountryList { Name = "San Marino", Value = "SM" });
            cboCountry.Items.Add(new CountryList { Name = "Sao Tome and Principe", Value = "ST" });
            cboCountry.Items.Add(new CountryList { Name = "Saudi Arabia", Value = "SA" });
            cboCountry.Items.Add(new CountryList { Name = "Senegal", Value = "SN" });
            cboCountry.Items.Add(new CountryList { Name = "Serbia", Value = "RS" });
            cboCountry.Items.Add(new CountryList { Name = "Seychelles", Value = "SC" });
            cboCountry.Items.Add(new CountryList { Name = "Sierra Leone", Value = "SL" });
            cboCountry.Items.Add(new CountryList { Name = "Singapore", Value = "SG" });
            cboCountry.Items.Add(new CountryList { Name = "Slovakia", Value = "SK" });
            cboCountry.Items.Add(new CountryList { Name = "Slovenia", Value = "SI" });
            cboCountry.Items.Add(new CountryList { Name = "Solomon Islands", Value = "SB" });
            cboCountry.Items.Add(new CountryList { Name = "Somalia", Value = "SO" });
            cboCountry.Items.Add(new CountryList { Name = "South Africa", Value = "ZA" });
            cboCountry.Items.Add(new CountryList { Name = "South Georgia and The South Sandwich Isl", Value = "GS" });
            cboCountry.Items.Add(new CountryList { Name = "Spain", Value = "ES" });
            cboCountry.Items.Add(new CountryList { Name = "Sri Lanka", Value = "LK" });
            cboCountry.Items.Add(new CountryList { Name = "Sudan", Value = "SD" });
            cboCountry.Items.Add(new CountryList { Name = "Suriname", Value = "SR" });
            cboCountry.Items.Add(new CountryList { Name = "Svalbard and Jan Mayen", Value = "SJ" });
            cboCountry.Items.Add(new CountryList { Name = "Swaziland", Value = "SZ" });
            cboCountry.Items.Add(new CountryList { Name = "Sweden", Value = "SE" });
            cboCountry.Items.Add(new CountryList { Name = "Switzerland", Value = "CH" });
            cboCountry.Items.Add(new CountryList { Name = "Syrian Arab Republic", Value = "SY" });
            cboCountry.Items.Add(new CountryList { Name = "Taiwan, Province of China", Value = "TW" });
            cboCountry.Items.Add(new CountryList { Name = "Tajikistan", Value = "TJ" });
            cboCountry.Items.Add(new CountryList { Name = "Tanzania, United Republic of", Value = "TZ" });
            cboCountry.Items.Add(new CountryList { Name = "Thailand", Value = "TH" });
            cboCountry.Items.Add(new CountryList { Name = "Timor-leste", Value = "TL" });
            cboCountry.Items.Add(new CountryList { Name = "Togo", Value = "TG" });
            cboCountry.Items.Add(new CountryList { Name = "Tokelau", Value = "TK" });
            cboCountry.Items.Add(new CountryList { Name = "Tonga", Value = "TO" });
            cboCountry.Items.Add(new CountryList { Name = "Trinidad and Tobago", Value = "TT" });
            cboCountry.Items.Add(new CountryList { Name = "Tunisia", Value = "TN" });
            cboCountry.Items.Add(new CountryList { Name = "Turkey", Value = "TR" });
            cboCountry.Items.Add(new CountryList { Name = "Turkmenistan", Value = "TM" });
            cboCountry.Items.Add(new CountryList { Name = "Turks and Caicos Islands", Value = "TC" });
            cboCountry.Items.Add(new CountryList { Name = "Tuvalu", Value = "TV" });
            cboCountry.Items.Add(new CountryList { Name = "Uganda", Value = "UG" });
            cboCountry.Items.Add(new CountryList { Name = "Ukraine", Value = "UA" });
            cboCountry.Items.Add(new CountryList { Name = "United Arab Emirates", Value = "AE" });
            cboCountry.Items.Add(new CountryList { Name = "United Kingdom", Value = "GB" });
            cboCountry.Items.Add(new CountryList { Name = "United States", Value = "US" });
            cboCountry.Items.Add(new CountryList { Name = "United States Minor Outlying Islands", Value = "UM" });
            cboCountry.Items.Add(new CountryList { Name = "Uruguay", Value = "UY" });
            cboCountry.Items.Add(new CountryList { Name = "Uzbekistan", Value = "UZ" });
            cboCountry.Items.Add(new CountryList { Name = "Vanuatu", Value = "VU" });
            cboCountry.Items.Add(new CountryList { Name = "Venezuela", Value = "VE" });
            cboCountry.Items.Add(new CountryList { Name = "Viet Nam", Value = "VN" });
            cboCountry.Items.Add(new CountryList { Name = "Virgin Islands, British", Value = "VG" });
            cboCountry.Items.Add(new CountryList { Name = "Virgin Islands, U.S.", Value = "VI" });
            cboCountry.Items.Add(new CountryList { Name = "Wallis and Futuna", Value = "WF" });
            cboCountry.Items.Add(new CountryList { Name = "Western Sahara", Value = "EH" });
            cboCountry.Items.Add(new CountryList { Name = "Yemen", Value = "YE" });
            cboCountry.Items.Add(new CountryList { Name = "Zambia", Value = "ZM" });
            cboCountry.Items.Add(new CountryList { Name = "Zimbabwe", Value = "ZW" });

            String Country = Properties.Settings.Default.Country;
            int index = cboCountry.FindString(Country);
            cboCountry.SelectedIndex = index;

        }
        #endregion  LoadCountry

      
        private void ChkFunds()
        {
            if (Operation == Enums.State.Sell)
            {
                GetBalance(PublicKey);

                if (!String.IsNullOrEmpty(txtBitcoins.Text) && !String.IsNullOrEmpty(lblBTCBalance.Text))
                {
                    if (Convert.ToDecimal(txtBitcoins.Text) > Convert.ToDecimal(lblBTCBalance.Text))
                    {
                        btnAction.Enabled = false;
                        btnAction.Text = "LOW FUNDS";
                        txtFiat.Text = "1";
                        return;
                    }
                }
                btnAction.Text = Operation.ToString();
                btnAction.Enabled = true;
            }
        }


        private void SendKeyReceipt(String CardId, String PublicKey, String PrivateKey)
        {
            try
            {

                String body = "";
                body += Environment.NewLine;

                body += "Dear " + FirstName + "," + Environment.NewLine;
                body += Environment.NewLine;
                body += Environment.NewLine;
                body += "Your Purchase" + Environment.NewLine;
                body += "From Terminal" + TerminalId + Environment.NewLine;
                body += Environment.NewLine;
                body += "Your Public Bitcoin Address is: https://blockchain.info/address/" + PublicKey + Environment.NewLine;
                body += Environment.NewLine;
                body += "LOSE THE FOLLOWING INFORMATION AND YOUR BITCOINS ARE LOST" + Environment.NewLine;
                body += "Your Private Key is: " + PrivateKey + Environment.NewLine;
                body += Environment.NewLine;
                body += "Activate your card here:" + Environment.NewLine;
                body += "http://diamondcircle.net" + Environment.NewLine;
                body += Environment.NewLine;
                body += "Thank you" + Environment.NewLine;
                body += Environment.NewLine;
                body += "Diamond Circle Team" + Environment.NewLine;
                body += Environment.NewLine;
                body += "Allow for 6 Confirmations before balance appears." + Environment.NewLine;
                body += "See Terms and Conditions " + Environment.NewLine;
                atmClient.SendEmailAsync(EmailAddress, "Diamond Circle Private Key. CardId:" + TagId, body);
            }
            catch (Exception ex)
            {
                GeneralExceptions("CannotSendEmail", System.Diagnostics.TraceEventType.Critical, ex);
            }
        }
        private String ChargeCard(String CardNumber, String CVC, String ExpiryMonth, String ExpiryYear, String Name, String Address1, String City, String State, String Postcode, String Country, int Amount, String Currency, String Desc, String EmailAddress)
        {
            try
            { 

            DCCard.ChargeResult chargeresult = new DCCard.ChargeResult();
            Currency = "AUD";
            chargeresult = cardClient.ChargeCreditCard(CardNumber, Amount, FirstName, LastName, Address1, City, State, Postcode, Country, "", "", EmailAddress, FirstName + " " +LastName, ExpiryMonth, ExpiryYear, CVC, Currency);

            if (chargeresult.failure_message != null)
            {
                return chargeresult.failure_message;
            }

                else
            {
                TransactionId = chargeresult.Id;
                return "Approved";
            }

                }
            catch (Exception ex)
            {
                TransactionId = "Deferred";
                return "Approved";
            }
            
            

            
                

        }
       
        //private string IssueRefund()
        //{
        //    try
        //    {
        //        PinPayments.PinService ps = new PinPayments.PinService(Properties.Settings.Default.Secret_API);
        //        ps.Refund(TransactionId, RefundAmount);
        //        PrintErrorMessage("Refunding your Credit Card Completed");
        //    }
        //    catch (Exception ex)
        //    {
             
        //        return "Fail";

        //    }
        
        //       return "Refunded";
        //}
        private void RetrieveCC(String TagId)
        {
            
            // TODO: Query the Cards Table and populate
            try
            {

            DCCard.CCInfo DCCardData  = cardClient.GetCustomerCC(TagId);
            txtCCNumber.Text = DCCardData.CardNumber;
            txtExpiryDateMM.Text = "";
            txtExpiryDateYY.Text = "";
            txtFirstName.Text = DCCardData.FirstName;
            txtLastName.Text = DCCardData.LastName;
            txtAddress.Text = DCCardData.Address;
            txtCity.Text = DCCardData.City;
            txtState.Text = DCCardData.State;
            txtZip.Text = DCCardData.Zip;
            cboCountry.SelectedValue = DCCardData.CountryName;
            lblCurrency.Text = "";
            Product = TagId;
            txtEmail.Text = DCCardData.EmailAddress;
            txtTelephone.Text = DCCardData.Telephone;
            txtDOB.Text = DCCardData.DOB;
       //     txtCVC2.Text = DCCardData.CVC2;  // Disabled for security reasons
                }
            catch (Exception ex)
            {
                // PrintErrorMessage("No CC on File");
               
                SaveCCData = true;
               
                
            }
             
        }

        private void btnCancelPay_Click(object sender, EventArgs e)
        {
            ReturnToMainMenu();

        }

        private void lblSellorBuy_Click(object sender, EventArgs e)
        {

        }

        
      
   

      

       

        

        
    }

    public class CountryList
    {
        public String Name { get; set; }
        public String Value { get; set; }
        public override String ToString() { return this.Name; }
    }

    

}


