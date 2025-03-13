using QuanLyVatTuKhoHang.Auth;
using System.Collections.Generic;
using System.Data.SqlClient;
using QuanLyVatTuKhoHang.Class;
using System;

namespace QuanLyVatTuKhoHang.Class
{
    public class Modify
    {
        public Modify()
        {
        }

        //dung de truy van cac cau lenh trong bangr
        SqlCommand cmd;
        //dung de doc du lieu trong bang
        SqlDataReader dataReader;

        public List<Employee> Employees(string query, List<SqlParameter> parameters)
        {
            List<Employee> employees = new List<Employee>();
            try
            {
                connec.Open();
                
                    using (SqlCommand cmd = new SqlCommand(query, connec))
                    {
                        cmd.Parameters.AddRange(parameters.ToArray());
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                employees.Add(new Employee(reader["EmployeeID"].ToString(), reader["Password"].ToString()));
                            }
                        }
                    }
                
            }
            catch(Exception ex) {
                Console.WriteLine("Bug: " +ex.Message);
            }
            return employees;
        }
    }
}
