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
                private DCPOS.INFC nfc;

        public Refund()
        {
            InitializeComponent();
        }

    
        private void txtAmount_TextChanged(object sender, EventArgs e)
        {
 
            getquote();
           
            
        }
        private void getquote()
        {
            if(txtAmount.Text != "" && Convert.ToInt32(txtAmount.Text) >0)
            { 

                Card.CardClient card = new Card.CardClient();

                decimal amount = Convert.ToInt32(txtAmount.Text);
                Decimal bitcoins = GetSpotPrice(cboCurrency.SelectedItem.ToString(), amount);

                txtBitcoins.Text = bitcoins.ToString("0.000000");
            }
            else
            {
                txtBitcoins.Text = "0";
            }

        }

        private void Refund_Load(object sender, EventArgs e)
        {
            cboCurrency.SelectedIndex = 1;

        }

        private void cboCurrency_SelectedIndexChanged(object sender, EventArgs e)
        {
            getquote();
        }

        private void btnRefund_Click(object sender, EventArgs e)
        {
            String CardId = "";
            nfc = DCPOS.Factory.GetNFC();
            if (nfc.InitReader())
            {
                if (nfc.ConnectReader())
                {
                    if (nfc.ReadTagID(ref CardId))
                    {
                        Decimal FiatAmount = Convert.ToInt32(txtAmount.Text);
                        Decimal Bitcoins = Convert.ToDecimal(txtBitcoins.Text);
                              
                        MerchantCard ReadMerchantCard = new MerchantCard();
                        ReadMerchantCard.ShowDialog();

                        DCCommon common = new DCCommon();

                        String result = common.SendBitcoins(Program.MerchantCardId, Program.MerchantPublicKey, Program.MerchantEncryptedPrivateKey, CardId, Bitcoins, FiatAmount, cboCurrency.SelectedItem.ToString());
                        MessageBox.Show(result);
                        
                        
                
                    }
                    else
                    {
                        MessageBox.Show("Cannot Read CardId", "DC PC POS", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk);
                    }
                }
                else
                {
                    MessageBox.Show("The Card is not Present", "DC PC POS", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk);
                }
            }

            else
            {
                MessageBox.Show("The Reader cannot be Initalised", "DC PC POS", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk);
            }
        }


            private string checkPin(String CardId, String Pin)
            {
                // For the FromCardId, Obtain the Pin.
                String DBPin = Pin;

                if ( Pin == DBPin)
                {
                    return "00"; // PIN Valid

                }
                return "01";//Invalid
            }
            private string ChkPINLimit(String CardId, Decimal Fiatamount, String Currency)
            {

                // Query Card table for DBCardLimit and for the cards default Fiat Currency

                Decimal DBCardLimit = 100;
                if (Fiatamount > DBCardLimit) {

                    return "01"; // Pin Required.
                }
                else
                {
                    return "00"; // 00 - Pin Not required.
                }
                
                  // 03 - Unknown Error
            }
            private Decimal GetSpotPrice(String Currency, Decimal amount)
            {
                // This function includes the margin.  Add GetSpotPriceNoMargin
                DCExchange.ExchangeClient ExchangeClient = new DCExchange.ExchangeClient();
                decimal bitcoins = ExchangeClient.GetSpotPrice(cboCurrency.SelectedItem.ToString(), amount, 0);
                return bitcoins;

            }

          

          
          
           

        

    }

     
    }


