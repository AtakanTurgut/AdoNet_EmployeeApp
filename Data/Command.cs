using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class Command
    {
        Connection Connection = new Connection();

        public SqlCommand SQLCommand(string sqlCommand) 
        {
            SqlCommand cmd = new SqlCommand(sqlCommand, Connection.OpenConnection());
           
            return cmd;
        }
    }
}
