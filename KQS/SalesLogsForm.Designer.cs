namespace KQS
{
    partial class SalesLogsForm
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
            this.dataGridViewSales = new System.Windows.Forms.DataGridView();
            this.dataGridViewSaleItems = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSales)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSaleItems)).BeginInit();
            this.SuspendLayout();

            this.dataGridViewSales.AllowUserToAddRows = false;
            this.dataGridViewSales.AllowUserToDeleteRows = false;
            this.dataGridViewSales.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewSales.Location = new System.Drawing.Point(20, 40);
            this.dataGridViewSales.Name = "dataGridViewSales";
            this.dataGridViewSales.ReadOnly = true;
            this.dataGridViewSales.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewSales.Size = new System.Drawing.Size(560, 150);
            this.dataGridViewSales.TabIndex = 0;
            this.dataGridViewSales.SelectionChanged += new System.EventHandler(this.dataGridViewSales_SelectionChanged);

            this.dataGridViewSaleItems.AllowUserToAddRows = false;
            this.dataGridViewSaleItems.AllowUserToDeleteRows = false;
            this.dataGridViewSaleItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewSaleItems.Location = new System.Drawing.Point(20, 230);
            this.dataGridViewSaleItems.Name = "dataGridViewSaleItems";
            this.dataGridViewSaleItems.ReadOnly = true;
            this.dataGridViewSaleItems.Size = new System.Drawing.Size(560, 150);
            this.dataGridViewSaleItems.TabIndex = 1;

            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(20, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Sales";

            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(20, 210);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Sale Items";

            this.btnClose.Location = new System.Drawing.Point(480, 400);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(100, 30);
            this.btnClose.TabIndex = 4;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);

            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 450);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridViewSaleItems);
            this.Controls.Add(this.dataGridViewSales);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "SalesLogsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "KQS - Sales Logs";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSales)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSaleItems)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewSales;
        private System.Windows.Forms.DataGridView dataGridViewSaleItems;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnClose;
    }
}