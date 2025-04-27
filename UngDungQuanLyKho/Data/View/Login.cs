using System;
using System.Windows.Forms;
using UngDungQuanLyKho.Data.Auth;
using UngDungQuanLyKho.Data.Models;
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
            string username = textBox_Username.Text.Trim(); 
            string password = textBox_Password.Text.Trim();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Vui lòng nhập username và mật khẩu!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            UserModel loggedInUser = AuthManager.AuthenticateUser(username, password);

            if (loggedInUser == null)
            {
                MessageBox.Show("Nhập sai tài khoản hoặc mật khẩu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox_Password.Clear();
                return;
            }

            MessageBox.Show($"Xin chào {loggedInUser.FullName}, bạn đã đăng nhập thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            Form nextForm = loggedInUser.Role == "Admin"
                ? (Form)new AdminDashboard(loggedInUser)
                : (Form)new Welcome();
            this.Hide();
            nextForm.ShowDialog();
            this.Close();
        }

        private void linkLabel_QuenMatKhau_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // Chuyển sang form khôi phục mật khẩu
            RecoverPassword recoverForm = new RecoverPassword();
            recoverForm.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Xác nhận người dùng có muốn thoát
            DialogResult result = MessageBox.Show("Bạn có muốn thoát không?", "Thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void Login_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Xác nhận khi form đóng
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn thoát không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        private void Login_Load(object sender, EventArgs e)
        {
            textBox_Password.PasswordChar = '*';
        }
    }
}