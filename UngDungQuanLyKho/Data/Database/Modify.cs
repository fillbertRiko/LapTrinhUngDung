using System;
using System.Data;
using System.Data.SqlClient;

namespace UngDungQuanLyKho.Data.Database
{
    class Modify
    {
        private readonly string connStr = @"Data Source=Heizzdoobert-F;Initial Catalog=WarehouseManagement;Integrated Security=True;Encrypt=True;Trust Server Certificate=True";

        // Phương thức trả về DataTable từ SP
        public DataTable ExecuteStoredProcedure(string spName, SqlParameter[] parameters = null)
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(connStr))
                //loi
            using (SqlCommand cmd = new SqlCommand(spName, conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;           // :contentReference[oaicite:4]{index=4}
                if (parameters != null) cmd.Parameters.AddRange(parameters);

                using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                {
                    adapter.Fill(dt);                                      // :contentReference[oaicite:5]{index=5}
                }
            }
            return dt;
        }

        internal object Employees(string query)
        {
            throw new NotImplementedException();
        }
    }
}
