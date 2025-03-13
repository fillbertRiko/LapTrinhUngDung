using System.Data.SqlClient;

namespace UngDungQuanLyKho.Data.Database
{
    class Connection
    {
        private static string stringCon = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""H:\Tài liệu học tập\2025\Lập trình ứng dụng\Project\LapTrinhUngDung\UngDungQuanLyKho\Data\Database\QLKhoHang.mdf"";Integrated Security=True;Connect Timeout=30";

        //ham tra ve doi tuong ket noi
        public static SqlConnection GetSqlConnection()
        {
            return new SqlConnection(stringCon);
        }
    }

}
