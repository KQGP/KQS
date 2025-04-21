using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;

namespace AccountingSystem
{
    public partial class FinancialReportsForm : Form
    {
        private string connectionString = "Server=.;Database=KQS;Integrated Security=True;";
        private DataTable incomeData;
        private DataTable expenseData;
        private decimal totalIncome;
        private decimal totalExpenses;
        private decimal profitLoss;

        public FinancialReportsForm()
        {
            InitializeComponent();
            dtpStartDate.Value = DateTime.Today.AddMonths(-1);
            dtpEndDate.Value = DateTime.Today;
        }

        private void btnGenerateReport_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                Application.DoEvents();

                if (dtpStartDate.Value > dtpEndDate.Value)
                {
                    MessageBox.Show("End date must be after start date.", "Invalid Date Range",
                                  MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                incomeData = GetIncomeData(dtpStartDate.Value, dtpEndDate.Value);
                expenseData = GetExpenseData(dtpStartDate.Value, dtpEndDate.Value);
                totalIncome = CalculateTotal(incomeData, "TotalAmount");
                totalExpenses = CalculateTotal(expenseData, "TotalAmount");
                profitLoss = totalIncome - totalExpenses;

                PrintPreviewDialog previewDialog = new PrintPreviewDialog();
                PrintDocument printDoc = new PrintDocument();
                printDoc.PrintPage += PrintReport;
                previewDialog.Document = printDoc;
                previewDialog.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error generating report: {ex.Message}", "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private DataTable GetIncomeData(DateTime startDate, DateTime endDate)
        {
            DataTable data = new DataTable();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = @"SELECT i.InvoiceName, i.InvoiceDate, i.TotalAmount, 
                               u.Username AS Seller, i.DueDate
                               FROM Invoices i
                               JOIN Users u ON i.SellerId = u.UserId
                               WHERE i.InvoiceDate BETWEEN @StartDate AND @EndDate
                               ORDER BY i.InvoiceDate";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@StartDate", startDate.Date);
                    cmd.Parameters.AddWithValue("@EndDate", endDate.Date.AddDays(1).AddSeconds(-1));

                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        adapter.Fill(data);
                    }
                }
            }

