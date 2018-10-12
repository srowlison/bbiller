namespace DCPOS
{
    partial class Purchase
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cboCurrency = new System.Windows.Forms.ComboBox();
            this.labelBitcoins = new System.Windows.Forms.Label();
            this.btnPurchase = new System.Windows.Forms.Button();
            this.txtBitcoins = new System.Windows.Forms.Label();
            this.labelErrorAmount = new System.Windows.Forms.Label();
            this.labelErrorCurrency = new System.Windows.Forms.Label();
            this.labelErrorPurchase = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Amount";
            // 
            // txtAmount
            // 
            this.txtAmount.Location = new System.Drawing.Point(70, 25);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(100, 20);
            this.txtAmount.TabIndex = 1;
            this.txtAmount.Leave += new System.EventHandler(this.txtAmount_Leave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Currency";
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
            this.cboCurrency.Location = new System.Drawing.Point(70, 67);
            this.cboCurrency.Name = "cboCurrency";
            this.cboCurrency.Size = new System.Drawing.Size(100, 21);
            this.cboCurrency.TabIndex = 3;
            this.cboCurrency.SelectedIndexChanged += new System.EventHandler(this.cboCurrency_SelectedIndexChanged);
            // 
            // labelBitcoins
            // 
            this.labelBitcoins.AutoSize = true;
            this.labelBitcoins.Location = new System.Drawing.Point(20, 115);
            this.labelBitcoins.Name = "labelBitcoins";
            this.labelBitcoins.Size = new System.Drawing.Size(44, 13);
            this.labelBitcoins.TabIndex = 4;
            this.labelBitcoins.Text = "Bitcoins";
            this.labelBitcoins.Visible = false;
            // 
            // btnPurchase
            // 
            this.btnPurchase.Location = new System.Drawing.Point(55, 169);
            this.btnPurchase.Name = "btnPurchase";
            this.btnPurchase.Size = new System.Drawing.Size(138, 66);
            this.btnPurchase.TabIndex = 6;
            this.btnPurchase.Text = "Purchase";
            this.btnPurchase.UseVisualStyleBackColor = true;
            this.btnPurchase.Click += new System.EventHandler(this.btnPurchase_Click);
            // 
            // txtBitcoins
            // 
            this.txtBitcoins.AutoSize = true;
            this.txtBitcoins.Location = new System.Drawing.Point(70, 115);
            this.txtBitcoins.Name = "txtBitcoins";
            this.txtBitcoins.Size = new System.Drawing.Size(13, 13);
            this.txtBitcoins.TabIndex = 7;
            this.txtBitcoins.Text = "0";
            this.txtBitcoins.Visible = false;
            // 
            // labelErrorAmount
            // 
            this.labelErrorAmount.AutoSize = true;
            this.labelErrorAmount.ForeColor = System.Drawing.Color.Red;
            this.labelErrorAmount.Location = new System.Drawing.Point(202, 28);
            this.labelErrorAmount.Name = "labelErrorAmount";
            this.labelErrorAmount.Size = new System.Drawing.Size(35, 13);
            this.labelErrorAmount.TabIndex = 8;
            this.labelErrorAmount.Text = "label4";
            this.labelErrorAmount.Visible = false;
            // 
            // labelErrorCurrency
            // 
            this.labelErrorCurrency.AutoSize = true;
            this.labelErrorCurrency.ForeColor = System.Drawing.Color.Red;
            this.labelErrorCurrency.Location = new System.Drawing.Point(202, 70);
            this.labelErrorCurrency.Name = "labelErrorCurrency";
            this.labelErrorCurrency.Size = new System.Drawing.Size(35, 13);
            this.labelErrorCurrency.TabIndex = 9;
            this.labelErrorCurrency.Text = "label4";
            this.labelErrorCurrency.Visible = false;
            // 
            // labelErrorPurchase
            // 
            this.labelErrorPurchase.AutoSize = true;
            this.labelErrorPurchase.ForeColor = System.Drawing.Color.Red;
            this.labelErrorPurchase.Location = new System.Drawing.Point(202, 196);
            this.labelErrorPurchase.Name = "labelErrorPurchase";
            this.labelErrorPurchase.Size = new System.Drawing.Size(35, 13);
            this.labelErrorPurchase.TabIndex = 10;
            this.labelErrorPurchase.Text = "label4";
            this.labelErrorPurchase.Visible = false;
            // 
            // Purchase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(361, 308);
            this.Controls.Add(this.labelErrorPurchase);
            this.Controls.Add(this.labelErrorCurrency);
            this.Controls.Add(this.labelErrorAmount);
            this.Controls.Add(this.txtBitcoins);
            this.Controls.Add(this.btnPurchase);
            this.Controls.Add(this.labelBitcoins);
            this.Controls.Add(this.cboCurrency);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtAmount);
            this.Controls.Add(this.label1);
            this.Name = "Purchase";
            this.Text = "Purchase";
            this.Load += new System.EventHandler(this.Purchase_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtAmount;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboCurrency;
        private System.Windows.Forms.Label labelBitcoins;
        private System.Windows.Forms.Button btnPurchase;
        private System.Windows.Forms.Label txtBitcoins;
        private System.Windows.Forms.Label labelErrorAmount;
        private System.Windows.Forms.Label labelErrorCurrency;
        private System.Windows.Forms.Label labelErrorPurchase;
    }
}