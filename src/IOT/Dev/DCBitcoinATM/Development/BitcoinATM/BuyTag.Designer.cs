namespace BitcoinATM
{
    partial class BuyTag
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
            this.grpBuyTag = new System.Windows.Forms.GroupBox();
            this.PurchaseTagStatus = new System.Windows.Forms.Label();
            this.btnBuyTagBack = new System.Windows.Forms.Button();
            this.btnPurchase = new System.Windows.Forms.Button();
            this.labTitle = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.grpBuyTag.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // grpBuyTag
            // 
            this.grpBuyTag.Controls.Add(this.PurchaseTagStatus);
            this.grpBuyTag.Controls.Add(this.btnBuyTagBack);
            this.grpBuyTag.Controls.Add(this.btnPurchase);
            this.grpBuyTag.Controls.Add(this.labTitle);
            this.grpBuyTag.Controls.Add(this.pictureBox1);
            this.grpBuyTag.Location = new System.Drawing.Point(-244, 8);
            this.grpBuyTag.Name = "grpBuyTag";
            this.grpBuyTag.Size = new System.Drawing.Size(1078, 490);
            this.grpBuyTag.TabIndex = 9;
            this.grpBuyTag.TabStop = false;
            // 
            // PurchaseTagStatus
            // 
            this.PurchaseTagStatus.AutoSize = true;
            this.PurchaseTagStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PurchaseTagStatus.Location = new System.Drawing.Point(479, 141);
            this.PurchaseTagStatus.Name = "PurchaseTagStatus";
            this.PurchaseTagStatus.Size = new System.Drawing.Size(0, 25);
            this.PurchaseTagStatus.TabIndex = 24;
            // 
            // btnBuyTagBack
            // 
            this.btnBuyTagBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuyTagBack.Font = new System.Drawing.Font("Open Sans", 25F, System.Drawing.FontStyle.Bold);
            this.btnBuyTagBack.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.btnBuyTagBack.Location = new System.Drawing.Point(13, 288);
            this.btnBuyTagBack.Name = "btnBuyTagBack";
            this.btnBuyTagBack.Size = new System.Drawing.Size(1043, 107);
            this.btnBuyTagBack.TabIndex = 23;
            this.btnBuyTagBack.Text = "Back";
            this.btnBuyTagBack.UseVisualStyleBackColor = true;
            // 
            // btnPurchase
            // 
            this.btnPurchase.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(59)))), ((int)(((byte)(84)))));
            this.btnPurchase.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPurchase.Font = new System.Drawing.Font("Open Sans", 25F, System.Drawing.FontStyle.Bold);
            this.btnPurchase.ForeColor = System.Drawing.Color.White;
            this.btnPurchase.Location = new System.Drawing.Point(13, 176);
            this.btnPurchase.Name = "btnPurchase";
            this.btnPurchase.Size = new System.Drawing.Size(1043, 107);
            this.btnPurchase.TabIndex = 15;
            this.btnPurchase.Text = "Purchase";
            this.btnPurchase.UseVisualStyleBackColor = false;
            // 
            // labTitle
            // 
            this.labTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labTitle.AutoSize = true;
            this.labTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labTitle.Location = new System.Drawing.Point(338, 17);
            this.labTitle.Name = "labTitle";
            this.labTitle.Size = new System.Drawing.Size(515, 25);
            this.labTitle.TabIndex = 14;
            this.labTitle.Text = "Purchase a Wallet for your Bitcoins - Only 10.00EUR";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::BitcoinATM.Properties.Resources.diamond_circle_nfc_tag_b18260be_78b5_4c83_aae1_1419bbd9d94a_2048x2048;
            this.pictureBox1.Location = new System.Drawing.Point(462, 29);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(180, 109);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 13;
            this.pictureBox1.TabStop = false;
            // 
            // BuyTag
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.grpBuyTag);
            this.Name = "BuyTag";
            this.Size = new System.Drawing.Size(910, 501);
            this.grpBuyTag.ResumeLayout(false);
            this.grpBuyTag.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpBuyTag;
        private System.Windows.Forms.Label PurchaseTagStatus;
        private System.Windows.Forms.Button btnBuyTagBack;
        private System.Windows.Forms.Button btnPurchase;
        private System.Windows.Forms.Label labTitle;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}
