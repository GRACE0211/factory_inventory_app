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

            // 切換不同分頁不用重新載入，所以寫在這裡
            // 只要選單內容有變動，就要執行 UpdateStockHint()
            this.comboBoxSupplier_tab4.SelectedIndexChanged += (sender, e) => UpdateStockHint();
            this.comboBoxProduct_tab4.SelectedIndexChanged += (sender, e) => UpdateStockHint();
            this.comboBoxType_tab4.SelectedIndexChanged += (sender, e) => UpdateStockHint();
            this.textBoxQuantity.TextChanged += (sender, e) => UpdateStockHint();
        }



        // 根據不同的tabPage頁面,載入不同的資料表格
        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // tabPage2頁面：“庫存” 一載入時，載入庫存表
            if (tabControl1.SelectedTab == tabPage2)
            {
                ApplyFilter_inventoryPage();
            }

            // tabPage3：“交易資料” 頁面一載入時，載入下拉式選單的選項以及庫存異動表格
            else if (tabControl1.SelectedTab == tabPage3)
            {
                LoadSupplierComboBox(comboBoxSupplier_tab3);
                LoadProductComboBox(comboBoxProduct_tab3);
                dateTimePickerStart.Value = new DateTime(2024, 12, 1);
                dateTimePickerEnd.MaxDate = DateTime.Today; // 設定日期選擇器的最大日期為今天
                comboBoxTransactionType.SelectedIndex = 0; // 預設選擇"全部"
                comboBoxProduct_tab3.SelectedIndex = 0; // 預設選擇"全部"
                comboBoxSupplier_tab3.SelectedIndex = 0; // 預設選擇"全部"
                ApplyFilter_transactionPage();
            }

            // tabPage4：“新增交易” 頁面載入時載入下拉式選單的選項
            else if (tabControl1.SelectedTab == tabPage4)
            {
                LoadSupplierComboBox(comboBoxSupplier_tab4);
                LoadProductComboBox(comboBoxProduct_tab4);
            }
        }

        // tabPage1: “基本資料” 根據不同按鈕，載入資料庫中的產品和供應商資料
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



        // 表格的條件格式化 -> 庫存低於80時，背景色變為淺紅色 
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
                        row.DefaultCellStyle.BackColor = Color.FromArgb(230,169,169);
                    else
                        row.DefaultCellStyle.BackColor = Color.White;
                }
            }
        }


        private void ApplyFilter_inventoryPage()
        {
            List<string> suppliers = new List<string>();
            // 若有勾選就加入suppliers陣列
            if (supplierA.Checked)
            {
                suppliers.Add("'A'");
            }
            if (supplierB.Checked)
            {
                suppliers.Add("'B'");
            }
            if (supplierC.Checked)
            {
                suppliers.Add("'C'");
            }
            if (supplierD.Checked)
            {
                suppliers.Add("'D'");
            }
            if (supplierE.Checked)
            {
                suppliers.Add("'E'");
            }

            // 若有勾選就加入products陣列
            List<string> products = new List<string>();
            if (toothbrush.Checked)
            {
                products.Add("'toothbrush'");
            }
            if (toothpaste.Checked)
            {
                products.Add("'toothpaste'");
            }
            if (shampoo.Checked)
            {
                products.Add("'shampoo'");
            }
            if (shaver.Checked)
            {
                products.Add("'shaver'");
            }
            if (comb.Checked)
            {
                products.Add("'comb'");
            }

            // 如果有選擇條件，就會產生s.name IN('A','B'...)
            // 如果沒有選擇供應商或產品，則使用1=1作為條件，表示不過濾
            string supplierFilter = suppliers.Count > 0 ? $"s.name IN ({string.Join(",", suppliers)})" : "1=1";
            string productFilter = products.Count > 0 ? $"prod.name IN ({string.Join(",", products)})" : "1=1";
            string query = $@"
                SELECT
                  prod.name AS '產品名稱',
                  s.name AS '供應商名稱',
                  ps.quantity + COALESCE(SUM(
                    CASE
                      WHEN t.transaction_type = 'IN' THEN t.quantity
                      WHEN t.transaction_type = 'OUT' THEN -t.quantity
                      ELSE 0
                    END
                  ), 0) AS '庫存數量'
                FROM
                  product_suppliers ps
                JOIN products prod ON ps.product_id = prod.product_id
                JOIN supplier s ON ps.supplier_id = s.supplier_id
                LEFT JOIN transactions t
                  ON t.product_id = ps.product_id AND t.supplier_id = ps.supplier_id
                WHERE
                  {supplierFilter} AND {productFilter}
                GROUP BY
                  ps.product_id, ps.supplier_id, ps.quantity, prod.name, s.name";



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
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = @"
                SELECT 
                    ps.quantity + COALESCE(SUM(
                        CASE
                            WHEN t.transaction_type = 'IN' THEN t.quantity
                            WHEN t.transaction_type = 'OUT' THEN -t.quantity
                            ELSE 0
                        END
                    ), 0) AS current_stock
                FROM product_suppliers ps
                JOIN products p ON ps.product_id = p.product_id
                JOIN supplier s ON ps.supplier_id = s.supplier_id
                LEFT JOIN transactions t
                    ON t.product_id = ps.product_id AND t.supplier_id = ps.supplier_id
                WHERE s.name = @supplier AND p.name = @product
                GROUP BY ps.quantity";
                    MySqlCommand command = new MySqlCommand(query, connection);
                    command.Parameters.AddWithValue("@supplier", supplier);
                    command.Parameters.AddWithValue("@product", product);
                    object result = command.ExecuteScalar();
                    return result == DBNull.Value ? 0 : Convert.ToInt32(result);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                    return 0;
                }
            }
        }


        // 動態顯示庫存提示
        private void UpdateStockHint()
        {
            // 假設你有 comboBoxSupplier, comboBoxProduct, comboBoxType, textBoxQuantity
            string supplier = comboBoxSupplier_tab4.SelectedItem?.ToString();
            string product = comboBoxProduct_tab4.SelectedItem?.ToString();
            string type = comboBoxType_tab4.SelectedItem?.ToString();
            int qty = 0;
            int.TryParse(textBoxQuantity.Text, out qty);

            // 如果還沒選擇供應商或產品，庫存還不會顯示
            if (supplier == "全部" || product == "全部" || string.IsNullOrEmpty(supplier) || string.IsNullOrEmpty(product))
            {
                labelCurrentStock.Text = "目前庫存：-";
                labelAfterStock.Text = "交易後庫存：-";
                return;
            }

            // 選擇供應商或產品之後就會顯示庫存
            // 查詢目前庫存
            int currentStock = GetCurrentStock(supplier, product);

            int afterStock = CalculateAfterStock();

            labelCurrentStock.Text = $"目前庫存：{currentStock}";
            labelAfterStock.Text = $"交易後庫存：{afterStock}";

            labelCurrentStock.ForeColor = currentStock > 80 ? Color.FromArgb(1,105,74) : Color.FromArgb(176, 28, 28);
            labelAfterStock.ForeColor = afterStock > 80 ? Color.FromArgb(1, 105, 74) : Color.FromArgb(176, 28, 28);


        }

        private int CalculateAfterStock()
        {
            string supplier = comboBoxSupplier_tab4.SelectedItem?.ToString();
            string product = comboBoxProduct_tab4.SelectedItem?.ToString();
            int qty = 0;
            int.TryParse(textBoxQuantity.Text, out qty);
            if (supplier == "全部" || product == "全部" || string.IsNullOrEmpty(supplier) || string.IsNullOrEmpty(product))
            {
                return 0;
            }
            // 查詢目前庫存
            int currentStock = GetCurrentStock(supplier, product);
            int afterStock = currentStock + (comboBoxType_tab4.SelectedItem.ToString() == "IN" ? qty : -qty);
            return afterStock;
        }

        private void submitButton_Click(object sender, EventArgs e)
        {
            int afterStock = CalculateAfterStock();
            string supplier = comboBoxSupplier_tab4.SelectedItem?.ToString();
            string product = comboBoxProduct_tab4.SelectedItem?.ToString();
            string type = comboBoxType_tab4.SelectedItem?.ToString();
            string quantity = textBoxQuantity.Text;
            DateTime date = dateTimePicker_trans.Value;
            string detailMsg =
                $"確認交易內容: \n\n" +
                $"供應商: {supplier}\n" +
                $"產品: {product}\n" +
                $"類型: {type}\n" +
                $"數量: {quantity}\n" +
                $"交易日期: {date}\n\n" +
                $"確定要進行交易嗎?";

            if (afterStock < 50)
            {
                MessageBox.Show($"庫存僅剩{afterStock} (低於50)，無法進行交易!", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (afterStock >= 50 && afterStock <= 80 && type == "OUT")
            {
                DialogResult result = MessageBox.Show($"交易後庫存量為{afterStock}，確定要進行交易?", "提醒", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.No)
                {
                    return; // 如果使用者選擇否，則不進行交易
                }
                else
                {
                    DialogResult confirmResult = MessageBox.Show(detailMsg, "確認交易", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (confirmResult == DialogResult.Yes)
                    {
                        int supplierId = -1, productId = -1;
                        using (var conn = new MySqlConnection(connectionString))
                        {
                            conn.Open();

                            // 查 supplier_id
                            var cmdSupplier = new MySqlCommand("SELECT supplier_id FROM supplier WHERE name = @name", conn);
                            cmdSupplier.Parameters.AddWithValue("@name", supplier);
                            object supIdResult = cmdSupplier.ExecuteScalar();
                            if (supIdResult != null) supplierId = Convert.ToInt32(supIdResult);

                            // 查 product_id
                            var cmdProduct = new MySqlCommand("SELECT product_id FROM products WHERE name = @name", conn);
                            cmdProduct.Parameters.AddWithValue("@name", product);
                            object prodIdResult = cmdProduct.ExecuteScalar();
                            if (prodIdResult != null) productId = Convert.ToInt32(prodIdResult);

                            if (supplierId == -1 || productId == -1)
                            {
                                MessageBox.Show("查無對應產品或供應商ID");
                                return;
                            }

                            // Insert 新交易
                            var cmdInsert = new MySqlCommand(
                                @"INSERT INTO transactions (product_id, supplier_id, transaction_type, quantity, transaction_date)
          VALUES (@pid, @sid, @type, @qty, @date)", conn);
                            cmdInsert.Parameters.AddWithValue("@pid", productId);
                            cmdInsert.Parameters.AddWithValue("@sid", supplierId);
                            cmdInsert.Parameters.AddWithValue("@type", type);
                            cmdInsert.Parameters.AddWithValue("@qty", quantity);
                            cmdInsert.Parameters.AddWithValue("@date", date);

                            int rows = cmdInsert.ExecuteNonQuery();
                            if (rows > 0)
                                MessageBox.Show("交易新增成功!", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            else
                                MessageBox.Show("交易新增失敗，請再試一次!", "失敗", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }

                    }
                    else
                    {
                        return; // 二次確認，如果使用者選擇否，則不進行交易
                    }
                }
            }
            else
            {
                DialogResult result = MessageBox.Show("確定進行交易?", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.No)
                {
                    return; // 如果使用者選擇否，則不進行交易
                }
                else
                {
                    DialogResult confirmResult = MessageBox.Show(detailMsg, "確認交易", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (confirmResult == DialogResult.Yes)
                    {
                        int supplierId = -1, productId = -1;
                        using (var conn = new MySqlConnection(connectionString))
                        {
                            conn.Open();

                            // 查 supplier_id
                            var cmdSupplier = new MySqlCommand("SELECT supplier_id FROM supplier WHERE name = @name", conn);
                            cmdSupplier.Parameters.AddWithValue("@name", supplier);
                            object supIdResult = cmdSupplier.ExecuteScalar();
                            if (supIdResult != null) supplierId = Convert.ToInt32(supIdResult);

                            // 查 product_id
                            var cmdProduct = new MySqlCommand("SELECT product_id FROM products WHERE name = @name", conn);
                            cmdProduct.Parameters.AddWithValue("@name", product);
                            object prodIdResult = cmdProduct.ExecuteScalar();
                            if (prodIdResult != null) productId = Convert.ToInt32(prodIdResult);

                            if (supplierId == -1 || productId == -1)
                            {
                                MessageBox.Show("查無對應產品或供應商ID");
                                return;
                            }

                            // Insert 新交易
                            var cmdInsert = new MySqlCommand(
                                @"INSERT INTO transactions (product_id, supplier_id, transaction_type, quantity, transaction_date)
          VALUES (@pid, @sid, @type, @qty, @date)", conn);
                            cmdInsert.Parameters.AddWithValue("@pid", productId);
                            cmdInsert.Parameters.AddWithValue("@sid", supplierId);
                            cmdInsert.Parameters.AddWithValue("@type", type);
                            cmdInsert.Parameters.AddWithValue("@qty", quantity);
                            cmdInsert.Parameters.AddWithValue("@date", date);

                            int rows = cmdInsert.ExecuteNonQuery();
                            if (rows > 0)
                                MessageBox.Show("交易新增成功!", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            else
                                MessageBox.Show("交易新增失敗，請再試一次!", "失敗", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }

                    }
                    else
                    {
                        return; // 二次確認，如果使用者選擇否，則不進行交易
                    }
                }
            }
        }


    }
}
