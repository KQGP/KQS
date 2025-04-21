using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;

namespace KQS
{
    public partial class SellsForm : Form
    {
        private const string ConnectionString = "Server=.;Database=KQS;Integrated Security=True;";
        private int _userId;
        private LoginForm _loginForm;
        private List<SaleItem> _cartItems = new List<SaleItem>();
        private DataTable _allItemsTable = new DataTable();
        private DataTable _displayedItemsTable = new DataTable();
        private DataTable _categoriesTable = new DataTable();

        public SellsForm(int userId, LoginForm loginForm)
        {
            InitializeComponent();
            _userId = userId;
            _loginForm = loginForm;
            lblWelcome.Text = $"Welcome, Seller (User ID: {_userId})";

            LoadCategories();
            LoadAllItems();
        }

        private void LoadAllItems()
        {
            try
            {
                _allItemsTable = new DataTable();

                using (var connection = new SqlConnection(ConnectionString))
                using (var command = new SqlCommand("SELECT * FROM Items WHERE Quantity > 0", connection))
                {
                    connection.Open();
                    using (var adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(_allItemsTable);
                    }
                }

                if (_allItemsTable != null)
                {
                    _displayedItemsTable = _allItemsTable.Copy();
                    UpdateItemsListView();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading items: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

                if (_categoriesTable != null && _categoriesTable.Rows.Count > 0)
                {
                    cmbCategories.DataSource = _categoriesTable;
                    cmbCategories.DisplayMember = "Name";
                    cmbCategories.ValueMember = "CategoryId";
                    cmbCategories.SelectedIndex = -1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading categories: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateItemsListView()
        {
            try
            {
                listViewItems.Items.Clear();

                if (_displayedItemsTable != null)
                {
                    foreach (DataRow row in _displayedItemsTable.Rows)
                    {
                        var item = new ListViewItem(row["Name"].ToString());
                        item.SubItems.Add(row["Price"].ToString());
                        item.SubItems.Add(row["Quantity"].ToString());
                        item.Tag = row["ItemId"];
                        listViewItems.Items.Add(item);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating item list: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbCategories_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (_allItemsTable == null) return;

                if (cmbCategories.SelectedIndex == -1)
                {
                    _displayedItemsTable = _allItemsTable.Copy();
                }
                else if (cmbCategories.SelectedValue != null)
                {
                    int categoryId;
                    if (cmbCategories.SelectedValue is DataRowView drv)
                    {
                        categoryId = Convert.ToInt32(drv["CategoryId"]);
                    }
                    else
                    {
                        categoryId = Convert.ToInt32(cmbCategories.SelectedValue);
                    }

                    DataView dv = _allItemsTable.DefaultView;
                    dv.RowFilter = $"CategoryId = {categoryId}";
                    _displayedItemsTable = dv.ToTable();
                }
                UpdateItemsListView();
            }
            catch (Exception)
            {
            }
        }

        private void btnClearFilter_Click(object sender, EventArgs e)
        {
            try
            {
                cmbCategories.SelectedIndex = -1;
                _displayedItemsTable = _allItemsTable.Copy();
                UpdateItemsListView();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error clearing filter: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void listViewItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtQuantity.Text = "1";
        }

        private void btnAddToCart_Click(object sender, EventArgs e)
        {
            if (listViewItems.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select an item", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!int.TryParse(txtQuantity.Text, out int quantity) || quantity <= 0)
            {
                MessageBox.Show("Please enter a valid quantity", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var selectedItem = listViewItems.SelectedItems[0];
            int availableQty = int.Parse(selectedItem.SubItems[2].Text);
            if (quantity > availableQty)
            {
                MessageBox.Show($"Only {availableQty} items available", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int itemId = (int)selectedItem.Tag;
            string itemName = selectedItem.Text;
            decimal price = decimal.Parse(selectedItem.SubItems[1].Text);
            decimal total = price * quantity;

            _cartItems.Add(new SaleItem
            {
                ItemId = itemId,
                ItemName = itemName,
                Price = price,
                Quantity = quantity,
                Total = total
            });

            UpdateCartDisplay();
            CalculateTotal();
        }

        private void UpdateCartDisplay()
        {
            listViewCart.Items.Clear();
            foreach (var item in _cartItems)
            {
                var listItem = new ListViewItem(item.ItemName);
                listItem.SubItems.Add(item.Price.ToString("0.00"));
                listItem.SubItems.Add(item.Quantity.ToString());
                listItem.SubItems.Add(item.Total.ToString("0.00"));
                listViewCart.Items.Add(listItem);
            }
        }

        private void CalculateTotal()
        {
            decimal total = 0;
            foreach (var item in _cartItems)
            {
                total += item.Total;
            }
            lblTotal.Text = $"Total: {total.ToString("0.00")}";
        }

        private void btnRemoveSelected_Click(object sender, EventArgs e)
        {
            if (listViewCart.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select an item to remove", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int selectedIndex = listViewCart.SelectedIndices[0];
            _cartItems.RemoveAt(selectedIndex);
            UpdateCartDisplay();
            CalculateTotal();
        }

        private void btnClearCart_Click(object sender, EventArgs e)
        {
            _cartItems.Clear();
            UpdateCartDisplay();
            CalculateTotal();
        }

        private void btnPrintBill_Click(object sender, EventArgs e)
        {
            if (_cartItems.Count == 0)
            {
                MessageBox.Show("Cart is empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                decimal totalAmount = 0;
                foreach (var item in _cartItems)
                {
                    totalAmount += item.Total;
                }

                int saleId;
                int invoiceId = 0;

                using (var connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();
                    using (var transaction = connection.BeginTransaction())
                    {
                        try
                        {
                            using (var command = new SqlCommand("sp_AddSale", connection, transaction))
                            {
                                command.CommandType = CommandType.StoredProcedure;
                                command.Parameters.AddWithValue("@TotalAmount", totalAmount);
                                command.Parameters.AddWithValue("@UserId", _userId);
                                saleId = Convert.ToInt32(command.ExecuteScalar());
                            }

                            using (var command = new SqlCommand("sp_CreateInvoice", connection, transaction))
                            {
                                command.CommandType = CommandType.StoredProcedure;
                                command.Parameters.AddWithValue("@SaleId", saleId);
                                command.Parameters.AddWithValue("@TotalAmount", totalAmount);
                                command.Parameters.AddWithValue("@SellerId", _userId);
                                command.Parameters.AddWithValue("@InvoiceName", GenerateInvoiceName());
                                invoiceId = Convert.ToInt32(command.ExecuteScalar());
                            }

                            foreach (var item in _cartItems)
                            {
                                using (var command = new SqlCommand("sp_AddInvoiceItem", connection, transaction))
                                {
                                    command.CommandType = CommandType.StoredProcedure;
                                    command.Parameters.AddWithValue("@InvoiceId", invoiceId);
                                    command.Parameters.AddWithValue("@ItemId", item.ItemId);
                                    command.Parameters.AddWithValue("@Quantity", item.Quantity);
                                    command.Parameters.AddWithValue("@UnitPrice", item.Price);
                                    command.Parameters.AddWithValue("@TotalPrice", item.Total);
                                    command.ExecuteNonQuery();
                                }

                                using (var command = new SqlCommand("UPDATE Items SET Quantity = Quantity - @Quantity WHERE ItemId = @ItemId", connection, transaction))
                                {
                                    command.Parameters.AddWithValue("@Quantity", item.Quantity);
                                    command.Parameters.AddWithValue("@ItemId", item.ItemId);
                                    command.ExecuteNonQuery();
                                }
                            }

                            transaction.Commit();
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback();
                            MessageBox.Show($"Error processing sale: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                }

                PrintInvoice(invoiceId);

                _cartItems.Clear();
                UpdateCartDisplay();
                CalculateTotal();
                LoadAllItems();

                MessageBox.Show("Sale completed and invoice generated successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error processing sale: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string GenerateInvoiceName()
        {
            return "INV-" + DateTime.Now.ToString("yyyyMMddHHmmss");
        }

        private void PrintInvoice(int invoiceId)
        {
            try
            {
                PrintDocument printDoc = new PrintDocument();
                printDoc.PrintPage += (sender, e) =>
                {
                    try
                    {
                        Graphics graphics = e.Graphics;
                        Font titleFont = new Font("Arial", 16, FontStyle.Bold);
                        Font headerFont = new Font("Arial", 12, FontStyle.Bold);
                        Font itemFont = new Font("Arial", 10);
                        Font totalFont = new Font("Arial", 12, FontStyle.Bold);

                        float yPos = 50;
                        float leftMargin = e.MarginBounds.Left;
                        float rightMargin = e.MarginBounds.Right;

                        graphics.DrawString("KQS - Invoice", titleFont, Brushes.Black, leftMargin, yPos);
                        yPos += titleFont.GetHeight() + 20;

                        DataTable invoiceDetails = GetInvoiceDetails(invoiceId);
                        if (invoiceDetails.Rows.Count == 0)
                        {
                            graphics.DrawString("Invoice not found!", headerFont, Brushes.Red, leftMargin, yPos);
                            return;
                        }

                        string invoiceName = invoiceDetails.Rows[0]["InvoiceName"].ToString();
                        DateTime invoiceDate = Convert.ToDateTime(invoiceDetails.Rows[0]["InvoiceDate"]);
                        decimal totalAmount = Convert.ToDecimal(invoiceDetails.Rows[0]["TotalAmount"]);

                        graphics.DrawString($"Invoice #: {invoiceName}", headerFont, Brushes.Black, leftMargin, yPos);
                        yPos += headerFont.GetHeight() + 5;
                        graphics.DrawString($"Date: {invoiceDate.ToString("g")}", headerFont, Brushes.Black, leftMargin, yPos);
                        yPos += headerFont.GetHeight() + 20;

                        graphics.DrawString("Item", headerFont, Brushes.Black, leftMargin, yPos);
                        graphics.DrawString("Price", headerFont, Brushes.Black, leftMargin + 200, yPos);
                        graphics.DrawString("Qty", headerFont, Brushes.Black, leftMargin + 300, yPos);
                        graphics.DrawString("Total", headerFont, Brushes.Black, rightMargin - 100, yPos);
                        yPos += headerFont.GetHeight() + 5;

                        graphics.DrawLine(Pens.Black, leftMargin, yPos, rightMargin, yPos);
                        yPos += 10;

                        DataTable invoiceItems = GetInvoiceItems(invoiceId);
                        foreach (DataRow row in invoiceItems.Rows)
                        {
                            string itemName = row.Table.Columns.Contains("Name") ? row["Name"].ToString() :
                                            row.Table.Columns.Contains("ItemName") ? row["ItemName"].ToString() :
                                            "Unknown Item";

                            string unitPrice = row.Table.Columns.Contains("UnitPrice") ?
                                             Convert.ToDecimal(row["UnitPrice"]).ToString("0.00") : "0.00";

                            string quantity = row.Table.Columns.Contains("Quantity") ?
                                             row["Quantity"].ToString() : "0";

                            string totalPrice = row.Table.Columns.Contains("TotalPrice") ?
                                              Convert.ToDecimal(row["TotalPrice"]).ToString("0.00") : "0.00";

                            graphics.DrawString(itemName, itemFont, Brushes.Black, leftMargin, yPos);
                            graphics.DrawString(unitPrice, itemFont, Brushes.Black, leftMargin + 200, yPos);
                            graphics.DrawString(quantity, itemFont, Brushes.Black, leftMargin + 300, yPos);
                            graphics.DrawString(totalPrice, itemFont, Brushes.Black, rightMargin - 100, yPos);
                            yPos += itemFont.GetHeight() + 5;
                        }

                        yPos += 10;
                        graphics.DrawLine(Pens.Black, leftMargin, yPos, rightMargin, yPos);
                        yPos += 20;

                        graphics.DrawString("Total Amount:", totalFont, Brushes.Black, rightMargin - 200, yPos);
                        graphics.DrawString(totalAmount.ToString("0.00"), totalFont, Brushes.Black, rightMargin - 100, yPos);
                        yPos += totalFont.GetHeight() + 20;

                        graphics.DrawString("Thank you for your purchase!", headerFont, Brushes.Black, leftMargin, yPos);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error generating invoice: {ex.Message}", "Print Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                };

                PrintPreviewDialog previewDialog = new PrintPreviewDialog();
                previewDialog.Document = printDoc;

                ToolStripButton printButton = new ToolStripButton("Print");
                printButton.Click += (sender, e) => { printDoc.Print(); };

                foreach (Control c in previewDialog.Controls)
                {
                    if (c is ToolStrip)
                    {
                        ((ToolStrip)c).Items.Add(printButton);
                        break;
                    }
                }

                previewDialog.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error printing invoice: {ex.Message}", "Print Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private DataTable GetInvoiceDetails(int invoiceId)
        {
            DataTable dt = new DataTable();
            using (var connection = new SqlConnection(ConnectionString))
            using (var command = new SqlCommand("SELECT * FROM Invoices WHERE InvoiceId = @InvoiceId", connection))
            {
                command.Parameters.AddWithValue("@InvoiceId", invoiceId);
                connection.Open();
                using (var adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(dt);
                }
            }
            return dt;
        }

        private DataTable GetInvoiceItems(int invoiceId)
        {
            DataTable dt = new DataTable();
            using (var connection = new SqlConnection(ConnectionString))
            using (var command = new SqlCommand("SELECT * FROM InvoiceItems WHERE InvoiceId = @InvoiceId", connection))
            {
                command.Parameters.AddWithValue("@InvoiceId", invoiceId);
                connection.Open();
                using (var adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(dt);
                }
            }
            return dt;
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Close();
            _loginForm.ShowLogin();
        }
    }

    public class SaleItem
    {
        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public decimal Total { get; set; }
    }
}