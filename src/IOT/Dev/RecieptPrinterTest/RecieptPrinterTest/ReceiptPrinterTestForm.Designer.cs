namespace RecieptPrinterTest
{
    partial class ReceiptPrinterTestForm
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
            this.txtTextToPrint = new System.Windows.Forms.TextBox();
            this.lblTextToPrintLabel = new System.Windows.Forms.Label();
            this.btnPrint = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtTextToPrint
            // 
            this.txtTextToPrint.Location = new System.Drawing.Point(16, 29);
            this.txtTextToPrint.Multiline = true;
            this.txtTextToPrint.Name = "txtTextToPrint";
            this.txtTextToPrint.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtTextToPrint.Size = new System.Drawing.Size(259, 84);
            this.txtTextToPrint.TabIndex = 1;
            // 
            // lblTextToPrintLabel
            // 
            this.lblTextToPrintLabel.AutoSize = true;
            this.lblTextToPrintLabel.Location = new System.Drawing.Point(13, 13);
            this.lblTextToPrintLabel.Name = "lblTextToPrintLabel";
            this.lblTextToPrintLabel.Size = new System.Drawing.Size(71, 13);
            this.lblTextToPrintLabel.TabIndex = 0;
            this.lblTextToPrintLabel.Text = "Text To Print:";
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(16, 120);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(75, 23);
            this.btnPrint.TabIndex = 2;
            this.btnPrint.Text = "Print";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // ReceiptPrinterTestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 154);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.lblTextToPrintLabel);
            this.Controls.Add(this.txtTextToPrint);
            this.Name = "ReceiptPrinterTestForm";
            this.Text = "Reciept Printer Test";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtTextToPrint;
        private System.Windows.Forms.Label lblTextToPrintLabel;
        private System.Windows.Forms.Button btnPrint;
    }
}

