namespace Anugraha.View
{
    partial class Master
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Master));
            this.panel1 = new System.Windows.Forms.Panel();
            this.topMenu = new System.Windows.Forms.MenuStrip();
            this.configurationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.companyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.categoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.productToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gSTToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.vendorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.customerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.purchaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.purchaseItemToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.purchaseReturnToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saleEntryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salesReturnToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.transactionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stockInHandToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.transactionToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.reportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.userToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logoutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MidPanel = new System.Windows.Forms.Panel();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.topMenu.SuspendLayout();
            this.MidPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.topMenu);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1006, 44);
            this.panel1.TabIndex = 4;
            // 
            // topMenu
            // 
            this.topMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.topMenu.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.topMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.topMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.configurationToolStripMenuItem,
            this.purchaseToolStripMenuItem,
            this.salesToolStripMenuItem,
            this.transactionToolStripMenuItem,
            this.reportToolStripMenuItem,
            this.userToolStripMenuItem,
            this.logoutToolStripMenuItem});
            this.topMenu.Location = new System.Drawing.Point(0, 0);
            this.topMenu.Name = "topMenu";
            this.topMenu.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.topMenu.Size = new System.Drawing.Size(1006, 44);
            this.topMenu.TabIndex = 0;
            this.topMenu.Text = "menuStrip1";
            // 
            // configurationToolStripMenuItem
            // 
            this.configurationToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.companyToolStripMenuItem,
            this.categoryToolStripMenuItem,
            this.productToolStripMenuItem,
            this.gSTToolStripMenuItem,
            this.vendorToolStripMenuItem,
            this.customerToolStripMenuItem});
            this.configurationToolStripMenuItem.Image = global::Anugraha.Properties.Resources.settings;
            this.configurationToolStripMenuItem.Name = "configurationToolStripMenuItem";
            this.configurationToolStripMenuItem.ShortcutKeyDisplayString = "";
            this.configurationToolStripMenuItem.Size = new System.Drawing.Size(210, 40);
            this.configurationToolStripMenuItem.Text = "&Configuration ";
            this.configurationToolStripMenuItem.ToolTipText = "To be Configuration";
            // 
            // companyToolStripMenuItem
            // 
            this.companyToolStripMenuItem.Image = global::Anugraha.Properties.Resources.sellers;
            this.companyToolStripMenuItem.Name = "companyToolStripMenuItem";
            this.companyToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F1;
            this.companyToolStripMenuItem.Size = new System.Drawing.Size(216, 26);
            this.companyToolStripMenuItem.Text = "C&ompany";
            this.companyToolStripMenuItem.Click += new System.EventHandler(this.companyToolStripMenuItem_Click);
            // 
            // categoryToolStripMenuItem
            // 
            this.categoryToolStripMenuItem.Image = global::Anugraha.Properties.Resources.marc;
            this.categoryToolStripMenuItem.Name = "categoryToolStripMenuItem";
            this.categoryToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F2;
            this.categoryToolStripMenuItem.Size = new System.Drawing.Size(216, 26);
            this.categoryToolStripMenuItem.Text = "C&ategory";
            this.categoryToolStripMenuItem.Click += new System.EventHandler(this.categoryToolStripMenuItem_Click);
            // 
            // productToolStripMenuItem
            // 
            this.productToolStripMenuItem.Image = global::Anugraha.Properties.Resources.if_Streamline_73_185093;
            this.productToolStripMenuItem.Name = "productToolStripMenuItem";
            this.productToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F4;
            this.productToolStripMenuItem.Size = new System.Drawing.Size(216, 26);
            this.productToolStripMenuItem.Text = "Product";
            this.productToolStripMenuItem.Click += new System.EventHandler(this.productToolStripMenuItem_Click);
            // 
            // gSTToolStripMenuItem
            // 
            this.gSTToolStripMenuItem.Image = global::Anugraha.Properties.Resources.sale1;
            this.gSTToolStripMenuItem.Name = "gSTToolStripMenuItem";
            this.gSTToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this.gSTToolStripMenuItem.Size = new System.Drawing.Size(216, 26);
            this.gSTToolStripMenuItem.Text = "GST";
            this.gSTToolStripMenuItem.Visible = false;
            // 
            // vendorToolStripMenuItem
            // 
            this.vendorToolStripMenuItem.Image = global::Anugraha.Properties.Resources.Agent;
            this.vendorToolStripMenuItem.Name = "vendorToolStripMenuItem";
            this.vendorToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F6;
            this.vendorToolStripMenuItem.Size = new System.Drawing.Size(216, 26);
            this.vendorToolStripMenuItem.Text = "Vendor";
            this.vendorToolStripMenuItem.Click += new System.EventHandler(this.vendorToolStripMenuItem_Click);
            // 
            // customerToolStripMenuItem
            // 
            this.customerToolStripMenuItem.Image = global::Anugraha.Properties.Resources.if_vector_65_01_473776__1_;
            this.customerToolStripMenuItem.Name = "customerToolStripMenuItem";
            this.customerToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F7;
            this.customerToolStripMenuItem.Size = new System.Drawing.Size(216, 26);
            this.customerToolStripMenuItem.Text = "Customer";
            this.customerToolStripMenuItem.Visible = false;
            // 
            // purchaseToolStripMenuItem
            // 
            this.purchaseToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.purchaseItemToolStripMenuItem,
            this.purchaseReturnToolStripMenuItem});
            this.purchaseToolStripMenuItem.Image = global::Anugraha.Properties.Resources.buy;
            this.purchaseToolStripMenuItem.Name = "purchaseToolStripMenuItem";
            this.purchaseToolStripMenuItem.Size = new System.Drawing.Size(138, 40);
            this.purchaseToolStripMenuItem.Text = "&Purchase";
            // 
            // purchaseItemToolStripMenuItem
            // 
            this.purchaseItemToolStripMenuItem.Image = global::Anugraha.Properties.Resources.buy;
            this.purchaseItemToolStripMenuItem.Name = "purchaseItemToolStripMenuItem";
            this.purchaseItemToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.P)));
            this.purchaseItemToolStripMenuItem.Size = new System.Drawing.Size(348, 26);
            this.purchaseItemToolStripMenuItem.Text = "Purchase Entry";
            this.purchaseItemToolStripMenuItem.Click += new System.EventHandler(this.purchaseItemToolStripMenuItem_Click);
            // 
            // purchaseReturnToolStripMenuItem
            // 
            this.purchaseReturnToolStripMenuItem.Image = global::Anugraha.Properties.Resources.if_round_trip_3383442;
            this.purchaseReturnToolStripMenuItem.Name = "purchaseReturnToolStripMenuItem";
            this.purchaseReturnToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.purchaseReturnToolStripMenuItem.Size = new System.Drawing.Size(348, 26);
            this.purchaseReturnToolStripMenuItem.Text = "Purchase Return";
            this.purchaseReturnToolStripMenuItem.Click += new System.EventHandler(this.purchaseReturnToolStripMenuItem_Click);
            // 
            // salesToolStripMenuItem
            // 
            this.salesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saleEntryToolStripMenuItem,
            this.salesReturnToolStripMenuItem});
            this.salesToolStripMenuItem.Image = global::Anugraha.Properties.Resources.sale;
            this.salesToolStripMenuItem.Name = "salesToolStripMenuItem";
            this.salesToolStripMenuItem.Size = new System.Drawing.Size(102, 40);
            this.salesToolStripMenuItem.Text = "&Sales";
            // 
            // saleEntryToolStripMenuItem
            // 
            this.saleEntryToolStripMenuItem.Image = global::Anugraha.Properties.Resources.sale;
            this.saleEntryToolStripMenuItem.Name = "saleEntryToolStripMenuItem";
            this.saleEntryToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.E)));
            this.saleEntryToolStripMenuItem.Size = new System.Drawing.Size(312, 26);
            this.saleEntryToolStripMenuItem.Text = "Sale Entry";
            this.saleEntryToolStripMenuItem.Click += new System.EventHandler(this.saleEntryToolStripMenuItem_Click);
            // 
            // salesReturnToolStripMenuItem
            // 
            this.salesReturnToolStripMenuItem.Image = global::Anugraha.Properties.Resources.if_round_trip_3383442;
            this.salesReturnToolStripMenuItem.Name = "salesReturnToolStripMenuItem";
            this.salesReturnToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.R)));
            this.salesReturnToolStripMenuItem.Size = new System.Drawing.Size(312, 26);
            this.salesReturnToolStripMenuItem.Text = "Sales Return";
            this.salesReturnToolStripMenuItem.Click += new System.EventHandler(this.salesReturnToolStripMenuItem_Click);
            // 
            // transactionToolStripMenuItem
            // 
            this.transactionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.stockInHandToolStripMenuItem,
            this.transactionToolStripMenuItem1});
            this.transactionToolStripMenuItem.Image = global::Anugraha.Properties.Resources.if_Checklist_clipboard_inventory_list_report_tasks_todo_1886533;
            this.transactionToolStripMenuItem.Name = "transactionToolStripMenuItem";
            this.transactionToolStripMenuItem.Size = new System.Drawing.Size(150, 40);
            this.transactionToolStripMenuItem.Text = "&Inventory";
            // 
            // stockInHandToolStripMenuItem
            // 
            this.stockInHandToolStripMenuItem.Image = global::Anugraha.Properties.Resources.if_Checklist_clipboard_inventory_list_report_tasks_todo_1886533;
            this.stockInHandToolStripMenuItem.Name = "stockInHandToolStripMenuItem";
            this.stockInHandToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.H)));
            this.stockInHandToolStripMenuItem.Size = new System.Drawing.Size(324, 26);
            this.stockInHandToolStripMenuItem.Text = "Stock In Hand";
            // 
            // transactionToolStripMenuItem1
            // 
            this.transactionToolStripMenuItem1.Image = global::Anugraha.Properties.Resources.transaction;
            this.transactionToolStripMenuItem1.Name = "transactionToolStripMenuItem1";
            this.transactionToolStripMenuItem1.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.T)));
            this.transactionToolStripMenuItem1.Size = new System.Drawing.Size(324, 26);
            this.transactionToolStripMenuItem1.Text = "Payment";
            // 
            // reportToolStripMenuItem
            // 
            this.reportToolStripMenuItem.Image = global::Anugraha.Properties.Resources.report;
            this.reportToolStripMenuItem.Name = "reportToolStripMenuItem";
            this.reportToolStripMenuItem.Size = new System.Drawing.Size(114, 40);
            this.reportToolStripMenuItem.Text = "&Report";
            // 
            // userToolStripMenuItem
            // 
            this.userToolStripMenuItem.Image = global::Anugraha.Properties.Resources.Agent;
            this.userToolStripMenuItem.Name = "userToolStripMenuItem";
            this.userToolStripMenuItem.Size = new System.Drawing.Size(90, 40);
            this.userToolStripMenuItem.Text = "&User";
            this.userToolStripMenuItem.Visible = false;
            // 
            // logoutToolStripMenuItem
            // 
            this.logoutToolStripMenuItem.Image = global::Anugraha.Properties.Resources.logout1;
            this.logoutToolStripMenuItem.Name = "logoutToolStripMenuItem";
            this.logoutToolStripMenuItem.ShortcutKeyDisplayString = "Logout";
            this.logoutToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F4)));
            this.logoutToolStripMenuItem.Size = new System.Drawing.Size(114, 40);
            this.logoutToolStripMenuItem.Text = "&Logout";
            this.logoutToolStripMenuItem.Click += new System.EventHandler(this.logoutToolStripMenuItem_Click);
            // 
            // MidPanel
            // 
            this.MidPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MidPanel.BackColor = System.Drawing.SystemColors.Control;
            this.MidPanel.BackgroundImage = global::Anugraha.Properties.Resources.bg1;
            this.MidPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.MidPanel.Controls.Add(this.mainPanel);
            this.MidPanel.Location = new System.Drawing.Point(0, 43);
            this.MidPanel.Name = "MidPanel";
            this.MidPanel.Size = new System.Drawing.Size(1006, 676);
            this.MidPanel.TabIndex = 3;
            // 
            // mainPanel
            // 
            this.mainPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mainPanel.BackColor = System.Drawing.Color.Transparent;
            this.mainPanel.Location = new System.Drawing.Point(39, 40);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(943, 626);
            this.mainPanel.TabIndex = 0;
            // 
            // Master
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1006, 721);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.MidPanel);
            this.Font = new System.Drawing.Font("High Tower Text", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.topMenu;
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "Master";
            this.Text = "Master";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Master_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.topMenu.ResumeLayout(false);
            this.topMenu.PerformLayout();
            this.MidPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.MenuStrip topMenu;
        private System.Windows.Forms.ToolStripMenuItem configurationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem purchaseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem salesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem transactionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem userToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem logoutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem companyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem categoryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem productToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gSTToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem vendorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem customerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stockInHandToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem transactionToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem purchaseItemToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem purchaseReturnToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saleEntryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem salesReturnToolStripMenuItem;
        private System.Windows.Forms.Panel MidPanel;
        private System.Windows.Forms.Panel mainPanel;
    }
}