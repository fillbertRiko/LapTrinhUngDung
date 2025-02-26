using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace QuanLyVatTuKhoHang
{
    internal static class Program
    {
        /*private SqlConnection Connect
        {
            try
            {

            }
        }
        */
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormMainLoad());
            /*
             * string strCon = @"Data Source=DESKTOP-P7SFE1O\DDHUY;"
                                + "Initial Catalog=SalesManagement;"
                                + "Integrated Security=True;"
                                + "Trust Server Certificate=True";
            SqlConnection sqlCon = null;
            */
        }
        
    }
}
