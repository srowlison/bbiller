namespace BitcoinATM
{
    partial class TapTag
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblStatusMessage = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.lblTagID = new System.Windows.Forms.Label();
            this.btnBack = new System.Windows.Forms.Button();
            this.lblBTCBalance = new System.Windows.Forms.Label();
            this.lblPublic = new System.Windows.Forms.Label();
            this.lblPrivateKey = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblStatusMessage);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(245, 95);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(358, 224);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            
            // 
            // lblStatusMessage
            // 
            this.lblStatusMessage.AutoSize = true;
            this.lblStatusMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatusMessage.Location = new System.Drawing.Point(126, 156);
            this.lblStatusMessage.Name = "lblStatusMessage";
            this.lblStatusMessage.Size = new System.Drawing.Size(73, 25);
            this.lblStatusMessage.TabIndex = 20;
            this.lblStatusMessage.Text = "Status";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(34, 81);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(286, 37);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tap Tag to Reader";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // lblTagID
            // 
            this.lblTagID.AutoSize = true;
            this.lblTagID.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTagID.Location = new System.Drawing.Point(355, 322);
            this.lblTagID.Name = "lblTagID";
            this.lblTagID.Size = new System.Drawing.Size(79, 29);
            this.lblTagID.TabIndex = 1;
            this.lblTagID.Text = "TagID";
            // 
            // btnBack
            // 
            this.btnBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBack.Location = new System.Drawing.Point(301, 451);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(235, 80);
            this.btnBack.TabIndex = 16;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = true;
            
            // 
            // lblBTCBalance
            // 
            this.lblBTCBalance.AutoSize = true;
            this.lblBTCBalance.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBTCBalance.Location = new System.Drawing.Point(355, 390);
            this.lblBTCBalance.Name = "lblBTCBalance";
            this.lblBTCBalance.Size = new System.Drawing.Size(100, 29);
            this.lblBTCBalance.TabIndex = 17;
            this.lblBTCBalance.Text = "Balance";
            // 
            // lblPublic
            // 
            this.lblPublic.AutoSize = true;
            this.lblPublic.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPublic.Location = new System.Drawing.Point(82, 9);
            this.lblPublic.Name = "lblPublic";
            this.lblPublic.Size = new System.Drawing.Size(114, 25);
            this.lblPublic.TabIndex = 18;
            this.lblPublic.Text = "Public Key";
            // 
            // lblPrivateKey
            // 
            this.lblPrivateKey.AutoSize = true;
            this.lblPrivateKey.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrivateKey.Location = new System.Drawing.Point(82, 54);
            this.lblPrivateKey.Name = "lblPrivateKey";
            this.lblPrivateKey.Size = new System.Drawing.Size(373, 25);
            this.lblPrivateKey.TabIndex = 19;
            this.lblPrivateKey.Text = "Encrypted PrivateKey - Paper Backup";
            // 
            // TapTag
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1375, 564);
            this.ControlBox = false;
            this.Controls.Add(this.lblPrivateKey);
            this.Controls.Add(this.lblPublic);
            this.Controls.Add(this.lblBTCBalance);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.lblTagID);
            this.Controls.Add(this.groupBox1);
            this.Name = "TapTag";
            this.Text = "TapTag";
            this.Load += new System.EventHandler(this.TapTag_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label lblTagID;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Label lblBTCBalance;
        private System.Windows.Forms.Label lblPublic;
        private System.Windows.Forms.Label lblPrivateKey;
        private System.Windows.Forms.Label lblStatusMessage;
    }
}