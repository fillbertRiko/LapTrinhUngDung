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
    public partial class Form1 : Form
    {
        string connectstring = @"Data Source = DESKTOP-P7SFE1O\DDHUY; Initial Catalog=SalesManagement; Intergrated Security=True";
        SqlConnection con;
        SqlDataAdapter adt;
        SqlCommand cmd;
        DataTable dt;
        public Form1()
        {
            InitializeComponent();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
            this.Hide();
        }
    }
}
