using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace KQS
{
    public partial class AddEditItemForm : Form
    {
        private const string ConnectionString = "Server=.;Database=KQS;Integrated Security=True;";

        public int ItemId { get; private set; }
        public string ItemName => txtName.Text.Trim();
        public string Description => txtDescription.Text.Trim();
        public decimal BuyPrice => decimal.Parse(txtBuyPrice.Text);
        public decimal SellPrice => decimal.Parse(txtSellPrice.Text);
        public int Quantity => int.Parse(txtQuantity.Text);
        public int CategoryId => (int)cmbCategory.SelectedValue;

        public AddEditItemForm()
        {
            InitializeComponent();
            LoadCategories();
        }

        public AddEditItemForm(int itemId, string name, string description, decimal buyPrice, decimal sellPrice, int quantity, int categoryId) : this()
        {
            ItemId = itemId;
            txtName.Text = name;
            txtDescription.Text = description;
            txtBuyPrice.Text = buyPrice.ToString("0.00");
            txtSellPrice.Text = sellPrice.ToString("0.00");
            txtQuantity.Text = quantity.ToString();
            cmbCategory.SelectedValue = categoryId;
            CalculateTotalCost(null, EventArgs.Empty);
        }

        private void LoadCategories()
        {
            DataTable categoriesTable = new DataTable();

            using (var connection = new SqlConnection(ConnectionString))
            using (var command = new SqlCommand("sp_GetAllCategories", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                connection.Open();

                using (var adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(categoriesTable);
                }
            }

            cmbCategory.DataSource = categoriesTable;
            cmbCategory.DisplayMember = "Name";
            cmbCategory.ValueMember = "CategoryId";
        }

        private void CalculateTotalCost(object sender, EventArgs e)
        {
            if (decimal.TryParse(txtBuyPrice.Text, out decimal buyPrice) &&
                int.TryParse(txtQuantity.Text, out int quantity))
            {
                decimal totalCost = buyPrice * quantity;
                lblTotalCostValue.Text = totalCost.ToString("C");
            }
            else
            {
                lblTotalCostValue.Text = "$0.00";
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Item name is required", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!decimal.TryParse(txtBuyPrice.Text, out decimal buyPrice) || buyPrice <= 0)
            {
                MessageBox.Show("Invalid buy price", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!decimal.TryParse(txtSellPrice.Text, out decimal sellPrice) || sellPrice <= 0)
            {
                MessageBox.Show("Invalid sell price", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (sellPrice < buyPrice)
            {
                MessageBox.Show("Sell price cannot be less than buy price", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(txtQuantity.Text, out int quantity) || quantity < 0)
            {
                MessageBox.Show("Invalid quantity", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cmbCategory.SelectedValue == null)
            {
                MessageBox.Show("Please select a category", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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