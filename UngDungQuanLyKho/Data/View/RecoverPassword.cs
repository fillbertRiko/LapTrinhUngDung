using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using UngDungQuanLyKho.Data.Database;
using UngDungQuanLyKho.Data.View;

namespace UngDungQuanLyKho.Data.UI.Forms.Index
{
    public partial class RecoverPassword : Form
    {
        public RecoverPassword()
        {
            InitializeComponent();
        }

        // Khi nhấn "Quay Lại", hiển thị form đăng nhập và ẩn form hiện tại
        private void linkLabel_QuayLai_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Hide();
        }

        // Xóa nội dung nhập và hiển thị thông tin
        private void linkLabel_XoaNoiDung_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            textBox_Email.Clear();
            label_Show.Text = "";
            textBox_Email.Focus();
        }

        // Lấy lại mật khẩu (ở đây chỉ thực hiện truy vấn và hiển thị kết quả)
        private void button_LayLaiTaiKhoan_Click(object sender, EventArgs e)
        {
            // 1. Lấy và kiểm tra email đầu vào
            string email = textBox_Email.Text.Trim();
            if (string.IsNullOrEmpty(email))
            {
                MessageBox.Show("Nhập vào email cần lấy lại", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // 2. Tạo kết nối và thực hiện truy vấn với parameter
                using (SqlConnection conn = Connection.GetSqlConnection())
                using (SqlCommand cmd = new SqlCommand("SELECT Password FROM Employees WHERE Email = @Email", conn))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.Add("@Email", SqlDbType.VarChar, 255).Value = email;

                    conn.Open();
                    object result = cmd.ExecuteScalar();

                    if (result != null && result != DBNull.Value)
                    {
                        label_Show.ForeColor = Color.Green;
                        label_Show.Text = result.ToString();
                    }
                    else
                    {
                        label_Show.ForeColor = Color.Red;
                        MessageBox.Show("Email không tồn tại trong hệ thống!", "Lỗi",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                // 3. Bắt và hiển thị lỗi
                MessageBox.Show($"Lỗi khi lấy lại tài khoản:\n{ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Sự kiện đóng form bằng nút điều khiển (ví dụ: nút x, nếu sử dụng thư viện của Guna)
        private void guna2ControlBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Sự kiện nút thoát, hiển thị hộp thoại xác nhận
        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có muốn thoát không?", "Thoát",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
                this.Close();
        }
    }
}