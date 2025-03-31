using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace UngDungQuanLyKho.Data.Auth
{
    class AuthManager
    {
        //tao xac thuc nguoi dung khi dang nhap dang xuat
        public static string TenNguoiDung { get; set; }

        private static string matKhau;
        public static string GetMatKhau()
        {
            return matKhau;
        }
        private static string matKhauStatic;
        public static void SetMatKhau(string matKhau)
        {
            matKhauStatic = matKhau;
        }

        public string GetTenNguoiDung()
        {
            // Implement the logic to get the user's name
            return "Tên người dùng";
        }
        public static void SetTenNguoiDung(string tenNguoiDung)
        {
            TenNguoiDung = tenNguoiDung;
        }

        public static bool KiemTraXacThucNguoiDung(string tenNguoiDung, string matKhau)
        {
            // Implement the logic to check user authentication
            // This is a placeholder implementation
            return tenNguoiDung == TenNguoiDung && matKhau == matKhauStatic;
        }

        public static string LayTenNguoiDungTuDatabase(string connectionString, string userId)
        {
            string tenNguoiDung = null;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT EmployeeName FROM Employees WHERE EmployeeId = @EmployeeId";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@UserId", userId);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            tenNguoiDung = reader["EmployeeName"].ToString();
                        }
                    }
                }
            }
            return tenNguoiDung;
        }
    }
}
