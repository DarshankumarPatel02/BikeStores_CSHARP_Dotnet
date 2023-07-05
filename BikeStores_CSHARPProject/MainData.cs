using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BikeStores_CSHARPProject
{
    public partial class MainData : Form
    {
        public MainData()
        {
            InitializeComponent();
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            //Close Form
            this.Close();
        }

        private void Change_Click(object sender, EventArgs e)
        {
            //Add Modify Delete Form Pop-up
            FormAMD operation = new FormAMD();
            operation.ShowDialog();
        }

        private void MainData_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'bikeStoresDataSet.customers' table. You can move, or remove it, as needed.
            this.customersTableAdapter.Fill(this.bikeStoresDataSet.customers);
        }

        private void Reload_Click(object sender, EventArgs e)
        {
            //Refreshing datagridview using DataAdapter(select query)
            SqlConnection connection = BikeStoresDB.GetConnection();
            SqlDataAdapter sda=new SqlDataAdapter(@"SELECT customer_id, first_name,last_name,email,street, city, state, zip_code FROM sales.customers ",connection);
            DataTable dt=new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void Query_Click(object sender, EventArgs e)
        {
            //Query Form Pop-up
            QueryBuilder query = new QueryBuilder();
            query.ShowDialog();
        }
    }
}
