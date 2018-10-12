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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnBack = new System.Windows.Forms.Button();
            this.lblStatusMessage = new System.Windows.Forms.Label();
            this.lblTagID = new System.Windows.Forms.Label();
            this.labTitle = new System.Windows.Forms.Label();
            this.grpBalance = new System.Windows.Forms.GroupBox();
            this.lblBalance = new System.Windows.Forms.Label();
            this.lblBTCBalance = new System.Windows.Forms.Label();
            this.btnViewonScreen = new System.Windows.Forms.Button();
            this.btnPrintBalance = new System.Windows.Forms.Button();
            this.grpBalance.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnBack
            // 
            this.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBack.Font = new System.Drawing.Font("Open Sans", 25F, System.Drawing.FontStyle.Bold);
            this.btnBack.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.btnBack.Location = new System.Drawing.Point(5, 291);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(1043, 107);
            this.btnBack.TabIndex = 41;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // lblStatusMessage
            // 
            this.lblStatusMessage.AutoSize = true;
            this.lblStatusMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatusMessage.Location = new System.Drawing.Point(436, 204);
            this.lblStatusMessage.Name = "lblStatusMessage";
            this.lblStatusMessage.Size = new System.Drawing.Size(73, 25);
            this.lblStatusMessage.TabIndex = 40;
            this.lblStatusMessage.Text = "Status";
            // 
            // lblTagID
            // 
            this.lblTagID.AutoSize = true;
            this.lblTagID.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTagID.Location = new System.Drawing.Point(436, 135);
            this.lblTagID.Name = "lblTagID";
            this.lblTagID.Size = new System.Drawing.Size(79, 29);
            this.lblTagID.TabIndex = 43;
            this.lblTagID.Text = "TagID";
            // 
            // labTitle
            // 
            this.labTitle.AutoSize = true;
            this.labTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labTitle.Location = new System.Drawing.Point(341, 32);
            this.labTitle.Name = "labTitle";
            this.labTitle.Size = new System.Drawing.Size(286, 37);
            this.labTitle.TabIndex = 42;
            this.labTitle.Text = "Tap Tag to Reader";
            // 
            // grpBalance
            // 
            this.grpBalance.Controls.Add(this.lblBalance);
            this.grpBalance.Controls.Add(this.lblBTCBalance);
            this.grpBalance.Controls.Add(this.btnViewonScreen);
            this.grpBalance.Controls.Add(this.btnPrintBalance);
            this.grpBalance.Location = new System.Drawing.Point(713, 11);
            this.grpBalance.Name = "grpBalance";
            this.grpBalance.Size = new System.Drawing.Size(322, 237);
            this.grpBalance.TabIndex = 44;
            this.grpBalance.TabStop = false;
            this.grpBalance.Visible = false;
            // 
            // lblBalance
            // 
            this.lblBalance.AutoSize = true;
            this.lblBalance.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBalance.Location = new System.Drawing.Point(24, 196);
            this.lblBalance.Name = "lblBalance";
            this.lblBalance.Size = new System.Drawing.Size(90, 25);
            this.lblBalance.TabIndex = 31;
            this.lblBalance.Text = "Balance";
            // 
            // lblBTCBalance
            // 
            this.lblBTCBalance.AutoSize = true;
            this.lblBTCBalance.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBTCBalance.Location = new System.Drawing.Point(151, 196);
            this.lblBTCBalance.Name = "lblBTCBalance";
            this.lblBTCBalance.Size = new System.Drawing.Size(26, 29);
            this.lblBTCBalance.TabIndex = 30;
            this.lblBTCBalance.Text = "0";
            this.lblBTCBalance.Visible = false;
            // 
            // btnViewonScreen
            // 
            this.btnViewonScreen.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnViewonScreen.Location = new System.Drawing.Point(9, 107);
            this.btnViewonScreen.Name = "btnViewonScreen";
            this.btnViewonScreen.Size = new System.Drawing.Size(302, 69);
            this.btnViewonScreen.TabIndex = 29;
            this.btnViewonScreen.Text = "On Screen";
            this.btnViewonScreen.UseVisualStyleBackColor = true;
            // 
            // btnPrintBalance
            // 
            this.btnPrintBalance.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrintBalance.Location = new System.Drawing.Point(9, 19);
            this.btnPrintBalance.Name = "btnPrintBalance";
            this.btnPrintBalance.Size = new System.Drawing.Size(302, 76);
            this.btnPrintBalance.TabIndex = 28;
            this.btnPrintBalance.Text = "Print Balance";
            this.btnPrintBalance.UseVisualStyleBackColor = true;
            // 
            // TapTag
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.lblStatusMessage);
            this.Controls.Add(this.lblTagID);
            this.Controls.Add(this.labTitle);
            this.Controls.Add(this.grpBalance);
            this.Name = "TapTag";
            this.Size = new System.Drawing.Size(1051, 401);
            this.grpBalance.ResumeLayout(false);
            this.grpBalance.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Label lblStatusMessage;
        private System.Windows.Forms.Label lblTagID;
        private System.Windows.Forms.Label labTitle;
        private System.Windows.Forms.GroupBox grpBalance;
        private System.Windows.Forms.Label lblBalance;
        private System.Windows.Forms.Label lblBTCBalance;
        private System.Windows.Forms.Button btnViewonScreen;
        private System.Windows.Forms.Button btnPrintBalance;

    }
}
