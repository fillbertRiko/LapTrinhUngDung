using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using UngDungQuanLyKho.Data.Database;
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
            dataGridView1.DataBindingComplete += dataGridView1_DataBindingComplete; 

            // Gán sự kiện cho các nút, giữ nguyên tên btnXXX_Click
            btnShowData.Click += btnShowData_Click;
            btnClear.Click += btnClear_Click;
            btnAdd.Click += btnAdd_Click;
            btnUpdate.Click += btnUpdate_Click;
            btnDelete.Click += btnDelete_Click;
            btnBackMenu.Click += btnBackMenu_Click;
            btnExit.Click += btnExit_Click;
            btnNew.Click += btnNew_Click;

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
                var dt = db.ExecuteStoredProcedure("usp_GetAllImports");             
                dataGridView1.DataSource = dt;                                      
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi load dữ liệu: {ex.Message}", "Lỗi",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                if (dataGridView1.Columns.Contains(col))
                    dataGridView1.Columns[col].Visible = false;
            }

            // Tắt sort và resize columns
            foreach (DataGridViewColumn c in dataGridView1.Columns)
                c.SortMode = DataGridViewColumnSortMode.NotSortable;                

            dataGridView1.AutoResizeColumns();                                   
        }

        private void btnShowData_Click(object sender, EventArgs e)
        {
            LoadData();                                                              
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;                                          
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var parameters = new[]
            {
                new SqlParameter("@ProductID",   txtProductID.Text),
                new SqlParameter("@Quantity",    int.Parse(txtQuantity.Text)),
                new SqlParameter("@Price",       decimal.Parse(txtPrice.Text)),
                new SqlParameter("@ImportDate",  dtpImportDate.Value),
                new SqlParameter("@EmployeeID",  txtEmployeeID.Text),
                new SqlParameter("@Supplier",    txtSupplier.Text)
            };
            db.ExecuteStoredProcedure("usp_AddImport", parameters);                  
            LoadData();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            var parameters = new[]
            {
                new SqlParameter("@ImportID",    GetSelectedID()),
                new SqlParameter("@ProductID",   txtProductID.Text),
                new SqlParameter("@Quantity",    int.Parse(txtQuantity.Text)),
                new SqlParameter("@Price",       decimal.Parse(txtPrice.Text)),
                new SqlParameter("@ImportDate",  dtpImportDate.Value),
                new SqlParameter("@EmployeeID",  txtEmployeeID.Text),
                new SqlParameter("@Supplier",    txtSupplier.Text)
            };
            db.ExecuteStoredProcedure("usp_UpdateImport", parameters);              
            LoadData();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var idParam = new[] { new SqlParameter("@ImportID", GetSelectedID()) };
            db.ExecuteStoredProcedure("usp_DeleteImport", idParam);                 
            LoadData();
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
            if (MessageBox.Show("Bạn có chắc chắn muốn thoát?", "Xác nhận",
                                MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                == DialogResult.Yes)
            {
                var menu = new Welcome();
                this.Hide();
                menu.ShowDialog();
                this.Close();
            }
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
            if (dataGridView1.CurrentRow == null)
                throw new InvalidOperationException("Chưa chọn bản ghi.");
            return Convert.ToInt32(dataGridView1.CurrentRow.Cells["ImportID"].Value);
        }
    }
}
