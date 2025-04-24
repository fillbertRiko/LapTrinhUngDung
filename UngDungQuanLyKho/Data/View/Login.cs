using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
using UngDungQuanLyKho.Data.Database;
using UngDungQuanLyKho.Data.UI.Forms.Index;
using UngDungQuanLyKho.Data.View;

namespace UngDungQuanLyKho.Data.View
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        Modify modify = new Modify();

        private void button_DangNhap_Click(object sender, EventArgs e)
        {
            string tentk = textBox_Email.Text.Trim();
            string matKhau = textBox_Password.Text.Trim();

            if (string.IsNullOrEmpty(tentk))
            {
                MessageBox.Show("Nhập email!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrEmpty(matKhau))
            {
                MessageBox.Show("Nhập password!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection conn = Connection.GetSqlConnection())
                {
                    conn.Open();

                    using (SqlCommand cmd = new SqlCommand("CheckLogin", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Email", tentk);
                        cmd.Parameters.AddWithValue("@Password", matKhau);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                string ten = reader["EmployeeName"].ToString();
                                string quyen = reader["Role"].ToString();
                                string email = reader["Email"].ToString();
                                string matkhau = reader["Password"].ToString();

                                MessageBox.Show($"Xin chào {ten}, bạn đã đăng nhập thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                Welcome welcome = new Welcome();
                                this.Hide();
                                welcome.ShowDialog();
                                this.Close();
                            }
                            else
                            {
                                MessageBox.Show("Nhập sai tài khoản hoặc mật khẩu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                textBox_Password.Clear();
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show($"Lỗi kết nối: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi không xác định: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void linkLabel_QuenMatKhau_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            RecoverPassword recoverPassword = new RecoverPassword();
            recoverPassword.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Login_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn thoát không ?", "Thoát", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.No)
            {
                e.Cancel = true;
            }
        }
    }
}