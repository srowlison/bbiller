namespace DCPOS
{
    partial class Refund
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
            this.btnRefund = new System.Windows.Forms.Button();
            this.labelBitcoins = new System.Windows.Forms.Label();
            this.cboCurrency = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtBitcoins = new System.Windows.Forms.Label();
            this.labelErrorAmount = new System.Windows.Forms.Label();
            this.labelErrorCurrency = new System.Windows.Forms.Label();
            this.labelErrorButton = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnRefund
            // 
            this.btnRefund.Location = new System.Drawing.Point(39, 170);
            this.btnRefund.Name = "btnRefund";
            this.btnRefund.Size = new System.Drawing.Size(138, 66);
            this.btnRefund.TabIndex = 13;
            this.btnRefund.Text = "Refund";
            this.btnRefund.UseVisualStyleBackColor = true;
            this.btnRefund.Click += new System.EventHandler(this.btnRefund_Click);
            // 
            // labelBitcoins
            // 
            this.labelBitcoins.AutoSize = true;
            this.labelBitcoins.Location = new System.Drawing.Point(27, 114);
            this.labelBitcoins.Name = "labelBitcoins";
            this.labelBitcoins.Size = new System.Drawing.Size(44, 13);
            this.labelBitcoins.TabIndex = 11;
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
            this.cboCurrency.Location = new System.Drawing.Point(77, 66);
            this.cboCurrency.Name = "cboCurrency";
            this.cboCurrency.Size = new System.Drawing.Size(100, 21);
            this.cboCurrency.TabIndex = 10;
            this.cboCurrency.SelectedIndexChanged += new System.EventHandler(this.cboCurrency_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Currency";
            // 
            // txtAmount
            // 
            this.txtAmount.Location = new System.Drawing.Point(77, 24);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(100, 20);
            this.txtAmount.TabIndex = 8;
            this.txtAmount.Leave += new System.EventHandler(this.txtAmount_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Amount";
            // 
            // txtBitcoins
            // 
            this.txtBitcoins.AutoSize = true;
            this.txtBitcoins.Location = new System.Drawing.Point(77, 114);
            this.txtBitcoins.Name = "txtBitcoins";
            this.txtBitcoins.Size = new System.Drawing.Size(13, 13);
            this.txtBitcoins.TabIndex = 14;
            this.txtBitcoins.Text = "0";
            // 
            // labelErrorAmount
            // 
            this.labelErrorAmount.AutoSize = true;
            this.labelErrorAmount.ForeColor = System.Drawing.Color.Red;
            this.labelErrorAmount.Location = new System.Drawing.Point(183, 27);
            this.labelErrorAmount.Name = "labelErrorAmount";
            this.labelErrorAmount.Size = new System.Drawing.Size(35, 13);
            this.labelErrorAmount.TabIndex = 15;
            this.labelErrorAmount.Text = "label4";
            this.labelErrorAmount.Visible = false;
            // 
            // labelErrorCurrency
            // 
            this.labelErrorCurrency.AutoSize = true;
            this.labelErrorCurrency.ForeColor = System.Drawing.Color.Red;
            this.labelErrorCurrency.Location = new System.Drawing.Point(183, 69);
            this.labelErrorCurrency.Name = "labelErrorCurrency";
            this.labelErrorCurrency.Size = new System.Drawing.Size(35, 13);
            this.labelErrorCurrency.TabIndex = 16;
            this.labelErrorCurrency.Text = "label4";
            this.labelErrorCurrency.Visible = false;
            // 
            // labelErrorButton
            // 
            this.labelErrorButton.AutoSize = true;
            this.labelErrorButton.ForeColor = System.Drawing.Color.Red;
            this.labelErrorButton.Location = new System.Drawing.Point(183, 197);
            this.labelErrorButton.Name = "labelErrorButton";
            this.labelErrorButton.Size = new System.Drawing.Size(35, 13);
            this.labelErrorButton.TabIndex = 17;
            this.labelErrorButton.Text = "label4";
            this.labelErrorButton.Visible = false;
            // 
            // Refund
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(346, 302);
            this.Controls.Add(this.labelErrorButton);
            this.Controls.Add(this.labelErrorCurrency);
            this.Controls.Add(this.labelErrorAmount);
            this.Controls.Add(this.txtBitcoins);
            this.Controls.Add(this.btnRefund);
            this.Controls.Add(this.labelBitcoins);
            this.Controls.Add(this.cboCurrency);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtAmount);
            this.Controls.Add(this.label1);
            this.Name = "Refund";
            this.Text = "Refund";
            this.Load += new System.EventHandler(this.Refund_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnRefund;
        private System.Windows.Forms.Label labelBitcoins;
        private System.Windows.Forms.ComboBox cboCurrency;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtAmount;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label txtBitcoins;
        private System.Windows.Forms.Label labelErrorAmount;
        private System.Windows.Forms.Label labelErrorCurrency;
        private System.Windows.Forms.Label labelErrorButton;
    }
}