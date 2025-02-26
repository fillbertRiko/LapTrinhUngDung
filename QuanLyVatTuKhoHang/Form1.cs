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

        }
    }
}
