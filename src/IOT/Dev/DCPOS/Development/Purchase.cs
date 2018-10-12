using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DCPOS
{
    public partial class Purchase : Form
    {

        #region Constructors and private properties

        
        private string _errorMessageAmount = "";
        private string _errorMessageCurrency = "";
        private string _errorMessagePurchase = "";

        private DCCommon common = new DCCommon();


        public Purchase()
        {
            InitializeComponent();

        }

        #endregion

        #region Bitcoin quote methods

        private void GetQuote()
        {
            UseWaitCursor = true;
            try
            {
                if (txtAmount.Text != "" && Convert.ToInt32(txtAmount.Text) > 0)
                {
                    txtBitcoins.Text = common.getquote(Convert.ToInt32(txtAmount.Text), cboCurrency.SelectedItem.ToString()).ToString("0.000000");
                    txtBitcoins.Visible = true;
                    labelBitcoins.Visible = true;
                }
                else
                {
                    txtBitcoins.Visible = false;
                    labelBitcoins.Visible = false;
                }

            }
            catch (Exception ex)
            {
                //TODO: Log error 
            }
            finally
            {
                UseWaitCursor = false;
            }

        }

        private Decimal GetSpotPrice(String Currency, Decimal amount)
        {
            Cursor.Current = Cursors.WaitCursor;
            decimal bitcoins = common.getspotprice(cboCurrency.SelectedItem.ToString(), amount);
            Cursor.Current = Cursors.Default;
            return bitcoins;

        }

        #endregion

        #region Common event methods

        private void Purchase_Load(object sender, EventArgs e)
        {
            cboCurrency.SelectedIndex = 1;

        }

        private void cboCurrency_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (IsValid())
            {
                GetQuote();
            }
        }

        private void txtAmount_Leave(object sender, EventArgs e)
        {
            if (IsValid())
            {
                try
                {


                    txtBitcoins.Text = common.getquote(Convert.ToInt32(txtAmount.Text), cboCurrency.SelectedItem.ToString()).ToString("0.000000");
                }
                catch (Exception ex)
                {

                }

            }           
            
        }

        #endregion

        #region Purchase methods

        private void btnPurchase_Click(object sender, EventArgs e)
        {
            try
            {
                UseWaitCursor = true;

                if (!IsValid()) return;

                String CardId = "";

                if (common.nfc.InitReader())
                {
                    if (common.nfc.ConnectReader())
                    {
                        if (common.nfc.ReadTagID(ref CardId))
                        {
                            Decimal FiatAmount = Convert.ToInt32(txtAmount.Text);
                            Decimal Bitcoins = Convert.ToDecimal(txtBitcoins.Text);
                            String encryptedPrivateKey = "";

                            if (common.nfc.readPrivateKey(ref encryptedPrivateKey))
                            {
                                String FromCardPublicAddress = "";
                                if (common.nfc.readPublicKey(ref FromCardPublicAddress))
                                {
                                    if (common.ChkPINLimit(CardId, FiatAmount, cboCurrency.SelectedItem.ToString()) == "01")
                                    {
                                        PinPad pinform = new PinPad();
                                        pinform.ShowDialog();

                                        if (common.checkPin(CardId, Program.Pin) == "00")
                                        {

                                            String result = common.SendBitcoins(CardId, FromCardPublicAddress, encryptedPrivateKey, Program.MerchantCardId, Bitcoins, FiatAmount, cboCurrency.SelectedItem.ToString());
                                            MessageBox.Show(result);
                                        }
                                            else
                                        {
                                            MessageBox.Show("Invalid Pin");
                                        }
                                        
                                    }
                                    else
                                    {  

                                        String result = common.SendBitcoins(CardId, FromCardPublicAddress, encryptedPrivateKey, Program.MerchantCardId, Bitcoins, FiatAmount, cboCurrency.SelectedItem.ToString());
                                        MessageBox.Show(result);
                                    }
                                }
                                else
                                {
                                    _errorMessagePurchase = "Cannot read Public Key";
                                }

                            }
                            else
                            {
                                _errorMessagePurchase = "Cannot read Private Key";

                            }
                        }
                        else
                        {
                            _errorMessagePurchase = "Card not on Reader or cannot read card ";
                        }
                    }
                    else
                    {
                        _errorMessagePurchase = "The Reader cannot be Initalised";
                    }
                }
                else
                {
                    _errorMessagePurchase = "The Reader cannot be Initalised";
                }
            }
            catch (Exception ex)
            {
                _errorMessagePurchase = ex.ToString();

                //ToDO: log error
            }
            finally
            {
                ShowValidationMessages();
                UseWaitCursor = false;
            }

        }

        #endregion

        #region Validation

        private bool IsValid()
        {
            ClearValidationMessages();

            bool isValid = true;
            decimal amount;
            var amountText = txtAmount.Text;
            if (string.IsNullOrWhiteSpace(amountText))
            {
                _errorMessageAmount = "Enter an amount ";
                isValid = false;
            }
            else
            {
                try
                {
                    amount = decimal.Parse(amountText);
                }
                catch
                {
                    _errorMessageAmount = "Invalid amount entered ";
                    isValid = false;
                }
            }
            if (cboCurrency.SelectedIndex < 0)
            {
                _errorMessageCurrency = "Select a currency";
                isValid = false;

            }
            return isValid;
        }


        private void ShowValidationMessages()
        {
            labelErrorAmount.Text = _errorMessageAmount;
            labelErrorCurrency.Text = _errorMessageCurrency;
            labelErrorPurchase.Text = _errorMessagePurchase;

            DisplayErrorMessages();
        }

        private void ClearValidationMessages()
        {
            _errorMessageAmount = string.Empty;
            _errorMessageCurrency = string.Empty;
            _errorMessagePurchase = string.Empty;
            DisplayErrorMessages();
        }

        private void DisplayErrorMessages()
        {
            labelErrorAmount.Visible = _errorMessageAmount.Length > 0;
            labelErrorCurrency.Visible = _errorMessageCurrency.Length > 0;
            labelErrorPurchase.Visible = _errorMessagePurchase.Length > 0;
        }


        #endregion


    }


}


