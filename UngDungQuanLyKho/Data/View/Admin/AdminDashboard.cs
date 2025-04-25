using System;
using System.Windows.Forms;
using UngDungQuanLyKho.Data.Auth;
using UngDungQuanLyKho.Data.Models;
using UngDungQuanLyKho.Data.View.MENU;

namespace UngDungQuanLyKho.Data.View.Admin
{
    public partial class AdminDashboard : Form
    {
        private UserModel CurrentUser;

        public AdminDashboard(UserModel loggedInUser)
        {
            InitializeComponent();
            CurrentUser = loggedInUser;
            IsMdiContainer = true;
        }

        private void AdminDashboard_Load(object sender, EventArgs e)
        {
            // Kiểm tra quyền truy cập
            if (CurrentUser == null || string.IsNullOrEmpty(CurrentUser.Role) || CurrentUser.Role != "Admin")
            {
                MessageBox.Show("Bạn không có quyền truy cập vào trang Admin!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Close();
                return;
            }

            // Ví dụ: Hiển thị tên người dùng (nếu có điều khiển lblWelcome trên form)
            try
            {
                if (this.Controls["lblWelcome"] is Label lblWelcome)
                {
                    lblWelcome.Text = $"Xin chào, {CurrentUser.FullName}!";
                }
                else
                {
                    // Nếu chưa có, có thể in ra console hoặc xử lý theo cách khác.
                    Console.WriteLine($"Xin chào, {CurrentUser.FullName}!");
                }

                // Tiếp tục các hàm khởi tạo khác cho AdminDashboard,
                // chẳng hạn như tải dữ liệu quản lý, thiết lập menu, vv.
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải dữ liệu Admin: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lblName_Click(object sender, EventArgs e)
        {

        }

        private void AdminDashboard_Load_1(object sender, EventArgs e)
        {

        }

        private void btnAccountManager_Click(object sender, EventArgs e)
        {
            OpenChildForm(new User());
        }

        private void btnProductManager_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Products());
        }

        private void btnExportImport_Click(object sender, EventArgs e)
        {
            OpenChildForm(new PhieuXuatKho());
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            OpenChildForm(new PhieuNhapKho());
        }

        private void btnReportManager_Click(object sender, EventArgs e)
        {
            OpenChildForm(new StockStatus());
        }

        private void OpenChildForm(Form childForm)
        {
            // Kiểm tra nếu một instance của lớp form đó đã tồn tại
            foreach (Form frm in this.MdiChildren)
            {
                if (frm.GetType() == childForm.GetType())
                {
                    frm.Activate();
                    return;
                }
            }
            childForm.MdiParent = this;
            childForm.Show();
        }
    }
}