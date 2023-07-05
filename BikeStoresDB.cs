using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeStores_CSHARPProject
{
    //getting connnection class
    internal class BikeStoresDB
    {
        public static SqlConnection GetConnection()
        {
            string connectionString =
                "Data Source = (LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\BikeStores.mdf;" +
                "Integrated Security = True";

            SqlConnection conn = new SqlConnection(connectionString);
            return conn;
        }
    }
}