            return data;
        }

        private DataTable GetExpenseData(DateTime startDate, DateTime endDate)
        {
            DataTable data = new DataTable();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"SELECT 
                           e.Description, 
                           e.ExpenseDate, 
                           e.TotalAmount, 
                           e.PaymentMethod, 
                           e.ReferenceNumber, 
                           u.Username AS CreatedBy
                           FROM Expenses e
                           LEFT JOIN Users u ON e.CreatedBy = u.UserId
                           WHERE e.ExpenseDate BETWEEN @StartDate AND @EndDate
                           ORDER BY e.ExpenseDate";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@StartDate", startDate.Date);
                        cmd.Parameters.AddWithValue("@EndDate", endDate.Date.AddDays(1).AddSeconds(-1));

                        using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                        {
                            adapter.Fill(data);

                            Console.WriteLine($"Retrieved {data.Rows.Count} expense records");
                            foreach (DataRow row in data.Rows)
                            {
                                Console.WriteLine($"{row["Description"]} - {row["TotalAmount"]}");
                            }
                        }
                    }
                }
            }
            catch (SqlException sqlEx)
            {
                MessageBox.Show($"Database error while loading expenses: {sqlEx.Message}",
                              "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading expense data: {ex.Message}",
                              "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return data;
        }

        private decimal CalculateTotal(DataTable data, string columnName)
        {
            decimal total = 0;
            foreach (DataRow row in data.Rows)
            {
                total += Convert.ToDecimal(row[columnName]);
            }
            return total;
        }

        private void PrintReport(object sender, PrintPageEventArgs e)
        {
            Graphics graphics = e.Graphics;
            Font titleFont = new Font("Arial", 20, FontStyle.Bold);
            Font headerFont = new Font("Arial", 12, FontStyle.Bold);
            Font itemFont = new Font("Arial", 10);
            Font summaryFont = new Font("Arial", 12, FontStyle.Bold);
            Font smallFont = new Font("Arial", 8);

            float yPos = 50;
            float leftMargin = e.MarginBounds.Left;
            float rightMargin = e.MarginBounds.Right;
            float center = e.MarginBounds.Width / 2;

            graphics.DrawString("Financial Report", titleFont, Brushes.Black, center - 100, yPos);
            yPos += titleFont.GetHeight() + 20;

            graphics.DrawString($"Date Range: {dtpStartDate.Value:d} to {dtpEndDate.Value:d}",
                              headerFont, Brushes.Black, leftMargin, yPos);
            yPos += headerFont.GetHeight() + 30;

            graphics.DrawString("Income Transactions", headerFont, Brushes.Black, leftMargin, yPos);
            yPos += headerFont.GetHeight() + 10;

            graphics.DrawString("Invoice #", headerFont, Brushes.Black, leftMargin, yPos);
            graphics.DrawString("Date", headerFont, Brushes.Black, leftMargin + 150, yPos);
            graphics.DrawString("Amount", headerFont, Brushes.Black, rightMargin - 100, yPos);
            yPos += headerFont.GetHeight() + 5;

            foreach (DataRow row in incomeData.Rows)
            {
                graphics.DrawString(row["InvoiceName"].ToString(), itemFont, Brushes.Black, leftMargin, yPos);
                graphics.DrawString(Convert.ToDateTime(row["InvoiceDate"]).ToString("d"), itemFont, Brushes.Black, leftMargin + 150, yPos);
                graphics.DrawString(Convert.ToDecimal(row["TotalAmount"]).ToString("C"), itemFont, Brushes.Black, rightMargin - 100, yPos);
                yPos += itemFont.GetHeight() + 5;
            }

            yPos += 20;
            graphics.DrawString($"Total Income: {totalIncome:C}", summaryFont, Brushes.Black, rightMargin - 200, yPos);
            yPos += summaryFont.GetHeight() + 30;

            graphics.DrawString("Expense Transactions", headerFont, Brushes.Black, leftMargin, yPos);
            yPos += headerFont.GetHeight() + 10;

            graphics.DrawString("Description", headerFont, Brushes.Black, leftMargin, yPos);
            graphics.DrawString("Date", headerFont, Brushes.Black, leftMargin + 200, yPos);
            graphics.DrawString("Amount", headerFont, Brushes.Black, rightMargin - 100, yPos);
            yPos += headerFont.GetHeight() + 5;

            foreach (DataRow row in expenseData.Rows)
            {
                graphics.DrawString(row["Description"].ToString(), itemFont, Brushes.Black, leftMargin, yPos);
                graphics.DrawString(Convert.ToDateTime(row["ExpenseDate"]).ToString("d"), itemFont, Brushes.Black, leftMargin + 200, yPos);
                graphics.DrawString(Convert.ToDecimal(row["TotalAmount"]).ToString("C"), itemFont, Brushes.Black, rightMargin - 100, yPos);
                yPos += itemFont.GetHeight() + 5;
            }

            yPos += 20;
            graphics.DrawString($"Total Expenses: {totalExpenses:C}", summaryFont, Brushes.Black, rightMargin - 200, yPos);
            yPos += summaryFont.GetHeight() + 20;

            Brush profitBrush = profitLoss >= 0 ? Brushes.Green : Brushes.Red;
            graphics.DrawString($"Net Profit/Loss: {profitLoss:C}", summaryFont, profitBrush, rightMargin - 200, yPos);
            yPos += summaryFont.GetHeight() + 30;

            graphics.DrawString($"Report generated on {DateTime.Now}", smallFont, Brushes.Black, leftMargin, yPos);
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (incomeData == null || expenseData == null)
            {
                MessageBox.Show("Please generate the report first", "Information",
                              MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            PrintDocument printDoc = new PrintDocument();
            printDoc.PrintPage += PrintReport;

            PrintDialog printDialog = new PrintDialog();
            printDialog.Document = printDoc;

            if (printDialog.ShowDialog() == DialogResult.OK)
            {
                printDoc.Print();
            }
        }
    }
}