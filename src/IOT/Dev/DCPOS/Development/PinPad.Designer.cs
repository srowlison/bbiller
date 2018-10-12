namespace DCPOS
{
    partial class PinPad
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
            this.lblPIN = new System.Windows.Forms.Label();
            this.txtPin = new System.Windows.Forms.TextBox();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblPIN
            // 
            this.lblPIN.AutoSize = true;
            this.lblPIN.Location = new System.Drawing.Point(62, 50);
            this.lblPIN.Name = "lblPIN";
            this.lblPIN.Size = new System.Drawing.Size(25, 13);
            this.lblPIN.TabIndex = 10;
            this.lblPIN.Text = "PIN";
            // 
            // txtPin
            // 
            this.txtPin.Location = new System.Drawing.Point(105, 47);
            this.txtPin.Name = "txtPin";
            this.txtPin.PasswordChar = '*';
            this.txtPin.Size = new System.Drawing.Size(100, 20);
            this.txtPin.TabIndex = 9;
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(65, 102);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 11;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(160, 102);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 12;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // PinPad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 177);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.lblPIN);
            this.Controls.Add(this.txtPin);
            this.Name = "PinPad";
            this.Text = "PinPad";
            this.Load += new System.EventHandler(this.PinPad_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblPIN;
        private System.Windows.Forms.TextBox txtPin;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
    }
}