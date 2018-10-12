namespace EftposTestApplication
{
    partial class EftposTest
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EftposTest));
            this.lblTransactionAmountLabel = new System.Windows.Forms.Label();
            this.txtTransactionAmount = new System.Windows.Forms.TextBox();
            this.btnStartTransaction = new System.Windows.Forms.Button();
            this.lblTransactionStatusLabel = new System.Windows.Forms.Label();
            this.txtTransactionStatus = new System.Windows.Forms.TextBox();
            this.btnCancelTransaction = new System.Windows.Forms.Button();
            this.eftposManager = new AxPosEftLib.AxPosEft();
            this.txtTransactionReference = new System.Windows.Forms.TextBox();
            this.lblTransactionReferenceLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.eftposManager)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTransactionAmountLabel
            // 
            this.lblTransactionAmountLabel.AutoSize = true;
            this.lblTransactionAmountLabel.Location = new System.Drawing.Point(17, 12);
            this.lblTransactionAmountLabel.Name = "lblTransactionAmountLabel";
            this.lblTransactionAmountLabel.Size = new System.Drawing.Size(46, 13);
            this.lblTransactionAmountLabel.TabIndex = 0;
            this.lblTransactionAmountLabel.Text = "Amount:";
            this.lblTransactionAmountLabel.Click += new System.EventHandler(this.lblTransactionAmountLabel_Click);
            // 
            // txtTransactionAmount
            // 
            this.txtTransactionAmount.Location = new System.Drawing.Point(69, 12);
            this.txtTransactionAmount.Name = "txtTransactionAmount";
            this.txtTransactionAmount.Size = new System.Drawing.Size(100, 20);
            this.txtTransactionAmount.TabIndex = 1;
            this.txtTransactionAmount.TextChanged += new System.EventHandler(this.txtTransactionAmount_TextChanged);
            // 
            // btnStartTransaction
            // 
            this.btnStartTransaction.Location = new System.Drawing.Point(69, 66);
            this.btnStartTransaction.Name = "btnStartTransaction";
            this.btnStartTransaction.Size = new System.Drawing.Size(120, 23);
            this.btnStartTransaction.TabIndex = 2;
            this.btnStartTransaction.Text = "Start Transaction";
            this.btnStartTransaction.UseVisualStyleBackColor = true;
            this.btnStartTransaction.Click += new System.EventHandler(this.btnStartTransaction_Click);
            // 
            // lblTransactionStatusLabel
            // 
            this.lblTransactionStatusLabel.AutoSize = true;
            this.lblTransactionStatusLabel.Location = new System.Drawing.Point(23, 96);
            this.lblTransactionStatusLabel.Name = "lblTransactionStatusLabel";
            this.lblTransactionStatusLabel.Size = new System.Drawing.Size(40, 13);
            this.lblTransactionStatusLabel.TabIndex = 4;
            this.lblTransactionStatusLabel.Text = "Status:";
            this.lblTransactionStatusLabel.Click += new System.EventHandler(this.lblTransactionStatusLabel_Click);
            // 
            // txtTransactionStatus
            // 
            this.txtTransactionStatus.Location = new System.Drawing.Point(69, 96);
            this.txtTransactionStatus.Multiline = true;
            this.txtTransactionStatus.Name = "txtTransactionStatus";
            this.txtTransactionStatus.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtTransactionStatus.Size = new System.Drawing.Size(217, 145);
            this.txtTransactionStatus.TabIndex = 5;
            this.txtTransactionStatus.TextChanged += new System.EventHandler(this.txtTransactionStatus_TextChanged);
            // 
            // btnCancelTransaction
            // 
            this.btnCancelTransaction.Location = new System.Drawing.Point(196, 66);
            this.btnCancelTransaction.Name = "btnCancelTransaction";
            this.btnCancelTransaction.Size = new System.Drawing.Size(75, 23);
            this.btnCancelTransaction.TabIndex = 3;
            this.btnCancelTransaction.Text = "Cancel";
            this.btnCancelTransaction.UseVisualStyleBackColor = true;
            this.btnCancelTransaction.Click += new System.EventHandler(this.btnCancelTransaction_Click);
            // 
            // eftposManager
            // 
            this.eftposManager.Enabled = true;
            this.eftposManager.Location = new System.Drawing.Point(15, 147);
            this.eftposManager.Name = "eftposManager";
            this.eftposManager.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("eftposManager.OcxState")));
            this.eftposManager.Size = new System.Drawing.Size(48, 50);
            this.eftposManager.TabIndex = 6;
            this.eftposManager.TransactionResponseEvent += new AxPosEftLib._DPosEftEvents_TransactionResponseEventEventHandler(this.eftposManager_TransactionResponseEvent);
            this.eftposManager.DisplayDataEvent += new AxPosEftLib._DPosEftEvents_DisplayDataEventEventHandler(this.eftposManager_DisplayDataEvent);
            // 
            // txtTransactionReference
            // 
            this.txtTransactionReference.Location = new System.Drawing.Point(69, 40);
            this.txtTransactionReference.Name = "txtTransactionReference";
            this.txtTransactionReference.Size = new System.Drawing.Size(100, 20);
            this.txtTransactionReference.TabIndex = 7;
            this.txtTransactionReference.TextChanged += new System.EventHandler(this.txtTransactionReference_TextChanged);
            // 
            // lblTransactionReferenceLabel
            // 
            this.lblTransactionReferenceLabel.AutoSize = true;
            this.lblTransactionReferenceLabel.Location = new System.Drawing.Point(3, 40);
            this.lblTransactionReferenceLabel.Name = "lblTransactionReferenceLabel";
            this.lblTransactionReferenceLabel.Size = new System.Drawing.Size(60, 13);
            this.lblTransactionReferenceLabel.TabIndex = 8;
            this.lblTransactionReferenceLabel.Text = "Reference:";
            this.lblTransactionReferenceLabel.Click += new System.EventHandler(this.lblTransactionReferenceLabel_Click);
            // 
            // EftposTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(305, 275);
            this.Controls.Add(this.lblTransactionReferenceLabel);
            this.Controls.Add(this.txtTransactionReference);
            this.Controls.Add(this.eftposManager);
            this.Controls.Add(this.btnCancelTransaction);
            this.Controls.Add(this.txtTransactionStatus);
            this.Controls.Add(this.lblTransactionStatusLabel);
            this.Controls.Add(this.btnStartTransaction);
            this.Controls.Add(this.txtTransactionAmount);
            this.Controls.Add(this.lblTransactionAmountLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "EftposTest";
            this.Text = "EFTPOS Test Form";
            this.Load += new System.EventHandler(this.EftposTest_Load);
            ((System.ComponentModel.ISupportInitialize)(this.eftposManager)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTransactionAmountLabel;
        private System.Windows.Forms.TextBox txtTransactionAmount;
        private System.Windows.Forms.Button btnStartTransaction;
        private System.Windows.Forms.Label lblTransactionStatusLabel;
        private System.Windows.Forms.TextBox txtTransactionStatus;
        private System.Windows.Forms.Button btnCancelTransaction;
        private AxPosEftLib.AxPosEft eftposManager;
        private System.Windows.Forms.TextBox txtTransactionReference;
        private System.Windows.Forms.Label lblTransactionReferenceLabel;
    }
}

