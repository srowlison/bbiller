namespace DCPOS
{
    partial class BuyBitcoin
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
            this.txtBitcoins = new System.Windows.Forms.Label();
            this.btnPurchase = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.cboCurrency = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtBitcoins
            // 
            this.txtBitcoins.AutoSize = true;
            this.txtBitcoins.Location = new System.Drawing.Point(160, 141);
            this.txtBitcoins.Name = "txtBitcoins";
            this.txtBitcoins.Size = new System.Drawing.Size(13, 13);
            this.txtBitcoins.TabIndex = 14;
            this.txtBitcoins.Text = "0";
            // 
            // btnPurchase
            // 
            this.btnPurchase.Location = new System.Drawing.Point(145, 195);
            this.btnPurchase.Name = "btnPurchase";
            this.btnPurchase.Size = new System.Drawing.Size(138, 66);
            this.btnPurchase.TabIndex = 13;
            this.btnPurchase.Text = "Purchase";
            this.btnPurchase.UseVisualStyleBackColor = true;
            this.btnPurchase.Click += new System.EventHandler(this.btnPurchase_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(110, 141);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Bitcoins";
            // 
            // cboCurrency
            // 
            this.cboCurrency.FormattingEnabled = true;
            this.cboCurrency.Items.AddRange(new object[] {
            "USD",
            "AUD",
            "EUR",
            "GBP"});
            this.cboCurrency.Location = new System.Drawing.Point(160, 93);
            this.cboCurrency.Name = "cboCurrency";
            this.cboCurrency.Size = new System.Drawing.Size(100, 21);
            this.cboCurrency.TabIndex = 11;
            this.cboCurrency.SelectedIndexChanged += new System.EventHandler(this.cboCurrency_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(111, 96);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Currency";
            // 
            // txtAmount
            // 
            this.txtAmount.Location = new System.Drawing.Point(160, 51);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(100, 20);
            this.txtAmount.TabIndex = 9;
            this.txtAmount.TextChanged += new System.EventHandler(this.txtAmount_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(111, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Amount";
            // 
            // BuyBitcoin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(393, 313);
            this.Controls.Add(this.txtBitcoins);
            this.Controls.Add(this.btnPurchase);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cboCurrency);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtAmount);
            this.Controls.Add(this.label1);
            this.Name = "BuyBitcoin";
            this.Text = "BuyBitcoin";
            this.Load += new System.EventHandler(this.BuyBitcoin_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label txtBitcoins;
        private System.Windows.Forms.Button btnPurchase;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboCurrency;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtAmount;
        private System.Windows.Forms.Label label1;
    }
}