namespace AccountingSystem
{
    partial class FinancialReportsForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DateTimePicker dtpStartDate, dtpEndDate;
        private System.Windows.Forms.Button btnGenerateReport;

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
            this.dtpStartDate = new System.Windows.Forms.DateTimePicker();
            this.dtpEndDate = new System.Windows.Forms.DateTimePicker();
            this.btnGenerateReport = new System.Windows.Forms.Button();
            this.SuspendLayout();

            this.dtpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpStartDate.Location = new System.Drawing.Point(21, 75);
            this.dtpStartDate.Name = "dtpStartDate";
            this.dtpStartDate.Size = new System.Drawing.Size(200, 26);
            this.dtpStartDate.TabIndex = 3;

            this.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpEndDate.Location = new System.Drawing.Point(241, 75);
            this.dtpEndDate.Name = "dtpEndDate";
            this.dtpEndDate.Size = new System.Drawing.Size(200, 26);
            this.dtpEndDate.TabIndex = 4;

            this.btnGenerateReport.Location = new System.Drawing.Point(21, 115);
            this.btnGenerateReport.Name = "btnGenerateReport";
            this.btnGenerateReport.Size = new System.Drawing.Size(150, 30);
            this.btnGenerateReport.TabIndex = 5;
            this.btnGenerateReport.Text = "Generate Report";
            this.btnGenerateReport.Click += new System.EventHandler(this.btnGenerateReport_Click);

            this.ClientSize = new System.Drawing.Size(477, 211);
            this.Controls.Add(this.dtpStartDate);
            this.Controls.Add(this.dtpEndDate);
            this.Controls.Add(this.btnGenerateReport);
            this.Name = "FinancialReportsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Financial Reports";
            this.ResumeLayout(false);

        }
    }
}