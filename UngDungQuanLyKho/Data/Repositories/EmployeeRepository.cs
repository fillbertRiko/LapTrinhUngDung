using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UngDungQuanLyKho.Data.Models;
using UngDungQuanLyKho.Data.Database;
using System.Data.SqlClient;

namespace UngDungQuanLyKho.Data.Repositories
{
    public class EmployeeRepository
    {
        /*
        // Lấy danh sách nhân viên
        public List<Employee> Employees()
        {
            List<Employee> employees = new List<Employee>();

            // Sử dụng truy vấn đầy đủ với các cột trong bảng Employees
            string query = "SELECT EmployeeID, EmployeeName, Role, Email, Password FROM Employees";

            try
            {
                using (SqlConnection connection = Connection.GetSqlConnection())
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Employee employee = new Employee
                                {
                                    EmployeeID = reader.GetInt32(0),
                                    EmployeeName = reader.GetString(1),
                                    Role = reader.GetString(2),
                                    Email = reader.GetString(3),
                                    Password = reader.GetString(4)
                                };
                                employees.Add(employee);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Bug khi truy vấn dữ liệu người dùng", ex);
            }
            return employees;
        }

        // Xác thực đăng nhập
        public Employee ValidateLogin(string email, string password)
        {
            Employee employee = null;
            string query = @"SELECT EmployeeID, EmployeeName, Role, Email, Password 
                             FROM Employees 
                             WHERE Email = @Email AND Password = @Password";
            try
            {
                using (SqlConnection connection = Connection.GetSqlConnection())
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        // Sử dụng tham số trong query để phòng chống SQL Injection
                        cmd.Parameters.AddWithValue("@Email", email);
                        cmd.Parameters.AddWithValue("@Password", password);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                employee = new Employee
                                {
                                    EmployeeID = reader.GetInt32(0),
                                    EmployeeName = reader.GetString(1),
                                    Role = reader.GetString(2),
                                    Email = reader.GetString(3),
                                    Password = reader.GetString(4)
                                };
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi xác thực đăng nhập", ex);
            }

            return employee;
        }
        */
    }
}
