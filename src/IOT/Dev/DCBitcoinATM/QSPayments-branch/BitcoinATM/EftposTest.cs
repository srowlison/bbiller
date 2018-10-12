using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EftposTestApplication
{
    /// <summary>
    /// Enables testing of EFTPOS functionality using the Quest EFTPOS machine.
    /// </summary>
    /// <author email="andrew@acomit.com.au">Andrew Ling</author>
    /// <dateCreated>Thursday 6 March 2014</dateCreated>
    public partial class EftposTest : Form
    {
        #region Fields

        #endregion

        #region Constructors
        /// <summary>
        /// Creates a new instance of EftposTest.
        /// </summary>
        public EftposTest()
        {
            InitializeComponent();
        }
        #endregion

        #region Properties

        #endregion

        #region Methods

        #region Start Transaction Button - Clicked
        private void btnStartTransaction_Click(object sender, EventArgs e)
        {
            double transactionAmount = double.Parse(txtTransactionAmount.Text);

            eftposManager.OperatorDisplayType = 2;
            eftposManager.CustomerDisplayType = 0;
            eftposManager.PrinterType = 0;

            eftposManager.TransactionReference = txtTransactionReference.Text;
            eftposManager.OperatorID = "diamondcircle";
            eftposManager.TransSubType = 0;
            eftposManager.PurchaseAmount = Convert.ToInt32(Math.Round(transactionAmount * 100));
            eftposManager.CashoutAmount = 0;

            long errorCode = eftposManager.StartTransaction();

            if(errorCode != 0)
            {

            }
        }
        #endregion

        #region Cancel Transaction Button - Clicked
        private void btnCancelTransaction_Click(object sender, EventArgs e)
        {
            eftposManager.CancelTransaction();
        }
        #endregion

        #region Eftpos Manager - On Transaction Response
        private void eftposManager_TransactionResponseEvent(object sender, AxPosEftLib._DPosEftEvents_TransactionResponseEventEvent e)
        {
            String strCode = e.errorCode;
            String strText = e.errorText;
            long lStatus = e.status;

            MessageBox.Show(String.Format("{0} - {1}", strCode, strText), "Transaction Response", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        #endregion

        #region Eftpos Manager - Display Datya
        private void eftposManager_DisplayDataEvent(object sender, AxPosEftLib._DPosEftEvents_DisplayDataEventEvent e)
        {
            txtTransactionStatus.Text = e.displayData;
        }
        #endregion

        #endregion
    }
}