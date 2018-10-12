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
    public partial class TapTag : UserControl
    {
        private String _title;
        public String Title
        {
            get
            {
                return _title;
            }
            set
            {
                labTitle.Text = value;
                _title = value;
            }
        }
        public TapTag()
        {
            InitializeComponent();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {

        }
    }
}
