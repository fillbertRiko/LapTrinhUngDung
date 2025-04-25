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
    }
}
