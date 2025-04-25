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

namespace UngDungQuanLyKho.Data.View.Admin
{
    public partial class Customers : Form
    {
        public Customers()
        {
            InitializeComponent();
        }

        //lay danh sach khach hang
        private void btnLoad_Click(object sender, EventArgs e)
        {
            CustomerModel customerModel = new CustomerModel();
            dgvCustomers.DataSource = customerModel.GetCustomers();
        }

        //tim kiem khach hang
        private void btnSearch_Click(object sender, EventArgs e)
        {
            CustomerModel customerModel = new CustomerModel();
            dgvCustomers.DataSource = customerModel.SearchCustomers(txtSearch.Text);
        }

        //them khach hang
        private void btnAdd_Click(object sender, EventArgs e)
        {
            CustomerModel customerModel = new CustomerModel();
            customerModel.AddCustomer(txtName.Text, txtAddress.Text, txtPhone.Text);
            LoadCustomers();
        }
        private void btnEdit_Click(object sender, EventArgs e)
        {
            int customerId = Convert.ToInt32(dgvCustomers.SelectedRows[0].Cells["CustomerID"].Value);
            CustomerModel customerModel = new CustomerModel();
            customerModel.UpdateCustomer(customerId, txtName.Text, txtAddress.Text, txtPhone.Text);
            LoadCustomers();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int customerId = Convert.ToInt32(dgvCustomers.SelectedRows[0].Cells["CustomerID"].Value);
            CustomerModel customerModel = new CustomerModel();
            customerModel.DeleteCustomer(customerId);
            LoadCustomers();
        }

        private void LoadCustomers()
        {
            try
            {
                CustomerModel customerModel = new CustomerModel();
                dgvCustomers.DataSource = customerModel.GetCustomers();
            }
            catch (Exception ex)
            {
                MessageBox.Show("lỗi tải danh sách khách hàng: " + ex.Message);
            }

        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            CustomerModel customerModel = new CustomerModel();
            customerModel.ExportCustomersToExcel(dgvCustomers);

        }
        private void btnLoadStats_Click(object sender, EventArgs e)
        {
            CustomerModel customerModel = new CustomerModel();
            dgvStatistics.DataSource = customerModel.GetCustomerOrders();
        }
    }
}
