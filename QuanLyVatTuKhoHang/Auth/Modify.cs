using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data.SqlClient;

namespace QuanLyVatTuKhoHang.Auth
{
    class Modify
    {
        public Modify()
        {
        }

        //dung de truy van cac cau lenh trong bangr
        SqlCommand cmd;
        //dung de doc du lieu trong bang
        SqlDataReader dataReader;

        public List<Employee> Employees(string query)
        {
            List<Employee> employees = new List<Employee>();
            using (SqlConnection conn = Connection.GetSqlConnection())
            {
                conn.Open();
                cmd = new SqlCommand(query, conn);
                dataReader = cmd.ExecuteReader();

                while (dataReader.Read())
                {
                    employees.Add(new Employee(dataReader.GetString(0),dataReader.GetString(1)));
                }

                conn.Close();
            }

            return employees;
        }
    }
}
