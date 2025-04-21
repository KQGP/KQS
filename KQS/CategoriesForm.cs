using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace KQS
{
    public partial class CategoriesForm : Form
    {
        private const string ConnectionString = "Server=.;Database=KQS;Integrated Security=True;";
        private DataTable _categoriesTable;

        public CategoriesForm()
        {
            InitializeComponent();
            LoadCategories();
        }

        private void LoadCategories()
        {
            try
            {
                _categoriesTable = new DataTable();

                using (var connection = new SqlConnection(ConnectionString))
                using (var command = new SqlCommand("sp_GetAllCategories", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    connection.Open();

                    using (var adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(_categoriesTable);
                    }
                }

                dataGridViewCategories.DataSource = _categoriesTable;
                if (dataGridViewCategories.Columns.Contains("CategoryId"))
                {
                    dataGridViewCategories.Columns["CategoryId"].Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load categories:\n\n{ex.Message}",
                              "Loading Error",
                              MessageBoxButtons.OK,
                              MessageBoxIcon.Error);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var addForm = new AddEditCategoryForm();
            if (addForm.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    using (var connection = new SqlConnection(ConnectionString))
                    using (var command = new SqlCommand("sp_AddCategory", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@Name", addForm.CategoryName);
                        command.Parameters.AddWithValue("@Description", addForm.Description);

                        connection.Open();
                        command.ExecuteNonQuery();
                    }

                    MessageBox.Show($"Category '{addForm.CategoryName}' was successfully added.",
                                  "Success",
                                  MessageBoxButtons.OK,
                                  MessageBoxIcon.Information);
                    LoadCategories();
                }
                catch (SqlException ex)
                {
                    string errorMessage = ex.Message.Contains("UNIQUE")
                        ? $"A category named '{addForm.CategoryName}' already exists.\nPlease choose a different name."
                        : $"Error adding category:\n\n{ex.Message}";

                    MessageBox.Show(errorMessage,
                                  "Error",
                                  MessageBoxButtons.OK,
                                  MessageBoxIcon.Error);
                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dataGridViewCategories.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a category to edit.",
                              "No Selection",
                              MessageBoxButtons.OK,
                              MessageBoxIcon.Information);
                return;
            }

            var selectedRow = dataGridViewCategories.SelectedRows[0];
            var editForm = new AddEditCategoryForm(
                Convert.ToInt32(selectedRow.Cells["CategoryId"].Value),
                selectedRow.Cells["Name"].Value.ToString(),
                selectedRow.Cells["Description"].Value.ToString());

            if (editForm.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    using (var connection = new SqlConnection(ConnectionString))
                    using (var command = new SqlCommand("sp_UpdateCategory", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@CategoryId", editForm.CategoryId);
                        command.Parameters.AddWithValue("@Name", editForm.CategoryName);
                        command.Parameters.AddWithValue("@Description", editForm.Description);

                        connection.Open();
                        command.ExecuteNonQuery();
                    }

                    MessageBox.Show($"Category '{editForm.CategoryName}' was successfully updated.",
                                  "Success",
                                  MessageBoxButtons.OK,
                                  MessageBoxIcon.Information);
                    LoadCategories();
                }
                catch (SqlException ex)
                {
                    string errorMessage = ex.Message.Contains("UNIQUE")
                        ? $"A category named '{editForm.CategoryName}' already exists.\nPlease choose a different name."
                        : $"Error updating category:\n\n{ex.Message}";

                    MessageBox.Show(errorMessage,
                                  "Error",
                                  MessageBoxButtons.OK,
                                  MessageBoxIcon.Error);
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridViewCategories.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a category to delete.",
                              "No Selection",
                              MessageBoxButtons.OK,
                              MessageBoxIcon.Information);
                return;
            }

            var selectedRow = dataGridViewCategories.SelectedRows[0];
            int categoryId = Convert.ToInt32(selectedRow.Cells["CategoryId"].Value);
            string categoryName = selectedRow.Cells["Name"].Value.ToString();

            var confirmResult = MessageBox.Show(
                $"You are about to delete the following category:\n\n" +
                $"Name: {categoryName}\n" +
                $"ID: {categoryId}\n\n" +
                "WARNING: This will affect all items in this category.\n" +
                "Are you sure you want to continue?",
                "Confirm Category Deletion",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning,
                MessageBoxDefaultButton.Button2);

            if (confirmResult != DialogResult.Yes)
            {
                MessageBox.Show("Category deletion was cancelled.",
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

                    using (var checkCommand = new SqlCommand(
                        "SELECT COUNT(*) FROM Items WHERE CategoryId = @CategoryId", connection))
                    {
                        checkCommand.Parameters.AddWithValue("@CategoryId", categoryId);
                        int itemCount = (int)checkCommand.ExecuteScalar();

                        if (itemCount > 0)
                        {
                            var continueDelete = MessageBox.Show(
                                $"This category contains {itemCount} item(s).\n" +
                                "Deleting it will remove these items from the system.\n\n" +
                                "Do you want to proceed with deletion?",
                                "Category Contains Items",
                                MessageBoxButtons.YesNo,
                                MessageBoxIcon.Warning);

                            if (continueDelete != DialogResult.Yes)
                            {
                                MessageBox.Show("Category deletion was cancelled.",
                                              "Cancelled",
                                              MessageBoxButtons.OK,
                                              MessageBoxIcon.Information);
                                return;
                            }
                        }
                    }

                    using (var command = new SqlCommand("sp_DeleteCategory", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@CategoryId", categoryId);
                        command.ExecuteNonQuery();
                    }
                }

                MessageBox.Show($"Category '{categoryName}' was successfully deleted.",
                              "Success",
                              MessageBoxButtons.OK,
                              MessageBoxIcon.Information);
                LoadCategories();
            }
            catch (SqlException ex)
            {
                string errorMessage = ex.Message.Contains("REFERENCE constraint")
                    ? "Cannot delete this category because it contains items that are referenced in sales records.\n\n" +
                      "Please remove or reassign these items first."
                    : $"Error deleting category:\n\n{ex.Message}";

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
    }
}