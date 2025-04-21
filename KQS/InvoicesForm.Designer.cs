namespace AccountingSystem
{
    partial class InvoicesForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView dgvInvoices;
        private System.Windows.Forms.TextBox txtInvoiceNumber, txtSubTotal, txtDiscountAmount, txtTotalAmount;
        private System.Windows.Forms.DateTimePicker dtpInvoiceDate, dtpDueDate;
        private System.Windows.Forms.Button btnAdd, btnUpdate, btnDelete;
        private System.Windows.Forms.Label lblInvoiceNumber, lblInvoiceDate, lblDueDate, lblSubTotal, lblDiscountAmount, lblTotalAmount;

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
            this.dgvInvoices = new System.Windows.Forms.DataGridView();
            this.txtInvoiceNumber = new System.Windows.Forms.TextBox();
            this.txtSubTotal = new System.Windows.Forms.TextBox();
            this.txtDiscountAmount = new System.Windows.Forms.TextBox();
            this.txtTotalAmount = new System.Windows.Forms.TextBox();
            this.dtpInvoiceDate = new System.Windows.Forms.DateTimePicker();
            this.dtpDueDate = new System.Windows.Forms.DateTimePicker();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.lblInvoiceNumber = new System.Windows.Forms.Label();
            this.lblInvoiceDate = new System.Windows.Forms.Label();
            this.lblDueDate = new System.Windows.Forms.Label();
            this.lblSubTotal = new System.Windows.Forms.Label();
            this.lblDiscountAmount = new System.Windows.Forms.Label();
            this.lblTotalAmount = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInvoices)).BeginInit();
            this.SuspendLayout();

            this.dgvInvoices.ColumnHeadersHeight = 34;
            this.dgvInvoices.Location = new System.Drawing.Point(20, 220);
            this.dgvInvoices.Name = "dgvInvoices";
            this.dgvInvoices.RowHeadersWidth = 62;
            this.dgvInvoices.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvInvoices.Size = new System.Drawing.Size(750, 200);
            this.dgvInvoices.TabIndex = 0;
            this.dgvInvoices.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvInvoices_CellClick);

            this.txtInvoiceNumber.Location = new System.Drawing.Point(140, 20);
            this.txtInvoiceNumber.Name = "txtInvoiceNumber";
            this.txtInvoiceNumber.Size = new System.Drawing.Size(200, 26);
            this.txtInvoiceNumber.TabIndex = 1;

            this.txtSubTotal.Location = new System.Drawing.Point(140, 110);
            this.txtSubTotal.Name = "txtSubTotal";
            this.txtSubTotal.Size = new System.Drawing.Size(100, 26);
            this.txtSubTotal.TabIndex = 4;

            this.txtDiscountAmount.Location = new System.Drawing.Point(140, 170);
            this.txtDiscountAmount.Name = "txtDiscountAmount";
            this.txtDiscountAmount.Size = new System.Drawing.Size(100, 26);
            this.txtDiscountAmount.TabIndex = 6;

            this.txtTotalAmount.Location = new System.Drawing.Point(140, 200);
            this.txtTotalAmount.Name = "txtTotalAmount";
            this.txtTotalAmount.Size = new System.Drawing.Size(100, 26);
            this.txtTotalAmount.TabIndex = 7;

            this.dtpInvoiceDate.Location = new System.Drawing.Point(140, 50);
            this.dtpInvoiceDate.Name = "dtpInvoiceDate";
            this.dtpInvoiceDate.Size = new System.Drawing.Size(200, 26);
            this.dtpInvoiceDate.TabIndex = 2;

            this.dtpDueDate.Location = new System.Drawing.Point(140, 80);
            this.dtpDueDate.Name = "dtpDueDate";
            this.dtpDueDate.Size = new System.Drawing.Size(200, 26);
            this.dtpDueDate.TabIndex = 3;

            this.btnAdd.Location = new System.Drawing.Point(380, 20);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 8;
            this.btnAdd.Text = "Add Invoice";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);

            this.btnUpdate.Location = new System.Drawing.Point(380, 60);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 23);
            this.btnUpdate.TabIndex = 9;
            this.btnUpdate.Text = "Update Invoice";
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);

            this.btnDelete.Location = new System.Drawing.Point(380, 100);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 10;
            this.btnDelete.Text = "Delete Invoice";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);

            this.lblInvoiceNumber.Location = new System.Drawing.Point(20, 20);
            this.lblInvoiceNumber.Name = "lblInvoiceNumber";
            this.lblInvoiceNumber.Size = new System.Drawing.Size(100, 23);
            this.lblInvoiceNumber.TabIndex = 11;
            this.lblInvoiceNumber.Text = "Invoice Number:";

            this.lblInvoiceDate.Location = new System.Drawing.Point(20, 50);
            this.lblInvoiceDate.Name = "lblInvoiceDate";
            this.lblInvoiceDate.Size = new System.Drawing.Size(100, 23);
            this.lblInvoiceDate.TabIndex = 12;
            this.lblInvoiceDate.Text = "Invoice Date:";

            this.lblDueDate.Location = new System.Drawing.Point(20, 80);
            this.lblDueDate.Name = "lblDueDate";
            this.lblDueDate.Size = new System.Drawing.Size(100, 23);
            this.lblDueDate.TabIndex = 13;
            this.lblDueDate.Text = "Due Date:";

            this.lblSubTotal.Location = new System.Drawing.Point(20, 110);
            this.lblSubTotal.Name = "lblSubTotal";
            this.lblSubTotal.Size = new System.Drawing.Size(100, 23);
            this.lblSubTotal.TabIndex = 14;
            this.lblSubTotal.Text = "Sub Total:";

            this.lblDiscountAmount.Location = new System.Drawing.Point(20, 170);
            this.lblDiscountAmount.Name = "lblDiscountAmount";
            this.lblDiscountAmount.Size = new System.Drawing.Size(100, 23);
            this.lblDiscountAmount.TabIndex = 16;
            this.lblDiscountAmount.Text = "Discount Amount:";
 
            this.lblTotalAmount.Location = new System.Drawing.Point(20, 200);
            this.lblTotalAmount.Name = "lblTotalAmount";
            this.lblTotalAmount.Size = new System.Drawing.Size(100, 23);
            this.lblTotalAmount.TabIndex = 17;
            this.lblTotalAmount.Text = "Total Amount:";

            this.ClientSize = new System.Drawing.Size(778, 444);
            this.Controls.Add(this.dgvInvoices);
            this.Controls.Add(this.txtInvoiceNumber);
            this.Controls.Add(this.dtpInvoiceDate);
            this.Controls.Add(this.dtpDueDate);
            this.Controls.Add(this.txtSubTotal);
            this.Controls.Add(this.txtDiscountAmount);
            this.Controls.Add(this.txtTotalAmount);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.lblInvoiceNumber);
            this.Controls.Add(this.lblInvoiceDate);
            this.Controls.Add(this.lblDueDate);
            this.Controls.Add(this.lblSubTotal);
            this.Controls.Add(this.lblDiscountAmount);
            this.Controls.Add(this.lblTotalAmount);
            this.Name = "InvoicesForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Invoice Management";
            ((System.ComponentModel.ISupportInitialize)(this.dgvInvoices)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
