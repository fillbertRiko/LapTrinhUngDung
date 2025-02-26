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

namespace QuanLyVatTuKhoHang
{
    public partial class FormMainLoad : Form
    {
        public FormMainLoad()
        {
            InitializeComponent();
        }

        private void FormMainLoad_Load(object sender, EventArgs e)
        {
            //mo ket noi
            Class.Function.Connect();
        }

        private void btnLogin_Click_1(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            int flag = 0;
            string u, p;
            u = lblUsername.Text;
            p = lblPassword.Text;
            if (u == "username" && p == "password")
            {
                flag = 1;
            }
            else
            {
                MessageBox.Show("Tài khoản hoặc mật khẩu sai!");
            }
            if (flag == 1)
            {
                f2.Show();
                this.Hide();
            }
        }
    }
}
