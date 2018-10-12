namespace DCPOS
{
    partial class SellBitcoin
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnSell = new System.Windows.Forms.Button();
            this.txtBitcoins = new System.Windows.Forms.Label();
            this.labelBitcoins = new System.Windows.Forms.Label();
            this.cboCurrency = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.labelErrorAmount = new System.Windows.Forms.Label();
            this.labelErrorCurrency = new System.Windows.Forms.Label();
            this.labelErrorSell = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnSell
            // 
            this.btnSell.Location = new System.Drawing.Point(43, 149);
            this.btnSell.Name = "btnSell";
            this.btnSell.Size = new System.Drawing.Size(154, 92);
            this.btnSell.TabIndex = 3;
            this.btnSell.Text = "Sell Bitcoin";
            this.btnSell.UseVisualStyleBackColor = true;
            this.btnSell.Click += new System.EventHandler(this.btnSell_Click);
            // 
            // txtBitcoins
            // 
            this.txtBitcoins.AutoSize = true;
            this.txtBitcoins.Location = new System.Drawing.Point(97, 116);
            this.txtBitcoins.Name = "txtBitcoins";
            this.txtBitcoins.Size = new System.Drawing.Size(13, 13);
            this.txtBitcoins.TabIndex = 20;
            this.txtBitcoins.Text = "0";
            // 
            // labelBitcoins
            // 
            this.labelBitcoins.AutoSize = true;
            this.labelBitcoins.Location = new System.Drawing.Point(47, 116);
            this.labelBitcoins.Name = "labelBitcoins";
            this.labelBitcoins.Size = new System.Drawing.Size(44, 13);
            this.labelBitcoins.TabIndex = 19;
            this.labelBitcoins.Text = "Bitcoins";
            // 
            // cboCurrency
            // 
            this.cboCurrency.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCurrency.FormattingEnabled = true;
            this.cboCurrency.Items.AddRange(new object[] {
            "USD",
            "AUD",
            "EUR",
            "GBP"});
            this.cboCurrency.Location = new System.Drawing.Point(97, 68);
            this.cboCurrency.Name = "cboCurrency";
            this.cboCurrency.Size = new System.Drawing.Size(100, 21);
            this.cboCurrency.TabIndex = 18;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(48, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 17;
            this.label2.Text = "Currency";
            // 
            // txtAmount
            // 
            this.txtAmount.Location = new System.Drawing.Point(97, 26);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(100, 20);
            this.txtAmount.TabIndex = 16;
            this.txtAmount.Leave += new System.EventHandler(this.txtAmount_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(48, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 15;
            this.label1.Text = "Amount";
            // 
            // labelErrorAmount
            // 
            this.labelErrorAmount.AutoSize = true;
            this.labelErrorAmount.ForeColor = System.Drawing.Color.Red;
            this.labelErrorAmount.Location = new System.Drawing.Point(217, 29);
            this.labelErrorAmount.Name = "labelErrorAmount";
            this.labelErrorAmount.Size = new System.Drawing.Size(35, 13);
            this.labelErrorAmount.TabIndex = 21;
            this.labelErrorAmount.Text = "label4";
            this.labelErrorAmount.Visible = false;
            // 
            // labelErrorCurrency
            // 
            this.labelErrorCurrency.AutoSize = true;
            this.labelErrorCurrency.ForeColor = System.Drawing.Color.Red;
            this.labelErrorCurrency.Location = new System.Drawing.Point(217, 71);
            this.labelErrorCurrency.Name = "labelErrorCurrency";
            this.labelErrorCurrency.Size = new System.Drawing.Size(35, 13);
            this.labelErrorCurrency.TabIndex = 22;
            this.labelErrorCurrency.Text = "label4";
            this.labelErrorCurrency.Visible = false;
            // 
            // labelErrorSell
            // 
            this.labelErrorSell.AutoSize = true;
            this.labelErrorSell.ForeColor = System.Drawing.Color.Red;
            this.labelErrorSell.Location = new System.Drawing.Point(217, 189);
            this.labelErrorSell.Name = "labelErrorSell";
            this.labelErrorSell.Size = new System.Drawing.Size(35, 13);
            this.labelErrorSell.TabIndex = 23;
            this.labelErrorSell.Text = "label4";
            this.labelErrorSell.Visible = false;
            // 
            // SellBitcoin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(404, 323);
            this.Controls.Add(this.labelErrorSell);
            this.Controls.Add(this.labelErrorCurrency);
            this.Controls.Add(this.labelErrorAmount);
            this.Controls.Add(this.txtBitcoins);
            this.Controls.Add(this.labelBitcoins);
            this.Controls.Add(this.cboCurrency);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtAmount);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSell);
            this.Name = "SellBitcoin";
            this.Text = "SellBitcoin";
            this.Load += new System.EventHandler(this.SellBitcoin_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSell;
        private System.Windows.Forms.Label txtBitcoins;
        private System.Windows.Forms.Label labelBitcoins;
        private System.Windows.Forms.ComboBox cboCurrency;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtAmount;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelErrorAmount;
        private System.Windows.Forms.Label labelErrorCurrency;
        private System.Windows.Forms.Label labelErrorSell;
    }
}