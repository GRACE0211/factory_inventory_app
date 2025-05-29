using System.data;
using MySql.Data.MySqlClient;
namespace factory_inventory_app;


public partial class Form1 : Form
{
    string connectionString = "server=localhost;user=root;password=0905656870;database=factory_inventory;port=3306;SslMode=None;";
    public Form1()
    {
        InitializeComponent();

    }
    private void btnShowSuppliers_Click(object sender, EventArgs e)
    {
        LoadData("SELECT * FROM products");
    }

    private void btnShowProducts_Click(object sender, EventArgs e)
    {
        LoadData("SELECT * FROM supplier");
    }

    private void LoadData(string query)
    {
        using (MySqlConnection connection = new MySqlConnection(connectionString))
        {
            MySqlCommand command = new MySqlCommand(query, connection);
            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            DataTable dataTable = new DataTable();
            try
            {
                connection.Open();
                adapter.Fill(dataTable);
                dataGridView1.DataSource = dataTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
    }
}
