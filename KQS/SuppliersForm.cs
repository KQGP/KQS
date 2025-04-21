using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Xml.Linq;

namespace AccountingSystem
{
    public partial class SuppliersForm : Form
    {
        private string connectionString = "Server=.;Database=KQS;Integrated Security=True;";

        public SuppliersForm()
        {
            InitializeComponent();
            LoadSuppliers();
        }

        private void LoadSuppliers()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Suppliers WHERE IsActive = 1", conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvSuppliers.DataSource = dt;
            }
        }

        private void dgvSuppliers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                txtName.Text = dgvSuppliers.Rows[e.RowIndex].Cells["Name"].Value.ToString();
                txtContactPerson.Text = dgvSuppliers.Rows[e.RowIndex].Cells["ContactPerson"].Value.ToString();
                txtEmail.Text = dgvSuppliers.Rows[e.RowIndex].Cells["Email"].Value.ToString();
                txtPhone.Text = dgvSuppliers.Rows[e.RowIndex].Cells["Phone"].Value.ToString();
                txtAddress.Text = dgvSuppliers.Rows[e.RowIndex].Cells["Address"].Value.ToString();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvSuppliers.SelectedRows.Count > 0)
            {
                int supplierId = Convert.ToInt32(dgvSuppliers.SelectedRows[0].Cells["SupplierId"].Value);
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "UPDATE Suppliers SET IsActive = 0 WHERE SupplierId = @SupplierId";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@SupplierId", supplierId);
                    cmd.ExecuteNonQuery();
                    LoadSuppliers();
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "INSERT INTO Suppliers (Name, ContactPerson, Email, Phone, Address, CreatedDate) " +
                               "VALUES (@Name, @ContactPerson, @Email, @Phone, @Address, GETDATE())";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Name", txtName.Text);
                cmd.Parameters.AddWithValue("@ContactPerson", txtContactPerson.Text);
                cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
                cmd.Parameters.AddWithValue("@Phone", txtPhone.Text);
                cmd.Parameters.AddWithValue("@Address", txtAddress.Text);
                cmd.ExecuteNonQuery();
                LoadSuppliers();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dgvSuppliers.SelectedRows.Count > 0)
            {
                int supplierId = Convert.ToInt32(dgvSuppliers.SelectedRows[0].Cells["SupplierId"].Value);
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "UPDATE Suppliers SET Name=@Name, ContactPerson=@ContactPerson, Email=@Email, " +
                                   "Phone=@Phone, Address=@Address WHERE SupplierId=@SupplierId";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Name", txtName.Text);
                    cmd.Parameters.AddWithValue("@ContactPerson", txtContactPerson.Text);
                    cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
                    cmd.Parameters.AddWithValue("@Phone", txtPhone.Text);
                    cmd.Parameters.AddWithValue("@Address", txtAddress.Text);
                    cmd.Parameters.AddWithValue("@SupplierId", supplierId);
                    cmd.ExecuteNonQuery();
                    LoadSuppliers();
                }
            }
        }
    }
}
