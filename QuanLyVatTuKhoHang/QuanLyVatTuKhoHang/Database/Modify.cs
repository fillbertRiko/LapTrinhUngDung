using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using QuanLyVatTuKhoHang.QuanLyVatTuKhoHang.Database;
using QuanLyVatTuKhoHang.QuanLyVatTuKhoHang.Models;

namespace QuanLyVatTuKhoHang.QuanLyVatTuKhoHang.Database
{
    public class Modify
    {
        public Modify()
        {
        }

        //lay method lay danh sach Employee dua vao truy van SQL va danh sach tham so
        public List<Employee> Employees(string query, List<SqlParameter> parameters)
        {
            List<Employee> employees = new List<Employee>();
            try
            {
                using (SqlConnection connec = Connection.GetSqlConnection())
                {
                    //mo ket noi neu chua mo
                    if (connec.State == ConnectionState.Closed)
                    {
                        connec.Open();
                    }

                    using (SqlCommand cmd = new SqlCommand(query, connec))
                    {
                        if (parameters != null && parameters.Count > 0)
                        {
                            cmd.Parameters.AddRange(parameters.ToArray());
                        }

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                employees.Add(new Employee(reader["EmployeeID"].ToString(), reader["Password"].ToString()));
                            }
                        }
                    }

                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Bug: " + ex.Message);
            }
            return employees;
        }
    }
}

