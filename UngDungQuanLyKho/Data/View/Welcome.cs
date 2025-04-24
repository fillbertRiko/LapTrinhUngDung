using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UngDungQuanLyKho.Data.View;
using UngDungQuanLyKho.Data.View.MENU;
using UngDungQuanLyKho.Data.Auth;

namespace UngDungQuanLyKho.Data.UI.Forms.Index
{
    public partial class Welcome : Form
    {
        public Welcome()
        {
            InitializeComponent();
        }

        //dong form welcome chuyen sang form main
        private void button_MoMain_Click(object sender, EventArgs e)
        {
            Main main = new Main();
            this.Hide();  // Ẩn form Welcome thay vì đóng ngay lập tức
            main.ShowDialog();
            this.Close();
        }

        private void Welcome_Load(object sender, EventArgs e)
        {

        }

        private void textBox_HienThiNguoiDung_TextChanged(object sender, EventArgs e)
        {
            //hien thi ten nguoi dung trong textbox
            textBox_HienThiNguoiDung.Text = AuthManager.TenNguoiDung;
        }

        private void button_DangXuat_Click(object sender, EventArgs e)
        {
            //tao chuc nang dang xuat
            //dong form welcome 
            this.Close();
            var confirmResult = MessageBox.Show("Bạn có chắc chắn muốn đăng xuất?",
                                     "Đăng xuất",
                                     MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {
                //dong form welcome chuyen sang form login
                this.Hide();
                Login login = new Login();
                login.ShowDialog();
                this.Close();
            }
            //xu ly chuc nnag dang xuat

        }

        private void button_PhieuNhap_Click(object sender, EventArgs e)
        {
            //hien thi form phieu nhap kho
            PhieuNhapKho phieuNhap = new PhieuNhapKho();
            this.Hide();
            phieuNhap.ShowDialog();
            this.Show();

        }

        private void button_PhieuXuat_Click(object sender, EventArgs e)
        {
            //Hien thi phieu xuat kho
            PhieuXuatKho phieuXuat = new PhieuXuatKho();
            this.Hide();
            phieuXuat.ShowDialog();
            this.Show();
        }

        private void button_PhieuLuuChuyen_Click(object sender, EventArgs e)
        {
            //hien thi phieu dieu chuyen
            PhieuXuatDieuChuyen phieuXuatDieuChuyen = new PhieuXuatDieuChuyen();
            this.Hide();
            phieuXuatDieuChuyen.ShowDialog();
            this.Show();
        }
    }
}
