using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UngDungQuanLyKho.Data.View;
using System.Data.SqlClient;
using UngDungQuanLyKho.Data.Database;
using UngDungQuanLyKho.Data.Models;

namespace UngDungQuanLyKho.Data.UI.Forms.Index
{
    public partial class RecoverPassword: Form
    {
        public RecoverPassword()
        {
            InitializeComponent();
        }

        private void linkLabel_QuayLai_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Hide();
        }

        Modify modify = new Modify();
        private void linkLabel_XoaNoiDung_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            textBox_Email.Clear();
            label_Show.Text = "";

            textBox_Email.Focus();
        }

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
                // 2. Tạo kết nối và command với parameter
                using (SqlConnection conn = Connection.GetSqlConnection())
                using (SqlCommand cmd = new SqlCommand(
                       "SELECT Password FROM Employees WHERE Email = @Email", conn))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.Add("@Email", SqlDbType.VarChar, 255).Value = email;
                    // Thêm parameter an toàn :contentReference[oaicite:0]{index=0}

                    conn.Open();
                    object result = cmd.ExecuteScalar();
                    // ExecuteScalar trả về giá trị cột đầu tiên, hàng đầu tiên :contentReference[oaicite:1]{index=1}

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


        private void guna2ControlBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult txt = MessageBox.Show("Bạn có muốn thoát không ?", "Thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (txt == DialogResult.Yes)
                this.Close();
        }
    }
}
