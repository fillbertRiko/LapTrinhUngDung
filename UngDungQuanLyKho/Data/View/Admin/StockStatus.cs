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
            int quantity = Convert.ToInt32(dgvStockStatus.Rows[e.RowIndex].Cells["Quantity"].Value);
            int minQuantity = Convert.ToInt32(dgvStockStatus.Rows[e.RowIndex].Cells["MinQuantity"].Value);

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
        /*
        private void btnSendAlert_Click(object sender, EventArgs e)
        {
            ProductModel productModel = new ProductModel();
            productModel.SendLowStockAlert("manager@example.com"); // Email quản lý kho
        }
        */
    }
}
