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
    public partial class User : Form
    {
        private DataTable dtUsers;
        private int currentPage = 1;
        private int totalPages = 0;
        private int pageSize = 10;

        public User()
        {
            InitializeComponent();
        }

        private void DisplayPage(int pageNumber)
        {
            if (dtUsers == null || dtUsers.Rows.Count == 0)
            {
                dgvUsers.DataSource = null; // dgvUsers là DataGridView hiển thị thông tin người dùng
                return;
            }

            // Tạo DataTable tạm chứa cấu trúc giống dtUsers
            DataTable dtPage = dtUsers.Clone();

            int startIndex = (pageNumber - 1) * pageSize;
            int endIndex = Math.Min(startIndex + pageSize, dtUsers.Rows.Count);

            // Import các dòng của trang tính từ dtUsers vào dtPage
            for (int i = startIndex; i < endIndex; i++)
            {
                dtPage.ImportRow(dtUsers.Rows[i]);
            }

            dgvUsers.DataSource = dtPage;

            // Nếu có Label hiển thị thông tin trang (ví dụ lblPageInfo), cập nhật ở đây (không bắt buộc)
            // lblPageInfo.Text = $"Trang {currentPage} trên {totalPages}";
        }

        private void LoadUsers()
        {
            try
            {
                // Khởi tạo đối tượng UserModel để lấy dữ liệu người dùng từ CSDL.
                UserModel userModel = new UserModel();
                DataTable dt = userModel.GetUsers();

                // Lưu toàn bộ dữ liệu vào biến dtUsers để dùng cho phân trang.
                dtUsers = dt;

                // Đặt số dòng hiển thị mỗi trang.
                pageSize = 10;

                // Tính toán tổng số trang dựa trên số dòng dữ liệu.
                totalPages = (int)Math.Ceiling((double)dtUsers.Rows.Count / pageSize);

                // Đặt trang hiện tại về 1 và hiển thị dữ liệu của trang đầu.
                currentPage = 1;
                DisplayPage(currentPage);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading users: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            LoadUsers();
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

        private void btnSearch_Click(object sender, EventArgs e)
        {
            SearchUsers();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            SearchUsers();
        }

        private void SearchUsers()
        {
            string keyword = txtSearch.Text.Trim();
            UserModel userModel = new UserModel();

            // Nếu ô tìm kiếm trống, tải lại toàn bộ danh sách người dùng
            if (string.IsNullOrEmpty(keyword))
            {
                LoadUsers();
            }
            else
            {
                dtUsers = userModel.SearchUsers(keyword) ?? new DataTable();
                currentPage = 1;
                totalPages = (dtUsers.Rows.Count > 0) ?
                             (int)Math.Ceiling((double)dtUsers.Rows.Count / pageSize) : 1;

                DisplayPage(currentPage);
            }
        }


        private void txtName_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                txtName.BackColor = Color.LightPink;
                errorProvider1.SetError(txtName, "Vui lòng nhập Username.");
            }
            else
            {
                txtName.BackColor = Color.White;
                errorProvider1.SetError(txtName, string.Empty);
            }

        }

        private void txtFullname_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFullname.Text))
            {
                txtFullname.BackColor = Color.LightPink;
                errorProvider1.SetError(txtFullname, "Vui lòng nhập Họ và Tên.");
            }
            else
            {
                txtFullname.BackColor = Color.White;
                errorProvider1.SetError(txtFullname, string.Empty);
            }

        }

        private void txtRole_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtRole.Text))
            {
                txtRole.BackColor = Color.LightPink;
                errorProvider1.SetError(txtRole, "Vui lòng nhập vai trò.");
            }
            else
            {
                txtRole.BackColor = Color.White;
                errorProvider1.SetError(txtRole, string.Empty);
            }

        }

        private void txtPasswordHash_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPasswordHash.Text))
            {
                txtPasswordHash.BackColor = Color.LightPink;
                errorProvider1.SetError(txtPasswordHash, "Vui lòng nhập mật khẩu.");
            }
            else
            {
                txtPasswordHash.BackColor = Color.White;
                errorProvider1.SetError(txtPasswordHash, string.Empty);
            }

        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            UserModel userModel = new UserModel();
            DataTable dtUsers = dgvUsers.DataSource as DataTable; // Lấy dữ liệu từ DataGridView

            if (!userModel.ExportUsersToCSV(dtUsers))
            {
                MessageBox.Show("Xuất dữ liệu thất bại!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                // Kiểm tra nhập liệu
                if (string.IsNullOrWhiteSpace(txtName.Text) ||
                    string.IsNullOrWhiteSpace(txtFullname.Text) ||
                    string.IsNullOrWhiteSpace(txtRole.Text) ||
                    string.IsNullOrWhiteSpace(txtPasswordHash.Text))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin.", "Lỗi đầu vào", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                UserModel userModel = new UserModel();
                bool success = userModel.AddUser(txtName.Text, txtPasswordHash.Text, txtFullname.Text, txtRole.Text);

                if (success)
                {
                    MessageBox.Show("Thêm người dùng thành công.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadUsers();  // Cập nhật danh sách sau khi thêm
                }
                else
                {
                    MessageBox.Show("Thêm người dùng thất bại.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm người dùng: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvUsers.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Vui lòng chọn người dùng cần sửa.", "Lỗi chọn", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int userId = Convert.ToInt32(dgvUsers.SelectedRows[0].Cells["UserID"].Value);

                if (string.IsNullOrWhiteSpace(txtName.Text) ||
                    string.IsNullOrWhiteSpace(txtFullname.Text) ||
                    string.IsNullOrWhiteSpace(txtRole.Text) ||
                    string.IsNullOrWhiteSpace(txtPasswordHash.Text))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin.", "Lỗi đầu vào", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                UserModel userModel = new UserModel();
                bool success = userModel.UpdateUser(userId, txtName.Text, txtPasswordHash.Text, txtFullname.Text, txtRole.Text);

                if (success)
                {
                    MessageBox.Show("Cập nhật người dùng thành công.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadUsers();  // Cập nhật danh sách sau khi chỉnh sửa
                }
                else
                {
                    MessageBox.Show("Cập nhật người dùng thất bại.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật người dùng: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvUsers.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Vui lòng chọn người dùng cần xoá.", "Lỗi chọn", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int userId = Convert.ToInt32(dgvUsers.SelectedRows[0].Cells["UserID"].Value);

                DialogResult result = MessageBox.Show("Bạn có chắc muốn xoá người dùng này?", "Xác nhận xoá", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    UserModel userModel = new UserModel();
                    bool success = userModel.DeleteUser(userId);

                    if (success)
                    {
                        MessageBox.Show("Xoá người dùng thành công.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadUsers();  // Cập nhật danh sách sau khi xoá
                    }
                    else
                    {
                        MessageBox.Show("Xoá người dùng thất bại.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xoá người dùng: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
