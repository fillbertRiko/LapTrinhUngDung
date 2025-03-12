using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QuanLyVatTuKhoHang.Class
{
    class Function
    {
        public static SqlConnection Con;

        public static void Connect()
        {
            //khoi tao doi tuong
            Con = new SqlConnection();

            Con.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\lap_trinh_ung_dung\laptrinhungdung\LapTrinhUngDung\QuanLyVatTuKhoHang\Class\Warehouse.mdf;Integrated Security=True;Connect Timeout=30";

            //mo ket noi
            Con.Open();

            //kiem tra ket noi
            if(Con.State == ConnectionState.Open)
            {
                MessageBox.Show("Kết nối thành công");
            }
            else
            {
                MessageBox.Show("Không thể kết nối với dữ liệu!");
            }
        }

        public static void Disconnect()
        {
            if (Con.State == ConnectionState.Open)
            {
                //dong ket noi
                Con.Close();
                //giai phong tai nguyen
                Con.Dispose();
                Con = null;
            }
        }
    }
}
