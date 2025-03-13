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
            
            if (tentk.Trim() == "") { MessageBox.Show("Nhập email!"); }
            else if (matKhau.Trim() == "") { MessageBox.Show("Nhập password!"); }
            else
            {
                string query = "SELECT * FROM Employees WHERE Email ='" + tentk + "' and Password = '" + matKhau + "'";

                if (modify.Employees(query).Count() != 0)
                {
                    MessageBox.Show("Đăng nhập thành công!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    //Application.Exit();
                    Welcome welcome = new Welcome();
                    welcome.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Có Bug!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void linkLabel_QuenMatKhau_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            RecoverPassword recoverPassword = new RecoverPassword();
            recoverPassword.Show();
            this.Hide();
        }
    }
}
