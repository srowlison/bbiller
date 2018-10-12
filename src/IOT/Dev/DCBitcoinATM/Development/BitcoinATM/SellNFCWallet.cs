using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BitcoinATM
{

    //DELETE THIS FORM
    public partial class SellNFCWallet : Form
    {
        public SellNFCWallet()
        {
            InitializeComponent();
        }

        private void btnPurchase_Click(object sender, EventArgs e)
        {

            // TODO Integrate Mag Swipe Reader
            // Read the Mag Swipe readcard API to get the card number


            // TODO: Specify an Enpoint Name
            
            DCPaymentService.Service2Client DCPaymentService = new DCPaymentService.Service2Client();

            if (DCPaymentService.CreateaPayment("PayPal"))
            {

                lblApproved.Text = "Approved - Collect Tag";

            }



                      
            // TO DO: Call API to eject Tag from Machine
            // Eject Tag from Machine

            

            // Print Receipt


            
            this.Dispose();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void SellNFCWallet_Load(object sender, EventArgs e)
        {

        }
    }
}
