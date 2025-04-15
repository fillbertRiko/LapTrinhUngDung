using System.Data.SqlClient;

namespace UngDungQuanLyKho.Data.Database
{
    class Connection
    {
        //khi chuyen may thi thay doi dong nay
        private static string stringCon = @"Data Source=Heizzdoobert-F;Initial Catalog=WarehouseManagement;Integrated Security=True;Trust Server Certificate=True";

        //ham tra ve doi tuong ket noi
        public static SqlConnection GetSqlConnection()
        {
            return new SqlConnection(stringCon);
        }
    }

}
