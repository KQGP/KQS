using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace AccountingSystem
{
    public partial class ExpensesForm : Form
    {
        private string connectionString = "Server=.;Database=KQS;Integrated Security=True;";

        public ExpensesForm()
        {
            InitializeComponent();
            LoadExpenses();
        }

        private void LoadExpenses()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Expenses", conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvExpenses.DataSource = dt;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = @"INSERT INTO Expenses (Description, TotalAmount, ExpenseDate, PaymentMethod, ReferenceNumber, CreatedDate) 
                        VALUES (@Description, @TotalAmount, @ExpenseDate, @PaymentMethod, @ReferenceNumber, GETDATE())";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Description", txtDescription.Text);
                cmd.Parameters.AddWithValue("@TotalAmount", decimal.Parse(txtAmount.Text));
                cmd.Parameters.AddWithValue("@ExpenseDate", dtpExpenseDate.Value);
                cmd.Parameters.AddWithValue("@PaymentMethod", cmbPaymentMethod.SelectedItem?.ToString() ?? "");
                cmd.Parameters.AddWithValue("@ReferenceNumber", txtReferenceNumber.Text);

                cmd.ExecuteNonQuery();
                LoadExpenses();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dgvExpenses.SelectedRows.Count > 0)
            {
                int expenseId = Convert.ToInt32(dgvExpenses.SelectedRows[0].Cells["ExpenseId"].Value);
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"UPDATE Expenses SET 
                            Description = @Description,
                            TotalAmount = @TotalAmount,
                            ExpenseDate = @ExpenseDate,
                            PaymentMethod = @PaymentMethod,
                            ReferenceNumber = @ReferenceNumber
                            WHERE ExpenseId = @ExpenseId";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Description", txtDescription.Text);
                    cmd.Parameters.AddWithValue("@TotalAmount", decimal.Parse(txtAmount.Text));
                    cmd.Parameters.AddWithValue("@ExpenseDate", dtpExpenseDate.Value);
                    cmd.Parameters.AddWithValue("@PaymentMethod", cmbPaymentMethod.SelectedItem?.ToString() ?? "");
                    cmd.Parameters.AddWithValue("@ReferenceNumber", txtReferenceNumber.Text);
                    cmd.Parameters.AddWithValue("@ExpenseId", expenseId);

                    cmd.ExecuteNonQuery();
                    LoadExpenses();
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvExpenses.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select an expense to delete.",
                               "No Selection",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Warning);
                return;
            }

            DataGridViewRow selectedRow = dgvExpenses.SelectedRows[0];
            int expenseId = Convert.ToInt32(selectedRow.Cells["ExpenseId"].Value);
            string description = selectedRow.Cells["Description"].Value?.ToString() ?? "this expense";
            decimal amount = Convert.ToDecimal(selectedRow.Cells["TotalAmount"].Value);

            var confirmResult = MessageBox.Show(
                $"WARNING: This will permanently delete {description} (Amount: {amount:C}).\n\n" +
                "This action cannot be undone!\n\n" +
                "Are you absolutely sure you want to delete?",
                "CONFIRM HARD DELETE",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning,
                MessageBoxDefaultButton.Button2);

            if (confirmResult != DialogResult.Yes)
            {
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string deleteQuery = "DELETE FROM Expenses WHERE ExpenseId = @ExpenseId";

                    using (SqlCommand cmd = new SqlCommand(deleteQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@ExpenseId", expenseId);

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Expense permanently deleted.",
                                          "Success",
                                          MessageBoxButtons.OK,
                                          MessageBoxIcon.Information);

                            LoadExpenses();
                        }
                        else
                        {
                            MessageBox.Show("No expense was deleted. The record may have already been deleted.",
                                          "Information",
                                          MessageBoxButtons.OK,
                                          MessageBoxIcon.Information);
                        }
                    }
                }
            }
            catch (SqlException sqlEx) when (sqlEx.Number == 547)
            {
                MessageBox.Show("Cannot delete this expense because it's referenced in other records.\n" +
                              "Please delete the related records first.",
                              "Delete Failed",
                              MessageBoxButtons.OK,
                              MessageBoxIcon.Error);
            }
            catch (SqlException sqlEx)
            {
                MessageBox.Show($"Database error #{sqlEx.Number}: {sqlEx.Message}",
                              "Error",
                              MessageBoxButtons.OK,
                              MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Unexpected error: {ex.Message}",
                              "Error",
                              MessageBoxButtons.OK,
                              MessageBoxIcon.Error);
            }
        }

        private void dgvExpenses_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvExpenses.Rows[e.RowIndex];

                txtAmount.Text = row.Cells["TotalAmount"].Value?.ToString() ?? "";
                txtDescription.Text = row.Cells["Description"].Value?.ToString() ?? "";

                if (row.Cells["PaymentMethod"].Value != null)
                    cmbPaymentMethod.SelectedItem = row.Cells["PaymentMethod"].Value.ToString();

                if (DateTime.TryParse(row.Cells["ExpenseDate"].Value?.ToString(), out DateTime expenseDate))
                    dtpExpenseDate.Value = expenseDate;

                txtReferenceNumber.Text = row.Cells["ReferenceNumber"].Value?.ToString() ?? "";
            }
        }
    }
}