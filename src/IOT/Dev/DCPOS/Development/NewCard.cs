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
    public partial class NewCard : Form
    {

        #region Constructors and private properities

        
        private DCCommon common = new DCCommon();
        private bool _isValid;
        private StringBuilder _errorList = new StringBuilder();

        public NewCard()
        {
            InitializeComponent();
        }

        #endregion

        #region Validation methods

        private bool ValidateControls()
        {
            _isValid = true;

            _errorList.Remove(0, _errorList.Length);
        
            ValidateRequiredField(txtEmail);
            ValidateRequiredField(cboCountry);
            ValidateRequiredField(txtPIN);
            ValidateRequiredField(txtLimit);
            ValidateRequiredField(cboCurrency);

            return _isValid;

        }

        public void ValidateIsNumeric(TextBox textBox)
        {
            decimal result;
            string textVal = textBox.Text;
            textVal = RemoveWhiteSpace(textVal);
            var isValid = decimal.TryParse(textVal, out result);

            SetControlValidState(textBox, isValid, "must be numeric");
        }

        private string RemoveWhiteSpace(string textVal)
        {
            while (textVal.IndexOf(" ") > 0)
            {
                var dx = textVal.IndexOf(" ");
                textVal = textVal.Remove(dx, 1);
            }
            return textVal;
        }

        public void ValidateRequiredField(Control control)
        {
            bool localIsValid = true;
            if (control.GetType() == typeof(TextBox))
            {
                if (string.IsNullOrWhiteSpace(((TextBox)control).Text))
                {
                    localIsValid = false;
                }
            }

            if (control.GetType() == typeof(ComboBox))
            {
                if (((ComboBox)control).SelectedIndex < 0)
                {
                    localIsValid = false;
                }
            }

            SetControlValidState(control, localIsValid, "is required");
            if (!localIsValid) _isValid = localIsValid;

        }

        public void SetControlValidState(Control control, bool isValid, string message)
        {
            if (isValid)
            {
                control.BackColor = System.Drawing.Color.White;
            }
            else
            {
                control.BackColor = System.Drawing.Color.LightPink;
                //Only add a maximum of 9 bullet point validation errors at a time
                if (_errorList.ToString().Split('\u2022').Count() < 10)
                {
                    _errorList.Append("\r\n\u2022 ");
                    _errorList.Append(control.Tag + " " + message);
                }
            }
        }

        #endregion

        #region Card activation methods

        private void btnActivate_Click(object sender, EventArgs e)
        {
            try
            {
                
                UseWaitCursor = true;
                if (!ValidateControls())
                {
                    lblStatusMessage.Text = _errorList.ToString();
                    lblStatusMessage.Show();
                }
                else
                {
                    lblStatusMessage.Hide();
                    String CardId = "";

                    progressBar1.PerformStep();
                    lblStatusMessage.Text = "Initalising Reader/Writer";
                    this.Refresh();

                    if (common.nfc.InitReader())
                    {
                        progressBar1.PerformStep();
                        lblStatusMessage.Text = "Connecting and Reading Card";
                        this.Refresh();

                        if (common.nfc.ConnectReader() && common.nfc.ReadTagID(ref CardId))
                        {
                            progressBar1.PerformStep();
                            lblStatusMessage.Text = "Reading File";
                            this.Refresh();

                            if (!common.IsCardOnFile(CardId))
                            {
                                progressBar1.PerformStep();
                                lblStatusMessage.Text = "Creating";
                                this.Refresh();
                                  dclapi.Keys key = common.CreatePublicEncryptedPrivateKey();
                                 // Localdclapi.Keys key = common.CreatePublicEncryptedPrivateKey();

                                String Password = key.Password.ToString();
                                String PrivateKey = key.PrivateKey;
                                String PublicKey = key.PublicKey;
                                String modifiedpublicuri = String.Format("bitcoin:{0}", PublicKey);
                                progressBar1.PerformStep();
                                lblStatusMessage.Text = "Writing";
                                this.Refresh();
                                if (common.nfc.WriteNFCTag(modifiedpublicuri, PrivateKey))
                                {
                                    lblStatusMessage.Text = "Saving";
                                    this.Refresh();

                                    // Write TagID to Database.
                                    Password = Convert.ToBase64String(key.Password);
                                    common.AddCardWithPinLimit(CardId, PublicKey, Password, txtFirstName.Text, txtLastName.Text, txtAddress.Text, txtCity.Text, txtZip.Text, txtState.Text, cboCountry.SelectedItem.ToString(), txtTelephone.Text, txtDOB.Text, txtEmail.Text, txtFirstName.Text + " " + txtLastName.Text, txtCCNumber.Text, txtExpiryDateMM.Text, txtExpiryDateYY.Text, txtCCNumber.Text, txtPIN.Text, cboCurrency.SelectedItem.ToString(), Convert.ToInt32(txtLimit.Text), chkAutoTopup.Enabled, Convert.ToInt32(txtTopUpAmount.Text));

                                    progressBar1.PerformStep();
                                    String body = "";

                                    body += Environment.NewLine;
                                    body += "Dear " + txtFirstName.Text + "," + Environment.NewLine;
                                    body += Environment.NewLine;
                                    body += Environment.NewLine;
                                    body += "Card Enrolled:" + CardId + Environment.NewLine;
                                    body += "From PC POS" + Environment.NewLine;
                                    body += Environment.NewLine;
                                    body += "Your Public Bitcoin Address is: https://blockchain.info/address/" + PublicKey + Environment.NewLine;
                                    body += Environment.NewLine;
                                    body += "LOSE THE FOLLOWING INFORMATION AND YOUR BITCOINS ARE LOST" + Environment.NewLine;
                                    body += "Your Private Key is: " + PrivateKey + Environment.NewLine;
                                    body += Environment.NewLine;
                                    body += Environment.NewLine;
                                    body += "Thank you" + Environment.NewLine;
                                    body += Environment.NewLine;
                                    body += "Diamond Circle Team" + Environment.NewLine;
                                    body += Environment.NewLine;
                                    body += "See Terms and Conditions " + Environment.NewLine;
                                    common.SendEmail(txtEmail.Text, "Diamond Circle Private Key. CardId:" + CardId, body);

                                    progressBar1.PerformStep();
                                    var result = MessageBox.Show("Public Key: " + PublicKey, "Card: " + CardId + " Activated", MessageBoxButtons.OK);
                                    

                                    this.Close();


                                }
                                else
                                {
                                    // Cannot write card.

                                    lblStatusMessage.Text = "Problem with Card - Cannot Write";
                                    this.Refresh();
                                }

                            }
                            else
                            {
                                // Card on file

                                lblStatusMessage.Text = "Card already registered";
                                this.Refresh();
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
                        lblStatusMessage.Text = "Cannot Initialse Reader";
                        this.Refresh();

                    }
                }

            }

            catch (Exception ex)
            {

                lblStatusMessage.Text = "Error:" + ex.ToString();
                this.Refresh();
                // GeneralExceptions("Encode Tag", System.Diagnostics.TraceEventType.Critical, ex);

            }
            finally
            {
                UseWaitCursor = false;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        #endregion

        private void NewCard_Load(object sender, EventArgs e)
        {



        }
        private void CheckCard()
        {
            

            btnActivate.Enabled = false;

            String CardId = "";
            if (common.nfc.InitReader() && common.nfc.ConnectReader() && common.nfc.ReadTagID(ref CardId))
            {

                if (common.IsCardOnFile(CardId))
                {

                    lblStatusMessage.Text = "Card already registered";
                    this.Refresh();
                }
                else
                {
                    btnActivate.Enabled = true;
                    tmrRead.Stop();
                    tmrRead.Enabled = false;
                    lblStatusMessage.Text = "Card is Ready for encoding";
                    this.Refresh();

                }
            }
            else
            {
                lblStatusMessage.Text = "Hold Card on Reader";
                this.Refresh();
                btnActivate.Enabled = false;

            }

        }

        private void tmrRead_Tick(object sender, EventArgs e)
        {
            CheckCard();
        }

        
    }

}


                
                