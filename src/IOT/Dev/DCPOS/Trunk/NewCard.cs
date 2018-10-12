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
        private DCPOS.INFC nfc;
        public NewCard()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private bool validate()
        {
            return (txtFirstName.Text != "" && txtLastName.Text != "" && txtAddress.Text != "" && txtCity.Text != "" && txtZip.Text != "" && txtState.Text != "" && txtTelephone.Text != "" && txtDOB.Text != "" && txtEmail.Text != "" && txtFirstName.Text != "" && txtLastName.Text != "" && txtCCNumber.Text != "" && txtExpiryDateMM.Text != "" && txtExpiryDateYY.Text != "" && txtCCNumber.Text != "" && txtPIN.Text != "" && txtLimit.Text != "");



        }
        private void btnActivate_Click(object sender, EventArgs e)
        {
            try
            {
                if (validate()) {

                
                String CardId = "";
                String body = "";
                nfc = DCPOS.Factory.GetNFC();
                Card.CardClient card = new Card.CardClient();
                ATM.AtmClient atm = new ATM.AtmClient();
                if (nfc.InitReader())
                {
                    if (nfc.ConnectReader() && nfc.ReadTagID(ref CardId))
                    {
                        if (!card.IsCardOnFile(CardId))
                        {
                            ATM.Keys key = atm.CreatePublicEncryptedPrivateKey();
                            String Password = key.Password.ToString();
                            String PrivateKey = key.PrivateKey;
                            String PublicKey = key.PublicKey;
                            String modifiedpublicuri = String.Format("bitcoin:{0}", PublicKey);
                            if (nfc.WriteNFCTag(modifiedpublicuri, PrivateKey))
                            {
                                body += Environment.NewLine;
                                body += "Dear " + txtFirstName.Text + "," + Environment.NewLine;
                                body += Environment.NewLine;
                                body += Environment.NewLine;
                                body += "Your Purchase" + Environment.NewLine;
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
                                body += "Allow for 6 Confirmations before balance appears." + Environment.NewLine;
                                body += "See Terms and Conditions " + Environment.NewLine;
                                atm.SendEmailAsync(txtEmail.Text, "Diamond Circle Private Key. CardId:" + CardId, body);
                                // Write TagID to Database.
                                Password = Convert.ToBase64String(key.Password);
                                // card.AddCardWithPinLimit(CardId, PublicKey, Password, txtFirstName.Text, txtLastName.Text, txtAddress.Text, txtCity.Text, txtZip.Text, txtState.Text, cboCountry.SelectedItem, txtTelephone.Text, txtDOB.Text, txtEmail.Text, txtFirstName.Text + " " + txtLastName.Text, txtCCNumber.Text, txtExpiryDateMM.Text, txtExpiryDateYY.Text, txtCCNumber.Text, txtPIN.Text, cboCurrency.SelectedItem, Convert.ToInt32(txtLimit.Text), chkTopup);


                            }
                            else
                            {
                                // Cannot write card.
                            }

                        }
                        else
                        {
                            // Card on file
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
                else
                {
                    lblStatusMessage.Text = "Complete all Fields";
                }

            }

            catch (Exception ex)
            {

                // GeneralExceptions("Encode Tag", System.Diagnostics.TraceEventType.Critical, ex);

            }
        }
    }
}


                