using System;
using System.Data.SqlClient;

namespace UngDungQuanLyKho.Data.Database
{
    class Connection
    {
        //khi chuyen may thi thay doi dong nay
        private static string stringCon = @"Data Source=Heizzdoobert-F;Initial Catalog=WarehouseManagement;Integrated Security=True;Encrypt=True;TrustServerCertificate=True";

        //ham tra ve doi tuong ket noi
        public static SqlConnection GetSqlConnection()
        {
            try
            {
                SqlConnection conn = new SqlConnection(stringCon);
                return conn;
            }
            catch(Exception ex)
            {
                Console.WriteLine("Lỗi kết nối đến cơ sở dữ liệu: " + ex.Message);
                return null;
            }
        }
    }

}
