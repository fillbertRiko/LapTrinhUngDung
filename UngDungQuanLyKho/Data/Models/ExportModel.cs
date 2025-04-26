using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UngDungQuanLyKho.Data.Database;
using OfficeOpenXml;
using System.Windows.Forms;
using System.IO;

namespace UngDungQuanLyKho.Data.Models
{
    internal class ExportModel
    {
        public DataTable GetExports()
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection conn = Connection.GetSqlConnection())
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("usp_GetExports", conn))
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        adapter.Fill(dt);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi tải danh sách đơn xuất hàng: {ex.Message}");
            }
            return dt;
        }

        public DataTable GetExportDetails(int exportId)
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection conn = Connection.GetSqlConnection())
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("usp_GetExportDetails", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@ExportID", exportId);
                        using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                        {
                            adapter.Fill(dt);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi tải chi tiết xuất hàng: {ex.Message}");
            }
            return dt;
        }



        public void UpdateTotalAmount(int exportId)
        {
            try
            {
                using (SqlConnection conn = Connection.GetSqlConnection())
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("usp_UpdateTotalAmount", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@ExportID", exportId);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi cập nhật tổng giá trị đơn hàng: {ex.Message}");
            }
        }

        public void AddExportDetail(int exportId, int productId, int quantity, decimal price)
        {
            try
            {
                if (exportId <= 0 || productId <= 0 || quantity <= 0 || price <= 0)
                {
                    Console.WriteLine("Dữ liệu đầu vào không hợp lệ.");
                    return;
                }

                using (SqlConnection conn = Connection.GetSqlConnection())
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("usp_AddExportDetail", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@ExportID", exportId);
                        cmd.Parameters.AddWithValue("@ProductID", productId);
                        cmd.Parameters.AddWithValue("@Quantity", quantity);
                        cmd.Parameters.AddWithValue("@Price", price);
                        cmd.ExecuteNonQuery();
                    }
                }

                // Cập nhật tổng giá trị đơn hàng
                UpdateTotalAmount(exportId);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi thêm chi tiết xuất hàng: {ex.Message}");
            }
        }

        public void ExportExportsToExcel(DataGridView dgv)
        {
            using (SaveFileDialog sfd = new SaveFileDialog() { Filter = "Excel Workbook|*.xlsx" })
            {
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    using (ExcelPackage package = new ExcelPackage())
                    {
                        ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("Exports");
                        worksheet.Cells["A1"].Value = "Mã xuất hàng";
                        worksheet.Cells["B1"].Value = "Ngày Xuất";
                        worksheet.Cells["C1"].Value = "Tên khách hàng";
                        worksheet.Cells["D1"].Value = "Tổng Tiền(VND)";

                        int row = 2;
                        foreach (DataGridViewRow dgvRow in dgv.Rows)
                        {
                            worksheet.Cells[row, 1].Value = dgvRow.Cells["ExportID"].Value;
                            worksheet.Cells[row, 2].Value = dgvRow.Cells["ExportDate"].Value;
                            worksheet.Cells[row, 3].Value = dgvRow.Cells["CustomerName"].Value;
                            worksheet.Cells[row, 4].Value = dgvRow.Cells["TotalAmount"].Value;
                            row++;
                        }

                        File.WriteAllBytes(sfd.FileName, package.GetAsByteArray());
                        MessageBox.Show("Xuất file Excel thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        public int AddExportDetail(DateTime exportDate, int customerId, decimal totalAmount)
        {
            try
            {
                using (SqlConnection conn = Connection.GetSqlConnection())
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("usp_AddExport", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@ExportDate", exportDate);
                        cmd.Parameters.AddWithValue("@CustomerID", customerId);
                        cmd.Parameters.AddWithValue("@TotalAmount", totalAmount);

                        object result = cmd.ExecuteScalar();
                        return result != null ? Convert.ToInt32(result) : -1;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi thêm chi tiết xuất hàng: {ex.Message}");
                return -1;
            }
        }

        //xoa don xuat kho
        public bool DeleteExport(int exportId)
        {
            try
            {
                using (SqlConnection conn = Connection.GetSqlConnection())
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("usp_DeleteExport", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@ExportID", exportId);
                        int rowsAffected = cmd.ExecuteNonQuery();
                        return rowsAffected > 0; // Nếu xoá thành công
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi xoá đơn xuất hàng: {ex.Message}");
                return false;
            }
        }

        //cap nhat chi tiet xuat kho
        public bool UpdateExportDetail(int exportId, int productId, int quantity, decimal price)
        {
            try
            {
                using (SqlConnection conn = Connection.GetSqlConnection())
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("usp_UpdateExportDetail", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@ExportID", exportId);
                        cmd.Parameters.AddWithValue("@ProductID", productId);
                        cmd.Parameters.AddWithValue("@Quantity", quantity);
                        cmd.Parameters.AddWithValue("@Price", price);
                        int rowsAffected = cmd.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi cập nhật chi tiết xuất hàng: {ex.Message}");
                return false;
            }
        }

        //lay danh sach kho theo khoang thoi gian
        public DataTable GetExportsByDateRange(DateTime startDate, DateTime endDate)
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection conn = Connection.GetSqlConnection())
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("usp_GetExportsByDate", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@StartDate", startDate);
                        cmd.Parameters.AddWithValue("@EndDate", endDate);
                        using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                        {
                            adapter.Fill(dt);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi lọc danh sách xuất kho theo ngày: {ex.Message}");
            }
            return dt;
        }

        public bool ValidateExportID(string exportID, out string errorMessage)
        {
            errorMessage = "";
            if (string.IsNullOrWhiteSpace(exportID))
            {
                errorMessage = "Vui lòng nhập mã xuất hàng.";
                return false;
            }
            if (!int.TryParse(exportID, out _))
            {
                errorMessage = "Mã xuất hàng phải là số.";
                return false;
            }
            return true;
        }

        public bool ValidateExportDate(DateTime exportDate, out string errorMessage)
        {
            errorMessage = "";
            if (exportDate > DateTime.Now.Date)
            {
                errorMessage = "Ngày xuất kho không thể lớn hơn ngày hiện tại.";
                return false;
            }
            return true;
        }

        public bool ValidateEmployeeSelection(object selectedValue, out string errorMessage)
        {
            errorMessage = "";
            if (selectedValue == null)
            {
                errorMessage = "Vui lòng chọn nhân viên xử lý đơn xuất kho.";
                return false;
            }
            return true;
        }

        //kiem tra ma san pham hop le hay khong
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

        //kiem tra so luong la so nguyen duong
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

        //kiem tra gia phai la so duong
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

        //kiem tra khach hang co hop le khong
        public bool ValidateCustomerSelection(object selectedValue, out string errorMessage)
        {
            errorMessage = "";
            if (selectedValue == null)
            {
                errorMessage = "Vui lòng chọn khách hàng.";
                return false;
            }
            return true;
        }

        //tinh tong tien
        public decimal CalculateTotal(DataGridView dgvExportDetails)
        {
            decimal totalAmount = 0;

            foreach (DataGridViewRow row in dgvExportDetails.Rows)
            {
                if (!row.IsNewRow)
                {
                    decimal price = Convert.ToDecimal(row.Cells["Price"].Value);
                    int quantity = Convert.ToInt32(row.Cells["Quantity"].Value);
                    totalAmount += price * quantity;
                }
            }

            return totalAmount;
        }

        //tai danh sach kho
        public DataTable LoadExports()
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection conn = Connection.GetSqlConnection())
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("usp_GetExports", conn))
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        adapter.Fill(dt);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi tải danh sách xuất kho: {ex.Message}");
            }
            return dt;
        }

        //xuat thong tin tren kho
        public void ClearExportForm(TextBox txtExportID, TextBox txtProductID, NumericUpDown txtQuantity, TextBox txtPrice, Label lblTotalAmount)
        {
            txtExportID.Clear();
            txtProductID.Clear();
            txtQuantity.Value = 1;
            txtPrice.Clear();
            lblTotalAmount.Text = "0 VND";
        }

        //them don xuat hang
        public bool AddExport(DateTime exportDate, int customerId, decimal totalAmount)
        {
            try
            {
                using (SqlConnection conn = Connection.GetSqlConnection())
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("usp_AddExport", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@ExportDate", exportDate);
                        cmd.Parameters.AddWithValue("@CustomerID", customerId);
                        cmd.Parameters.AddWithValue("@TotalAmount", totalAmount);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi thêm đơn xuất hàng: {ex.Message}");
                return false;
            }
        }

        //sua don xuat hang
        public bool UpdateExport(int exportId, DateTime exportDate, int customerId, decimal totalAmount)
        {
            try
            {
                using (SqlConnection conn = Connection.GetSqlConnection())
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("usp_UpdateExport", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@ExportID", exportId);
                        cmd.Parameters.AddWithValue("@ExportDate", exportDate);
                        cmd.Parameters.AddWithValue("@CustomerID", customerId);
                        cmd.Parameters.AddWithValue("@TotalAmount", totalAmount);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi cập nhật đơn xuất hàng: {ex.Message}");
                return false;
            }
        }

        public int GetSelectedExportID(DataGridView dgvExports)
        {
            if (dgvExports.SelectedRows.Count > 0)
            {
                return Convert.ToInt32(dgvExports.SelectedRows[0].Cells["ExportID"].Value);
            }

            // Trả về -1 nếu không có dòng nào được chọn
            return -1; 
        }

        //su kien kiem tra va lay thong tin san pham
        public (int productId, int quantity, decimal price) GetSelectedExportDetail(DataGridView dgvExportDetails)
        {
            if (dgvExportDetails.SelectedRows.Count > 0)
            {
                int productId = Convert.ToInt32(dgvExportDetails.SelectedRows[0].Cells["ProductID"].Value);
                int quantity = Convert.ToInt32(dgvExportDetails.SelectedRows[0].Cells["Quantity"].Value);
                decimal price = Convert.ToDecimal(dgvExportDetails.SelectedRows[0].Cells["Price"].Value);

                return (productId, quantity, price);
            }

            // Trả về giá trị mặc định nếu không có dòng nào được chọn
            return (-1, 0, 0); 
        }
    }
}
