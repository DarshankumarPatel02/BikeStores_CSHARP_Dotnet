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
    public partial class QueryBuilder : Form
    {
        public QueryBuilder()
        {
            InitializeComponent();
        }
        private void Execute_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection connection = BikeStoresDB.GetConnection();
                string query = QuertTxtBox.Text;
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                DataSet ds = new DataSet();
                adapter.Fill(ds);
                connection.Close();
                if (ds.Tables[0].Rows.Count != 0)
                {
                    dataGridView1.DataSource = ds.Tables[0];
                }
                else
                {
                    MessageBox.Show("No Data Found!!!");
                }
            }
            catch(Exception)
            {
                MessageBox.Show("Wrong Query");
            }
        }
    }
}
