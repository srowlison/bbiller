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
        
        private DCCommon common = new DCCommon();
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

            try
            {
                
                if (common.nfc.InitReader())
                {
                    if (common.nfc.ConnectReader())
                    {
                        tmrRead.Stop();
                        tmrRead.Enabled = false;

                        String CardId = "";
                        if (common.nfc.ReadTagID(ref CardId))
                        {
                            lblCardId.Text = CardId;


                            String PublicKey = "";
                            if (common.nfc.readPublicKey(ref PublicKey))
                            {
                                txtPublicKey.Text = PublicKey;



                                lblBTCBalance.Text = common.getbalance(PublicKey, 1).ToString("0.000000 BTC");
                                lblStatus.Text = "Ok";


                                this.Refresh();

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
            catch (Exception ex)
            {
                lblStatus.Text = "Error" + ex.ToString();

            }
        }

        private void tmrRead_Tick(object sender, EventArgs e)
        {
            readCard();
        }

        private void CardBalance_Load(object sender, EventArgs e)
        {
            lblStatus.Text = "";
        }

        
    }
}
