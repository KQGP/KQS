namespace AccountingSystem
{
    partial class SuppliersForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView dgvSuppliers;
        private System.Windows.Forms.TextBox txtName, txtContactPerson, txtEmail, txtPhone, txtAddress;
        private System.Windows.Forms.Button btnAdd, btnUpdate, btnDelete;
        private System.Windows.Forms.Label lblName, lblContactPerson, lblEmail, lblPhone, lblAddress;

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
            this.dgvSuppliers = new System.Windows.Forms.DataGridView();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtContactPerson = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.lblName = new System.Windows.Forms.Label();
            this.lblContactPerson = new System.Windows.Forms.Label();
            this.lblEmail = new System.Windows.Forms.Label();
            this.lblPhone = new System.Windows.Forms.Label();
            this.lblAddress = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSuppliers)).BeginInit();
            this.SuspendLayout();

            this.dgvSuppliers.ColumnHeadersHeight = 34;
            this.dgvSuppliers.Location = new System.Drawing.Point(20, 220);
            this.dgvSuppliers.Name = "dgvSuppliers";
            this.dgvSuppliers.RowHeadersWidth = 62;
            this.dgvSuppliers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSuppliers.Size = new System.Drawing.Size(750, 200);
            this.dgvSuppliers.TabIndex = 0;
            this.dgvSuppliers.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSuppliers_CellClick);

            this.txtName.Location = new System.Drawing.Point(140, 20);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(200, 26);
            this.txtName.TabIndex = 1;

            this.txtContactPerson.Location = new System.Drawing.Point(140, 50);
            this.txtContactPerson.Name = "txtContactPerson";
            this.txtContactPerson.Size = new System.Drawing.Size(100, 26);
            this.txtContactPerson.TabIndex = 2;

            this.txtEmail.Location = new System.Drawing.Point(140, 80);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(100, 26);
            this.txtEmail.TabIndex = 3;

            this.txtPhone.Location = new System.Drawing.Point(140, 110);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(100, 26);
            this.txtPhone.TabIndex = 4;

            this.txtAddress.Location = new System.Drawing.Point(140, 140);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(100, 26);
            this.txtAddress.TabIndex = 5;

            this.btnAdd.Location = new System.Drawing.Point(380, 20);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 7;
            this.btnAdd.Text = "Add";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);

            this.btnUpdate.Location = new System.Drawing.Point(380, 60);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 23);
            this.btnUpdate.TabIndex = 8;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);

            this.btnDelete.Location = new System.Drawing.Point(380, 100);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 9;
            this.btnDelete.Text = "Delete";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);

            this.lblName.Location = new System.Drawing.Point(20, 20);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(100, 23);
            this.lblName.TabIndex = 10;
            this.lblName.Text = "Name:";

            this.lblContactPerson.Location = new System.Drawing.Point(20, 50);
            this.lblContactPerson.Name = "lblContactPerson";
            this.lblContactPerson.Size = new System.Drawing.Size(100, 23);
            this.lblContactPerson.TabIndex = 11;
            this.lblContactPerson.Text = "Contact Person:";

            this.lblEmail.Location = new System.Drawing.Point(20, 80);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(100, 23);
            this.lblEmail.TabIndex = 12;
            this.lblEmail.Text = "Email:";

            this.lblPhone.Location = new System.Drawing.Point(20, 110);
            this.lblPhone.Name = "lblPhone";
            this.lblPhone.Size = new System.Drawing.Size(100, 23);
            this.lblPhone.TabIndex = 13;
            this.lblPhone.Text = "Phone:";

            this.lblAddress.Location = new System.Drawing.Point(20, 140);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(100, 23);
            this.lblAddress.TabIndex = 14;
            this.lblAddress.Text = "Address:";

            this.ClientSize = new System.Drawing.Size(778, 444);
            this.Controls.Add(this.dgvSuppliers);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.txtContactPerson);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.txtPhone);
            this.Controls.Add(this.txtAddress);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.lblContactPerson);
            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.lblPhone);
            this.Controls.Add(this.lblAddress);
            this.Name = "SuppliersForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Supplier Management";
            ((System.ComponentModel.ISupportInitialize)(this.dgvSuppliers)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
