using System;
using System.Windows.Forms;
using AccountingSystem;

namespace KQS
{
    public partial class DashboardForm : Form
    {
        private int _userId;
        private LoginForm _loginForm;

        public DashboardForm(int userId, LoginForm loginForm)
        {
            InitializeComponent();
            _userId = userId;
            _loginForm = loginForm;
            lblWelcome.Text = $"Welcome, Admin (User ID: {_userId})";
        }

        private void btnManageUsers_Click(object sender, EventArgs e)
        {
            var usersForm = new UsersForm();
            usersForm.ShowDialog();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Close();
            _loginForm.ShowLogin();
        }

        private void btnManageItems_Click(object sender, EventArgs e)
        {
            var itemsForm = new ItemsForm();
            itemsForm.ShowDialog();
        }

        private void btnManageCategories_Click(object sender, EventArgs e)
        {
            var categoriesForm = new CategoriesForm();
            categoriesForm.ShowDialog();
        }

        private void btnViewSalesLogs_Click(object sender, EventArgs e)
        {
            var salesLogsForm = new SalesLogsForm();
            salesLogsForm.ShowDialog();
        }

        private void btnGoToSeller_Click(object sender, EventArgs e)
        {
            var sellsForm = new SellsForm(_userId, _loginForm);
            sellsForm.Show();
        }

        private void btnFinancialReports_Click(object sender, EventArgs e)
        {
            var reportsForm = new FinancialReportsForm();
            reportsForm.ShowDialog();
        }

        private void btnManageCustomers_Click(object sender, EventArgs e)
        {
            var customersForm = new CustomersForm();
            customersForm.ShowDialog();
        }

        private void btnManageSuppliers_Click(object sender, EventArgs e)
        {
            var suppliersForm = new SuppliersForm();
            suppliersForm.ShowDialog();
        }

        private void btnManageInvoices_Click(object sender, EventArgs e)
        {
            var invoicesForm = new InvoicesForm();
            invoicesForm.ShowDialog();
        }

        private void btnExpenseTracking_Click(object sender, EventArgs e)
        {
            var expensesForm = new ExpensesForm();
            expensesForm.ShowDialog();
        }

        private void btnInventoryManagement_Click(object sender, EventArgs e)
        {
            var inventoryForm = new InventoryForm();
            inventoryForm.ShowDialog();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void groupBoxStats_Enter(object sender, EventArgs e)
        {

        }
    }
}