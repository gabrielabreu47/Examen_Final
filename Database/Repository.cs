using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Database
{
    public class Repository
    {
        

        public bool ExecuteDml(SqlCommand cmd)
        {
            SqlConnection connection = new SqlConnection("Data Source = localhost\\SQLEXPRESS; Initial Catalog = EXAMEN_FINAL; Integrated Security = True");
            cmd.Connection = connection;
            try
            {
                connection.Open();
                cmd.ExecuteNonQuery();
                connection.Close();
                connection.Dispose();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        public DataTable ExecuteRead(string query)
        {
            SqlConnection connection = new SqlConnection("Data Source = localhost\\SQLEXPRESS; Initial Catalog = EXAMEN_FINAL; Integrated Security = True");
            try
            {
                DataTable dataTable = new DataTable();
                SqlCommand cmd = new SqlCommand(query, connection);
                connection.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dataTable);
                connection.Close();
                connection.Dispose();
                return dataTable;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }
    }
}
