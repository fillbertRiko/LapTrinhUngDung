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
    public partial class Location : Form
    {
        ImportModel importModel = new ImportModel(); // Kết nối đến lớp xử lý dữ liệu

        public Location()
        {
            InitializeComponent();
            LoadLocations(); // Tải danh sách khi mở form
        }

        private void LoadLocations()
        {
            dgvLocations.DataSource = importModel.GetLocations();
        }

        private void btnSaveLocation_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtLocationName.Text))
            {
                MessageBox.Show("Vui lòng nhập tên vị trí!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string locationName = txtLocationName.Text;
            string area = cbbArea.SelectedItem?.ToString() ?? "";

            bool success = importModel.AddLocation(locationName, area);
            if (success)
            {
                MessageBox.Show("Thêm vị trí thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadLocations(); // Cập nhật danh sách
            }
            else
            {
                MessageBox.Show("Lỗi khi thêm vị trí!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClearLocation_Click_1(object sender, EventArgs e)
        {
            txtLocationName.Clear();
            cbbArea.SelectedIndex = -1;
        }
    }
}
