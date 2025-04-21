namespace KQS
{
    partial class SellsForm
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
            this.lblWelcome = new System.Windows.Forms.Label();
            this.cmbCategories = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.listViewItems = new System.Windows.Forms.ListView();
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label3 = new System.Windows.Forms.Label();
            this.txtQuantity = new System.Windows.Forms.TextBox();
            this.btnAddToCart = new System.Windows.Forms.Button();
            this.listViewCart = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnRemoveSelected = new System.Windows.Forms.Button();
            this.btnClearCart = new System.Windows.Forms.Button();
            this.btnPrintBill = new System.Windows.Forms.Button();
            this.lblTotal = new System.Windows.Forms.Label();
            this.btnLogout = new System.Windows.Forms.Button();
            this.btnClearFilter = new System.Windows.Forms.Button();
            this.SuspendLayout();

            this.lblWelcome.AutoSize = true;
            this.lblWelcome.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWelcome.Location = new System.Drawing.Point(30, 31);
            this.lblWelcome.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(191, 29);
            this.lblWelcome.TabIndex = 0;
            this.lblWelcome.Text = "Welcome, Seller";

            this.cmbCategories.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCategories.FormattingEnabled = true;
            this.cmbCategories.Location = new System.Drawing.Point(120, 92);
            this.cmbCategories.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmbCategories.Name = "cmbCategories";
            this.cmbCategories.Size = new System.Drawing.Size(269, 28);
            this.cmbCategories.TabIndex = 1;
            this.cmbCategories.SelectedIndexChanged += new System.EventHandler(this.cmbCategories_SelectedIndexChanged);

            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 97);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Category";

            this.listViewItems.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader7});
            this.listViewItems.FullRowSelect = true;
            this.listViewItems.GridLines = true;
            this.listViewItems.HideSelection = false;
            this.listViewItems.Location = new System.Drawing.Point(30, 154);
            this.listViewItems.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.listViewItems.Name = "listViewItems";
            this.listViewItems.Size = new System.Drawing.Size(448, 229);
            this.listViewItems.TabIndex = 3;
            this.listViewItems.UseCompatibleStateImageBehavior = false;
            this.listViewItems.View = System.Windows.Forms.View.Details;
            this.listViewItems.SelectedIndexChanged += new System.EventHandler(this.listViewItems_SelectedIndexChanged);

            this.columnHeader5.Text = "Item";
            this.columnHeader5.Width = 150;

            this.columnHeader6.Text = "Price";
            this.columnHeader6.Width = 70;

            this.columnHeader7.Text = "Available";
            this.columnHeader7.Width = 70;

            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(30, 400);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "Quantity";

            this.txtQuantity.Location = new System.Drawing.Point(120, 400);
            this.txtQuantity.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.Size = new System.Drawing.Size(148, 26);
            this.txtQuantity.TabIndex = 6;
            this.txtQuantity.Text = "1";

            this.btnAddToCart.Location = new System.Drawing.Point(300, 400);
            this.btnAddToCart.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnAddToCart.Name = "btnAddToCart";
            this.btnAddToCart.Size = new System.Drawing.Size(180, 35);
            this.btnAddToCart.TabIndex = 7;
            this.btnAddToCart.Text = "Add to Cart";
            this.btnAddToCart.UseVisualStyleBackColor = true;
            this.btnAddToCart.Click += new System.EventHandler(this.btnAddToCart_Click);

            this.listViewCart.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.listViewCart.FullRowSelect = true;
            this.listViewCart.GridLines = true;
            this.listViewCart.HideSelection = false;
            this.listViewCart.Location = new System.Drawing.Point(525, 92);
            this.listViewCart.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.listViewCart.Name = "listViewCart";
            this.listViewCart.Size = new System.Drawing.Size(598, 306);
            this.listViewCart.TabIndex = 8;
            this.listViewCart.UseCompatibleStateImageBehavior = false;
            this.listViewCart.View = System.Windows.Forms.View.Details;

            this.columnHeader1.Text = "Item";
            this.columnHeader1.Width = 200;

            this.columnHeader2.Text = "Price";
            this.columnHeader2.Width = 80;

            this.columnHeader3.Text = "Qty";

            this.columnHeader4.Text = "Total";
            this.columnHeader4.Width = 80;

            this.btnRemoveSelected.Location = new System.Drawing.Point(525, 415);
            this.btnRemoveSelected.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnRemoveSelected.Name = "btnRemoveSelected";
            this.btnRemoveSelected.Size = new System.Drawing.Size(180, 46);
            this.btnRemoveSelected.TabIndex = 9;
            this.btnRemoveSelected.Text = "Remove Selected";
            this.btnRemoveSelected.UseVisualStyleBackColor = true;
            this.btnRemoveSelected.Click += new System.EventHandler(this.btnRemoveSelected_Click);

            this.btnClearCart.Location = new System.Drawing.Point(720, 415);
            this.btnClearCart.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnClearCart.Name = "btnClearCart";
            this.btnClearCart.Size = new System.Drawing.Size(150, 46);
            this.btnClearCart.TabIndex = 10;
            this.btnClearCart.Text = "Clear Cart";
            this.btnClearCart.UseVisualStyleBackColor = true;
            this.btnClearCart.Click += new System.EventHandler(this.btnClearCart_Click);

            this.btnPrintBill.Location = new System.Drawing.Point(945, 415);
            this.btnPrintBill.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnPrintBill.Name = "btnPrintBill";
            this.btnPrintBill.Size = new System.Drawing.Size(180, 46);
            this.btnPrintBill.TabIndex = 11;
            this.btnPrintBill.Text = "Print Bill";
            this.btnPrintBill.UseVisualStyleBackColor = true;
            this.btnPrintBill.Click += new System.EventHandler(this.btnPrintBill_Click);

            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.Location = new System.Drawing.Point(525, 477);
            this.lblTotal.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(87, 29);
            this.lblTotal.TabIndex = 12;
            this.lblTotal.Text = "Total: ";

            this.btnLogout.Location = new System.Drawing.Point(945, 31);
            this.btnLogout.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(180, 46);
            this.btnLogout.TabIndex = 13;
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);

            this.btnClearFilter.Location = new System.Drawing.Point(397, 92);
            this.btnClearFilter.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnClearFilter.Name = "btnClearFilter";
            this.btnClearFilter.Size = new System.Drawing.Size(120, 28);
            this.btnClearFilter.TabIndex = 14;
            this.btnClearFilter.Text = "Clear Filter";
            this.btnClearFilter.UseVisualStyleBackColor = true;
            this.btnClearFilter.Click += new System.EventHandler(this.btnClearFilter_Click);

            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1155, 554);
            this.Controls.Add(this.btnClearFilter);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.btnPrintBill);
            this.Controls.Add(this.btnClearCart);
            this.Controls.Add(this.btnRemoveSelected);
            this.Controls.Add(this.listViewCart);
            this.Controls.Add(this.btnAddToCart);
            this.Controls.Add(this.txtQuantity);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.listViewItems);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbCategories);
            this.Controls.Add(this.lblWelcome);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.Name = "SellsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "KQS - Seller View";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.ComboBox cmbCategories;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView listViewItems;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtQuantity;
        private System.Windows.Forms.Button btnAddToCart;
        private System.Windows.Forms.ListView listViewCart;
        private System.Windows.Forms.Button btnRemoveSelected;
        private System.Windows.Forms.Button btnClearCart;
        private System.Windows.Forms.Button btnPrintBill;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.Button btnClearFilter;
    }
}