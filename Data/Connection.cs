using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class Connection
    {
        SqlConnection conn = new SqlConnection("Data Source=DESKTOP-R6K64T9\\SQLEXPRESS;Initial Catalog=AdoEmployee;Integrated Security=True");

        public SqlConnection OpenConnection()
        {
            conn.Open();   
            return conn;
        }

        public SqlConnection CloseConnection()
        {
            conn.Close();
            return conn;
        }
    }
}
