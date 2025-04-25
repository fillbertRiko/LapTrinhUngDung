using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UngDungQuanLyKho.Data.Models;
using OfficeOpenXml;
using System.IO;

namespace UngDungQuanLyKho.Data.View.MENU
{
    public partial class PhieuXuatKho : Form
    {
        public PhieuXuatKho()
        {
            InitializeComponent();
        }

        //load danh sach xuat kho
        private void LoadExports()
        {
            try
            {
                ExportModel exportModel = new ExportModel();
                DataTable dt = exportModel.GetExports();

                if (dt == null || dt.Rows.Count == 0)
                {
                    MessageBox.Show("Không có đơn xuất hàng nào!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dgvExports.DataSource = null;
                    return;
                }

                dgvExports.DataSource = dt;

                //hien thi cot tong tien
                if (dgvExports.Columns.Contains("TotalAmount"))
                {
                    dgvExports.Columns["TotalAmount"].HeaderText = "Tổng tiền";
                    dgvExports.Columns["TotalAmount"].DefaultCellStyle.Format = "N2"; // Hiển thị 2 chữ số thập phân
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải danh sách xuất hàng: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Exports_Load(object sender, EventArgs e)
        {
            LoadExports();
        }

        //kiem tra database trước khi tải chi tiết xuất hàng
        private void dgvExports_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dgvExports.SelectedRows.Count > 0)
                {
                    int exportId = Convert.ToInt32(dgvExports.SelectedRows[0].Cells["ExportID"].Value);
                    decimal totalAmount = Convert.ToDecimal(dgvExports.SelectedRows[0].Cells["TotalAmount"].Value);

                    lblTotalAmount.Text = $"Tổng tiền đơn xuất: {totalAmount:N2} VND";
                    LoadExportDetails(exportId);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi hiển thị tổng tiền: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //them kiem tra chi tiet xuat hang
        //tranh tinh trang loi khi khong co san pham nao xuat hang
        private void LoadExportDetails(int exportId)
        {
            try
            {
                ExportModel exportModel = new ExportModel();
                DataTable dt = exportModel.GetExportDetails(exportId);

                if (dt == null || dt.Rows.Count == 0)
                {
                    dgvExportDetails.DataSource = null;
                    MessageBox.Show("Không có chi tiết sản phẩm nào cho đơn xuất này!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                dgvExportDetails.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải chi tiết xuất hàng: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //chuc nang xuat hang
        private void btnAddExport_Click(object sender, EventArgs e)
        {
            try
            {
                ExportModel exportModel = new ExportModel();
                int exportId = exportModel.AddExportDetail(dtpExportDate.Value, Convert.ToInt32(cbCustomerID.SelectedValue), Convert.ToDecimal(lblTotalAmount.Text));

                if (exportId > 0)
                {
                    MessageBox.Show("Đơn xuất hàng đã được thêm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadExports();
                }
                else
                {
                    MessageBox.Show("Lỗi khi thêm đơn xuất hàng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Vui lòng nhập đúng định dạng số!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi thêm đơn xuất hàng: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            ExportModel exportModel = new ExportModel();
            exportModel.ExportExportsToExcel(dgvExports);
        }
    }
}
