using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using UngDungQuanLyKho.Data.Database;

namespace UngDungQuanLyKho.Data.Models
{
    public class UserModel
    {
        // Kiểm tra tài khoản đăng nhập với mật khẩu đã hash
        public DataTable CheckLogin(string username, string password)
        {
            try
            {
                using (SqlConnection conn = Connection.GetSqlConnection())
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("usp_CheckLogin", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Username", username);
                        cmd.Parameters.AddWithValue("@Password", HashPassword(password)); // Mã hóa mật khẩu

                        using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            adapter.Fill(dt);
                            // Trả về DataTable nếu có kết quả, ngược lại trả về null
                            return dt.Rows.Count > 0 ? dt : null;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi CheckLogin: {ex.Message}");
                return null;
            }
        }

        // Thêm tài khoản mới với mật khẩu đã mã hóa
        public bool AddUser(string username, string password, string fullname, string role)
        {
            try
            {
                using (SqlConnection conn = Connection.GetSqlConnection())
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("usp_AddUser", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Username", username);
                        cmd.Parameters.AddWithValue("@Password", password);  // Nếu cần băm mật khẩu, hãy xử lý trước khi truyền vào đây
                        cmd.Parameters.AddWithValue("@FullName", fullname);
                        cmd.Parameters.AddWithValue("@Role", role);

                        int rowsAffected = cmd.ExecuteNonQuery(); // Kiểm tra số hàng bị ảnh hưởng
                        return rowsAffected > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm người dùng: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }


        // Kiểm tra quyền tài khoản
        public DataTable GetPermissions(string role)
        {
            if (string.IsNullOrEmpty(role))
            {
                Console.WriteLine("Vai trò không hợp lệ!");
                return null;
            }

            try
            {
                using (SqlConnection conn = Connection.GetSqlConnection())
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("usp_GetPermissions", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Role", role);

                        using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            adapter.Fill(dt);
                            return dt;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi GetPermissions: {ex.Message}");
                return null;
            }
        }

        // Lấy danh sách người dùng
        public DataTable GetUsers()
        {
            try
            {
                using (SqlConnection conn = Connection.GetSqlConnection())
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("usp_GetUsers", conn))
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        // Trả về DataTable nếu có dữ liệu, hoặc null nếu danh sách rỗng
                        return dt.Rows.Count > 0 ? dt : null;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi GetUsers: {ex.Message}");
                return null;
            }
        }

        // Hàm hash mật khẩu bằng SHA256 + Salt để tăng cường bảo mật
        private string HashPassword(string password)
        {
            // Salt cố định; lưu ý: trong thực tế, nên sử dụng salt riêng cho từng user
            string salt = "KhoWarehouse123";
            using (var sha256 = System.Security.Cryptography.SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(System.Text.Encoding.UTF8.GetBytes(salt + password));
                return BitConverter.ToString(bytes).Replace("-", "").ToLower();
            }
        }
        public int UserID { get; set; }
        public string Username { get; set; }
        public string FullName { get; set; }
        public string Role { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; private set; }
        public string EmployeeName { get; set; }

        public void SetPassword(string password)
        {
            string salt = "KhoWarehouse123";
            using (var sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(salt + password));
                PasswordHash = BitConverter.ToString(bytes).Replace("-", "").ToLower();
            }
        }

        public bool ValidatePassword(string inputPassword)
        {
            string salt = "KhoWarehouse123";
            using (var sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(salt + inputPassword));
                string hashedInput = BitConverter.ToString(bytes).Replace("-", "").ToLower();
                return hashedInput == PasswordHash;
            }
        }

        public DataTable SearchUsers(string keyword)
        {
            try
            {
                using (SqlConnection conn = Connection.GetSqlConnection())
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("usp_SearchUsers", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Keyword", keyword);

                        using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            adapter.Fill(dt);
                            return dt;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tìm kiếm người dùng: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new DataTable(); // Trả về bảng trống nếu có lỗi để tránh null
            }
        }


        public bool UpdateUser(int userId, string username, string password, string fullname, string role)
        {
            try
            {
                using (SqlConnection conn = Connection.GetSqlConnection())
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("usp_UpdateUser", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@UserID", userId);
                        cmd.Parameters.AddWithValue("@Username", username);
                        cmd.Parameters.AddWithValue("@Password", password);  // Nếu cần băm mật khẩu, hãy xử lý trước khi truyền vào đây
                        cmd.Parameters.AddWithValue("@FullName", fullname);
                        cmd.Parameters.AddWithValue("@Role", role);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        return rowsAffected > 0;  // Trả về `true` nếu cập nhật thành công
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật người dùng: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }


        public bool DeleteUser(int userId)
        {
            try
            {
                using (SqlConnection conn = Connection.GetSqlConnection())
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("usp_DeleteUser", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@UserID", userId);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        return rowsAffected > 0; // Trả về `true` nếu xoá thành công
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xoá người dùng: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }


        public bool ExportUsersToCSV(DataTable dtUsers)
        {
            if (dtUsers == null || dtUsers.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu để xuất.", "Export", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "CSV file (*.csv)|*.csv";
            saveFileDialog.FileName = "UsersExport.csv";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    using (StreamWriter sw = new StreamWriter(saveFileDialog.FileName))
                    {
                        // Xuất tiêu đề cột
                        List<string> headers = new List<string>();
                        foreach (DataColumn col in dtUsers.Columns)
                        {
                            headers.Add(col.ColumnName);
                        }
                        sw.WriteLine(string.Join(",", headers));

                        // Xuất dữ liệu từng hàng
                        foreach (DataRow row in dtUsers.Rows)
                        {
                            List<string> cells = new List<string>();
                            foreach (var cell in row.ItemArray)
                            {
                                // Thêm giá trị của ô, dùng dấu ngoặc kép nếu cần xử lý chứa dấu phẩy
                                string cellText = cell?.ToString().Replace("\"", "\"\"") ?? "";
                                cells.Add("\"" + cellText + "\"");
                            }
                            sw.WriteLine(string.Join(",", cells));
                        }
                    }

                    MessageBox.Show("Xuất dữ liệu thành công!", "Export", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Xuất dữ liệu thất bại: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            return false;
        }

    }
}