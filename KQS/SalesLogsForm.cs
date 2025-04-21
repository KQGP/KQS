using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace KQS
{
    public partial class SalesLogsForm : Form
    {
        private const string ConnectionString = "Server=.;Database=KQS;Integrated Security=True;";

        public SalesLogsForm()
        {
            InitializeComponent();
            LoadSalesLogs();
        }

        private void LoadSalesLogs()
        {
            DataTable salesTable = new DataTable();

            using (var connection = new SqlConnection(ConnectionString))
            using (var command = new SqlCommand("sp_GetAllSales", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                connection.Open();

                using (var adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(salesTable);
                }
            }

            dataGridViewSales.DataSource = salesTable;
            dataGridViewSales.Columns["SaleId"].Visible = false;
        }

        private void dataGridViewSales_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewSales.SelectedRows.Count > 0)
            {
                int saleId = Convert.ToInt32(dataGridViewSales.SelectedRows[0].Cells["SaleId"].Value);
                LoadSaleItems(saleId);
            }
        }

        private void LoadSaleItems(int saleId)
        {
            DataTable itemsTable = new DataTable();

            using (var connection = new SqlConnection(ConnectionString))
            using (var command = new SqlCommand("sp_GetSaleItems", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@SaleId", saleId);
                connection.Open();

                using (var adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(itemsTable);
                }
            }

            dataGridViewSaleItems.DataSource = itemsTable;
            dataGridViewSaleItems.Columns["SaleItemId"].Visible = false;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}