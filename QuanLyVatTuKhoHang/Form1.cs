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
        //Tao bien cuc bo
        string strCon = @"Data Source = DESKTOP-P7SFE1O\DDHUY; Initial Catalog=SalesManagement; Intergrated Security=True";
        // Doi tuong ket noi
        SqlConnection sqlCon = null;
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
            // Mo ket noi va kiem tra tai khoan trong csdl
            try
            {
                if (sqlCon == null)
                {
                    sqlCon = new SqlConnection(strCon);
                }
                if (sqlCon.State == ConnectionState.Closed)
                {
                    sqlCon.Open();
                }
                return;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,
                    "Error Message",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }
        }
    }
}
