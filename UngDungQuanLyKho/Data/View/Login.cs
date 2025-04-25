using System;
using System.Windows.Forms;
using UngDungQuanLyKho.Data.Auth;
using UngDungQuanLyKho.Data.UI.Forms.Index;
using UngDungQuanLyKho.Data.View.Admin;
using UngDungQuanLyKho.Data.View.MENU_User;


namespace UngDungQuanLyKho.Data.View
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void button_DangNhap_Click(object sender, EventArgs e)
        {
            string email = textBox_Email.Text.Trim();
            string password = textBox_Password.Text.Trim();

            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Vui lòng nhập email và mật khẩu!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (AuthManager.KiemTraXacThucNguoiDung(email, password))
            {
                var userInfo = AuthManager.LayThongTinNguoiDung(email);
                MessageBox.Show($"Xin chào {userInfo.EmployeeName}, bạn đã đăng nhập thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                if (userInfo.Role == "Admin")
                {
                    Employee admin = new Employee();
                    this.Hide();
                    admin.ShowDialog();
                }
                else
                {
                    Welcome welcome = new Welcome();
                    this.Hide();
                    welcome.ShowDialog();
                }

                this.Close();
            }
            else
            {
                MessageBox.Show("Nhập sai tài khoản hoặc mật khẩu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox_Password.Clear();
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
            if (MessageBox.Show("Bạn có muốn thoát không?", "Thoát", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.No)
            {
                e.Cancel = true;
            }
        }
    }
}