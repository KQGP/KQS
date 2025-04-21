using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace AccountingSystem
{
    public partial class InventoryForm : Form
    {
        private string connectionString = "Server=.;Database=KQS;Integrated Security=True;";

        public InventoryForm()
        {
            InitializeComponent();
            LoadCategories();
            LoadProducts();
        }

        private void LoadCategories()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlDataAdapter da = new SqlDataAdapter("SELECT CategoryId, Name FROM Categories", conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                cmbCategory.DataSource = dt;
                cmbCategory.DisplayMember = "Name";
                cmbCategory.ValueMember = "CategoryId";
            }
        }

        private void LoadProducts()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Products WHERE IsActive = 1", conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvProducts.DataSource = dt;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "INSERT INTO Products (Name, Description, Category, UnitPrice, CostPrice, QuantityInStock, ReorderLevel, CreatedDate) " +
                                   "VALUES (@Name, @Description, @Category, @UnitPrice, @CostPrice, @QuantityInStock, @ReorderLevel, GETDATE())";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Name", txtProductName.Text);
                    cmd.Parameters.AddWithValue("@Description", txtDescription.Text ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@Category", cmbCategory.SelectedValue);
                    cmd.Parameters.AddWithValue("@UnitPrice", decimal.Parse(txtUnitPrice.Text));
                    cmd.Parameters.AddWithValue("@CostPrice", decimal.Parse(txtCostPrice.Text));
                    cmd.Parameters.AddWithValue("@QuantityInStock", numQuantityInStock.Value);
                    cmd.Parameters.AddWithValue("@ReorderLevel", numReorderLevel.Value);
                    cmd.ExecuteNonQuery();
                    LoadProducts();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding product: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dgvProducts.SelectedRows.Count > 0)
            {
                try
                {
                    int productId = Convert.ToInt32(dgvProducts.SelectedRows[0].Cells["ProductId"].Value);
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        conn.Open();
                        string query = "UPDATE Products SET Name=@Name, Description=@Description, Category=@Category, " +
                                       "UnitPrice=@UnitPrice, CostPrice=@CostPrice, QuantityInStock=@QuantityInStock, ReorderLevel=@ReorderLevel " +
                                       "WHERE ProductId=@ProductId";
                        SqlCommand cmd = new SqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@Name", txtProductName.Text);
                        cmd.Parameters.AddWithValue("@Description", string.IsNullOrEmpty(txtDescription.Text) ? (object)DBNull.Value : txtDescription.Text);
                        cmd.Parameters.AddWithValue("@Category", cmbCategory.SelectedValue);
                        cmd.Parameters.AddWithValue("@UnitPrice", decimal.Parse(txtUnitPrice.Text));
                        cmd.Parameters.AddWithValue("@CostPrice", decimal.Parse(txtCostPrice.Text));
                        cmd.Parameters.AddWithValue("@QuantityInStock", numQuantityInStock.Value);
                        cmd.Parameters.AddWithValue("@ReorderLevel", numReorderLevel.Value);
                        cmd.Parameters.AddWithValue("@ProductId", productId);
                        cmd.ExecuteNonQuery();
                        LoadProducts();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error updating product: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvProducts.SelectedRows.Count > 0)
            {
                try
                {
                    int productId = Convert.ToInt32(dgvProducts.SelectedRows[0].Cells["ProductId"].Value);
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        conn.Open();
                        string query = "UPDATE Products SET IsActive = 0 WHERE ProductId = @ProductId";
                        SqlCommand cmd = new SqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@ProductId", productId);
                        cmd.ExecuteNonQuery();
                        LoadProducts();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error deleting product: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dgvProducts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvProducts.Rows[e.RowIndex].Cells["ProductId"].Value != DBNull.Value)
            {
                DataGridViewRow row = dgvProducts.Rows[e.RowIndex];

                txtProductName.Text = row.Cells["Name"].Value?.ToString() ?? "";
                txtDescription.Text = row.Cells["Description"].Value?.ToString() ?? "";

                if (row.Cells["Category"].Value != DBNull.Value)
                    cmbCategory.SelectedValue = row.Cells["Category"].Value;

                txtUnitPrice.Text = row.Cells["UnitPrice"].Value?.ToString() ?? "0";
                txtCostPrice.Text = row.Cells["CostPrice"].Value?.ToString() ?? "0";

                if (decimal.TryParse(row.Cells["QuantityInStock"].Value?.ToString(), out decimal qty))
                    numQuantityInStock.Value = qty;

                if (decimal.TryParse(row.Cells["ReorderLevel"].Value?.ToString(), out decimal reorder))
                    numReorderLevel.Value = reorder;
            }
        }
    }
}