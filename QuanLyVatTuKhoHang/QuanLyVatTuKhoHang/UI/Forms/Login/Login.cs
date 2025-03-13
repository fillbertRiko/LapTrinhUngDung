using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;
using QuanLyVatTuKhoHang.QuanLyVatTuKhoHang.Database;
using QuanLyVatTuKhoHang.QuanLyVatTuKhoHang.Models;

namespace QuanLyVatTuKhoHang.Ui.Forms.Login
{
    
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            // Initialize form components here
        }
        /*
        private void FormMainLoad_Load(object sender, EventArgs e)
        {
            try
            {
                //mo ket noi
                QuanLyVatTuKhoHang.Database.Connection.Connect();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi kết nối tới database: {ex.Message}", "Bug Gòi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            
            }
        }

        // Khởi tạo hàm modify
        Modify modify = new Modify();
        private void btnLogin_Click_1(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;
            if (username.Trim() == "") { MessageBox.Show("Vui lòng nhập tên người dùng!"); }
            else if (password.Trim() == "") { MessageBox.Show("Vui lòng nhập mật khẩu người dùng!"); }
            else
            {
                string query = "Select * from Employees where EmployeeID = @username and Password = @password";
                List<SqlParameter> parameters = new List<SqlParameter>
                    {
                        new SqlParameter("@username", username),
                        new SqlParameter("@password", password)
                    };

                if (modify.Employees(query, parameters).Count() > 0)
                {
                    MessageBox.Show("Đăng nhập thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Tài khoản hoặc mật khẩu không tồn tại, vui lòng thử lại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void lkbForgetPassword_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            QuanVatTuKhoHang.Ui.Forms.Login.FormRecover forgetPassword = new FormRecover();
            forgetPassword.ShowDialog();
        }
    }
    */
}
