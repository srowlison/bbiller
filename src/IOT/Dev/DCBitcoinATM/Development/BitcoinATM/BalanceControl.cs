using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BitcoinATM
{
    public partial class BalanceControl : UserControl
    {
        private Decimal _balance;

        public Decimal Balance
        {
            get { return _balance; }
            set
            {
                _balance = value;
                this.lblBalance.Text = value.ToString("0.000000 BTC");
            }
        }
        public BalanceControl()
        {
            InitializeComponent();
        }

        private void btnPrintBalance_Click(object sender, EventArgs e)
        {

        }

        private void btnViewonScreen_Click(object sender, EventArgs e)
        {

        }

        private void lblBalance_Click(object sender, EventArgs e)
        {

        }
    }
}
