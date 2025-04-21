using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace KQS
{
    public partial class UsersForm : Form
    {
        private const string ConnectionString = "Server=.;Database=KQS;Integrated Security=True;";
        private DataTable _usersTable;

        public UsersForm()
        {
            InitializeComponent();
            LoadUsers();
        }

        private void LoadUsers()
        {
            _usersTable = new DataTable();

            using (var connection = new SqlConnection(ConnectionString))
            using (var command = new SqlCommand("sp_GetAllUsers", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                connection.Open();

                using (var adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(_usersTable);
                }
            }

            dataGridViewUsers.DataSource = _usersTable;
            dataGridViewUsers.Columns["UserId"].Visible = false;
            dataGridViewUsers.Columns["DateCreated"].HeaderText = "Created On";
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var addForm = new AddEditUserForm();
            if (addForm.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string passwordHash = PasswordHelper.HashPassword(addForm.Password);

                    using (var connection = new SqlConnection(ConnectionString))
                    using (var command = new SqlCommand("sp_CreateUser", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@Username", addForm.Username);
                        command.Parameters.AddWithValue("@PasswordHash", passwordHash);
                        command.Parameters.AddWithValue("@UserType", addForm.UserType);

                        connection.Open();
                        command.ExecuteNonQuery();
                    }

                    LoadUsers();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Error adding user: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dataGridViewUsers.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a user to edit", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var selectedRow = dataGridViewUsers.SelectedRows[0];
            var editForm = new AddEditUserForm(
                Convert.ToInt32(selectedRow.Cells["UserId"].Value),
                selectedRow.Cells["Username"].Value.ToString(),
                selectedRow.Cells["UserType"].Value.ToString());

            if (editForm.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    using (var connection = new SqlConnection(ConnectionString))
                    using (var command = new SqlCommand("sp_UpdateUser", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@UserId", editForm.UserId);
                        command.Parameters.AddWithValue("@Username", editForm.Username);
                        command.Parameters.AddWithValue("@UserType", editForm.UserType);
                        command.Parameters.AddWithValue("@ChangePassword", editForm.ChangePassword);

                        if (editForm.ChangePassword)
                        {
                            string newPasswordHash = PasswordHelper.HashPassword(editForm.Password);
                            command.Parameters.AddWithValue("@NewPasswordHash", newPasswordHash);
                        }

                        connection.Open();
                        command.ExecuteNonQuery();
                    }

                    LoadUsers();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Error updating user: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridViewUsers.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a user to delete", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var selectedRow = dataGridViewUsers.SelectedRows[0];
            int userId = Convert.ToInt32(selectedRow.Cells["UserId"].Value);
            string username = selectedRow.Cells["Username"].Value.ToString();

            if (MessageBox.Show($"Are you sure you want to delete user '{username}'?",
                "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    using (var connection = new SqlConnection(ConnectionString))
                    using (var command = new SqlCommand("sp_DeleteUser", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@UserId", userId);

                        connection.Open();
                        using (var reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                bool success = Convert.ToBoolean(reader["Success"]);
                                if (!success)
                                {
                                    MessageBox.Show("Cannot delete the last admin user", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                        }
                    }

                    LoadUsers();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Error deleting user: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}