using System;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;
using UngDungQuanLyKho.Data.Models;
using UngDungQuanLyKho.Data.Database; // Import lớp Connection

namespace UngDungQuanLyKho.Data.Auth
{
    public class AuthManager
    {
        // Hàm băm mật khẩu theo SHA2-256 và chuyển sang dạng chuỗi hex
        private static string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                // Chuyển đổi sang chuỗi hex giống SQL hàm CONVERT(..., 2)
                StringBuilder builder = new StringBuilder();
                foreach (byte b in bytes)
                {
                    builder.Append(b.ToString("x2")); // "x2" cho chữ thường, tương tự như LOWER() trong SQL
                }
                return builder.ToString();
            }
        }

        // Hàm xác thực người dùng
        public static UserModel AuthenticateUser(string username, string password)
        {
            try
            {
                Console.WriteLine($"Đang xác thực: {username} - {password} (Băm: {HashPassword(password)})");

                using (SqlConnection conn = Connection.GetSqlConnection())
                using (SqlCommand cmd = new SqlCommand("usp_CheckLogin", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Username", username);
                    cmd.Parameters.AddWithValue("@Password", password); // Lưu ý: Stored procedure tự xử lý băm

                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            Console.WriteLine("Đăng nhập thành công!");
                            return new UserModel
                            {
                                UserID = Convert.ToInt32(reader["UserID"]),
                                Username = username,
                                FullName = reader["FullName"].ToString(),
                                Role = reader["Role"].ToString()
                            };
                        }
                        else
                        {
                            Console.WriteLine("Đăng nhập thất bại!");
                            return null;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi xác thực: " + ex.Message);
                return null;
            }
        }

    }
}