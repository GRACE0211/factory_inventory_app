using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace factory_inventory
{
    public partial class factory_inventory_system : Form
    {
        // MySQL connection string
        private string connectionString = "server=localhost;user id=root;password=0905656870;database=factory_inventory;SslMode=None";
        public factory_inventory_system()
        {
            InitializeComponent();

            this.comboBoxSupplier_tab4.SelectedIndexChanged += (sender, e) => UpdateStockHint();
            this.comboBoxProduct_tab4.SelectedIndexChanged += (sender, e) => UpdateStockHint();
            this.comboBoxType_tab4.SelectedIndexChanged += (sender, e) => UpdateStockHint();
            this.textBoxQuantity.TextChanged += (sender, e) => UpdateStockHint();
        }



        // 根據不同的tabPage頁面,載入不同的資料表格
        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // tabPage2頁面一載入時，載入資料庫中的產品和供應商資料
            if (tabControl1.SelectedTab == tabPage2)
            {
                ApplyFilter_inventoryPage();
            }

            // tabPage3頁面一載入時，載入下拉式選單的選項以及庫存異動表格
            else if (tabControl1.SelectedTab == tabPage3)
            {
                LoadSupplierComboBox(comboBoxSupplier_tab3);
                LoadProductComboBox(comboBoxProduct_tab3);
                dateTimePickerStart.Value = new DateTime(2024,12,1);
                dateTimePickerEnd.MaxDate = DateTime.Today; // 設定日期選擇器的最大日期為今天
                comboBoxTransactionType.SelectedIndex = 0; // 預設選擇"全部"
                comboBoxProduct_tab3.SelectedIndex = 0; // 預設選擇"全部"
                comboBoxSupplier_tab3.SelectedIndex = 0; // 預設選擇"全部"
                ApplyFilter_transactionPage();
            }
            else if(tabControl1.SelectedTab == tabPage4)
            {
                LoadSupplierComboBox(comboBoxSupplier_tab4);
                LoadProductComboBox(comboBoxProduct_tab4);
            }
        }

        // 顯示產品表格
        private void btnShowProducts_Click(object sender, EventArgs e)
        {
            Load_Product_Supplier_Data("SELECT * FROM products");
        }

        // 顯示供應商表格
        private void btnShowSuppliers_Click(object sender, EventArgs e)
        {
            Load_Product_Supplier_Data("SELECT * FROM supplier");
        }

        // for tabPage1，顯示產品供應商關聯表格
        // 按鈕點擊之後，呼叫 Load_Product_Supplier_Data 方法時傳入查詢語句
        private void Load_Product_Supplier_Data(string query)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    MySqlDataAdapter adapter = new MySqlDataAdapter(query, connection);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    dataGridView1.DataSource = dataTable;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }


        // for tabPage2，顯示庫存表格
        private void Load_Inventory_Data(string query)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    MySqlDataAdapter adapter = new MySqlDataAdapter(query, connection);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    dataGridView2.DataSource = dataTable;
                    dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        

        // 表格的條件格式化>庫存低於80時，背景色變為淺紅色 
        private void dataGridView_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView2.Rows)
            {
                if (row.IsNewRow) continue; // 跳過最後一行的空白輸入行

                object cellValue = row.Cells["庫存數量"].Value;
                int qty = 0;
                if (cellValue != null && int.TryParse(cellValue.ToString(), out qty))
                {
                    if (qty <= 80)
                        row.DefaultCellStyle.BackColor = Color.LightCoral;
                    else
                        row.DefaultCellStyle.BackColor = Color.White;
                }
            }
        }


        private void ApplyFilter_inventoryPage()
        {
            List<string> suppliers = new List<string>();
            if(supplierA.Checked)
            {
                suppliers.Add("'A'");
            }
            if(supplierB.Checked)
            {
                suppliers.Add("'B'");
            }
            if(supplierC.Checked)
            {
                suppliers.Add("'C'");
            }
            if(supplierD.Checked)
            {
                suppliers.Add("'D'");
            }
            if(supplierE.Checked)
            {
                suppliers.Add("'E'");
            }

            List<string> products = new List<string>();
            if(toothbrush.Checked)
            {
                products.Add("'toothbrush'");
            }   
            if(toothpaste.Checked)
            {
                products.Add("'toothpaste'");
            }
            if(shampoo.Checked)
            {
                products.Add("'shampoo'");
            }   
            if(shaver.Checked)
            {
                products.Add("'shaver'");
            }
            if(comb.Checked)
            {
                products.Add("'comb'");
            }

            // 如果有選擇條件，就會產生s.name IN('A','B'...)
            // 如果沒有選擇供應商或產品，則使用1=1作為條件，表示不過濾
            string supplierFilter = suppliers.Count > 0 ? $"s.name IN ({string.Join(",",suppliers)})" : "1=1";
            string productFilter = products.Count > 0 ? $"prod.name IN ({string.Join(",", products)})" : "1=1";
            string query = $@"
                SELECT
                  prod.name as '產品名稱',
                  s.name as '供應商名稱',
                  COALESCE(t_sum.sum_q, 0) + COALESCE(p.quantity, 0) AS '庫存數量'
                FROM
                  (
                    SELECT
                      t.product_id,
                      t.supplier_id,
                      SUM(CASE WHEN t.transaction_type = 'IN' THEN t.quantity ELSE 0 END)
                      -
                      SUM(CASE WHEN t.transaction_type = 'OUT' THEN t.quantity ELSE 0 END) AS sum_q
                    FROM
                      transactions t
                    GROUP BY
                      t.product_id, t.supplier_id
                  ) t_sum
                LEFT JOIN product_suppliers p
                  ON t_sum.product_id = p.product_id AND t_sum.supplier_id = p.supplier_id
                LEFT JOIN products prod
                  ON t_sum.product_id = prod.product_id
                LEFT JOIN supplier s
                  ON t_sum.supplier_id = s.supplier_id
                WHERE
                  {supplierFilter} AND {productFilter}";


            Load_Inventory_Data(query);
        }

        

        private void supplierA_CheckedChanged(object sender, EventArgs e)
        {
            ApplyFilter_inventoryPage();
        }
        private void supplierB_CheckedChanged(object sender, EventArgs e)
        {
            ApplyFilter_inventoryPage();
        }
        private void supplierC_CheckedChanged(object sender, EventArgs e)
        {
            ApplyFilter_inventoryPage();
        }
        private void supplierD_CheckedChanged(object sender, EventArgs e)
        {
            ApplyFilter_inventoryPage();
        }
        private void supplierE_CheckedChanged(object sender, EventArgs e)
        {
            ApplyFilter_inventoryPage();
        }
        private void toothbrush_CheckedChanged(object sender, EventArgs e)
        {
            ApplyFilter_inventoryPage();
        }
        private void toothpaste_CheckedChanged(object sender, EventArgs e)
        {
            ApplyFilter_inventoryPage();
        }
        private void shampoo_CheckedChanged(object sender, EventArgs e)
        {
            ApplyFilter_inventoryPage();
        }
        private void shaver_CheckedChanged(object sender, EventArgs e)
        {
            ApplyFilter_inventoryPage();
        }
        private void comb_CheckedChanged(object sender, EventArgs e)
        {
            ApplyFilter_inventoryPage();
        }


        private void LoadSupplierComboBox(ComboBox targetComboBox)
        {
            targetComboBox.Items.Clear();
            targetComboBox.Items.Add("全部");
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    MySqlCommand command = new MySqlCommand("SELECT name FROM supplier", connection);
                    MySqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        targetComboBox.Items.Add(reader.GetString("name"));
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
            targetComboBox.SelectedIndex = 0; // 預設選擇"全部"
        }

        private void LoadProductComboBox(ComboBox targetComboBox)
        {
            targetComboBox.Items.Clear();
            targetComboBox.Items.Add("全部");
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    MySqlCommand command = new MySqlCommand("SELECT name FROM products", connection);
                    MySqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        targetComboBox.Items.Add(reader.GetString("name"));
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
            targetComboBox.SelectedIndex = 0; // 預設選擇"全部"
        }

        private void ApplyFilter_transactionPage()
        {
            // 取得 ComboBox 目前選到的選項
            string supplier = comboBoxSupplier_tab3.SelectedItem?.ToString() ?? "全部";
            string product = comboBoxProduct_tab3.SelectedItem?.ToString() ?? "全部";
            string type = comboBoxTransactionType.SelectedItem?.ToString() ?? "全部";
            DateTime startDate = dateTimePickerStart.Value.Date;
            DateTime endDate = dateTimePickerEnd.Value.Date;

            // 動態組合查詢條件
            List<string> filters = new List<string>();

            if (supplier != "全部")
                filters.Add("s.name = @supplier");
            if (product != "全部")
                filters.Add("p.name = @product");
            if (type != "全部")
                filters.Add("t.transaction_type = @type");

            filters.Add("t.transaction_date BETWEEN @startDate AND @endDate");

            string whereClause = filters.Count > 0 ? "WHERE " + string.Join(" AND ", filters) : "";

            string query = $@"
                SELECT
                    t.transaction_id AS '交易ID',
                    p.name AS '產品名稱',
                    s.name AS '供應商名稱',
                    t.transaction_type AS '交易類型',
                    t.transaction_date AS '交易日期',
                    t.quantity AS '數量'
                FROM transactions t
                LEFT JOIN products p ON t.product_id = p.product_id
                LEFT JOIN supplier s ON t.supplier_id = s.supplier_id
                {whereClause}
                ";

            // 送出查詢
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    MySqlCommand cmd = new MySqlCommand(query, connection);

                    // 綁定參數
                    if (supplier != "全部") cmd.Parameters.AddWithValue("@supplier", supplier);
                    if (product != "全部") cmd.Parameters.AddWithValue("@product", product);
                    if (type != "全部") cmd.Parameters.AddWithValue("@type", type);

                    cmd.Parameters.AddWithValue("@startDate", startDate);
                    cmd.Parameters.AddWithValue("@endDate", endDate);

                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dataGridView3.DataSource = dt;
                    dataGridView3.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
            }

        private void comboBoxSupplier_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApplyFilter_transactionPage();
        }

        private void comboBoxProduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApplyFilter_transactionPage();
        }

        private void comboBoxTransactionType_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApplyFilter_transactionPage();
        }

        private void dateTimePickerStart_ValueChanged(object sender, EventArgs e)
        {
            ApplyFilter_transactionPage();
        }

        private void dateTimePickerEnd_ValueChanged(object sender, EventArgs e)
        {
            ApplyFilter_transactionPage();
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            ApplyFilter_transactionPage();
        }

        private int GetCurrentStock(string supplier, string product)
        {
            // 這個方法可以用來查詢目前庫存數量
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = @"
                        SELECT COALESCE(SUM(CASE WHEN t.transaction_type = 'IN' THEN t.quantity ELSE 0 END), 0) - 
                               COALESCE(SUM(CASE WHEN t.transaction_type = 'OUT' THEN t.quantity ELSE 0 END), 0) AS current_stock
                        FROM transactions t
                        LEFT JOIN products p ON t.product_id = p.product_id
                        LEFT JOIN supplier s ON t.supplier_id = s.supplier_id
                        WHERE s.name = @supplier AND p.name = @product";
                    MySqlCommand command = new MySqlCommand(query, connection);
                    command.Parameters.AddWithValue("@supplier", supplier);
                    command.Parameters.AddWithValue("@product", product);
                    object result = command.ExecuteScalar();
                    return Convert.ToInt32(result);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                    return 0;
                }
            }
        }

        private void UpdateStockHint()
        {
            // 假設你有 comboBoxSupplier, comboBoxProduct, comboBoxType, textBoxQuantity
            string supplier = comboBoxSupplier_tab4.SelectedItem?.ToString();
            string product = comboBoxProduct_tab4.SelectedItem?.ToString();
            string type = comboBoxType_tab4.SelectedItem?.ToString();
            int qty = 0;
            int.TryParse(textBoxQuantity.Text, out qty);

            if(supplier == "全部" || product == "全部" || type == "全部" || string.IsNullOrEmpty(supplier) || string.IsNullOrEmpty(product))
            {
                labelCurrentStock.Text = "目前庫存：-";
                labelAfterStock.Text = "交易後庫存：-";
                return;
            }

            // 查詢目前庫存
            int currentStock = GetCurrentStock(supplier, product); // 你需要寫這個查詢資料庫的方法

            int afterStock = type == "IN" ? currentStock + qty : currentStock - qty;

            labelCurrentStock.Text = $"目前庫存：{currentStock}";
            labelAfterStock.Text = $"交易後庫存：{afterStock}";

            labelCurrentStock.ForeColor = Color.SeaGreen;
            labelAfterStock.ForeColor = afterStock < 0 ? Color.Red : Color.IndianRed;

            // 你要 panelHint.Visible = true; （或讓 panelHint 顯示/隱藏）
        }

    }
}
