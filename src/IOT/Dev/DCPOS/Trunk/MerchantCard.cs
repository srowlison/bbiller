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
    public partial class MerchantCard : Form
        
        

    {
        private DCPOS.INFC nfc;
        public MerchantCard()
        {
            InitializeComponent();
        }

        private void MerchantCard_Load(object sender, EventArgs e)
        {
            nfc = DCPOS.Factory.GetNFC();
            
          
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void readMerchantCard()
        {
            if (nfc.InitReader())
            {
                if (nfc.ConnectReader())
                {
                    String CardId = "";
                    if (nfc.ReadTagID(ref CardId))
                    {
                        Program.MerchantCardId = CardId;
                        String PublicKey = "";
                        if (nfc.readPublicKey(ref PublicKey))
                        {
                            Program.MerchantPublicKey = PublicKey;
                            String EncryptedPrivateKey = "";
                            
                            if (nfc.readPrivateKey(ref EncryptedPrivateKey))
                            {
                                Program.MerchantEncryptedPrivateKey = EncryptedPrivateKey;
                                this.Close();
                            }
                            else
                            {
                                lblStatus.Text = "Cannot read Private Key";
                            }    

                        }
                        else
                        {

                            lblStatus.Text = "Cannot read Private Key";
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
            readMerchantCard();
        }   
    }
}

