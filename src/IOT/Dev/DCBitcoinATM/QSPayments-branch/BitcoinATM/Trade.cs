using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ServiceModel;
using System.ServiceModel.Channels;

namespace BitcoinATM
{
    public partial class Trade : Form
    {

        public Decimal FiatAmount { get; set; }
        public Decimal BitcoinAmount { get; set; }
        public Decimal Price { get; set; }
        public Boolean NewTag { get; set; }
        public String PINNumber { get; set; }
        public String BUYorSELL { get; set; }


        //HTTPS PROXY
        //srAtms.AtmClient client = new srAtms.AtmClient();
        srAtm.AtmClient client = new srAtm.AtmClient();
    
        public Trade()
        {
            InitializeComponent();

            client.ClientCredentials.Windows.ClientCredential.UserName = "atm-1";
            client.ClientCredentials.Windows.ClientCredential.Password = "NjhsD5lvkv";
            client.ClientCredentials.Windows.ClientCredential.Domain = "dcnode-1";
        }

     
      
        private void AddCredit_Load(object sender, EventArgs e)
        {

        //    this.Text = BUYorSELL;
        //    btnAction.Text = BUYorSELL;
        //    grpPIN.Visible = NewTag;
        //    GetQuote();
            
            
            

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

            
        // TO DO: Add this method to SellBitcoins
        private async void GetQuote()
        {

            try
            {
                // Gets a quote for bitcoins - Not a balance.  Bad Method Name - TODO

                FiatAmount = Convert.ToDecimal(txtAmount.Text);

                // TODO: Refresh Service Reference
         //      BitcoinAmount = await client.GetBitcoinAmountAsync(FiatAmount, "AUD");

                Price = BitcoinAmount / FiatAmount;

                txtBitcoins.Text = BitcoinAmount.ToString();

                txtRate.Text = Price.ToString();


            }
            catch (FaultException ex)
            {
                string msg = "FaultException: " + ex.Message;
                MessageFault fault = ex.CreateMessageFault();
                if (fault.HasDetail == true)
                {
                    System.Xml.XmlReader reader = fault.GetReaderAtDetailContents();
                    if (reader.Name == "ExceptionDetail")
                    {
                        ExceptionDetail detail = fault.GetDetail<ExceptionDetail>();
                        msg += "\n\nStack Trace: " + detail.StackTrace;
                    }
                }
                MessageBox.Show(msg);
            }


        }

        private void txtAmount_TextChanged(object sender, EventArgs e)
        {
            GetQuote();
        }

 
        private void btnAction_Click(object sender, EventArgs e)
        {

            if (BUYorSELL == "BUY")
            {
                if (NewTag)
                {
                    // Confirm Pin Number
                    if (txtPin.Text == txtConfirmPin.Text)
                    {
                        PINNumber = txtPin.Text.ToString();

                        this.Dispose();
                    }
                    else
                    {
                        lblError.Text = "PIN Numbers Do not Match -Try Again";
                    }
                }
                else
                {
                    this.Dispose();
                }

            }

            else if (BUYorSELL == "SELL")
            {

            }
            
        }

        private void Btn1_Click(object sender, EventArgs e)
        {

        }

        private void Btn2_Click(object sender, EventArgs e)
        {

        }

        private void Btn3_Click(object sender, EventArgs e)
        {

        }

        private void Btn6_Click(object sender, EventArgs e)
        {

        }

        private void Btn5_Click(object sender, EventArgs e)
        {

        }

        private void Btn4_Click(object sender, EventArgs e)
        {

        }

        private void Btn7_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void Btn9_Click(object sender, EventArgs e)
        {

        }

        private void BtnClear_Click(object sender, EventArgs e)
        {

        }

        private void BtnPoint_Click(object sender, EventArgs e)
        {

        }

        private void Btn0_Click(object sender, EventArgs e)
        {

        }

        private void grpPIN_Enter(object sender, EventArgs e)
        {

        }

        private void Btn8_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void txtBitcoins_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblPIN_Click(object sender, EventArgs e)
        {

        }

        private void txtPin_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblConfirmPIN_Click(object sender, EventArgs e)
        {

        }

        private void txtConfirmPin_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnBack_Click_1(object sender, EventArgs e)
        {

        }

        private void txtRate_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

    }
        

}
