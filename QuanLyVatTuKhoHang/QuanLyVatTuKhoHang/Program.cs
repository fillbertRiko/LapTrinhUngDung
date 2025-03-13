using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using QuanLyVatTuKhoHang.UI.Forms.Login;

namespace QuanLyVatTuKhoHang.UI.Forms.Login
{
    public partial class FormLogin:Form
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormLogin());
        }
    }
    internal static class Program
    {

    }
}
