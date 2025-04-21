using System;
using System.Windows.Forms;

namespace KQS
{
    partial class DashboardForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.panelSidebar = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnExpenseTracking = new System.Windows.Forms.Button();
            this.btnInventoryManagement = new System.Windows.Forms.Button();
            this.btnManageInvoices = new System.Windows.Forms.Button();
            this.btnManageSuppliers = new System.Windows.Forms.Button();
            this.btnManageCustomers = new System.Windows.Forms.Button();
            this.btnFinancialReports = new System.Windows.Forms.Button();
            this.btnGoToSeller = new System.Windows.Forms.Button();
            this.btnViewSalesLogs = new System.Windows.Forms.Button();
            this.btnManageCategories = new System.Windows.Forms.Button();
            this.btnManageItems = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.btnManageUsers = new System.Windows.Forms.Button();
            this.panelHeader = new System.Windows.Forms.Panel();
            this.lblWelcome = new System.Windows.Forms.Label();
            this.panelMain = new System.Windows.Forms.Panel();
            this.panelStatusBar = new System.Windows.Forms.Panel();
            this.panelSidebar.SuspendLayout();
            this.panelHeader.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelSidebar
            // 
            this.panelSidebar.BackColor = System.Drawing.Color.SteelBlue;
            this.panelSidebar.Controls.Add(this.btnClose);
            this.panelSidebar.Controls.Add(this.btnExpenseTracking);
            this.panelSidebar.Controls.Add(this.btnInventoryManagement);
            this.panelSidebar.Controls.Add(this.btnManageInvoices);
            this.panelSidebar.Controls.Add(this.btnManageSuppliers);
            this.panelSidebar.Controls.Add(this.btnManageCustomers);
            this.panelSidebar.Controls.Add(this.btnFinancialReports);
            this.panelSidebar.Controls.Add(this.btnGoToSeller);
            this.panelSidebar.Controls.Add(this.btnViewSalesLogs);
            this.panelSidebar.Controls.Add(this.btnManageCategories);
            this.panelSidebar.Controls.Add(this.btnManageItems);
            this.panelSidebar.Controls.Add(this.btnLogout);
            this.panelSidebar.Controls.Add(this.btnManageUsers);
            this.panelSidebar.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelSidebar.Location = new System.Drawing.Point(0, 0);
            this.panelSidebar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panelSidebar.Name = "panelSidebar";
            this.panelSidebar.Size = new System.Drawing.Size(300, 1017);
            this.panelSidebar.TabIndex = 0;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.Firebrick;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(18, 942);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(264, 55);
            this.btnClose.TabIndex = 13;
            this.btnClose.Text = "Exit System";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnExpenseTracking
            // 
            this.btnExpenseTracking.BackColor = System.Drawing.Color.Teal;
            this.btnExpenseTracking.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExpenseTracking.ForeColor = System.Drawing.Color.White;
            this.btnExpenseTracking.Location = new System.Drawing.Point(18, 812);
            this.btnExpenseTracking.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnExpenseTracking.Name = "btnExpenseTracking";
            this.btnExpenseTracking.Size = new System.Drawing.Size(264, 55);
            this.btnExpenseTracking.TabIndex = 11;
            this.btnExpenseTracking.Text = "Expense Tracking";
            this.btnExpenseTracking.UseVisualStyleBackColor = false;
            this.btnExpenseTracking.Click += new System.EventHandler(this.btnExpenseTracking_Click);
            // 
            // btnInventoryManagement
            // 
            this.btnInventoryManagement.BackColor = System.Drawing.Color.Teal;
            this.btnInventoryManagement.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInventoryManagement.ForeColor = System.Drawing.Color.White;
            this.btnInventoryManagement.Location = new System.Drawing.Point(18, 748);
            this.btnInventoryManagement.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnInventoryManagement.Name = "btnInventoryManagement";
            this.btnInventoryManagement.Size = new System.Drawing.Size(264, 55);
            this.btnInventoryManagement.TabIndex = 10;
            this.btnInventoryManagement.Text = "Inventory Management";
            this.btnInventoryManagement.UseVisualStyleBackColor = false;
            this.btnInventoryManagement.Click += new System.EventHandler(this.btnInventoryManagement_Click);
            // 
            // btnManageInvoices
            // 
            this.btnManageInvoices.BackColor = System.Drawing.Color.Teal;
            this.btnManageInvoices.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnManageInvoices.ForeColor = System.Drawing.Color.White;
            this.btnManageInvoices.Location = new System.Drawing.Point(18, 683);
            this.btnManageInvoices.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnManageInvoices.Name = "btnManageInvoices";
            this.btnManageInvoices.Size = new System.Drawing.Size(264, 55);
            this.btnManageInvoices.TabIndex = 9;
            this.btnManageInvoices.Text = "Manage Invoices";
            this.btnManageInvoices.UseVisualStyleBackColor = false;
            this.btnManageInvoices.Click += new System.EventHandler(this.btnManageInvoices_Click);
            // 
            // btnManageSuppliers
            // 
            this.btnManageSuppliers.BackColor = System.Drawing.Color.Teal;
            this.btnManageSuppliers.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnManageSuppliers.ForeColor = System.Drawing.Color.White;
            this.btnManageSuppliers.Location = new System.Drawing.Point(18, 618);
            this.btnManageSuppliers.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnManageSuppliers.Name = "btnManageSuppliers";
            this.btnManageSuppliers.Size = new System.Drawing.Size(264, 55);
            this.btnManageSuppliers.TabIndex = 8;
            this.btnManageSuppliers.Text = "Manage Suppliers";
            this.btnManageSuppliers.UseVisualStyleBackColor = false;
            this.btnManageSuppliers.Click += new System.EventHandler(this.btnManageSuppliers_Click);
            // 
            // btnManageCustomers
            // 
            this.btnManageCustomers.BackColor = System.Drawing.Color.Teal;
            this.btnManageCustomers.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnManageCustomers.ForeColor = System.Drawing.Color.White;
            this.btnManageCustomers.Location = new System.Drawing.Point(18, 554);
            this.btnManageCustomers.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnManageCustomers.Name = "btnManageCustomers";
            this.btnManageCustomers.Size = new System.Drawing.Size(264, 55);
            this.btnManageCustomers.TabIndex = 7;
            this.btnManageCustomers.Text = "Manage Customers";
            this.btnManageCustomers.UseVisualStyleBackColor = false;
            this.btnManageCustomers.Click += new System.EventHandler(this.btnManageCustomers_Click);
            // 
            // btnFinancialReports
            // 
            this.btnFinancialReports.BackColor = System.Drawing.Color.Teal;
            this.btnFinancialReports.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFinancialReports.ForeColor = System.Drawing.Color.White;
            this.btnFinancialReports.Location = new System.Drawing.Point(18, 489);
            this.btnFinancialReports.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnFinancialReports.Name = "btnFinancialReports";
            this.btnFinancialReports.Size = new System.Drawing.Size(264, 55);
            this.btnFinancialReports.TabIndex = 6;
            this.btnFinancialReports.Text = "Financial Reports";
            this.btnFinancialReports.UseVisualStyleBackColor = false;
            this.btnFinancialReports.Click += new System.EventHandler(this.btnFinancialReports_Click);
            // 
            // btnGoToSeller
            // 
            this.btnGoToSeller.BackColor = System.Drawing.Color.DarkOrange;
            this.btnGoToSeller.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGoToSeller.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGoToSeller.ForeColor = System.Drawing.Color.White;
            this.btnGoToSeller.Location = new System.Drawing.Point(18, 425);
            this.btnGoToSeller.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnGoToSeller.Name = "btnGoToSeller";
            this.btnGoToSeller.Size = new System.Drawing.Size(264, 55);
            this.btnGoToSeller.TabIndex = 5;
            this.btnGoToSeller.Text = "POS System";
            this.btnGoToSeller.UseVisualStyleBackColor = false;
            this.btnGoToSeller.Click += new System.EventHandler(this.btnGoToSeller_Click);
            // 
            // btnViewSalesLogs
            // 
            this.btnViewSalesLogs.BackColor = System.Drawing.Color.Teal;
            this.btnViewSalesLogs.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnViewSalesLogs.ForeColor = System.Drawing.Color.White;
            this.btnViewSalesLogs.Location = new System.Drawing.Point(18, 360);
            this.btnViewSalesLogs.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnViewSalesLogs.Name = "btnViewSalesLogs";
            this.btnViewSalesLogs.Size = new System.Drawing.Size(264, 55);
            this.btnViewSalesLogs.TabIndex = 4;
            this.btnViewSalesLogs.Text = "View Sales Logs";
            this.btnViewSalesLogs.UseVisualStyleBackColor = false;
            this.btnViewSalesLogs.Click += new System.EventHandler(this.btnViewSalesLogs_Click);
            // 
            // btnManageCategories
            // 
            this.btnManageCategories.BackColor = System.Drawing.Color.Teal;
            this.btnManageCategories.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnManageCategories.ForeColor = System.Drawing.Color.White;
            this.btnManageCategories.Location = new System.Drawing.Point(18, 295);
            this.btnManageCategories.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnManageCategories.Name = "btnManageCategories";
            this.btnManageCategories.Size = new System.Drawing.Size(264, 55);
            this.btnManageCategories.TabIndex = 3;
            this.btnManageCategories.Text = "Manage Categories";
            this.btnManageCategories.UseVisualStyleBackColor = false;
            this.btnManageCategories.Click += new System.EventHandler(this.btnManageCategories_Click);
            // 
            // btnManageItems
            // 
            this.btnManageItems.BackColor = System.Drawing.Color.Teal;
            this.btnManageItems.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnManageItems.ForeColor = System.Drawing.Color.White;
            this.btnManageItems.Location = new System.Drawing.Point(18, 231);
            this.btnManageItems.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnManageItems.Name = "btnManageItems";
            this.btnManageItems.Size = new System.Drawing.Size(264, 55);
            this.btnManageItems.TabIndex = 2;
            this.btnManageItems.Text = "Manage Products";
            this.btnManageItems.UseVisualStyleBackColor = false;
            this.btnManageItems.Click += new System.EventHandler(this.btnManageItems_Click);
            // 
            // btnLogout
            // 
            this.btnLogout.BackColor = System.Drawing.Color.DarkSlateGray;
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout.ForeColor = System.Drawing.Color.White;
            this.btnLogout.Location = new System.Drawing.Point(18, 166);
            this.btnLogout.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(264, 55);
            this.btnLogout.TabIndex = 1;
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = false;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // btnManageUsers
            // 
            this.btnManageUsers.BackColor = System.Drawing.Color.Teal;
            this.btnManageUsers.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnManageUsers.ForeColor = System.Drawing.Color.White;
            this.btnManageUsers.Location = new System.Drawing.Point(18, 102);
            this.btnManageUsers.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnManageUsers.Name = "btnManageUsers";
            this.btnManageUsers.Size = new System.Drawing.Size(264, 55);
            this.btnManageUsers.TabIndex = 0;
            this.btnManageUsers.Text = "Manage Users";
            this.btnManageUsers.UseVisualStyleBackColor = false;
            this.btnManageUsers.Click += new System.EventHandler(this.btnManageUsers_Click);
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.LightSteelBlue;
            this.panelHeader.Controls.Add(this.lblWelcome);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(300, 0);
            this.panelHeader.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(1326, 92);
            this.panelHeader.TabIndex = 1;
            // 
            // lblWelcome
            // 
            this.lblWelcome.AutoSize = true;
            this.lblWelcome.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWelcome.Location = new System.Drawing.Point(30, 28);
            this.lblWelcome.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(139, 32);
            this.lblWelcome.TabIndex = 0;
            this.lblWelcome.Text = "Welcome";
            // 
            // panelMain
            // 
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(300, 92);
            this.panelMain.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panelMain.Name = "panelMain";
            this.panelMain.Padding = new System.Windows.Forms.Padding(30, 31, 30, 31);
            this.panelMain.Size = new System.Drawing.Size(1326, 925);
            this.panelMain.TabIndex = 2;
            // 
            // panelStatusBar
            // 
            this.panelStatusBar.BackColor = System.Drawing.Color.Gainsboro;
            this.panelStatusBar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelStatusBar.Location = new System.Drawing.Point(300, 971);
            this.panelStatusBar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panelStatusBar.Name = "panelStatusBar";
            this.panelStatusBar.Size = new System.Drawing.Size(1326, 46);
            this.panelStatusBar.TabIndex = 3;
            // 
            // DashboardForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1626, 1017);
            this.Controls.Add(this.panelStatusBar);
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.panelHeader);
            this.Controls.Add(this.panelSidebar);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MinimumSize = new System.Drawing.Size(1639, 1047);
            this.Name = "DashboardForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Retail Management System";
            this.panelSidebar.ResumeLayout(false);
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelSidebar;
        private System.Windows.Forms.Button btnManageUsers;
        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Button btnManageItems;
        private System.Windows.Forms.Button btnManageCategories;
        private System.Windows.Forms.Button btnViewSalesLogs;
        private System.Windows.Forms.Button btnGoToSeller;
        private System.Windows.Forms.Button btnFinancialReports;
        private System.Windows.Forms.Button btnManageCustomers;
        private System.Windows.Forms.Button btnManageSuppliers;
        private System.Windows.Forms.Button btnManageInvoices;
        private System.Windows.Forms.Button btnInventoryManagement;
        private System.Windows.Forms.Button btnExpenseTracking;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Panel panelStatusBar;
    }
}