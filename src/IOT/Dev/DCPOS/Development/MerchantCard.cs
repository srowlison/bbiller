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
        private DCCommon common = new DCCommon();
        public MerchantCard()
        {
            InitializeComponent();
            
        }

        private void MerchantCard_Load(object sender, EventArgs e)
        {
            
            
          
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void readMerchantCard()
        {
            try
            {

            
            if (common.nfc.InitReader())
            {
                if (common.nfc.ConnectReader())
                {
                    String CardId = "";
                    if (common.nfc.ReadTagID(ref CardId))
                    {

                        DCPOS.Properties.Settings.Default.CardId = CardId;
                        DCPOS.Properties.Settings.Default.Save();
                        Program.MerchantCardId = CardId;
                        
                        String PublicKey = "";
                        if (common.nfc.readPublicKey(ref PublicKey))
                        {


                            DCPOS.Properties.Settings.Default.PublicKey = PublicKey;
                            DCPOS.Properties.Settings.Default.Save();
                            Program.MerchantPublicKey = PublicKey;
                            

                            String EncryptedPrivateKey = "";

                            if (common.nfc.readPrivateKey(ref EncryptedPrivateKey))
                            {
                                                                
                                DCPOS.Properties.Settings.Default.EncryptedPrivateKey = EncryptedPrivateKey;
                                DCPOS.Properties.Settings.Default.Save();
                                Program.MerchantEncryptedPrivateKey = EncryptedPrivateKey;

                                tmrRead.Stop();
                                var result = MessageBox.Show("Public Key: " + PublicKey, "Card: " + CardId + " Is enrolled on this Terminal", MessageBoxButtons.OK);


                                this.Close();
                            }
                            else
                            {
                                lblStatus.Text = "Cannot read Private Key";
                            }    

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
                lblStatus.Text = ex.ToString();
            }
        }

        private void tmrRead_Tick(object sender, EventArgs e)
        {
            readMerchantCard();
        }   
    }
}

