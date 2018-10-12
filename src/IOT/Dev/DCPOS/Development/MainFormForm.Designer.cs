namespace DCPOS
{
    partial class MainFormForm
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hELPToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.btnNewCard = new System.Windows.Forms.Button();
            this.btnCardBalance = new System.Windows.Forms.Button();
            this.btnSell = new System.Windows.Forms.Button();
            this.btnBuy = new System.Windows.Forms.Button();
            this.btnRefund = new System.Windows.Forms.Button();
            this.btnPurchase = new System.Windows.Forms.Button();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setMerchantToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.toolStripContainer1.ContentPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.toolsToolStripMenuItem,
            this.hELPToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(964, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(40, 20);
            this.fileToolStripMenuItem.Text = "&FILE";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.exitToolStripMenuItem.Text = "E&xit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // hELPToolStripMenuItem
            // 
            this.hELPToolStripMenuItem.Name = "hELPToolStripMenuItem";
            this.hELPToolStripMenuItem.Size = new System.Drawing.Size(47, 20);
            this.hELPToolStripMenuItem.Text = "&HELP";
            this.hELPToolStripMenuItem.Click += new System.EventHandler(this.hELPToolStripMenuItem_Click);
            // 
            // toolStripContainer1
            // 
            this.toolStripContainer1.BottomToolStripPanelVisible = false;
            // 
            // toolStripContainer1.ContentPanel
            // 
            this.toolStripContainer1.ContentPanel.Controls.Add(this.btnNewCard);
            this.toolStripContainer1.ContentPanel.Controls.Add(this.btnCardBalance);
            this.toolStripContainer1.ContentPanel.Controls.Add(this.btnSell);
            this.toolStripContainer1.ContentPanel.Controls.Add(this.btnBuy);
            this.toolStripContainer1.ContentPanel.Controls.Add(this.btnRefund);
            this.toolStripContainer1.ContentPanel.Controls.Add(this.btnPurchase);
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(964, 101);
            this.toolStripContainer1.ContentPanel.Load += new System.EventHandler(this.toolStripContainer1_ContentPanel_Load);
            this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripContainer1.LeftToolStripPanelVisible = false;
            this.toolStripContainer1.Location = new System.Drawing.Point(0, 24);
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.RightToolStripPanelVisible = false;
            this.toolStripContainer1.Size = new System.Drawing.Size(964, 126);
            this.toolStripContainer1.TabIndex = 1;
            this.toolStripContainer1.Text = "toolStripContainer1";
            // 
            // btnNewCard
            // 
            this.btnNewCard.Location = new System.Drawing.Point(803, 3);
            this.btnNewCard.Name = "btnNewCard";
            this.btnNewCard.Size = new System.Drawing.Size(154, 92);
            this.btnNewCard.TabIndex = 5;
            this.btnNewCard.Text = "New Card";
            this.btnNewCard.UseVisualStyleBackColor = true;
            this.btnNewCard.Click += new System.EventHandler(this.btnNewCard_Click);
            // 
            // btnCardBalance
            // 
            this.btnCardBalance.Location = new System.Drawing.Point(643, 3);
            this.btnCardBalance.Name = "btnCardBalance";
            this.btnCardBalance.Size = new System.Drawing.Size(154, 92);
            this.btnCardBalance.TabIndex = 4;
            this.btnCardBalance.Text = "Card balance";
            this.btnCardBalance.UseVisualStyleBackColor = true;
            this.btnCardBalance.Click += new System.EventHandler(this.btnCardBalance_Click);
            // 
            // btnSell
            // 
            this.btnSell.Location = new System.Drawing.Point(483, 3);
            this.btnSell.Name = "btnSell";
            this.btnSell.Size = new System.Drawing.Size(154, 92);
            this.btnSell.TabIndex = 3;
            this.btnSell.Text = "Sell Bitcoin";
            this.btnSell.UseVisualStyleBackColor = true;
            this.btnSell.Click += new System.EventHandler(this.btnSell_Click);
            // 
            // btnBuy
            // 
            this.btnBuy.Location = new System.Drawing.Point(323, 3);
            this.btnBuy.Name = "btnBuy";
            this.btnBuy.Size = new System.Drawing.Size(154, 92);
            this.btnBuy.TabIndex = 2;
            this.btnBuy.Text = "Buy Bitcoin";
            this.btnBuy.UseVisualStyleBackColor = true;
            this.btnBuy.Click += new System.EventHandler(this.btnBuy_Click);
            // 
            // btnRefund
            // 
            this.btnRefund.Location = new System.Drawing.Point(163, 3);
            this.btnRefund.Name = "btnRefund";
            this.btnRefund.Size = new System.Drawing.Size(154, 92);
            this.btnRefund.TabIndex = 1;
            this.btnRefund.Text = "Refund";
            this.btnRefund.UseVisualStyleBackColor = true;
            this.btnRefund.Click += new System.EventHandler(this.btnRefund_Click);
            // 
            // btnPurchase
            // 
            this.btnPurchase.Location = new System.Drawing.Point(3, 3);
            this.btnPurchase.Name = "btnPurchase";
            this.btnPurchase.Size = new System.Drawing.Size(154, 92);
            this.btnPurchase.TabIndex = 0;
            this.btnPurchase.Text = "Purchase";
            this.btnPurchase.UseVisualStyleBackColor = true;
            this.btnPurchase.Click += new System.EventHandler(this.btnPurchase_Click);
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.setMerchantToolStripMenuItem});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(56, 20);
            this.toolsToolStripMenuItem.Text = "&TOOLS";
            this.toolsToolStripMenuItem.Click += new System.EventHandler(this.toolsToolStripMenuItem_Click);
            // 
            // setMerchantToolStripMenuItem
            // 
            this.setMerchantToolStripMenuItem.Name = "setMerchantToolStripMenuItem";
            this.setMerchantToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.setMerchantToolStripMenuItem.Text = "Set &Merchant";
            this.setMerchantToolStripMenuItem.Click += new System.EventHandler(this.setMerchantToolStripMenuItem_Click);
            // 
            // MainFormForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(964, 150);
            this.Controls.Add(this.toolStripContainer1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainFormForm";
            this.Text = "Diamond Circle PC POS";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolStripContainer1.ContentPanel.ResumeLayout(false);
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
        private System.Windows.Forms.Button btnPurchase;
        private System.Windows.Forms.Button btnRefund;
        private System.Windows.Forms.Button btnBuy;
        private System.Windows.Forms.Button btnSell;
        private System.Windows.Forms.Button btnCardBalance;
        private System.Windows.Forms.Button btnNewCard;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hELPToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem setMerchantToolStripMenuItem;
    }
}

