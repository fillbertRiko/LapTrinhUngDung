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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RecoverPassword));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.linkLabel_XoaNoiDung = new System.Windows.Forms.LinkLabel();
            this.linkLabel_QuayLai = new System.Windows.Forms.LinkLabel();
            this.button_LayLaiTaiKhoan = new System.Windows.Forms.Button();
            this.label_Show = new System.Windows.Forms.Label();
            this.textBox_Email = new Guna.UI2.WinForms.Guna2TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(393, 38);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(424, 215);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(298, 310);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Email";
            // 
            // linkLabel_XoaNoiDung
            // 
            this.linkLabel_XoaNoiDung.AutoSize = true;
            this.linkLabel_XoaNoiDung.Location = new System.Drawing.Point(728, 384);
            this.linkLabel_XoaNoiDung.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.linkLabel_XoaNoiDung.Name = "linkLabel_XoaNoiDung";
            this.linkLabel_XoaNoiDung.Size = new System.Drawing.Size(134, 25);
            this.linkLabel_XoaNoiDung.TabIndex = 4;
            this.linkLabel_XoaNoiDung.TabStop = true;
            this.linkLabel_XoaNoiDung.Text = "Xoá Nội Dung";
            this.linkLabel_XoaNoiDung.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel_XoaNoiDung_LinkClicked);
            // 
            // linkLabel_QuayLai
            // 
            this.linkLabel_QuayLai.AutoSize = true;
            this.linkLabel_QuayLai.Location = new System.Drawing.Point(58, 48);
            this.linkLabel_QuayLai.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.linkLabel_QuayLai.Name = "linkLabel_QuayLai";
            this.linkLabel_QuayLai.Size = new System.Drawing.Size(237, 25);
            this.linkLabel_QuayLai.TabIndex = 5;
            this.linkLabel_QuayLai.TabStop = true;
            this.linkLabel_QuayLai.Text = "<-Quay trang đăng nhập?";
            this.linkLabel_QuayLai.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel_QuayLai_LinkClicked);
            // 
            // button_LayLaiTaiKhoan
            // 
            this.button_LayLaiTaiKhoan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.button_LayLaiTaiKhoan.ForeColor = System.Drawing.Color.White;
            this.button_LayLaiTaiKhoan.Location = new System.Drawing.Point(494, 496);
            this.button_LayLaiTaiKhoan.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button_LayLaiTaiKhoan.Name = "button_LayLaiTaiKhoan";
            this.button_LayLaiTaiKhoan.Size = new System.Drawing.Size(197, 86);
            this.button_LayLaiTaiKhoan.TabIndex = 9;
            this.button_LayLaiTaiKhoan.Text = "Lấy Lại";
            this.button_LayLaiTaiKhoan.UseVisualStyleBackColor = false;
            this.button_LayLaiTaiKhoan.Click += new System.EventHandler(this.button_LayLaiTaiKhoan_Click);
            // 
            // label_Show
            // 
            this.label_Show.AutoSize = true;
            this.label_Show.Location = new System.Drawing.Point(419, 348);
            this.label_Show.Name = "label_Show";
            this.label_Show.Size = new System.Drawing.Size(0, 25);
            this.label_Show.TabIndex = 10;
            // 
            // textBox_Email
            // 
            this.textBox_Email.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.textBox_Email.DefaultText = "";
            this.textBox_Email.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.textBox_Email.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.textBox_Email.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.textBox_Email.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.textBox_Email.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.textBox_Email.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.textBox_Email.ForeColor = System.Drawing.Color.Black;
            this.textBox_Email.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.textBox_Email.IconLeft = ((System.Drawing.Image)(resources.GetObject("textBox_Email.IconLeft")));
            this.textBox_Email.IconLeftSize = new System.Drawing.Size(35, 35);
            this.textBox_Email.Location = new System.Drawing.Point(393, 289);
            this.textBox_Email.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.textBox_Email.Name = "textBox_Email";
            this.textBox_Email.PlaceholderForeColor = System.Drawing.Color.Black;
            this.textBox_Email.PlaceholderText = "";
            this.textBox_Email.SelectedText = "";
            this.textBox_Email.Size = new System.Drawing.Size(548, 46);
            this.textBox_Email.TabIndex = 0;
            // 
            // RecoverPassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1132, 611);
            this.Controls.Add(this.textBox_Email);
            this.Controls.Add(this.label_Show);
            this.Controls.Add(this.button_LayLaiTaiKhoan);
            this.Controls.Add(this.linkLabel_QuayLai);
            this.Controls.Add(this.linkLabel_XoaNoiDung);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "RecoverPassword";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Register";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.LinkLabel linkLabel_XoaNoiDung;
        private System.Windows.Forms.LinkLabel linkLabel_QuayLai;
        private System.Windows.Forms.Button button_LayLaiTaiKhoan;
        private System.Windows.Forms.Label label_Show;
        private Guna.UI2.WinForms.Guna2TextBox textBox_Email;
    }
}