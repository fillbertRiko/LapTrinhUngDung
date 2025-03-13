using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UngDungQuanLyKho.Data.UI.Forms.Index
{
    public partial class Welcome: Form
    {
        public Welcome()
        {
            InitializeComponent();
        }

        //dong form welcome chuyen sang form main
        private void button_MoMain_Click(object sender, EventArgs e)
        {
            //mo main
            Main main = new Main();
            main.ShowDialog();

            this.Close();
        }
    }
}
