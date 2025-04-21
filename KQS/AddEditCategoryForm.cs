using System;
using System.Windows.Forms;
using System.Xml.Linq;

namespace KQS
{
    public partial class AddEditCategoryForm : Form
    {
        public int CategoryId { get; private set; }
        public string CategoryName => txtName.Text.Trim();
        public string Description => txtDescription.Text.Trim();

        public AddEditCategoryForm()
        {
            InitializeComponent();
        }

        public AddEditCategoryForm(int categoryId, string name, string description) : this()
        {
            CategoryId = categoryId;
            txtName.Text = name;
            txtDescription.Text = description;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Category name is required", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}