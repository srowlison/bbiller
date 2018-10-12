namespace BitcoinATM
{
    partial class SellNFCWallet
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnPurchase = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.lblApproved = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(436, 124);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 50);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(379, 76);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(274, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Purchase a Wallet for your Bitcoins - Collect below $1.00";
            // 
            // btnPurchase
            // 
            this.btnPurchase.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPurchase.Location = new System.Drawing.Point(545, 307);
            this.btnPurchase.Name = "btnPurchase";
            this.btnPurchase.Size = new System.Drawing.Size(231, 80);
            this.btnPurchase.TabIndex = 12;
            this.btnPurchase.Text = "Purchase";
            this.btnPurchase.UseVisualStyleBackColor = true;
            this.btnPurchase.Click += new System.EventHandler(this.btnPurchase_Click);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(148, 307);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(235, 80);
            this.button2.TabIndex = 16;
            this.button2.Text = "Back";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // lblApproved
            // 
            this.lblApproved.AutoSize = true;
            this.lblApproved.Location = new System.Drawing.Point(414, 456);
            this.lblApproved.Name = "lblApproved";
            this.lblApproved.Size = new System.Drawing.Size(35, 13);
            this.lblApproved.TabIndex = 22;
            this.lblApproved.Text = "label4";
            // 
            // SellNFCWallet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1037, 560);
            this.ControlBox = false;
            this.Controls.Add(this.lblApproved);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btnPurchase);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Name = "SellNFCWallet";
            this.Text = "Purchase Wallet";
            this.Load += new System.EventHandler(this.SellNFCWallet_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnPurchase;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label lblApproved;
    }
}