using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UngDungQuanLyKho.Data.Database;
using System.Net;
using System.Net.Mail;
using System.Windows.Forms;
using UngDungQuanLyKho.Data.Auth;
using UngDungQuanLyKho.Data.Models;

namespace UngDungQuanLyKho.Data.Models
{
    class ProductModel
    {
        private object dgvStockStatus;

        public DataTable GetProducts()
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection conn = Connection.GetSqlConnection())
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("usp_GetProducts", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                        {
                            adapter.Fill(dt);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải danh sách sản phẩm: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return dt;
        }

        public DataTable SearchProducts(string keyword)
        {
            using (SqlConnection conn = Connection.GetSqlConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("usp_SearchProducts", conn))
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
        public bool AddProduct(string name, string category, string unit, int quantity, int minQuantity, int locationId)
        {
            try
            {
                using (SqlConnection conn = Connection.GetSqlConnection())
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("usp_AddProduct", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@ProductName", name);
                        cmd.Parameters.AddWithValue("@Category", category);
                        cmd.Parameters.AddWithValue("@Unit", unit);
                        cmd.Parameters.AddWithValue("@Quantity", quantity);
                        cmd.Parameters.AddWithValue("@MinQuantity", minQuantity);
                        cmd.Parameters.AddWithValue("@LocationID", locationId);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        return rowsAffected > 0; // Trả về `true` nếu thêm thành công
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi thêm sản phẩm: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public bool UpdateProduct(int id, string name, string category, string unit, int quantity, int minQuantity, int locationId)
        {
            try
            {
                using (SqlConnection conn = Connection.GetSqlConnection())
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("usp_UpdateProduct", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@ProductID", id);
                        cmd.Parameters.AddWithValue("@ProductName", name);
                        cmd.Parameters.AddWithValue("@Category", category);
                        cmd.Parameters.AddWithValue("@Unit", unit);
                        cmd.Parameters.AddWithValue("@Quantity", quantity);
                        cmd.Parameters.AddWithValue("@MinQuantity", minQuantity);
                        cmd.Parameters.AddWithValue("@LocationID", locationId);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi cập nhật sản phẩm: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public void DeleteProduct(int id)
        {
            using (SqlConnection conn = Connection.GetSqlConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("usp_DeleteProduct", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ProductID", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        //lay thong ke san pham
        public DataTable GetLowStockProducts()
        {
            using (SqlConnection conn = Connection.GetSqlConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("usp_GetLowStockProducts", conn))
                {
                    // Đặt command type là StoredProcedure
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        return dt;
                    }
                }
            }
        }

        /*
        public void SendLowStockAlert(string recipientEmail)
        {
            StringBuilder body = new StringBuilder();
            body.AppendLine("Danh sách sản phẩm cần nhập thêm:");

            foreach (DataGridViewRow row in dgvStockStatus.Rows)
            {
                body.AppendLine($"- {row.Cells["ProductName"].Value}: Còn {row.Cells["Quantity"].Value} (Mức tối thiểu: {row.Cells["MinQuantity"].Value})");
            }

            try
            {
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress("your-email@example.com"); // Thay bằng email quản lý kho
                mail.To.Add(recipientEmail);
                mail.Subject = "Cảnh báo hàng tồn kho thấp";
                mail.Body = body.ToString();

                SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
                smtp.Credentials = new NetworkCredential("your-email@example.com", "your-password"); // Thay đổi thông tin đăng nhập
                smtp.EnableSsl = true;
                smtp.Send(mail);

                MessageBox.Show("Đã gửi thông báo tồn kho cho quản lý!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi gửi email: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        */
    }
}
