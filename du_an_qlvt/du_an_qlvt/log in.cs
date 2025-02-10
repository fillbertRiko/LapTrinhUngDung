using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace du_an_qlvt
{
    public partial class manage : Form
    {
        public manage()
        {
            InitializeComponent();

            this.AcceptButton = enter;
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click_1(object sender, EventArgs e)
        {
            this.AcceptButton = enter;
            // đăng nhập admin
            if (txtusername.Text == "admin" && txtpassword.Text == "1234")
            {
                fAdmin admin = new fAdmin();
                admin.Show();
                this.Hide(); // Ẩn form đăng nhập
            }
            else if (txtusername.Text == "david" && txtpassword.Text == "1234")
            {
                staff staff = new staff();
                staff.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Invalid username or password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void manage_Load(object sender, EventArgs e)
        {
           
        }

        private void reload_Click(object sender, EventArgs e)
        {
            txtusername.Clear();
            txtpassword.Clear();
            // tai lai trang
        }

        private void txtusername_TextChanged(object sender, EventArgs e)
        {
            
            
        }

    }
}
