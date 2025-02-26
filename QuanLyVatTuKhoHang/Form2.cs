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
    public partial class Form2 : Form
    {
        
        public Form2()
        {
            InitializeComponent();
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void bigLabel2_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            txttel.Text = string.Empty;
            cbxPay.Text = string.Empty;
            txtSo.Text = string.Empty;
            txtnameKH.Text = string.Empty;
            txtcodeKH.Text = string.Empty;
            txtAddress.Text = string.Empty;
            txtAC.Text = string.Empty;
            cbxBank.Text = string.Empty;
            txtWords.Text = string.Empty;
        }
    }
}
