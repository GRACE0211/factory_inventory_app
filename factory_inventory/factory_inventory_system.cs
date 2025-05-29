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
        private string connectionString = "server=localhost;user id=root;password=0905656870;database=factory_inventory;SslMode=None";
        public factory_inventory_system()
        {
            InitializeComponent();
        }

        private void factory_inventory_system_Load(object sender, EventArgs e)
        {
            // Load initial data
            ApplyFilter();
        }

        private void btnShowProducts_Click(object sender, EventArgs e)
        {
            Load_Product_Supplier_Data("SELECT * FROM products");
        }

        private void btnShowSuppliers_Click(object sender, EventArgs e)
        {
            Load_Product_Supplier_Data("SELECT * FROM supplier");
        }

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

        private void dataGridView_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView2.Rows)
            {
                if (row.IsNewRow) continue; // 跳過新行

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


        private void ApplyFilter()
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
            ApplyFilter();
        }
        private void supplierB_CheckedChanged(object sender, EventArgs e)
        {
            ApplyFilter();
        }
        private void supplierC_CheckedChanged(object sender, EventArgs e)
        {
            ApplyFilter();
        }
        private void supplierD_CheckedChanged(object sender, EventArgs e)
        {
            ApplyFilter();
        }
        private void supplierE_CheckedChanged(object sender, EventArgs e)
        {
            ApplyFilter();
        }
        private void toothbrush_CheckedChanged(object sender, EventArgs e)
        {
            ApplyFilter();
        }
        private void toothpaste_CheckedChanged(object sender, EventArgs e)
        {
            ApplyFilter();
        }
        private void shampoo_CheckedChanged(object sender, EventArgs e)
        {
            ApplyFilter();
        }
        private void shaver_CheckedChanged(object sender, EventArgs e)
        {
            ApplyFilter();
        }
        private void comb_CheckedChanged(object sender, EventArgs e)
        {
            ApplyFilter();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        
    }
}
