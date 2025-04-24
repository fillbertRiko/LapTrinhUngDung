using System;
using System.Data;
using System.Data.SqlClient;
using UngDungQuanLyKho.Data.Database;

namespace UngDungQuanLyKho.Data.Database
{
    class Modify
    {
        // Phương thức trả về DataTable từ Stored Procedure
        public DataTable ExecuteStoredProcedure(string spName, SqlParameter[] parameters = null)
        {
            DataTable dt = new DataTable();

            try
            {
                using (SqlConnection conn = Connection.GetSqlConnection())
                {
                    conn.Open(); // Đảm bảo kết nối được mở trước khi sử dụng

                    using (SqlCommand cmd = new SqlCommand(spName, conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        if (parameters != null)
                            cmd.Parameters.AddRange(parameters);

                        using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                        {
                            adapter.Fill(dt);
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"SQL Error: {ex.Message}");
                throw; // Ném lỗi để xử lý ở cấp cao hơn
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unexpected Error: {ex.Message}");
                throw;
            }

            return dt;
        }

        internal object Employees(string query)
        {
            throw new NotImplementedException();
        }

        internal DataTable ExecuteStoredProcedure(string query, object parameters)
        {
            throw new NotImplementedException();
        }
    }
}