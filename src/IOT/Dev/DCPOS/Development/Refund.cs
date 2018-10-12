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
    public partial class Refund : Form
    {
        #region Constructors and private methods

        
                private string _errorMessageAmount = "";
                private string _errorMessageCurrency = "";
                private string _errorMessageButton = "";

        private DCCommon common = new DCCommon();

        public Refund()
        {
            InitializeComponent();
        }

        private void Refund_Load(object sender, EventArgs e)
        {
            cboCurrency.SelectedIndex = 1;

        }

        #endregion

        #region Refund methods

        private void btnRefund_Click(object sender, EventArgs e)
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

                            
                            String result = common.SendBitcoins(Program.MerchantCardId, Program.MerchantPublicKey, Program.MerchantEncryptedPrivateKey, CardId, Bitcoins, FiatAmount, cboCurrency.SelectedItem.ToString());
                            MessageBox.Show(result);


                        }
                        else
                        {
                            _errorMessageButton = "Cannot Read CardId";
                            this.Refresh();
                        }
                    }
                    else
                    {
                        _errorMessageButton = "The Card is not Present";
                        this.Refresh();
                    }
                }

                else
                {
                    _errorMessageButton = "The Reader cannot be Initalised";
                    this.Refresh();
                }
            }
            catch (Exception ex)
            {
                _errorMessageButton = "Error:" + ex.ToString();
                this.Refresh();
            }
            finally
            {
                UseWaitCursor = false;
                ShowValidationMessages();
            }
        }

        #endregion 

        #region Common event methods

        private void txtAmount_Leave(object sender, EventArgs e)
        {
            if (IsValid())
            {
                GetQuote();
            }
        }


        private void cboCurrency_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (IsValid())
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
                }
                else
                {
                    txtBitcoins.Visible = false;
                    labelBitcoins.Visible = false;
                }

            }
            catch (Exception ex)
            {
                
                _errorMessageButton = ex.ToString();
                this.Refresh();
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


        private void ShowValidationMessages()
        {
            labelErrorAmount.Text = _errorMessageAmount;
            labelErrorCurrency.Text = _errorMessageCurrency;
            labelErrorButton.Text = _errorMessageButton;

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
            labelErrorButton.Visible = _errorMessageButton.Length > 0;
        }


        #endregion
    }

     
    }


