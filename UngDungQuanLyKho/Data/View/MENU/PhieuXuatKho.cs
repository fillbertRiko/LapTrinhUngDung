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

        private void txtExportID_TextChanged(object sender, EventArgs e)
        {
            ExportModel exportModel = new ExportModel();
            if (!exportModel.ValidateExportID(txtExportID.Text, out string errorMessage))
            {
                txtExportID.BackColor = Color.LightPink;
                errorProvider1.SetError(txtExportID, errorMessage);
            }
            else
            {
                txtExportID.BackColor = Color.White;
                errorProvider1.SetError(txtExportID, string.Empty);
            }

        }

        private void dtpExportDate_ValueChanged(object sender, EventArgs e)
        {
            ExportModel exportModel = new ExportModel();
            if (!exportModel.ValidateExportDate(dtpExportDate.Value, out string errorMessage))
            {
                errorProvider1.SetError(dtpExportDate, errorMessage);
            }
            else
            {
                errorProvider1.SetError(dtpExportDate, string.Empty);
            }

        }

        private void cbEmployeeID_SelectedIndexChanged(object sender, EventArgs e)
        {
            ExportModel exportModel = new ExportModel();
            if (!exportModel.ValidateEmployeeSelection(cbEmployeeID.SelectedValue, out string errorMessage))
            {
                errorProvider1.SetError(cbEmployeeID, errorMessage);
            }
            else
            {
                errorProvider1.SetError(cbEmployeeID, string.Empty);
            }

        }

        private void cbCustomerID_SelectedIndexChanged(object sender, EventArgs e)
        {
            ExportModel exportModel = new ExportModel();
            if (!exportModel.ValidateCustomerSelection(cbCustomerID.SelectedValue, out string errorMessage))
            {
                errorProvider1.SetError(cbCustomerID, errorMessage);
            }
            else
            {
                errorProvider1.SetError(cbCustomerID, string.Empty);
            }
        }

        private void txtProductID_TextChanged(object sender, EventArgs e)
        {
            ExportModel exportModel = new ExportModel();
            if (!exportModel.ValidateProductID(txtProductID.Text, out string errorMessage))
            {
                txtProductID.BackColor = Color.LightPink;
                errorProvider1.SetError(txtProductID, errorMessage);
            }
            else
            {
                txtProductID.BackColor = Color.White;
                errorProvider1.SetError(txtProductID, string.Empty);
            }
        }

        private void txtQuantity_ValueChanged(object sender, EventArgs e)
        {
            ExportModel exportModel = new ExportModel();
            if (!exportModel.ValidateQuantity((int)txtQuantity.Value, out string errorMessage))
            {
                errorProvider1.SetError(txtQuantity, errorMessage);
            }
            else
            {
                errorProvider1.SetError(txtQuantity, string.Empty);
            }
        }

        private void txtPrice_TextChanged(object sender, EventArgs e)
        {
            ExportModel exportModel = new ExportModel();
            if (!exportModel.ValidatePrice(txtPrice.Text, out string errorMessage))
            {
                txtPrice.BackColor = Color.LightPink;
                errorProvider1.SetError(txtPrice, errorMessage);
            }
            else
            {
                txtPrice.BackColor = Color.White;
                errorProvider1.SetError(txtPrice, string.Empty);
            }
        }

        private void btnCaculateTotal_Click(object sender, EventArgs e)
        {
            ExportModel exportModel = new ExportModel();
            decimal totalAmount = exportModel.CalculateTotal(dgvExportDetails);
            lblTotalAmount.Text = $"Tổng tiền đơn xuất: {totalAmount:N2} VND";
        }

        private void btnExportExcel_Click_1(object sender, EventArgs e)
        {
            ExportModel exportModel = new ExportModel();
            exportModel.ExportExportsToExcel(dgvExports);
        }

        private void btnLoadExports_Click(object sender, EventArgs e)
        {
            ExportModel exportModel = new ExportModel();
            dgvExports.DataSource = exportModel.LoadExports();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ExportModel exportModel = new ExportModel();
            exportModel.ClearExportForm(txtExportID, txtProductID, txtQuantity, txtPrice, lblTotalAmount);
        }

        private void btnAddExport_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (cbCustomerID.SelectedValue == null)
                {
                    MessageBox.Show("Vui lòng chọn khách hàng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                decimal totalAmount = decimal.TryParse(lblTotalAmount.Text.Replace(" VND", ""), out decimal amount) ? amount : 0;

                ExportModel exportModel = new ExportModel();
                bool success = exportModel.AddExport(dtpExportDate.Value, Convert.ToInt32(cbCustomerID.SelectedValue), totalAmount);

                if (success)
                {
                    MessageBox.Show("Thêm đơn xuất hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnLoadExports_Click(sender, e);
                }
                else
                {
                    MessageBox.Show("Thêm đơn xuất hàng thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi thêm đơn xuất hàng: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEditExport_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvExports.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Vui lòng chọn đơn xuất hàng cần sửa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int exportId = Convert.ToInt32(dgvExports.SelectedRows[0].Cells["ExportID"].Value);
                decimal totalAmount = decimal.TryParse(lblTotalAmount.Text.Replace(" VND", ""), out decimal amount) ? amount : 0;

                ExportModel exportModel = new ExportModel();
                bool success = exportModel.UpdateExport(exportId, dtpExportDate.Value, Convert.ToInt32(cbCustomerID.SelectedValue), totalAmount);

                if (success)
                {
                    MessageBox.Show("Cập nhật đơn xuất hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnLoadExports_Click(sender, e);
                }
                else
                {
                    MessageBox.Show("Cập nhật đơn xuất hàng thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi cập nhật đơn xuất hàng: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDeleteExport_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvExports.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Vui lòng chọn đơn xuất hàng cần xoá!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int exportId = Convert.ToInt32(dgvExports.SelectedRows[0].Cells["ExportID"].Value);
                DialogResult confirmDelete = MessageBox.Show($"Bạn có chắc chắn muốn xoá đơn xuất hàng có ID {exportId}?",
                    "Xác nhận xoá", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (confirmDelete == DialogResult.Yes)
                {
                    ExportModel exportModel = new ExportModel();
                    bool success = exportModel.DeleteExport(exportId);

                    if (success)
                    {
                        MessageBox.Show("Xoá đơn xuất hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        btnLoadExports_Click(sender, e);
                    }
                    else
                    {
                        MessageBox.Show("Lỗi khi xoá đơn xuất hàng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi xoá đơn xuất hàng: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        
        private void btnShowDetails_Click(object sender, EventArgs e)
        {
            if (dgvExports.SelectedRows.Count > 0)
            {
                int exportId = Convert.ToInt32(dgvExports.SelectedRows[0].Cells["ExportID"].Value);
                LoadExportDetails(exportId);
            }
        }

        private void btnBackMenu_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvExports_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            ExportModel exportModel = new ExportModel();
            int exportId = exportModel.GetSelectedExportID(dgvExports);

            if (exportId > 0)
            {
                LoadExportDetails(exportId);
                decimal totalAmount = decimal.TryParse(dgvExports.SelectedRows[0].Cells["TotalAmount"].Value.ToString(), out decimal amount) ? amount : 0;
                lblTotalAmount.Text = $"Tổng tiền đơn xuất: {totalAmount:N2} VND";
            }
        }

        private void dgvExportDetails_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            ExportModel exportModel = new ExportModel();
            var (productId, quantity, price) = exportModel.GetSelectedExportDetail(dgvExportDetails);

            if (productId > 0)
            {
                txtProductID.Text = productId.ToString();
                txtQuantity.Value = quantity;
                txtPrice.Text = price.ToString("N2");
            }
        }
    }
}
