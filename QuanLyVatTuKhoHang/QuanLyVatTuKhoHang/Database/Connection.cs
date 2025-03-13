using System.Data.SqlClient;
using System.Data;

namespace QuanLyVatTuKhoHang.Auth
{
    public static class Connection
    {
        private static SqlConnection connec;

        public static void Connect()
        {
            //Tao chuoi ket noi
            string conStr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""H:\Tài liệu học tập\2025\Lập trình ứng dụng\Project\LapTrinhUngDung\QuanLyVatTuKhoHang\QuanLyVatTuKhoHang\Database\Warehouse.mdf"";Integrated Security=True";
            connec = new SqlConnection(conStr);
            connec.Open();
        }

        public static SqlConnection GetSqlConnection()
        {
            //kiem tra ket noi
            if (connec == null || connec.State == ConnectionState.Closed)
            {
                Connect();
            }
            return connec;
        }
    }
}
