using System;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;

namespace UngDungQuanLyKho.Data.Auth
{
    class AuthManager
    {
        private static string hashedPassword;  // Thay đổi biến mật khẩu thành dạng đã băm
        public static string TenNguoiDung { get; private set; }

        // Mã hóa mật khẩu bằng SHA-256
        private static string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder builder = new StringBuilder();
                foreach (byte b in bytes)
                {
                    builder.Append(b.ToString("x2"));
                }
                return builder.ToString();
            }
        }

        // Gán mật khẩu đã băm
        public static void SetMatKhau(string mk) => hashedPassword = HashPassword(mk);

        // Kiểm tra xác thực người dùng
        public static bool KiemTraXacThucNguoiDung(string tenNguoiDung, string mk)
            => tenNguoiDung == TenNguoiDung && HashPassword(mk) == hashedPassword;

        // Lấy tên người dùng từ DB theo EmployeeId
        public static string LayTenNguoiDungTuDatabase(string userId)
        {
            if (!int.TryParse(userId, out int id))
            {
                Console.WriteLine("Lỗi: EmployeeId không hợp lệ.");
                return null;
            }

            string connStr = @"Data Source=Heizzdoobert-F;Initial Catalog=WarehouseManagement;Integrated Security=True;Encrypt=True;Trust Server Certificate=True";
            const string query = "SELECT EmployeeName FROM Employees WHERE EmployeeId = @EmployeeId";

            using (var conn = new SqlConnection(connStr))
            using (var cmd = new SqlCommand(query, conn))
            {
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add(new SqlParameter("@EmployeeId", SqlDbType.Int) { Value = id });

                conn.Open();
                object result = cmd.ExecuteScalar();
                return result as string;  // Trả về tên hoặc null nếu không có kết quả
            }
        }
    }
}