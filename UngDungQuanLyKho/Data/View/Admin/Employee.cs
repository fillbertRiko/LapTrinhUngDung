using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UngDungQuanLyKho.Data.Database;
using UngDungQuanLyKho.Data.Models;
using UngDungQuanLyKho.Data.View.Admin;

namespace UngDungQuanLyKho.Data.View.MENU_User
{
    public partial class Employee : Form
    {
        public Employee()
        {
            InitializeComponent();
        }

        private void Employee_Load(object sender, EventArgs e)
        {

        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            LoadEmployees();
        }

        EmployeeModel employeeModel = new EmployeeModel();

        // Nạp danh sách nhân viên lên `DataGridView`
        private void LoadEmployees()
        {
            dvgEmployees.DataSource = employeeModel.GetEmployees();
        }

        // Thêm nhân viên mới
        private void btnAdd_Click(object sender, EventArgs e)
        {
            employeeModel.AddEmployee(txtName.Text, txtRole.Text, txtEmail.Text, txtPassword.Text);
            LoadEmployees(); // Tải lại danh sách
        }

        private void dvgEmployees_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            int employeeId = Convert.ToInt32(dvgEmployees.SelectedRows[0].Cells["EmployeeID"].Value);
            employeeModel.UpdateEmployee(employeeId, txtName.Text, txtRole.Text, txtEmail.Text);
            LoadEmployees();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa nhân viên này?", "Xóa nhân viên", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                int employeeId = Convert.ToInt32(dvgEmployees.SelectedRows[0].Cells["EmployeeID"].Value);
                employeeModel.DeleteEmployee(employeeId);
                LoadEmployees();
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            dvgEmployees.DataSource = employeeModel.SearchEmployee(txtSearch.Text);
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            employeeModel.ExportToExcel(dvgEmployees);
        }

        //lat trang
        int currentPage = 1;
        int pageSize = 10;

        private void btnNextPage_Click(object sender, EventArgs e)
        {
            currentPage++;
            dvgEmployees.DataSource = employeeModel.GetEmployeesByPage(currentPage, pageSize);
        }

        private void btnPrevPage_Click(object sender, EventArgs e)
        {
            if (currentPage > 1) currentPage--;
            dvgEmployees.DataSource = employeeModel.GetEmployeesByPage(currentPage, pageSize);
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            // Lấy từ khóa hiện tại từ TextBox, loại bỏ khoảng trắng thừa
            string keyword = txtSearch.Text.Trim();

            // Khởi tạo đối tượng ProductModel
            ProductModel productModel = new ProductModel();

            // DataTable để chứa kết quả trả về
            DataTable dt;

            // Nếu ô tìm kiếm rỗng, load tất cả các sản phẩm, nếu không thì tìm kiếm theo từ khóa.
            if (string.IsNullOrEmpty(keyword))
            {
                dt = productModel.GetProducts();
            }
            else
            {
                dt = productModel.SearchProducts(keyword);
            }

            // Cập nhật DataGridView để hiển thị kết quả tìm kiếm (đảm bảo dataGridViewProducts đã được khai báo trên form)
            dvgEmployees.DataSource = dt;
        }
    }
}
