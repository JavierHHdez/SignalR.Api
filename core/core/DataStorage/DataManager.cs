using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using core.Models;

namespace core.DataStorage
{
    public static class DataManager
    {
        public static List<Employee> GetData()
        {

            List<Employee> employee = new List<Employee>();

            using (SqlConnection connection = new SqlConnection("Data Source=EISEILAP0114;Initial Catalog=Base.api;Integrated Security=True"))
            {
                connection.Open();
                string query = "SELECT * FROM [dbo].[Employees]";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                           employee.Add(new Employee() {
                               EmployeeId = Convert.ToInt32(reader["EmployeeId"]),
                               FirstName = Convert.ToString(reader["FirstName"]),
                               LastName = Convert.ToString(reader["LastName"]),
                               DateOfBirth = Convert.ToDateTime(reader["DateOfBirth"]),
                               PhoneNumber = Convert.ToString(reader["PhoneNumber"]),
                               Email = Convert.ToString(reader["Email"]),
                               Gender = Convert.ToString(reader["Gender"])
                           });
                        }
                    }
                }
                connection.Close();
            }

            return employee;
        }
    }
}
