using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace AccountingSystem
{
    public partial class CustomersForm : Form
    {
        private string connectionString = "Server=.;Database=KQS;Integrated Security=True;";

        public CustomersForm()
        {
            InitializeComponent();
            LoadCustomers();
        }

        private void LoadCustomers()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Customers WHERE IsActive = 1", conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvCustomers.DataSource = dt;
            }
        }

        private void dgvCustomers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                txtName.Text = dgvCustomers.Rows[e.RowIndex].Cells["Name"].Value.ToString();
                txtContactPerson.Text = dgvCustomers.Rows[e.RowIndex].Cells["ContactPerson"].Value.ToString();
                txtEmail.Text = dgvCustomers.Rows[e.RowIndex].Cells["Email"].Value.ToString();
                txtPhone.Text = dgvCustomers.Rows[e.RowIndex].Cells["Phone"].Value.ToString();
                txtAddress.Text = dgvCustomers.Rows[e.RowIndex].Cells["Address"].Value.ToString();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvCustomers.SelectedRows.Count > 0)
            {
                int customerId = Convert.ToInt32(dgvCustomers.SelectedRows[0].Cells["CustomerId"].Value);
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "UPDATE Customers SET IsActive = 0 WHERE CustomerId = @CustomerId";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@CustomerId", customerId);
                    cmd.ExecuteNonQuery();
                    LoadCustomers();
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "INSERT INTO Customers (Name, ContactPerson, Email, Phone, Address, CreatedDate) " +
                               "VALUES (@Name, @ContactPerson, @Email, @Phone, @Address, GETDATE())";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Name", txtName.Text);
                cmd.Parameters.AddWithValue("@ContactPerson", txtContactPerson.Text);
                cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
                cmd.Parameters.AddWithValue("@Phone", txtPhone.Text);
                cmd.Parameters.AddWithValue("@Address", txtAddress.Text);
                cmd.ExecuteNonQuery();
                LoadCustomers();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dgvCustomers.SelectedRows.Count > 0)
            {
                int customerId = Convert.ToInt32(dgvCustomers.SelectedRows[0].Cells["CustomerId"].Value);
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "UPDATE Customers SET Name=@Name, ContactPerson=@ContactPerson, Email=@Email, " +
                                   "Phone=@Phone, Address=@Address WHERE CustomerId=@CustomerId";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Name", txtName.Text);
                    cmd.Parameters.AddWithValue("@ContactPerson", txtContactPerson.Text);
                    cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
                    cmd.Parameters.AddWithValue("@Phone", txtPhone.Text);
                    cmd.Parameters.AddWithValue("@Address", txtAddress.Text);
                    cmd.Parameters.AddWithValue("@CustomerId", customerId);
                    cmd.ExecuteNonQuery();
                    LoadCustomers();
                }
            }
        }
    }
}
