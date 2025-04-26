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
        private DataTable dtProducts;  // lưu toàn bộ danh sách sản phẩm
        private int currentPage = 1;
        private int pageSize = 10;     // số hàng trên một trang (có thể điều chỉnh)
        private int totalPages = 0;

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
            try
            {
                ProductModel productModel = new ProductModel();
                dtProducts = productModel.GetProducts();
                currentPage = 1;
                totalPages = (int)Math.Ceiling((double)dtProducts.Rows.Count / pageSize);
                DisplayPage(currentPage);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading products: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DisplayPage(int pageNumber)
        {
            if (dtProducts == null || dtProducts.Rows.Count == 0)
            {
                dgvProducts.DataSource = null;
                return;
            }

            DataTable dtPage = dtProducts.Clone(); // tạo bảng mới với cùng cấu trúc
            int startIndex = (pageNumber - 1) * pageSize;
            int endIndex = Math.Min(startIndex + pageSize, dtProducts.Rows.Count);

            for (int i = startIndex; i < endIndex; i++)
            {
                dtPage.ImportRow(dtProducts.Rows[i]);
            }

            dgvProducts.DataSource = dtPage;

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            ProductModel productModel = new ProductModel();
            dgvProducts.DataSource = productModel.SearchProducts(txtSearch.Text);
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            
        }

        private void btnStockReport_Click(object sender, EventArgs e)
        {
            StockStatus stockStatus = new StockStatus();
            stockStatus.ShowDialog();
        }

        private void dgvProducts_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {

        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            //xu ly
            LoadProducts();
        }

        private void btnPrevPage_Click(object sender, EventArgs e)
        {
            if (currentPage > 1)
            {
                currentPage--;
                DisplayPage(currentPage);
            }
            else
            {
                MessageBox.Show("Bạn đã ở trang đầu tiên.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnNextPage_Click(object sender, EventArgs e)
        {
            if (currentPage < totalPages)
            {
                currentPage++;
                DisplayPage(currentPage);
            }
            else
            {
                MessageBox.Show("Bạn đã ở trang cuối cùng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        // Sự kiện nhấn nút tìm kiếm (phiên bản 1)
        private void btnSearch_Click_1(object sender, EventArgs e)
        {
            string keyword = txtSearch.Text.Trim();
            ProductModel productModel = new ProductModel();

            // Nếu tìm kiếm rỗng, tải lại danh sách sản phẩm
            if (string.IsNullOrEmpty(keyword))
            {
                LoadProducts();
            }
            else
            {
                DataTable dt = productModel.SearchProducts(keyword);
                dgvProducts.DataSource = dt;
            }
        }

        // Sự kiện tìm kiếm khi văn bản trong ô txtSearch thay đổi
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            // Có thể gọi tìm kiếm ngay khi người dùng gõ, để cập nhật theo thời gian thực.
            string keyword = txtSearch.Text.Trim();
            ProductModel productModel = new ProductModel();

            // Nếu ô tìm kiếm trống, hiển thị toàn bộ sản phẩm; nếu không, tìm kiếm theo từ khóa.
            if (string.IsNullOrEmpty(keyword))
            {
                LoadProducts();
            }
            else
            {
                DataTable dt = productModel.SearchProducts(keyword);
                dgvProducts.DataSource = dt;
            }
        }

        private void txtProductName_TextChanged(object sender, EventArgs e)
        {
            // Kiểm tra nếu trường "Tên sản phẩm" để trống
            if (string.IsNullOrWhiteSpace(txtProductName.Text))
            {
                // Đổi màu nền để cảnh báo, thiết lập thông báo lỗi
                txtProductName.BackColor = Color.LightPink;
                if (errorProvider1 != null)
                    errorProvider1.SetError(txtProductName, "Vui lòng nhập tên sản phẩm.");
            }
            else
            {
                // Nếu có dữ liệu, đặt lại màu nền và xóa thông báo lỗi
                txtProductName.BackColor = Color.White;
                if (errorProvider1 != null)
                    errorProvider1.SetError(txtProductName, string.Empty);
            }
        }

        private void txtCategory_TextChanged(object sender, EventArgs e)
        {
            // Kiểm tra nếu trường "Danh mục" để trống
            if (string.IsNullOrWhiteSpace(txtCategory.Text))
            {
                // Đổi màu nền và thông báo lỗi
                txtCategory.BackColor = Color.LightPink;
                if (errorProvider1 != null)
                    errorProvider1.SetError(txtCategory, "Vui lòng nhập danh mục.");
            }
            else
            {
                // Nếu có dữ liệu, đặt lại màu nền và xóa lỗi
                txtCategory.BackColor = Color.White;
                if (errorProvider1 != null)
                    errorProvider1.SetError(txtCategory, string.Empty);
            }
        }

        // Xử lý cho txtUnit: chỉ cần kiểm tra không được để trống
        private void txtUnit_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUnit.Text))
            {
                txtUnit.BackColor = Color.LightPink;
                if (errorProvider1 != null)
                    errorProvider1.SetError(txtUnit, "Vui lòng nhập đơn vị.");
            }
            else
            {
                txtUnit.BackColor = Color.White;
                if (errorProvider1 != null)
                    errorProvider1.SetError(txtUnit, string.Empty);
            }
        }

        // Xử lý cho txtQuantity: nhập số phải là số nguyên và không được để trống
        private void txtQuantity_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtQuantity.Text))
            {
                txtQuantity.BackColor = Color.LightPink;
                if (errorProvider1 != null)
                    errorProvider1.SetError(txtQuantity, "Vui lòng nhập số lượng.");
            }
            else
            {
                if (!int.TryParse(txtQuantity.Text, out int temp))
                {
                    txtQuantity.BackColor = Color.LightPink;
                    if (errorProvider1 != null)
                        errorProvider1.SetError(txtQuantity, "Số lượng phải là số nguyên.");
                }
                else
                {
                    txtQuantity.BackColor = Color.White;
                    if (errorProvider1 != null)
                        errorProvider1.SetError(txtQuantity, string.Empty);
                }
            }
        }

        // Xử lý cho txtMinQuantity: nhập số không được để trống và phải là số nguyên
        private void txtMinQuantity_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMinQuantity.Text))
            {
                txtMinQuantity.BackColor = Color.LightPink;
                if (errorProvider1 != null)
                    errorProvider1.SetError(txtMinQuantity, "Vui lòng nhập mức tồn tối thiểu.");
            }
            else
            {
                if (!int.TryParse(txtMinQuantity.Text, out int temp))
                {
                    txtMinQuantity.BackColor = Color.LightPink;
                    if (errorProvider1 != null)
                        errorProvider1.SetError(txtMinQuantity, "Mức tồn tối thiểu phải là số nguyên.");
                }
                else
                {
                    txtMinQuantity.BackColor = Color.White;
                    if (errorProvider1 != null)
                        errorProvider1.SetError(txtMinQuantity, string.Empty);
                }
            }
        }

        // Xử lý cho txtLocationID: nhập mã vị trí phải là số nguyên và không được để trống
        private void txtLocationID_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtLocationID.Text))
            {
                txtLocationID.BackColor = Color.LightPink;
                if (errorProvider1 != null)
                    errorProvider1.SetError(txtLocationID, "Vui lòng nhập mã vị trí.");
            }
            else
            {
                if (!int.TryParse(txtLocationID.Text, out int temp))
                {
                    txtLocationID.BackColor = Color.LightPink;
                    if (errorProvider1 != null)
                        errorProvider1.SetError(txtLocationID, "Mã vị trí phải là số nguyên.");
                }
                else
                {
                    txtLocationID.BackColor = Color.White;
                    if (errorProvider1 != null)
                        errorProvider1.SetError(txtLocationID, string.Empty);
                }
            }
        }

        private void btnAdd_Click_1(object sender, EventArgs e)
        {
            ProductModel productModel = new ProductModel();
            productModel.AddProduct(txtProductName.Text, txtCategory.Text, txtUnit.Text, int.Parse(txtQuantity.Text), int.Parse(txtMinQuantity.Text), int.Parse(txtLocationID.Text));
            LoadProducts(); // Cập nhật danh sách sản phẩm

            //thong bao 
            MessageBox.Show("Thêm sản phẩm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnEdit_Click_1(object sender, EventArgs e)
        {
            int productId = Convert.ToInt32(dgvProducts.SelectedRows[0].Cells["ProductID"].Value);
            ProductModel productModel = new ProductModel();
            productModel.UpdateProduct(productId, txtProductName.Text, txtCategory.Text, txtUnit.Text, int.Parse(txtQuantity.Text), int.Parse(txtMinQuantity.Text), int.Parse(txtLocationID.Text));
            LoadProducts();
            //thong bao
            MessageBox.Show("Cập nhật sản phẩm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnDelete_Click_1(object sender, EventArgs e)
        {
            int productId = Convert.ToInt32(dgvProducts.SelectedRows[0].Cells["ProductID"].Value);
            ProductModel productModel = new ProductModel();
            productModel.DeleteProduct(productId);
            LoadProducts();
            //thong bao
            MessageBox.Show("Xóa sản phẩm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // Sự kiện khi click vào nội dung trong dgvProducts
        private void dgvProducts_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Kiểm tra chỉ số hàng hợp lệ
            if (e.RowIndex >= 0)
            {
                // Lấy hàng được click
                DataGridViewRow row = dgvProducts.Rows[e.RowIndex];

                // Giả sử cột tên cột trùng với tên các TextBox
                txtProductName.Text = row.Cells["ProductName"].Value?.ToString() ?? "";
                txtCategory.Text = row.Cells["Category"].Value?.ToString() ?? "";
                txtUnit.Text = row.Cells["Unit"].Value?.ToString() ?? "";
                txtQuantity.Text = row.Cells["Quantity"].Value?.ToString() ?? "";
                txtMinQuantity.Text = row.Cells["MinQuantity"].Value?.ToString() ?? "";
                txtLocationID.Text = row.Cells["LocationID"].Value?.ToString() ?? "";
            }
        }        
    }
}
