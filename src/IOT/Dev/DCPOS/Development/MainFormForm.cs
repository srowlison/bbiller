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
    public partial class MainFormForm : Form
    {


        
        public MainFormForm()
        {
            InitializeComponent();

            
        }

      

        private void btnRefund_Click(object sender, EventArgs e)
        {
            Refund f = new Refund();
            f.ShowDialog();
        }

        private void btnPurchase_Click(object sender, EventArgs e)
        {
            Purchase f = new Purchase();
            f.ShowDialog();
        }

        private void btnBuy_Click(object sender, EventArgs e)
        {
            BuyBitcoin f = new BuyBitcoin();
            f.ShowDialog();
        }

        private void btnSell_Click(object sender, EventArgs e)
        {
            SellBitcoin f = new SellBitcoin();
            f.ShowDialog();
        }

        private void btnCardBalance_Click(object sender, EventArgs e)
        {
            CardBalance f = new CardBalance();
            f.ShowDialog();
        }

        private void btnNewCard_Click(object sender, EventArgs e)
        {
            NewCard f = new NewCard();
            f.ShowDialog();
        }

        private void hELPToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void toolStripContainer1_ContentPanel_Load(object sender, EventArgs e)
        {

        }

        private void toolsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void setMerchantToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MerchantCard ReadMerchantCard = new MerchantCard();
            ReadMerchantCard.ShowDialog();
        }

      
    
    }
}
