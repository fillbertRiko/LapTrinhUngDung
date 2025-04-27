using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using UngDungQuanLyKho.Data.Database;
using UngDungQuanLyKho.Data.Models;
using UngDungQuanLyKho.Data.UI.Forms.Index;

namespace UngDungQuanLyKho.Data.View.MENU
{
    public partial class PhieuNhapKho : Form
    {
        private readonly Modify db = new Modify();

        public PhieuNhapKho()
        {
            InitializeComponent();

            // Chỉ subscribe DataBindingComplete một lần
            dgvImports.DataBindingComplete += dataGridView1_DataBindingComplete;

            // Gán sự kiện cho các nút, giữ nguyên tên btnXXX_Click
            btnShowData.Click += btnShowData_Click;
            btnClear.Click += btnClear_Click;
            btnAdd.Click += btnAdd_Click;
            btnUpdate.Click += btnUpdate_Click;
            btnDelete.Click += btnDelete_Click;
            btnBackMenu.Click += btnBackMenu_Click;
            //btnNew.Click += btnNew_Click;

            // Khi Form load, gọi LoadData
            this.Load += PhieuNhapKho_Load;
        }

        private void PhieuNhapKho_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                ImportModel importModel = new ImportModel();
                DataTable dt = importModel.GetImports();

                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("Không có phiếu nhập nào!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dgvImports.DataSource = null;
                    return;
                }

                dgvImports.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải danh sách phiếu nhập: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void dataGridView1_DataBindingComplete(object sender,
                                                       DataGridViewBindingCompleteEventArgs e)
        {
            // Ẩn cột không cần thiết
            foreach (string col in new[] { "ImportID","ProductID","Quantity",
                                           "Price","ImportDate","EmployeeID",
                                           "Supplier" })
            {
                if (dgvImports.Columns.Contains(col))
                    dgvImports.Columns[col].Visible = false;
            }

            // Tắt sort và resize columns
            foreach (DataGridViewColumn c in dgvImports.Columns)
                c.SortMode = DataGridViewColumnSortMode.NotSortable;

            dgvImports.AutoResizeColumns();
        }

        private void btnShowData_Click(object sender, EventArgs e)
        {
            ImportModel importModel = new ImportModel();
            dgvImports.DataSource = importModel.GetImports();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            dgvImports.DataSource = null;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtProductID.Text) || string.IsNullOrWhiteSpace(txtQuantity.Text) || string.IsNullOrWhiteSpace(txtPrice.Text))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin sản phẩm!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                ImportModel importModel = new ImportModel();
                int importId = importModel.AddImport(dtpImportDate.Value, Convert.ToInt32(cbEmployeeID.SelectedValue), cbbSupplier.Text);

