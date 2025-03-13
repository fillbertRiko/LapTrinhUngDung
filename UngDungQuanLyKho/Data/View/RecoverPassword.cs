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
            textBox_Email.Text = "";
            label_Show.Text = "";

            textBox_Email.Focus();
        }

        private void button_LayLaiTaiKhoan_Click(object sender, EventArgs e)
        {
            string email = textBox_Email.Text;

            //kiem tra
            if (email.Trim() == "") { MessageBox.Show("Nhập vào email cần lấy lại"); }
            else
            {
                string query = "SELECT * FROM Employees WHERE Email = '" + email + "'";
                if (modify.Employees(query).Count() != 0)
                {
                    label_Show.ForeColor = Color.Green;
                    label_Show.Text = modify.Employees(query)[0].Password;
                    MessageBox.Show("Chú em nhớ kĩ vào đừng để quên!!!");
                }
                else
                {
                    label_Show.ForeColor= Color.Red;
                    MessageBox.Show("Ơ Ơ Ơ, làm cái gì đấy, Mắt sang vành à!");
                }
            }
        }
    }
}
