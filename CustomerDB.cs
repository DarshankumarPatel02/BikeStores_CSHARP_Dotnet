using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeStores_CSHARPProject
{
    internal class CustomerDB
    {
        //query to get customer_info using customer_id(select query)
        public static Customer GetCustomer(int customerID)
        {
            SqlConnection connection = BikeStoresDB.GetConnection();
            string selectStatement = "SELECT customer_id, first_name,last_name, " +
                "email,street, city, state, zip_code " +
                "FROM sales.customers "
                + "WHERE customer_id = @customer_id";
            SqlCommand selectCommand = new SqlCommand(selectStatement, connection);
            selectCommand.Parameters.AddWithValue("@customer_id", customerID);

            try
            {
                connection.Open();
                SqlDataReader custReader =
                    selectCommand.ExecuteReader(System.Data.CommandBehavior.SingleRow);
                if (custReader.Read())
                {
                    Customer customer = new Customer();
                    customer.customer_id = (int)custReader["customer_id"];
                    customer.first_name = custReader["first_name"].ToString();
                    customer.last_name = custReader["last_name"].ToString();
                    customer.email = custReader["email"].ToString();
                    customer.street = custReader["street"].ToString();
                    customer.city = custReader["city"].ToString();
                    customer.state = custReader["state"].ToString();
                    customer.zip_code = custReader["zip_code"].ToString();
                    return customer;
                }
                else
                {
                    return null;
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
            }
        }
        //Modify an existing customer(Update query)
        public static bool UpdateCustomer(Customer oldCustomer,
            Customer newCustomer)
        {
            SqlConnection connection = BikeStoresDB.GetConnection();
            string updateStatement =
                "UPDATE sales.customers SET " +
                "first_name = @Newfirst_name, " +
                "last_name = @Newlast_name, " +
                "email = @Newemail, " +
                "street = @Newstreet, " +
                "city = @Newcity, " +
                "state = @Newstate, " +
                "zip_code = @Newzip_code " +
                "WHERE customer_id = @Oldcustomer_id " +
                "AND first_name = @Oldfirst_name " +
                "AND last_name = @Oldlast_name " +
                "AND email = @Oldemail " +
                "AND street = @Oldstreet " +
                "AND city = @Oldcity " +
                "AND state = @Oldstate " +
                "AND zip_code = @Oldzip_code ";

            SqlCommand updateCommand =
                new SqlCommand(updateStatement, connection);

            updateCommand.Parameters.AddWithValue(
                "@Newfirst_name", newCustomer.first_name);
            updateCommand.Parameters.AddWithValue(
                "@Newlast_name", newCustomer.last_name);
            updateCommand.Parameters.AddWithValue(
                "@Newemail", newCustomer.email);
            updateCommand.Parameters.AddWithValue(
                "@Newstreet", newCustomer.street);
            updateCommand.Parameters.AddWithValue(
                "@Newcity", newCustomer.city);
            updateCommand.Parameters.AddWithValue(
                "@Newstate", newCustomer.state);
            updateCommand.Parameters.AddWithValue(
                "@Newzip_code", newCustomer.zip_code);

            updateCommand.Parameters.AddWithValue(
            "@Oldcustomer_id", oldCustomer.customer_id);
            updateCommand.Parameters.AddWithValue(
                "@Oldfirst_name", oldCustomer.first_name);
            updateCommand.Parameters.AddWithValue(
                "@Oldlast_name", oldCustomer.last_name);
            updateCommand.Parameters.AddWithValue(
                "@Oldemail", oldCustomer.email);
            updateCommand.Parameters.AddWithValue(
                "@Oldstreet", newCustomer.street); 
            updateCommand.Parameters.AddWithValue(
                "@Oldcity", oldCustomer.city);
            updateCommand.Parameters.AddWithValue(
                "@Oldstate", oldCustomer.state);
            updateCommand.Parameters.AddWithValue(
                "@Oldzip_code", oldCustomer.zip_code);
            try
            {
                connection.Open();
                int count = updateCommand.ExecuteNonQuery();
                if (count > 0)
                    return true;
                else
                    return false;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
            }
        }
        //Adding new customer(insert query)
        public static int AddCustomer(Customer customer)
        {
            SqlConnection connection = BikeStoresDB.GetConnection();
            string insertStatement =
                "INSERT sales.customers " +
                "(first_name, last_name, email, street, city, state, zip_code) " +
                "VALUES (@first_name, @last_name, @email, @street, @city, @state, @zip_code)";
            SqlCommand insertCommand =
                new SqlCommand(insertStatement, connection);
            insertCommand.Parameters.AddWithValue(
                 "@first_name", customer.first_name);
            insertCommand.Parameters.AddWithValue(
                 "@last_name", customer.last_name);
            insertCommand.Parameters.AddWithValue(
                 "@email", customer.email);
            insertCommand.Parameters.AddWithValue(
                "@street", customer.street);
            insertCommand.Parameters.AddWithValue(
                "@city", customer.city);
            insertCommand.Parameters.AddWithValue(
                "@state", customer.state);
            insertCommand.Parameters.AddWithValue(
                "@zip_code", customer.zip_code);
            try
            {
                connection.Open();
                insertCommand.ExecuteNonQuery();
                string selectStatement =
                    "SELECT IDENT_CURRENT('sales.customers') FROM sales.customers";
                SqlCommand selectCommand =
                    new SqlCommand(selectStatement, connection);
                int customerID = Convert.ToInt32(selectCommand.ExecuteScalar());
                return customerID;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
            }
        }
        //Delete Existing Customer(Delete Query)
        public static bool DeleteCustomer(Customer customer)
        {
            SqlConnection connection = BikeStoresDB.GetConnection();
            string deleteStatement =
                "DELETE FROM sales.customers " +
                "WHERE customer_id = @customer_id " +
                "AND first_name = @first_name " +
                "AND last_name = @last_name " +
                "AND email = @email " +
                "AND street = @street " +
                "AND city = @city " +
                "AND state = @state " +
                "AND zip_code = @zip_code";
            SqlCommand deleteCommand =
                new SqlCommand(deleteStatement, connection);
            deleteCommand.Parameters.AddWithValue(
                "@customer_id", customer.customer_id);
            deleteCommand.Parameters.AddWithValue(
                "@first_name", customer.first_name);
            deleteCommand.Parameters.AddWithValue(
                "@last_name", customer.last_name);
            deleteCommand.Parameters.AddWithValue(
                "@email", customer.email);
            deleteCommand.Parameters.AddWithValue(
                "@street", customer.street);
            deleteCommand.Parameters.AddWithValue(
                "@city", customer.city);
            deleteCommand.Parameters.AddWithValue(
                "@state", customer.state);
            deleteCommand.Parameters.AddWithValue(
                "@zip_code", customer.zip_code);
            try
            {
                connection.Open();
                int count = deleteCommand.ExecuteNonQuery();
                if (count > 0)
                    return true;
                else
                    return false;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
            }
        }
    }
}