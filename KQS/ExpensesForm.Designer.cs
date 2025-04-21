namespace AccountingSystem
{
    partial class ExpensesForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView dgvExpenses;
        private System.Windows.Forms.TextBox txtAmount, txtDescription, txtReferenceNumber;
        private System.Windows.Forms.ComboBox cmbPaymentMethod;
        private System.Windows.Forms.DateTimePicker dtpExpenseDate;
        private System.Windows.Forms.Button btnAdd, btnUpdate, btnDelete;
        private System.Windows.Forms.Label lblAmount, lblDescription, lblPaymentMethod, lblExpenseDate, lblReferenceNumber;

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
            this.dgvExpenses = new System.Windows.Forms.DataGridView();
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.txtReferenceNumber = new System.Windows.Forms.TextBox();
            this.cmbPaymentMethod = new System.Windows.Forms.ComboBox();
            this.dtpExpenseDate = new System.Windows.Forms.DateTimePicker();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.lblAmount = new System.Windows.Forms.Label();
            this.lblDescription = new System.Windows.Forms.Label();
            this.lblPaymentMethod = new System.Windows.Forms.Label();
            this.lblExpenseDate = new System.Windows.Forms.Label();
            this.lblReferenceNumber = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvExpenses)).BeginInit();
            this.SuspendLayout();

            this.dgvExpenses.ColumnHeadersHeight = 34;
            this.dgvExpenses.Location = new System.Drawing.Point(20, 220);
            this.dgvExpenses.Name = "dgvExpenses";
            this.dgvExpenses.RowHeadersWidth = 62;
            this.dgvExpenses.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvExpenses.Size = new System.Drawing.Size(750, 200);
            this.dgvExpenses.TabIndex = 0;
            this.dgvExpenses.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvExpenses_CellClick);

            this.txtAmount.Location = new System.Drawing.Point(140, 20);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(200, 26);
            this.txtAmount.TabIndex = 1;

            this.txtDescription.Location = new System.Drawing.Point(140, 50);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(200, 54);
            this.txtDescription.TabIndex = 2;

            this.txtReferenceNumber.Location = new System.Drawing.Point(140, 170);
            this.txtReferenceNumber.Name = "txtReferenceNumber";
            this.txtReferenceNumber.Size = new System.Drawing.Size(200, 26);

            this.cmbPaymentMethod.Location = new System.Drawing.Point(140, 110);
            this.cmbPaymentMethod.Name = "cmbPaymentMethod";
            this.cmbPaymentMethod.Size = new System.Drawing.Size(200, 28);
            this.cmbPaymentMethod.TabIndex = 4;

            this.dtpExpenseDate.Location = new System.Drawing.Point(140, 140);
            this.dtpExpenseDate.Name = "dtpExpenseDate";
            this.dtpExpenseDate.Size = new System.Drawing.Size(200, 26);
            this.dtpExpenseDate.TabIndex = 5;

            this.btnAdd.Location = new System.Drawing.Point(380, 20);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 7;
            this.btnAdd.Text = "Add Expense";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);

            this.btnUpdate.Location = new System.Drawing.Point(380, 60);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 23);
            this.btnUpdate.TabIndex = 8;
            this.btnUpdate.Text = "Update Expense";
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);

            this.btnDelete.Location = new System.Drawing.Point(380, 100);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 9;
            this.btnDelete.Text = "Delete Expense";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);

            this.lblAmount.Location = new System.Drawing.Point(20, 20);
            this.lblAmount.Name = "lblAmount";
            this.lblAmount.Size = new System.Drawing.Size(100, 23);
            this.lblAmount.TabIndex = 10;
            this.lblAmount.Text = "Amount:";

            this.lblDescription.Location = new System.Drawing.Point(20, 50);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(100, 23);
            this.lblDescription.TabIndex = 11;
            this.lblDescription.Text = "Description:";

            this.lblPaymentMethod.Location = new System.Drawing.Point(20, 110);
            this.lblPaymentMethod.Name = "lblPaymentMethod";
            this.lblPaymentMethod.Size = new System.Drawing.Size(100, 23);
            this.lblPaymentMethod.TabIndex = 13;
            this.lblPaymentMethod.Text = "Payment Method:";

            this.lblExpenseDate.Location = new System.Drawing.Point(20, 140);
            this.lblExpenseDate.Name = "lblExpenseDate";
            this.lblExpenseDate.Size = new System.Drawing.Size(100, 23);
            this.lblExpenseDate.TabIndex = 14;
            this.lblExpenseDate.Text = "Expense Date:";

            this.lblReferenceNumber.Location = new System.Drawing.Point(20, 170);
            this.lblReferenceNumber.Name = "lblReferenceNumber";
            this.lblReferenceNumber.Size = new System.Drawing.Size(100, 23);
            this.lblReferenceNumber.TabIndex = 15;
            this.lblReferenceNumber.Text = "Reference Number:";

            this.ClientSize = new System.Drawing.Size(778, 444);
            this.Controls.Add(this.dgvExpenses);
            this.Controls.Add(this.txtAmount);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.cmbPaymentMethod);
            this.Controls.Add(this.dtpExpenseDate);
            this.Controls.Add(this.txtReferenceNumber);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.lblAmount);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.lblPaymentMethod);
            this.Controls.Add(this.lblExpenseDate);
            this.Controls.Add(this.lblReferenceNumber);
            this.Name = "ExpensesForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Expenses Management";
            ((System.ComponentModel.ISupportInitialize)(this.dgvExpenses)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}