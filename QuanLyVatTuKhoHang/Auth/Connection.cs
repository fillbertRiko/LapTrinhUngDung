using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace QuanLyVatTuKhoHang.Auth
{
    class Connection
    {
        private static string strCon = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""H:\Tài liệu học tập\2025\Lập trình ứng dụng\Project\LapTrinhUngDung\QuanLyVatTuKhoHang\Class\Warehouse.mdf"";Integrated Security=True;Connect Timeout=30;Encrypt=True";

        public static SqlConnection GetSqlConnection()
        {
            return new SqlConnection(strCon);
        }
    }
}
