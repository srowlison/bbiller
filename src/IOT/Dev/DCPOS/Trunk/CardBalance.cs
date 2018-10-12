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
    public partial class CardBalance : Form
    {
        private DCPOS.INFC nfc;
        public CardBalance()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void readCard()
        {
            nfc = DCPOS.Factory.GetNFC();
            if (nfc.InitReader())
            {
                if (nfc.ConnectReader())
                {
                    String CardId = "";
                    if (nfc.ReadTagID(ref CardId))
                    {
        
                        String PublicKey = "";
                        if (nfc.readPublicKey(ref PublicKey))
                        {
                            // Get Balance
                            ATM.AtmClient atm = new ATM.AtmClient();
                            
                            decimal value = atm.GetBalance(PublicKey, 1); 
                            

                            lblBTCBalance.Text = value.ToString("0.000000 BTC");

        
                        }
                        else
                        {

                            lblStatus.Text = "Cannot read Public Key";
                        }

                    }
                    else
                    {
                        lblStatus.Text = "Cannot read CardId";
                    }
                }
                else
                {
                    lblStatus.Text = "Card not Present on Reader";
                }
            }
            else
            {
                lblStatus.Text = "Cannot Initalise Reader";

            }
        }

        private void tmrRead_Tick(object sender, EventArgs e)
        {
            readCard();
        }

        private void CardBalance_Load(object sender, EventArgs e)
        {

        }

        
    }
}
