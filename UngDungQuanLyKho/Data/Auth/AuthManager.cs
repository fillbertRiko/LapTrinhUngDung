using System;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;

namespace UngDungQuanLyKho.Data.Auth
{
    class AuthManager
    {

        public static string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder builder = new StringBuilder();
                foreach (byte b in bytes)
                    builder.Append(b.ToString("x2"));
                return builder.ToString();
            }
        }

        public static bool KiemTraXacThucNguoiDung(string email, string password)
        {
            string hashedInput = HashPassword(password);
            string storedHash = LayMatKhauTuDatabase(email);

            return !string.IsNullOrEmpty(storedHash) && storedHash == hashedInput;
        }

        private static string LayMatKhauTuDatabase(string email)
        {
            string connStr = @"Data Source=Heizzdoobert-F;Initial Catalog=WarehouseManagement;Integrated Security=True;Encrypt=True;Trust Server Certificate=True";
            string query = "SELECT Password FROM Employees WHERE Email = @Email";

            using (var conn = new SqlConnection(connStr))
            using (var cmd = new SqlCommand(query, conn))
            {
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@Email", email);

                conn.Open();
                object result = cmd.ExecuteScalar();
                return result as string; // Trả về mật khẩu đã mã hóa hoặc null
            }
        }

        public static (string EmployeeName, string Role) LayThongTinNguoiDung(string email)
        {
            string connStr = @"Data Source=Heizzdoobert-F;Initial Catalog=WarehouseManagement;Integrated Security=True;Encrypt=True;Trust Server Certificate=True";
            string query = "SELECT EmployeeName, Role FROM Employees WHERE Email = @Email";

            using (var conn = new SqlConnection(connStr))
            using (var cmd = new SqlCommand(query, conn))
            {
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@Email", email);

                conn.Open();
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return (reader["EmployeeName"].ToString(), reader["Role"].ToString());
                    }
                }
            }
            return (null, null);
        }


    }
}