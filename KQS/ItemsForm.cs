using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace KQS
{
    public partial class ItemsForm : Form
    {
        private const string ConnectionString = "Server=.;Database=KQS;Integrated Security=True;";
        private DataTable _allItemsTable;
        private DataTable _displayedItemsTable;

        public ItemsForm()
        {
            InitializeComponent();
            LoadAllItems();
            LoadCategories();
        }

        private void LoadAllItems()
        {
            _allItemsTable = new DataTable();

            using (var connection = new SqlConnection(ConnectionString))
            using (var command = new SqlCommand("sp_GetAllItems", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                connection.Open();

                using (var adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(_allItemsTable);
                }
            }

            _displayedItemsTable = _allItemsTable.Copy();
            dataGridViewItems.DataSource = _displayedItemsTable;

            if (dataGridViewItems.Columns.Contains("ItemId"))
                dataGridViewItems.Columns["ItemId"].Visible = false;

            if (dataGridViewItems.Columns.Contains("CategoryId"))
                dataGridViewItems.Columns["CategoryId"].Visible = false;

            if (dataGridViewItems.Columns.Contains("BuyPrice"))
                dataGridViewItems.Columns["BuyPrice"].DefaultCellStyle.Format = "C2";

            if (dataGridViewItems.Columns.Contains("Price"))
                dataGridViewItems.Columns["Price"].DefaultCellStyle.Format = "C2";

            if (_displayedItemsTable.Columns.Contains("BuyPrice") && _displayedItemsTable.Columns.Contains("Price"))
            {
                if (!_displayedItemsTable.Columns.Contains("Profit"))
                {
                    _displayedItemsTable.Columns.Add("Profit", typeof(decimal), "Price - BuyPrice");
                    dataGridViewItems.Columns["Profit"].DefaultCellStyle.Format = "C2";
                }
            }
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

            cmbCategories.DataSource = categoriesTable;
            cmbCategories.DisplayMember = "Name";
            cmbCategories.ValueMember = "CategoryId";
            cmbCategories.SelectedIndex = -1;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var addForm = new AddEditItemForm();
            if (addForm.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    using (var connection = new SqlConnection(ConnectionString))
                    using (var command = new SqlCommand("sp_AddItem", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@Name", addForm.ItemName);
                        command.Parameters.AddWithValue("@Description", addForm.Description);
                        command.Parameters.AddWithValue("@BuyPrice", addForm.BuyPrice);
                        command.Parameters.AddWithValue("@Price", addForm.SellPrice);
                        command.Parameters.AddWithValue("@Quantity", addForm.Quantity);
                        command.Parameters.AddWithValue("@CategoryId", addForm.CategoryId);

                        connection.Open();
                        command.ExecuteNonQuery();
                    }

                    LoadAllItems();
                    MessageBox.Show("Item added successfully and expense record created for inventory purchase.",
                                  "Success",
                                  MessageBoxButtons.OK,
                                  MessageBoxIcon.Information);
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Error adding item: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dataGridViewItems.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select an item to edit", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var selectedRow = dataGridViewItems.SelectedRows[0];
            var editForm = new AddEditItemForm(
                Convert.ToInt32(selectedRow.Cells["ItemId"].Value),
                selectedRow.Cells["Name"].Value.ToString(),
                selectedRow.Cells["Description"].Value.ToString(),
                Convert.ToDecimal(selectedRow.Cells["BuyPrice"].Value),
                Convert.ToDecimal(selectedRow.Cells["Price"].Value),
                Convert.ToInt32(selectedRow.Cells["Quantity"].Value),
                Convert.ToInt32(selectedRow.Cells["CategoryId"].Value));

            if (editForm.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    using (var connection = new SqlConnection(ConnectionString))
                    using (var command = new SqlCommand("sp_UpdateItemWithPrices", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@ItemId", editForm.ItemId);
                        command.Parameters.AddWithValue("@Name", editForm.ItemName);
                        command.Parameters.AddWithValue("@Description", editForm.Description);
                        command.Parameters.AddWithValue("@BuyPrice", editForm.BuyPrice);
                        command.Parameters.AddWithValue("@Price", editForm.SellPrice);
                        command.Parameters.AddWithValue("@Quantity", editForm.Quantity);
                        command.Parameters.AddWithValue("@CategoryId", editForm.CategoryId);

                        connection.Open();
                        command.ExecuteNonQuery();
                    }

                    LoadAllItems();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Error updating item: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridViewItems.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select an item to delete.",
                               "No Item Selected",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Information);
                return;
            }

            var selectedRow = dataGridViewItems.SelectedRows[0];
            int itemId = Convert.ToInt32(selectedRow.Cells["ItemId"].Value);
            string itemName = selectedRow.Cells["Name"].Value.ToString();

            var confirmResult = MessageBox.Show(
                $"You are about to delete the following item:\n\n" +
                $"Name: {itemName}\n" +
                $"ID: {itemId}\n\n" +
                "This action cannot be undone. Are you sure you want to continue?",
                "Confirm Item Deletion",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning,
                MessageBoxDefaultButton.Button2);

            if (confirmResult != DialogResult.Yes)
            {
                MessageBox.Show("Item deletion cancelled.",
                               "Cancelled",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Information);
                return;
            }

            try
            {
                using (var connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();

                    using (var command = new SqlCommand("DELETE FROM SaleItems WHERE ItemId = @ItemId", connection))
                    {
                        command.Parameters.AddWithValue("@ItemId", itemId);
                        command.ExecuteNonQuery();
                    }

                    using (var command = new SqlCommand("sp_DeleteItem", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@ItemId", itemId);
                        command.ExecuteNonQuery();
                    }
                }

                MessageBox.Show($"Item '{itemName}' (ID: {itemId}) was successfully deleted.",
                               "Deletion Successful",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Information);

                LoadAllItems();
            }
            catch (SqlException ex)
            {
                string errorMessage = ex.Message.Contains("REFERENCE constraint") ?
                    "Cannot delete this item because it has existing sales records.\n\n" +
                    "Please contact your database administrator to resolve this issue." :
                    "An error occurred while deleting the item:\n\n" + ex.Message;

                MessageBox.Show(errorMessage,
                               "Deletion Error",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An unexpected error occurred:\n\n{ex.Message}",
                               "Error",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Error);
            }
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            if (cmbCategories.SelectedValue != null)
            {
                int categoryId = (int)cmbCategories.SelectedValue;
                DataView dv = _allItemsTable.DefaultView;
                dv.RowFilter = $"CategoryId = {categoryId}";
                _displayedItemsTable = dv.ToTable();
                dataGridViewItems.DataSource = _displayedItemsTable;
            }
        }

        private void btnClearFilter_Click(object sender, EventArgs e)
        {
            _displayedItemsTable = _allItemsTable.Copy();
            dataGridViewItems.DataSource = _displayedItemsTable;
            cmbCategories.SelectedIndex = -1;
        }
    }
}