using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestHarness
{
    public partial class Form1 : Form
    {

        public atm.AtmClient client = new atm.AtmClient();

        public Form1()
        {
            
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            
           
            string PublicKey = "18X32dXzSSqGVYVnGT6rPUGHkSodkeDE45";

            decimal btc = 0.00002m;
            
            

            atm.Order order = client.CreateOrder(PublicKey, btc);

            int indx;

            string content = "";

            




            for (indx = 0; indx <= 50; indx++)
            {

                atm.Keys key = client.CreatePublicEncryptedPrivateKey();
                


            content += key.PrivateKey + Environment.NewLine;

        }
            listBox1.Text = content;

            listBox1.Refresh();



            
            




        }
    }
}
