using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using UngDungQuanLyKho.Data.Database;

namespace UngDungQuanLyKho.Data.Models
{
    public class ImportModel
    {
        public DataTable GetImports()
        {
            using (SqlConnection conn = Connection.GetSqlConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("usp_GetImports", conn))
                using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    return dt;
                }
            }
        }

        public DataTable GetImportDetails(int importId)
        {
            using (SqlConnection conn = Connection.GetSqlConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("usp_GetImportDetails", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ImportID", importId);
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        return dt;
                    }
                }
            }
        }

        public int AddImport(DateTime importDate, int employeeId, string supplier)
        {
            int newImportId = -1;
            using (SqlConnection conn = Connection.GetSqlConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("usp_AddImport", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ImportDate", importDate);
                    cmd.Parameters.AddWithValue("@EmployeeID", employeeId);
                    cmd.Parameters.AddWithValue("@Supplier", supplier);

                    object result = cmd.ExecuteScalar();
                    if (result != null)
                        newImportId = Convert.ToInt32(result);
                }
            }
            return newImportId;
        }

        public void AddImportDetail(int importId, int productId, int quantity, decimal price)
        {
            using (SqlConnection conn = Connection.GetSqlConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("usp_AddImportDetail", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ImportID", importId);
                    cmd.Parameters.AddWithValue("@ProductID", productId);
                    cmd.Parameters.AddWithValue("@Quantity", quantity);
                    cmd.Parameters.AddWithValue("@Price", price);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public bool ValidateProductID(string productID, out string errorMessage)
        {
            errorMessage = "";
            if (string.IsNullOrWhiteSpace(productID))
            {
                errorMessage = "Vui lòng nhập mã sản phẩm.";
                return false;
            }
            if (!int.TryParse(productID, out _))
            {
                errorMessage = "Mã sản phẩm phải là số.";
                return false;
            }
            return true;
        }

        public bool ValidateImportDate(DateTime importDate, out string errorMessage)
        {
            errorMessage = "";
            if (importDate > DateTime.Now.Date)
            {
                errorMessage = "Ngày nhập kho không thể lớn hơn ngày hiện tại.";
                return false;
            }
            return true;
        }

        public bool ValidateEmployeeSelection(object selectedValue, out string errorMessage)
        {
            errorMessage = "";
            if (selectedValue == null)
            {
                errorMessage = "Vui lòng chọn nhân viên nhập kho.";
                return false;
            }
            return true;
        }

        public bool ValidateSupplierSelection(object selectedValue, out string errorMessage)
        {
            errorMessage = "";
            if (selectedValue == null)
            {
                errorMessage = "Vui lòng chọn nhà cung cấp.";
                return false;
            }
            return true;
        }

        public bool ValidateTextInput(string text, out string errorMessage)
        {
            errorMessage = "";
            if (string.IsNullOrWhiteSpace(text))
            {
                errorMessage = "Vui lòng nhập dữ liệu hợp lệ.";
                return false;
            }
            return true;
        }

        public bool ValidateQuantity(int quantity, out string errorMessage)
        {
            errorMessage = "";
            if (quantity <= 0)
            {
                errorMessage = "Số lượng phải lớn hơn 0.";
                return false;
            }
            return true;
        }

        public bool ValidatePrice(string priceText, out string errorMessage)
        {
            errorMessage = "";
            if (string.IsNullOrWhiteSpace(priceText) || !decimal.TryParse(priceText, out decimal price))
            {
                errorMessage = "Giá sản phẩm không hợp lệ.";
                return false;
            }
            if (price <= 0)
            {
                errorMessage = "Giá sản phẩm phải lớn hơn 0.";
                return false;
            }
            return true;
        }

        public DataTable GetLocations()
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection conn = Connection.GetSqlConnection())
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("usp_GetLocations", conn))
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        adapter.Fill(dt);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi tải danh sách vị trí: {ex.Message}");
            }
            return dt;
        }

        public bool ValidateInteger(string input, out string errorMessage)
        {
            errorMessage = "";
            if (string.IsNullOrWhiteSpace(input))
            {
                errorMessage = "Vui lòng nhập mã vị trí.";
                return false;
            }
            if (!int.TryParse(input, out _))
            {
                errorMessage = "Mã vị trí phải là số nguyên.";
                return false;
            }
            return true;
        }

        public bool AddLocation(string locationName, string area)
        {
            try
            {
                using (SqlConnection conn = Connection.GetSqlConnection())
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("usp_AddLocation", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@LocationName", locationName);
                        cmd.Parameters.AddWithValue("@Area", area);
                        int rowsAffected = cmd.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi thêm vị trí: {ex.Message}");
                return false;
            }
        }

        public DataRow GetLocationDetails(int locationID)
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection conn = Connection.GetSqlConnection())
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("SELECT * FROM Locations WHERE LocationID = @LocationID", conn))
                    {
                        cmd.Parameters.AddWithValue("@LocationID", locationID);
                        using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                        {
                            adapter.Fill(dt);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi lấy thông tin vị trí: {ex.Message}");
            }

            return dt.Rows.Count > 0 ? dt.Rows[0] : null;
        }
    }
}
