using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyVatTuKhoHang
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnThemSP_Click(object sender, EventArgs e)
        {
            Extend form2 = new Extend();
            form2.ShowDialog();
        }

        private void btnDuyethoadon_Click(object sender, EventArgs e)
        {
            Extend form4 = new Extend();
            form4.ShowDialog();
        }
    }
}
