namespace DCPOS
{
    partial class CardBalance
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
            this.components = new System.ComponentModel.Container();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            this.tmrRead = new System.Windows.Forms.Timer(this.components);
            this.lblBTCBalance = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblCardId = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtPublicKey = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(121, 193);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(118, 71);
            this.btnCancel.TabIndex = 0;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.ForeColor = System.Drawing.Color.Red;
            this.lblStatus.Location = new System.Drawing.Point(101, 119);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(47, 13);
            this.lblStatus.TabIndex = 3;
            this.lblStatus.Text = "lblStatus";
            // 
            // tmrRead
            // 
            this.tmrRead.Enabled = true;
            this.tmrRead.Tick += new System.EventHandler(this.tmrRead_Tick);
            // 
            // lblBTCBalance
            // 
            this.lblBTCBalance.AutoSize = true;
            this.lblBTCBalance.Location = new System.Drawing.Point(123, 91);
            this.lblBTCBalance.Name = "lblBTCBalance";
            this.lblBTCBalance.Size = new System.Drawing.Size(13, 13);
            this.lblBTCBalance.TabIndex = 5;
            this.lblBTCBalance.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(39, 91);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Balance";
            // 
            // lblCardId
            // 
            this.lblCardId.AutoSize = true;
            this.lblCardId.Location = new System.Drawing.Point(101, 38);
            this.lblCardId.Name = "lblCardId";
            this.lblCardId.Size = new System.Drawing.Size(38, 13);
            this.lblCardId.TabIndex = 8;
            this.lblCardId.Text = "CardId";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(39, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "CardId";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(39, 69);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "PublicKey";
            // 
            // txtPublicKey
            // 
            this.txtPublicKey.Location = new System.Drawing.Point(104, 69);
            this.txtPublicKey.Name = "txtPublicKey";
            this.txtPublicKey.ReadOnly = true;
            this.txtPublicKey.Size = new System.Drawing.Size(226, 20);
            this.txtPublicKey.TabIndex = 11;
            // 
            // CardBalance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(364, 276);
            this.Controls.Add(this.txtPublicKey);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblCardId);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblBTCBalance);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.btnCancel);
            this.Name = "CardBalance";
            this.Text = "Card Balance";
            this.Load += new System.EventHandler(this.CardBalance_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Timer tmrRead;
        private System.Windows.Forms.Label lblBTCBalance;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblCardId;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtPublicKey;
    }
}