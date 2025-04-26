using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using UngDungQuanLyKho.Data.Models;

namespace UngDungQuanLyKho.Data.View.Admin
{
    public partial class StockStatus : Form
    {
        public StockStatus()
        {
            InitializeComponent();
        }

        private void StockStatus_Load(object sender, EventArgs e)
        {
            LoadLowStockProducts();
            dgvStockStatus.RowPrePaint += dgvStockStatus_RowPrePaint;

            //kiem tra san pham ton kho thap
            if (dgvStockStatus.Rows.Count > 0)
            {
                MessageBox.Show($"Có {dgvStockStatus.Rows.Count} sản phẩm dưới mức tồn kho tối thiểu!",
                                "Cảnh báo hàng tồn kho", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void LoadLowStockProducts()
        {
            ProductModel productModel = new ProductModel();
            dgvStockStatus.DataSource = productModel.GetLowStockProducts();
        }

        private void dgvStockStatus_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            object quantityObj = dgvStockStatus.Rows[e.RowIndex].Cells["Quantity"].Value;
            object minQuantityObj = dgvStockStatus.Rows[e.RowIndex].Cells["MinQuantity"].Value;

            if (quantityObj == null || minQuantityObj == null || quantityObj == DBNull.Value || minQuantityObj == DBNull.Value)
            {
                return; // Bỏ qua hàng nếu có dữ liệu trống
            }

            int quantity = Convert.ToInt32(quantityObj);
            int minQuantity = Convert.ToInt32(minQuantityObj);

            if (quantity == 0)
            {
                dgvStockStatus.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Red; // Hết hàng
                dgvStockStatus.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.White;
            }
            else if (quantity < minQuantity)
            {
                dgvStockStatus.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Yellow; // Sắp hết
            }
        }

        private void dgvStockStatus_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Kiểm tra chỉ số hàng hợp lệ
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvStockStatus.Rows[e.RowIndex];

                // Giả sử các cột chính của sản phẩm tồn kho là "ProductName", "Quantity" và "MinQuantity"
                string productName = row.Cells["ProductName"].Value?.ToString() ?? "";
                string quantity = row.Cells["Quantity"].Value?.ToString() ?? "";
                string minQuantity = row.Cells["MinQuantity"].Value?.ToString() ?? "";

                // Hiển thị chi tiết sản phẩm dưới dạng MessageBox (có thể thay thế bằng cách mở form chi tiết nếu cần)
                MessageBox.Show(
                    $"Sản phẩm: {productName}\nSố lượng hiện tại: {quantity}\nMức tồn tối thiểu: {minQuantity}",
                    "Chi tiết sản phẩm",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
        }

        private void btnRefesh_Click(object sender, EventArgs e)
        {
            // Tải lại danh sách sản phẩm
            LoadLowStockProducts();
        }

        private void btnSendAlert_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Đã gửi thông báo đến quản lý kho!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
