namespace AccountingSystem
{
    partial class InventoryForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView dgvProducts;
        private System.Windows.Forms.TextBox txtProductName, txtDescription, txtUnitPrice, txtCostPrice;
        private System.Windows.Forms.ComboBox cmbCategory;
        private System.Windows.Forms.NumericUpDown numQuantityInStock, numReorderLevel;
        private System.Windows.Forms.Button btnAdd, btnUpdate, btnDelete;
        private System.Windows.Forms.Label lblProductName, lblDescription, lblCategory, lblUnitPrice, lblCostPrice, lblQuantityInStock, lblReorderLevel;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.dgvProducts = new System.Windows.Forms.DataGridView();
            this.txtProductName = new System.Windows.Forms.TextBox();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.txtUnitPrice = new System.Windows.Forms.TextBox();
            this.txtCostPrice = new System.Windows.Forms.TextBox();
            this.cmbCategory = new System.Windows.Forms.ComboBox();
            this.numQuantityInStock = new System.Windows.Forms.NumericUpDown();
            this.numReorderLevel = new System.Windows.Forms.NumericUpDown();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.lblProductName = new System.Windows.Forms.Label();
            this.lblDescription = new System.Windows.Forms.Label();
            this.lblCategory = new System.Windows.Forms.Label();
            this.lblUnitPrice = new System.Windows.Forms.Label();
            this.lblCostPrice = new System.Windows.Forms.Label();
            this.lblQuantityInStock = new System.Windows.Forms.Label();
            this.lblReorderLevel = new System.Windows.Forms.Label();

            ((System.ComponentModel.ISupportInitialize)(this.dgvProducts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numQuantityInStock)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numReorderLevel)).BeginInit();
            this.SuspendLayout();

            this.dgvProducts.Location = new System.Drawing.Point(20, 220);
            this.dgvProducts.Size = new System.Drawing.Size(750, 200);
            this.dgvProducts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;

            this.dgvProducts.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProducts_CellClick);
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);

            this.lblProductName.Text = "Product Name:";
            this.lblProductName.Location = new System.Drawing.Point(20, 20);
            this.lblDescription.Text = "Description:";
            this.lblDescription.Location = new System.Drawing.Point(20, 50);
            this.lblCategory.Text = "Category:";
            this.lblCategory.Location = new System.Drawing.Point(20, 80);
            this.lblUnitPrice.Text = "Unit Price:";
            this.lblUnitPrice.Location = new System.Drawing.Point(20, 110);
            this.lblCostPrice.Text = "Cost Price:";
            this.lblCostPrice.Location = new System.Drawing.Point(20, 140);
            this.lblQuantityInStock.Text = "Quantity in Stock:";
            this.lblQuantityInStock.Location = new System.Drawing.Point(20, 170);
            this.lblReorderLevel.Text = "Reorder Level:";
            this.lblReorderLevel.Location = new System.Drawing.Point(20, 200);

            this.txtProductName.Location = new System.Drawing.Point(140, 20);
            this.txtProductName.Size = new System.Drawing.Size(200, 20);
            this.txtDescription.Location = new System.Drawing.Point(140, 50);
            this.txtDescription.Size = new System.Drawing.Size(200, 20);
            this.txtUnitPrice.Location = new System.Drawing.Point(140, 110);
            this.txtUnitPrice.Size = new System.Drawing.Size(200, 20);
            this.txtCostPrice.Location = new System.Drawing.Point(140, 140);
            this.txtCostPrice.Size = new System.Drawing.Size(200, 20);
            this.cmbCategory.Location = new System.Drawing.Point(140, 80);
            this.cmbCategory.Size = new System.Drawing.Size(200, 20);
            this.numQuantityInStock.Location = new System.Drawing.Point(140, 170);
            this.numQuantityInStock.Size = new System.Drawing.Size(120, 20);
            this.numReorderLevel.Location = new System.Drawing.Point(140, 200);
            this.numReorderLevel.Size = new System.Drawing.Size(120, 20);

            this.btnAdd.Text = "Add Product";
            this.btnAdd.Location = new System.Drawing.Point(380, 20);
            this.btnUpdate.Text = "Update Product";
            this.btnUpdate.Location = new System.Drawing.Point(380, 60);
            this.btnDelete.Text = "Delete Product";
            this.btnDelete.Location = new System.Drawing.Point(380, 100);

            this.Controls.Add(this.dgvProducts);
            this.Controls.Add(this.txtProductName);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.txtUnitPrice);
            this.Controls.Add(this.txtCostPrice);
            this.Controls.Add(this.cmbCategory);
            this.Controls.Add(this.numQuantityInStock);
            this.Controls.Add(this.numReorderLevel);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.lblProductName);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.lblCategory);
            this.Controls.Add(this.lblUnitPrice);
            this.Controls.Add(this.lblCostPrice);
            this.Controls.Add(this.lblQuantityInStock);
            this.Controls.Add(this.lblReorderLevel);

            this.Text = "Inventory Management";
            this.Size = new System.Drawing.Size(800, 500);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;

            ((System.ComponentModel.ISupportInitialize)(this.dgvProducts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numQuantityInStock)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numReorderLevel)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}