using System;
using System.Windows.Forms;

namespace KQS
{
    public partial class AddEditUserForm : Form
    {
        public int UserId { get; private set; }
        public string Username { get; private set; }
        public string UserType { get; private set; }
        public string Password { get; private set; }
        public bool ChangePassword { get; private set; }

        public AddEditUserForm()
        {
            InitializeComponent();
            this.Text = "Add New User";
            lblTitle.Text = "Add New User";
            chkChangePassword.Visible = false;
        }

        public AddEditUserForm(int userId, string username, string userType) : this()
        {
            UserId = userId;
            txtUsername.Text = username;
            cmbUserType.Text = userType;
            this.Text = "Edit User";
            lblTitle.Text = "Edit User";
            chkChangePassword.Visible = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUsername.Text))
            {
                MessageBox.Show("Username is required", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(cmbUserType.Text))
            {
                MessageBox.Show("User type is required", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if ((UserId == 0 || chkChangePassword.Checked) && string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("Password is required", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (txtPassword.Text != txtConfirmPassword.Text)
            {
                MessageBox.Show("Passwords don't match", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Username = txtUsername.Text;
            UserType = cmbUserType.Text;
            Password = txtPassword.Text;
            ChangePassword = chkChangePassword.Checked;

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void chkChangePassword_CheckedChanged(object sender, EventArgs e)
        {
            txtPassword.Enabled = chkChangePassword.Checked;
            txtConfirmPassword.Enabled = chkChangePassword.Checked;
        }
    }
}