                if (importId > 0)
                {
                    importModel.AddImportDetail(importId, Convert.ToInt32(txtProductID.Text), Convert.ToInt32(txtQuantity.Text), Convert.ToDecimal(txtPrice.Text));
                    MessageBox.Show("Phiếu nhập đã được thêm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData();
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Số lượng và giá phải là số hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi thêm phiếu nhập: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvImports.CurrentRow == null)
                {
                    MessageBox.Show("Vui lòng chọn một phiếu nhập để chỉnh sửa!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var parameters = new[]
                {
            new SqlParameter("@ImportID", GetSelectedID()),
            new SqlParameter("@ProductID", txtProductID.Text),
            new SqlParameter("@Quantity", int.Parse(txtQuantity.Text)),
            new SqlParameter("@Price", decimal.Parse(txtPrice.Text)),
            new SqlParameter("@ImportDate", dtpImportDate.Value),
            new SqlParameter("@EmployeeID", cbEmployeeID.Text),
            new SqlParameter("@Supplier", cbbSupplier.Text)
        };

                db.ExecuteStoredProcedure("usp_UpdateImport", parameters);
                LoadData();
                MessageBox.Show("Cập nhật phiếu nhập thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi cập nhật phiếu nhập: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvImports.CurrentRow == null)
                {
                    MessageBox.Show("Vui lòng chọn một phiếu nhập để xóa!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (MessageBox.Show("Bạn có chắc chắn muốn xóa phiếu nhập này?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    var idParam = new[] { new SqlParameter("@ImportID", GetSelectedID()) };
                    db.ExecuteStoredProcedure("usp_DeleteImport", idParam);
                    LoadData();
                    MessageBox.Show("Phiếu nhập đã được xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi xóa phiếu nhập: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBackMenu_Click(object sender, EventArgs e)
        {
            var menu = new Welcome();
            this.Hide();  // Ẩn form hiện tại thay vì đóng ngay lập tức
            menu.ShowDialog();
            this.Close();  // Đóng form sau khi Welcome đã được đóng
        }

        private void btnExit_Click(object sender, EventArgs e)
        {

        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            var f = new PhieuNhapKho();
            f.ShowDialog();
            this.Hide();
            f.Close();
            this.Close();
        }

        // Lấy ID dòng hiện tại
        private int GetSelectedID()
        {
            if (dgvImports.CurrentRow == null)
                throw new InvalidOperationException("Chưa chọn bản ghi.");
            return Convert.ToInt32(dgvImports.CurrentRow.Cells["ImportID"].Value);
        }

        //hien thi chi tiet nhap hang khi chon mot phieu nhap
        private void dgvImports_SelectionChanged(object sender, EventArgs e)
        {
            /*
            if (dgvImports.SelectedRows.Count > 0)
            {
                int importId = Convert.ToInt32(dgvImports.SelectedRows[0].Cells["ImportID"].Value);
                ImportModel importModel = new ImportModel();
                dgvImportDetails.DataSource = importModel.GetImportDetails(importId);
            }
            */
        }

        private void btnAddImport_Click(object sender, EventArgs e)
        {
            ImportModel importModel = new ImportModel();
            int importId = importModel.AddImport(dtpImportDate.Value, Convert.ToInt32(cbEmployeeID.SelectedValue), cbbSupplier.Text);

            if (importId > 0)
            {
                MessageBox.Show("Phiếu nhập đã được thêm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadImports();
            }
        }
        /*
        private void btnAddImportDetail_Click(object sender, EventArgs e)
        {
            if (dgvImports.SelectedRows.Count == 0)
            {
                MessageBox.Show("Chọn một phiếu nhập trước!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int importId = Convert.ToInt32(dgvImports.SelectedRows[0].Cells["ImportID"].Value);
            ImportModel importModel = new ImportModel();
            importModel.AddImportDetail(importId, Convert.ToInt32(cbProduct.SelectedValue), Convert.ToInt32(txtQuantity.Text), Convert.ToDecimal(txtPrice.Text));

            MessageBox.Show("Sản phẩm đã được nhập!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LoadImports();
        }
        */

        //phuong thuc lay du lieu nhap hang trong database
        private void LoadImports()
        {
            try
            {
                ImportModel importModel = new ImportModel();
                DataTable dt = importModel.GetImports();

                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("Không có phiếu nhập nào!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dgvImports.DataSource = null;
                    return;
                }

                dgvImports.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải danh sách phiếu nhập: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExitForm_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc muốn thoát không?", "Xác nhận",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void txtProductID_TextChanged(object sender, EventArgs e)
        {
            ImportModel importModel = new ImportModel();
            if (!importModel.ValidateProductID(txtProductID.Text, out string errorMessage))
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

        private void dtpImportDate_ValueChanged(object sender, EventArgs e)
        {
            ImportModel importModel = new ImportModel();
            if (!importModel.ValidateImportDate(dtpImportDate.Value, out string errorMessage))
            {
                errorProvider1.SetError(dtpImportDate, errorMessage);
            }
            else
            {
                errorProvider1.SetError(dtpImportDate, string.Empty);
            }
        }

        private void cbEmployeeID_SelectedIndexChanged(object sender, EventArgs e)
        {
            ImportModel importModel = new ImportModel();
            if (!importModel.ValidateEmployeeSelection(cbEmployeeID.SelectedValue, out string errorMessage))
            {
                errorProvider1.SetError(cbEmployeeID, errorMessage);
            }
            else
            {
                errorProvider1.SetError(cbEmployeeID, string.Empty);
            }
        }

        private void cbbSupplier_SelectedIndexChanged(object sender, EventArgs e)
        {
            ImportModel importModel = new ImportModel();
            if (!importModel.ValidateSupplierSelection(cbbSupplier.SelectedValue, out string errorMessage))
            {
                errorProvider1.SetError(cbbSupplier, errorMessage);
            }
            else
            {
                errorProvider1.SetError(cbbSupplier, string.Empty);
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            ImportModel importModel = new ImportModel();
            if (!importModel.ValidateTextInput(textBox3.Text, out string errorMessage))
            {
                textBox3.BackColor = Color.LightPink;
                errorProvider1.SetError(textBox3, errorMessage);
            }
            else
            {
                textBox3.BackColor = Color.White;
                errorProvider1.SetError(textBox3, string.Empty);
            }
        }

        private void txtQuantity_ValueChanged(object sender, EventArgs e)
        {
            ImportModel importModel = new ImportModel();
            if (!importModel.ValidateQuantity((int)txtQuantity.Value, out string errorMessage))
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
            ImportModel importModel = new ImportModel();
            if (!importModel.ValidatePrice(txtPrice.Text, out string errorMessage))
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
    }
}
