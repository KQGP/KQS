namespace KQS
{
    partial class AddEditItemForm
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
            this.lblName = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.lblBuyPrice = new System.Windows.Forms.Label();
            this.txtBuyPrice = new System.Windows.Forms.TextBox();
            this.lblSellPrice = new System.Windows.Forms.Label();
            this.txtSellPrice = new System.Windows.Forms.TextBox();
            this.lblQuantity = new System.Windows.Forms.Label();
            this.txtQuantity = new System.Windows.Forms.TextBox();
            this.lblCategory = new System.Windows.Forms.Label();
            this.cmbCategory = new System.Windows.Forms.ComboBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblTotalCost = new System.Windows.Forms.Label();
            this.lblTotalCostValue = new System.Windows.Forms.Label();
            this.SuspendLayout();

            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(20, 20);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(58, 13);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "Item Name";

            this.txtName.Location = new System.Drawing.Point(20, 40);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(200, 20);
            this.txtName.TabIndex = 1;

            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(20, 70);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(60, 13);
            this.lblDescription.TabIndex = 2;
            this.lblDescription.Text = "Description";

            this.txtDescription.Location = new System.Drawing.Point(20, 90);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(200, 60);
            this.txtDescription.TabIndex = 3;

            this.lblBuyPrice.AutoSize = true;
            this.lblBuyPrice.Location = new System.Drawing.Point(20, 160);
            this.lblBuyPrice.Name = "lblBuyPrice";
            this.lblBuyPrice.Size = new System.Drawing.Size(51, 13);
            this.lblBuyPrice.TabIndex = 4;
            this.lblBuyPrice.Text = "Buy Price";

            this.txtBuyPrice.Location = new System.Drawing.Point(20, 180);
            this.txtBuyPrice.Name = "txtBuyPrice";
            this.txtBuyPrice.Size = new System.Drawing.Size(90, 20);
            this.txtBuyPrice.TabIndex = 5;
            this.txtBuyPrice.Text = "0.00";
            this.txtBuyPrice.TextChanged += new System.EventHandler(this.CalculateTotalCost);

            this.lblSellPrice.AutoSize = true;
            this.lblSellPrice.Location = new System.Drawing.Point(120, 160);
            this.lblSellPrice.Name = "lblSellPrice";
            this.lblSellPrice.Size = new System.Drawing.Size(51, 13);
            this.lblSellPrice.TabIndex = 6;
            this.lblSellPrice.Text = "Sell Price";

            this.txtSellPrice.Location = new System.Drawing.Point(120, 180);
            this.txtSellPrice.Name = "txtSellPrice";
            this.txtSellPrice.Size = new System.Drawing.Size(100, 20);
            this.txtSellPrice.TabIndex = 7;
            this.txtSellPrice.Text = "0.00";

            this.lblQuantity.AutoSize = true;
            this.lblQuantity.Location = new System.Drawing.Point(20, 210);
            this.lblQuantity.Name = "lblQuantity";
            this.lblQuantity.Size = new System.Drawing.Size(46, 13);
            this.lblQuantity.TabIndex = 8;
            this.lblQuantity.Text = "Quantity";

            this.txtQuantity.Location = new System.Drawing.Point(20, 230);
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.Size = new System.Drawing.Size(90, 20);
            this.txtQuantity.TabIndex = 9;
            this.txtQuantity.Text = "0";
            this.txtQuantity.TextChanged += new System.EventHandler(this.CalculateTotalCost);

            this.lblCategory.AutoSize = true;
            this.lblCategory.Location = new System.Drawing.Point(120, 210);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Size = new System.Drawing.Size(49, 13);
            this.lblCategory.TabIndex = 10;
            this.lblCategory.Text = "Category";

            this.cmbCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCategory.FormattingEnabled = true;
            this.cmbCategory.Location = new System.Drawing.Point(120, 230);
            this.cmbCategory.Name = "cmbCategory";
            this.cmbCategory.Size = new System.Drawing.Size(100, 21);
            this.cmbCategory.TabIndex = 11;

            this.btnSave.Location = new System.Drawing.Point(20, 290);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(90, 30);
            this.btnSave.TabIndex = 12;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);

            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(130, 290);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(90, 30);
            this.btnCancel.TabIndex = 13;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);

            this.lblTotalCost.AutoSize = true;
            this.lblTotalCost.Location = new System.Drawing.Point(20, 260);
            this.lblTotalCost.Name = "lblTotalCost";
            this.lblTotalCost.Size = new System.Drawing.Size(55, 13);
            this.lblTotalCost.TabIndex = 14;
            this.lblTotalCost.Text = "Total Cost";

            this.lblTotalCostValue.AutoSize = true;
            this.lblTotalCostValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalCostValue.Location = new System.Drawing.Point(80, 260);
            this.lblTotalCostValue.Name = "lblTotalCostValue";
            this.lblTotalCostValue.Size = new System.Drawing.Size(39, 13);
            this.lblTotalCostValue.TabIndex = 15;
            this.lblTotalCostValue.Text = "$0.00";

            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(240, 340);
            this.Controls.Add(this.lblTotalCostValue);
            this.Controls.Add(this.lblTotalCost);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.cmbCategory);
            this.Controls.Add(this.lblCategory);
            this.Controls.Add(this.txtQuantity);
            this.Controls.Add(this.lblQuantity);
            this.Controls.Add(this.txtSellPrice);
            this.Controls.Add(this.lblSellPrice);
            this.Controls.Add(this.txtBuyPrice);
            this.Controls.Add(this.lblBuyPrice);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lblName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddEditItemForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add/Edit Item";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label lblBuyPrice;
        private System.Windows.Forms.TextBox txtBuyPrice;
        private System.Windows.Forms.Label lblSellPrice;
        private System.Windows.Forms.TextBox txtSellPrice;
        private System.Windows.Forms.Label lblQuantity;
        private System.Windows.Forms.TextBox txtQuantity;
        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.ComboBox cmbCategory;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblTotalCost;
        private System.Windows.Forms.Label lblTotalCostValue;
    }
}