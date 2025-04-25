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
    public partial class Products : Form
    {
        public Products()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void Products_Load(object sender, EventArgs e)
        {
            LoadProducts();
        }

        private void LoadProducts()
        {
            ProductModel productModel = new ProductModel();
            dgvProducts.DataSource = productModel.GetProducts();
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            ProductModel productModel = new ProductModel();
            dgvProducts.DataSource = productModel.SearchProducts(txtSearch.Text);
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            ProductModel productModel = new ProductModel();
            productModel.AddProduct(txtProductName.Text, txtCategory.Text, txtUnit.Text, int.Parse(txtQuantity.Text), int.Parse(txtMinQuantity.Text), int.Parse(txtLocationID.Text));
            LoadProducts(); // Cập nhật danh sách sản phẩm
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            int productId = Convert.ToInt32(dgvProducts.SelectedRows[0].Cells["ProductID"].Value);
            ProductModel productModel = new ProductModel();
            productModel.UpdateProduct(productId, txtProductName.Text, txtCategory.Text, txtUnit.Text, int.Parse(txtQuantity.Text), int.Parse(txtMinQuantity.Text), int.Parse(txtLocationID.Text));
            LoadProducts();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int productId = Convert.ToInt32(dgvProducts.SelectedRows[0].Cells["ProductID"].Value);
            ProductModel productModel = new ProductModel();
            productModel.DeleteProduct(productId);
            LoadProducts();
        }

        private void btnStockReport_Click(object sender, EventArgs e)
        {
            StockStatus stockStatus = new StockStatus();
            stockStatus.ShowDialog();
        }

        private void dgvProducts_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {

        }
    }
}
