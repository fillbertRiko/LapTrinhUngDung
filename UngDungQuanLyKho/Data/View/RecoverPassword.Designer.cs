namespace UngDungQuanLyKho.Data.UI.Forms.Index
{
    partial class RecoverPassword
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label_Show = new System.Windows.Forms.Label();
            this.linkLabel_XoaNoiDung = new System.Windows.Forms.LinkLabel();
            this.linkLabel_QuayLai = new System.Windows.Forms.LinkLabel();
            this.textBox_Email = new System.Windows.Forms.TextBox();
            this.button_LayLaiTaiKhoan = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(245, 31);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(256, 133);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(154, 218);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Email";
            // 
            // label_Show
            // 
            this.label_Show.AutoSize = true;
            this.label_Show.Location = new System.Drawing.Point(326, 282);
            this.label_Show.Name = "label_Show";
            this.label_Show.Size = new System.Drawing.Size(0, 16);
            this.label_Show.TabIndex = 2;
            // 
            // linkLabel_XoaNoiDung
            // 
            this.linkLabel_XoaNoiDung.AutoSize = true;
            this.linkLabel_XoaNoiDung.Location = new System.Drawing.Point(457, 364);
            this.linkLabel_XoaNoiDung.Name = "linkLabel_XoaNoiDung";
            this.linkLabel_XoaNoiDung.Size = new System.Drawing.Size(90, 16);
            this.linkLabel_XoaNoiDung.TabIndex = 4;
            this.linkLabel_XoaNoiDung.TabStop = true;
            this.linkLabel_XoaNoiDung.Text = "Xoá Nội Dung";
            this.linkLabel_XoaNoiDung.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel_XoaNoiDung_LinkClicked);
            // 
            // linkLabel_QuayLai
            // 
            this.linkLabel_QuayLai.AutoSize = true;
            this.linkLabel_QuayLai.Location = new System.Drawing.Point(218, 364);
            this.linkLabel_QuayLai.Name = "linkLabel_QuayLai";
            this.linkLabel_QuayLai.Size = new System.Drawing.Size(146, 16);
            this.linkLabel_QuayLai.TabIndex = 5;
            this.linkLabel_QuayLai.TabStop = true;
            this.linkLabel_QuayLai.Text = "Quay trang đăng nhập?";
            this.linkLabel_QuayLai.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel_QuayLai_LinkClicked);
            // 
            // textBox_Email
            // 
            this.textBox_Email.Location = new System.Drawing.Point(329, 215);
            this.textBox_Email.Name = "textBox_Email";
            this.textBox_Email.Size = new System.Drawing.Size(272, 22);
            this.textBox_Email.TabIndex = 6;
            // 
            // button_LayLaiTaiKhoan
            // 
            this.button_LayLaiTaiKhoan.Location = new System.Drawing.Point(329, 392);
            this.button_LayLaiTaiKhoan.Name = "button_LayLaiTaiKhoan";
            this.button_LayLaiTaiKhoan.Size = new System.Drawing.Size(132, 55);
            this.button_LayLaiTaiKhoan.TabIndex = 9;
            this.button_LayLaiTaiKhoan.Text = "Lấy Lại";
            this.button_LayLaiTaiKhoan.UseVisualStyleBackColor = true;
            this.button_LayLaiTaiKhoan.Click += new System.EventHandler(this.button_LayLaiTaiKhoan_Click);
            // 
            // RecoverPassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button_LayLaiTaiKhoan);
            this.Controls.Add(this.textBox_Email);
            this.Controls.Add(this.linkLabel_QuayLai);
            this.Controls.Add(this.linkLabel_XoaNoiDung);
            this.Controls.Add(this.label_Show);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Name = "RecoverPassword";
            this.Text = "Register";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label_Show;
        private System.Windows.Forms.LinkLabel linkLabel_XoaNoiDung;
        private System.Windows.Forms.LinkLabel linkLabel_QuayLai;
        private System.Windows.Forms.TextBox textBox_Email;
        private System.Windows.Forms.Button button_LayLaiTaiKhoan;
    }
}