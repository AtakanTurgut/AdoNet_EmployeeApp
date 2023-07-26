using Data;
using Service.DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class Employee : IEmployee
    {
        Connection connection = new Connection(); 
        Command command = new Command();

        public List<EmployeeDTO> employees(string sqlCommand)
        {
            SqlCommand cmd = command.SQLCommand(sqlCommand);
            SqlDataReader dataReader = cmd.ExecuteReader();

            List<EmployeeDTO> employees = new List<EmployeeDTO>();

            while (dataReader.Read())
            {
                employees.Add(new EmployeeDTO
                {
                    Id = Convert.ToInt32(dataReader["Id"].ToString()),
                    Name = dataReader["Name"].ToString(),
                    Surname = dataReader["Surname"].ToString(),
                    DateOfRegistration = Convert.ToDateTime(dataReader["DateOfRegistration"].ToString()),
                });
            }

            connection.CloseConnection();
            return employees;
        }

        public int insert(string sqlCommand)
        {
            SqlCommand cmd = command.SQLCommand(sqlCommand);
            cmd.ExecuteNonQuery();

            connection.CloseConnection();
            return 0;
        }

        public void delete(string sqlCommand)
        {
            SqlCommand cmd = command.SQLCommand(sqlCommand);
            cmd.ExecuteNonQuery();

            connection.CloseConnection();
        }

        public void update(string sqlCommand)
        {
            SqlCommand cmd = command.SQLCommand(sqlCommand);
            cmd.ExecuteNonQuery();

            connection.CloseConnection();
        }
    }
}
