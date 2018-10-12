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
    public partial class PinPad : Form
    {
        
        public PinPad()
        {
            InitializeComponent();
        }

        private void PinPad_Load(object sender, EventArgs e)
        {

        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            Program.Pin = txtPin.Text;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {

            Program.Pin = "";
            
            this.Close();

        }
    }
}
