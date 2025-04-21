using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace KQS
{
    public partial class SignupForm : Form
    {
        private const string ConnectionString = "Server=.;Database=KQS;Integrated Security=True;";

        public SignupForm()
        {
            InitializeComponent();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUsername.Text) ||
                string.IsNullOrWhiteSpace(txtPassword.Text) ||
                string.IsNullOrWhiteSpace(txtConfirmPassword.Text))
            {
                ShowError("All fields are required");
                return;
            }

            if (txtPassword.Text != txtConfirmPassword.Text)
            {
                ShowError("Passwords don't match");
                return;
            }

            if (txtPassword.Text.Length < 6)
            {
                ShowError("Password must be at least 6 characters");
                return;
            }

            try
            {
                string passwordHash = PasswordHelper.HashPassword(txtPassword.Text);

                using (var connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();
                    using (var command = new SqlCommand("sp_CreateUser", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@Username", txtUsername.Text);
                        command.Parameters.AddWithValue("@PasswordHash", passwordHash);
                        command.Parameters.AddWithValue("@UserType", "Admin");

                        command.ExecuteNonQuery();
                    }
                }

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627)
                {
                    ShowError("Username already exists");
                }
                else
                {
                    ShowError("Database error: " + ex.Message);
                }
            }
        }

        private void ShowError(string message)
        {
            lblMessage.Text = message;
            lblMessage.ForeColor = System.Drawing.Color.Red;
        }
    }
}