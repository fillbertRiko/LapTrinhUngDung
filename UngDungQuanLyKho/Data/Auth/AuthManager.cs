using System;
using System.Configuration;               
using System.Data;
using System.Data.SqlClient;

namespace UngDungQuanLyKho.Data.Auth
{
    class AuthManager
    {
        // Lưu trữ tạm mật khẩu - dùng 1 biến duy nhất
        private static string matKhau;

        // Tên người dùng hiện tại
        public static string TenNguoiDung { get; private set; }

        // Lấy mật khẩu đã lưu
        public static string GetMatKhau() => matKhau;

        // Gán mật khẩu
        public static void SetMatKhau(string mk) => matKhau = mk;  // Đơn nhất hóa biến :contentReference[oaicite:6]{index=6}

        // Gán tên người dùng
        public static void SetTenNguoiDung(string ten) => TenNguoiDung = ten;

        // Xác thực bằng so sánh với giá trị lưu tĩnh
        public static bool KiemTraXacThucNguoiDung(string tenNguoiDung, string mk)
            => tenNguoiDung == TenNguoiDung && mk == matKhau;

        // Lấy tên người dùng từ DB theo EmployeeId
        public static string LayTenNguoiDungTuDatabase(string userId)
        {
            object ConfigurationManager = null;
            // Đọc chuỗi kết nối từ app.config
            //string connStr = ConfigurationManager
            //    .ConnectionStrings["QuanLyKho"].ConnectionString;   // :contentReference[oaicite:7]{index=7}

            string connStr = @"Data Source=Heizzdoobert-F;Initial Catalog=WarehouseManagement;Integrated Security=True;Encrypt=True;Trust Server Certificate=True";

            const string query =
                "SELECT EmployeeName FROM Employees WHERE EmployeeId = @EmployeeId";

            using (var conn = new SqlConnection(connStr))
            using (var cmd = new SqlCommand(query, conn))
            {
                cmd.CommandType = CommandType.Text;
                // Thêm tham số an toàn, định rõ kiểu và độ dài nếu cần :contentReference[oaicite:8]{index=8}
                cmd.Parameters.Add(new SqlParameter("@EmployeeId", SqlDbType.Int)
                { Value = int.Parse(userId) });

                conn.Open();
                // ExecuteScalar trả về giá trị cột đầu tiên, hàng đầu tiên :contentReference[oaicite:9]{index=9}
                object result = cmd.ExecuteScalar();
                return result as string;    // null nếu không có kết quả :contentReference[oaicite:10]{index=10}
            }
        }
    }
}
