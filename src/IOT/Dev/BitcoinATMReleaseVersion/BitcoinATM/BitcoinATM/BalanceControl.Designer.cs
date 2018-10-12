namespace BitcoinATM
{
    partial class BalanceControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblBalance = new System.Windows.Forms.Label();
            this.btnViewonScreen = new System.Windows.Forms.Button();
            this.btnPrintBalance = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblBalance
            // 
            this.lblBalance.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblBalance.AutoSize = true;
            this.lblBalance.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBalance.Location = new System.Drawing.Point(122, 190);
            this.lblBalance.Name = "lblBalance";
            this.lblBalance.Size = new System.Drawing.Size(90, 25);
            this.lblBalance.TabIndex = 34;
            this.lblBalance.Text = "Balance";
            this.lblBalance.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblBalance.Click += new System.EventHandler(this.lblBalance_Click);
            // 
            // btnViewonScreen
            // 
            this.btnViewonScreen.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnViewonScreen.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnViewonScreen.Location = new System.Drawing.Point(12, 104);
            this.btnViewonScreen.Name = "btnViewonScreen";
            this.btnViewonScreen.Size = new System.Drawing.Size(302, 69);
            this.btnViewonScreen.TabIndex = 33;
            this.btnViewonScreen.Text = "On Screen";
            this.btnViewonScreen.UseVisualStyleBackColor = true;
            this.btnViewonScreen.Click += new System.EventHandler(this.btnViewonScreen_Click);
            // 
            // btnPrintBalance
            // 
            this.btnPrintBalance.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrintBalance.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrintBalance.Location = new System.Drawing.Point(12, 22);
            this.btnPrintBalance.Name = "btnPrintBalance";
            this.btnPrintBalance.Size = new System.Drawing.Size(302, 76);
            this.btnPrintBalance.TabIndex = 32;
            this.btnPrintBalance.Text = "Print Balance";
            this.btnPrintBalance.UseVisualStyleBackColor = true;
            this.btnPrintBalance.Click += new System.EventHandler(this.btnPrintBalance_Click);
            // 
            // BalanceControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblBalance);
            this.Controls.Add(this.btnViewonScreen);
            this.Controls.Add(this.btnPrintBalance);
            this.Name = "BalanceControl";
            this.Size = new System.Drawing.Size(326, 236);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblBalance;
        private System.Windows.Forms.Button btnViewonScreen;
        private System.Windows.Forms.Button btnPrintBalance;

    }
}
