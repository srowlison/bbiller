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
    public partial class SellBitcoin : Form
    {
        #region Constructors and private methods

        
        private string _errorMessageAmount = "";
        private string _errorMessageCurrency = "";
        private string _errorMessageButton = "";

        private DCCommon common = new DCCommon();


        public SellBitcoin()
        {
            InitializeComponent();
        }

        #endregion

        #region Sell Bitcoin methods

        private void btnSell_Click(object sender, EventArgs e)
        {
            try
            {
                UseWaitCursor = false;
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
                                            MessageBox.Show("Pin Invalid");
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
                                    _errorMessageButton = "Cannot read Public Key";
                                    this.Refresh();
                                }
                            }
                            else
                            {
                                _errorMessageButton = "Cannot read Private Key";
                                this.Refresh();
                            }
                        }
                        else
                        {
                            _errorMessageButton = "Card not on Reader or cannot read card ";
                            this.Refresh();
                        }

                    }
                    else
                    {
                        _errorMessageButton = "The Reader cannot be Connected ";
                        this.Refresh();
                    }
                }
                else
                {
                    _errorMessageButton = "The Reader cannot be Initalised ";
                    this.Refresh();
                }
            }
            catch (Exception ex)
            {
                //TODO: log error
                _errorMessageButton = "Error:" + ex.ToString();
                this.Refresh();


            }
            finally
            {
                ShowValidationMessages();
                UseWaitCursor = false;
            }
        }

        #endregion

        #region Common event methods


        private void SellBitcoin_Load(object sender, EventArgs e)
        {
            cboCurrency.SelectedIndex = 1;

        }


        private void cboCurrency_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboCurrency.SelectedIndex > 0)
            {
                GetQuote();
            }
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
                    this.Refresh();
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
                txtBitcoins.Text = "Unable to get quote";
                this.Refresh();
                txtBitcoins.Visible = true;
            }
            finally
            {
                UseWaitCursor = false;
            }

        }

        #endregion

        #region Validation


        private bool IsValid()
        {
            bool isValid = true;
            decimal amount;
            var amountText = txtAmount.Text;
            if (string.IsNullOrEmpty(amountText))
            {
                _errorMessageAmount = "Enter an amount ";
                this.Refresh();
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
                    this.Refresh();
                    isValid = false;
                }
            }
            if (cboCurrency.SelectedIndex < 0)
            {
                _errorMessageCurrency = "Select a currency";
                this.Refresh();
                isValid = false;

            }
            return isValid;
        }

        private void txtAmount_Leave(object sender, EventArgs e)
        {
            if (cboCurrency.SelectedIndex > 0)
            {
                GetQuote();
            }
        }


        private void ShowValidationMessages()
        {
            labelErrorAmount.Text = _errorMessageAmount;
            labelErrorCurrency.Text = _errorMessageCurrency;
            labelErrorSell.Text = _errorMessageButton;

            DisplayErrorMessages();
        }

        private void ClearValidationMessages()
        {
            _errorMessageAmount = string.Empty;
            _errorMessageCurrency = string.Empty;
            _errorMessageButton = string.Empty;
            DisplayErrorMessages();
        }

        private void DisplayErrorMessages()
        {
            labelErrorAmount.Visible = _errorMessageAmount.Length > 0;
            labelErrorCurrency.Visible = _errorMessageCurrency.Length > 0;
            labelErrorSell.Visible = _errorMessageButton.Length > 0;

            this.Refresh();
        }


        #endregion


    }
}
