using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using UngDungQuanLyKho.Data.Models;
using System.Data;

namespace UngDungQuanLyKho.Data.Database
{
    class Modify
    {
        public Modify()
        {
        }

        //cau lenh dung de truy van insert, update delete
        SqlCommand cmd;
        //doc du lieu trong bang
        SqlDataReader reader;

        //ham tra ve list danh sach
        public List<Employee> Employees(string query)
        {
            List<Employee> employees = new List<Employee>();

            //thuc thi cau lenh trong using roi xoa no di
            using (SqlConnection sqlConnection = Connection.GetSqlConnection())
            {
                sqlConnection.Open();
                cmd = new SqlCommand(query, sqlConnection);
                reader = cmd.ExecuteReader();    //tien hanh doc 
                while (reader.Read())
                {
                    employees.Add(new Employee(reader.GetString(3),reader.GetString(4)));
                }

                sqlConnection.Close();
            }

            return employees;
        }

        void LoadAccountList()
        {
            string query = "SELECT * FROM Employees";
            SqlCommand cmd = new SqlCommand(query, Connection.GetSqlConnection());

            DataTable data = new DataTable();

            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(data);

            Connection.GetSqlConnection().Close();

            //hien thi datasource o day
        }
    }
}
