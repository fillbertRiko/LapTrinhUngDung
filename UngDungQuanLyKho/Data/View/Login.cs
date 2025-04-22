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
using UngDungQuanLyKho.Data.Database;
using UngDungQuanLyKho.Data.UI.Forms.Index;

namespace UngDungQuanLyKho.Data.View
{
    public partial class Login: Form
    {
        public Login()
        {
            InitializeComponent();
        }

        Modify modify = new Modify();
        private void button_DangNhap_Click(object sender, EventArgs e)
        {
            string tentk = textBox_Email.Text;
            string matKhau = textBox_Password.Text;

            //kiem tra dieu kien qua dau cach
            if (tentk.Trim() == "") { MessageBox.Show("Nhập email!"); }
            else if (matKhau.Trim() == "") { MessageBox.Show("Nhập password!"); }
            else
            {
                string query = "SELECT * FROM Employees WHERE Email = @Email AND Password = @Password";

                // Use parameterized query to prevent SQL injection
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@Email", tentk),
                    new SqlParameter("@Password", matKhau)
                };

                DataTable result = modify.ExecuteStoredProcedure(query, parameters) as DataTable;

                if (result != null && result.Rows.Count > 0)
                {
                    MessageBox.Show("Đăng nhập thành công!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    Welcome welcome = new Welcome();
                    this.Hide();
                    welcome.ShowDialog();
                    this.Show();
                }
                else
                {
                    MessageBox.Show("Nhập sai tài khoản hoăc mật khẩu!!!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void linkLabel_QuenMatKhau_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            RecoverPassword recoverPassword = new RecoverPassword();
            recoverPassword.Show();
            this.Hide();
        }

        private void textBox_Email_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox_Password_TextChanged(object sender, EventArgs e)
        {

        }

        //update phuong thuc thoat trong form login
        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Login_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(MessageBox.Show("Bạn có muốn thoát không ?", "Thoát", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.No)
            {
                e.Cancel = true;
            }
        }
    }
}
