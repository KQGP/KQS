using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace AccountingSystem
{
    public partial class InvoicesForm : Form
    {
        private string connectionString = "Server=.;Database=KQS;Integrated Security=True;";

        public InvoicesForm()
        {
            InitializeComponent();
            LoadInvoices();
        }

        private void LoadInvoices()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Invoices", conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvInvoices.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading invoices: {ex.Message}", "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvInvoices_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvInvoices.Rows[e.RowIndex];

                txtInvoiceNumber.Text = row.Cells["InvoiceName"].Value?.ToString() ?? "";

                if (DateTime.TryParse(row.Cells["InvoiceDate"].Value?.ToString(), out DateTime invoiceDate))
                    dtpInvoiceDate.Value = invoiceDate;

                if (DateTime.TryParse(row.Cells["DueDate"].Value?.ToString(), out DateTime dueDate))
                    dtpDueDate.Value = dueDate;

                txtSubTotal.Text = row.Cells["SubTotal"].Value?.ToString() ?? "0";
                txtDiscountAmount.Text = row.Cells["DiscountAmount"].Value?.ToString() ?? "0";
                txtTotalAmount.Text = row.Cells["TotalAmount"].Value?.ToString() ?? "0";
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvInvoices.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select an invoice to delete.", "Information",
                              MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                int invoiceId = Convert.ToInt32(dgvInvoices.SelectedRows[0].Cells["InvoiceId"].Value);

                var confirm = MessageBox.Show("Are you sure you want to permanently delete this invoice?",
                                            "Confirm Delete",
                                            MessageBoxButtons.YesNo,
                                            MessageBoxIcon.Warning);

                if (confirm != DialogResult.Yes) return;

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "DELETE FROM Invoices WHERE InvoiceId = @InvoiceId";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@InvoiceId", invoiceId);

                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Invoice permanently deleted.", "Success",
                                      MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadInvoices();
                    }
                }
            }
            catch (SqlException sqlEx) when (sqlEx.Number == 547)
            {
                MessageBox.Show("Cannot delete invoice because it has related records in other tables.",
                              "Delete Failed",
                              MessageBoxButtons.OK,
                              MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error deleting invoice: {ex.Message}", "Error",
                              MessageBoxButtons.OK,
                              MessageBoxIcon.Error);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtInvoiceNumber.Text))
                {
                    MessageBox.Show("Please enter an invoice name/number.", "Error",
                                  MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (!decimal.TryParse(txtSubTotal.Text, out decimal subTotal) ||
                    !decimal.TryParse(txtDiscountAmount.Text, out decimal discount) ||
                    !decimal.TryParse(txtTotalAmount.Text, out decimal total))
                {
                    MessageBox.Show("Please enter valid numeric amounts.", "Error",
                                  MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"INSERT INTO Invoices 
                            (InvoiceName, InvoiceDate, DueDate, SubTotal, DiscountAmount, TotalAmount) 
                            VALUES (@InvoiceName, @InvoiceDate, @DueDate, @SubTotal, @DiscountAmount, @TotalAmount)";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@InvoiceName", txtInvoiceNumber.Text);
                    cmd.Parameters.AddWithValue("@InvoiceDate", dtpInvoiceDate.Value);
                    cmd.Parameters.AddWithValue("@DueDate", dtpDueDate.Value);
                    cmd.Parameters.AddWithValue("@SubTotal", subTotal);
                    cmd.Parameters.AddWithValue("@DiscountAmount", discount);
                    cmd.Parameters.AddWithValue("@TotalAmount", total);

                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Invoice added successfully.", "Success",
                                  MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadInvoices();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding invoice: {ex.Message}", "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dgvInvoices.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select an invoice to update.", "Information",
                              MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                int invoiceId = Convert.ToInt32(dgvInvoices.SelectedRows[0].Cells["InvoiceId"].Value);

                if (!decimal.TryParse(txtSubTotal.Text, out decimal subTotal) ||
                    !decimal.TryParse(txtDiscountAmount.Text, out decimal discount) ||
                    !decimal.TryParse(txtTotalAmount.Text, out decimal total))
                {
                    MessageBox.Show("Please enter valid numeric amounts.", "Error",
                                  MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"UPDATE Invoices SET 
                                    InvoiceName = @InvoiceName,
                                    InvoiceDate = @InvoiceDate,
                                    DueDate = @DueDate,
                                    SubTotal = @SubTotal,
                                    DiscountAmount = @DiscountAmount,
                                    TotalAmount = @TotalAmount
                                    WHERE InvoiceId = @InvoiceId";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@InvoiceName", txtInvoiceNumber.Text);
                    cmd.Parameters.AddWithValue("@InvoiceDate", dtpInvoiceDate.Value);
                    cmd.Parameters.AddWithValue("@DueDate", dtpDueDate.Value);
                    cmd.Parameters.AddWithValue("@SubTotal", subTotal);
                    cmd.Parameters.AddWithValue("@DiscountAmount", discount);
                    cmd.Parameters.AddWithValue("@TotalAmount", total);
                    cmd.Parameters.AddWithValue("@InvoiceId", invoiceId);

                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Invoice updated successfully.", "Success",
                                      MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadInvoices();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating invoice: {ex.Message}", "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}