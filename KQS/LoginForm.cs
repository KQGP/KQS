using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace KQS
{
    public partial class LoginForm : Form
    {
        private const string ConnectionString = "Server=.;Database=KQS;Integrated Security=True;";

        public LoginForm()
        {
            InitializeComponent();
            CheckForExistingUsers();
        }

        private void CheckForExistingUsers()
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                using (var command = new SqlCommand("SELECT COUNT(*) FROM Users", connection))
                {
                    int userCount = (int)command.ExecuteScalar();
                    if (userCount == 0)
                    {
                        var signupForm = new SignupForm();
                        if (signupForm.ShowDialog() == DialogResult.OK)
                        {
                            lblMessage.Text = "Admin account created. Please login.";
                            lblMessage.ForeColor = System.Drawing.Color.Green;
                        }
                        else
                        {
                            Application.Exit();
                        }
                    }
                }
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                using (var command = new SqlCommand("sp_AuthenticateUser", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Username", txtUsername.Text);

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string storedHash = reader["PasswordHash"].ToString();
                            if (PasswordHelper.VerifyPassword(txtPassword.Text, storedHash))
                            {
                                int userId = Convert.ToInt32(reader["UserId"]);
                                string userType = reader["UserType"].ToString();

                                this.Hide();
                                if (userType == "Admin")
                                {
                                    var dashboard = new DashboardForm(userId, this);
                                    dashboard.Show();
                                }
                                else
                                {
                                    var sellsForm = new SellsForm(userId, this);
                                    sellsForm.Show();
                                }
                            }
                            else
                            {
                                ShowError("Invalid password");
                            }
                        }
                        else
                        {
                            ShowError("Username not found");
                        }
                    }
                }
            }
        }

        private void ShowError(string message)
        {
            lblMessage.Text = message;
            lblMessage.ForeColor = System.Drawing.Color.Red;
            txtPassword.Clear();
            txtPassword.Focus();
        }

        public void ShowLogin()
        {
            this.Show();
            txtUsername.Clear();
            txtPassword.Clear();
            txtUsername.Focus();
        }
    }
}