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
using System.IdentityModel.Tokens;

namespace QuanLyVatTuKhoHang
{
    public partial class Form1 : Form
    {
        //Tao bien cuc bo
        string strCon = @"Data Source = DESKTOP-P7SFE1O\DDHUY; Initial Catalog=SalesManagement; Intergrated Security=True";
        // Doi tuong ket noi
        SqlConnection cn = null;
        SqlDataAdapter adt;
        SqlCommand cmd;
        DataTable dt;
        public Form1()
        {
            InitializeComponent();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            //Ham kiem tra tai khoan mat khau nguoi dung
            if(lblUsername.Text != "" && lblPassword.Text != "")
            {
                //Khai bao bien de check trong csdl
                string queryText = @"SELECT  FROM User
                                     WHERE username = @Username AND password = @Password";
                //Chua tao bang User trong csdl
                using (SqlConnection cn = new SqlConnection(queryText))
                {
                    SqlCommand cmd = cn.CreateCommand();
                    cn.Open();
                    cmd.Parameters.AddWithValue("@Username", lblUsername.Text);
                    cmd.Parameters.AddWithValue("@Password", lblPassword.Text);
                    int result = (int)cmd.ExecuteScalar();
                    if(result >0)
                    {
                        MessageBox.Show("LOGGING!");
                    }
                    else
                    {
                        MessageBox.Show("USER NOT FOUND!, TRY AGAIN!");
                    }
                }
            }
        }
    }
}
