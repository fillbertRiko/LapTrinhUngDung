using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using QuanLyVatTuKhoHang.Auth;

namespace QuanLyVatTuKhoHang
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }

        private void FormMainLoad_Load(object sender, EventArgs e)
        {
            //mo ket noi
            Class.Function.Connect();
        }

        //khoi tao ham modify
        Modify modify = new Modify();
        private void btnLogin_Click_1(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;
            if(username.Trim()=="") { MessageBox.Show("Vui lòng nhập tên người dùng!");}
            else if(password.Trim()=="") { MessageBox.Show("Vui lòng nhập tài khoản người dùng!");}
            else {
                string query = "Select * from Emloyees where EmployeeID = '"+username+"' and Password = '"+password+"'";
                if (modify.Employees(query).Count() > 0)
                {
                    MessageBox.Show("Đăng nhập thành công!","Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Tài khoản hoặc mật khẩu không tồn tại, vui lòng thử lại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void lkbForgetPassword_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FormRecover forgetPassword = new FormRecover();
            forgetPassword.ShowDialog();
        }
    }
}
