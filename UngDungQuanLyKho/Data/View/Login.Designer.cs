namespace UngDungQuanLyKho.Data.View
{
    partial class Login
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.linkLabel_QuenMatKhau = new System.Windows.Forms.LinkLabel();
            this.button_DangNhap = new System.Windows.Forms.Button();
            this.textBox_Email = new Guna.UI2.WinForms.Guna2TextBox();
            this.textBox_Password = new Guna.UI2.WinForms.Guna2TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(162, 15);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(266, 177);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // linkLabel_QuenMatKhau
            // 
            this.linkLabel_QuenMatKhau.AutoSize = true;
            this.linkLabel_QuenMatKhau.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.linkLabel_QuenMatKhau.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.linkLabel_QuenMatKhau.Location = new System.Drawing.Point(479, 388);
            this.linkLabel_QuenMatKhau.Name = "linkLabel_QuenMatKhau";
            this.linkLabel_QuenMatKhau.Size = new System.Drawing.Size(132, 22);
            this.linkLabel_QuenMatKhau.TabIndex = 3;
            this.linkLabel_QuenMatKhau.TabStop = true;
            this.linkLabel_QuenMatKhau.Text = "Quên mật khẩu";
            this.linkLabel_QuenMatKhau.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel_QuenMatKhau_LinkClicked);
            // 
            // button_DangNhap
            // 
            this.button_DangNhap.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.button_DangNhap.ForeColor = System.Drawing.Color.White;
            this.button_DangNhap.Location = new System.Drawing.Point(232, 450);
            this.button_DangNhap.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button_DangNhap.Name = "button_DangNhap";
            this.button_DangNhap.Size = new System.Drawing.Size(202, 47);
            this.button_DangNhap.TabIndex = 6;
            this.button_DangNhap.Text = "Đăng Nhập";
            this.button_DangNhap.UseVisualStyleBackColor = false;
            this.button_DangNhap.Click += new System.EventHandler(this.button_DangNhap_Click);
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
            this.textBox_Email.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.textBox_Email.ForeColor = System.Drawing.Color.Black;
            this.textBox_Email.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.textBox_Email.IconLeft = ((System.Drawing.Image)(resources.GetObject("textBox_Email.IconLeft")));
            this.textBox_Email.IconLeftSize = new System.Drawing.Size(35, 35);
            this.textBox_Email.Location = new System.Drawing.Point(73, 242);
            this.textBox_Email.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.textBox_Email.Name = "textBox_Email";
            this.textBox_Email.PlaceholderForeColor = System.Drawing.Color.Black;
            this.textBox_Email.PlaceholderText = "";
            this.textBox_Email.SelectedText = "";
            this.textBox_Email.Size = new System.Drawing.Size(505, 47);
            this.textBox_Email.TabIndex = 0;
            // 
            // textBox_Password
            // 
            this.textBox_Password.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.textBox_Password.DefaultText = "";
            this.textBox_Password.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.textBox_Password.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.textBox_Password.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.textBox_Password.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.textBox_Password.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.textBox_Password.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.textBox_Password.ForeColor = System.Drawing.Color.Black;
            this.textBox_Password.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.textBox_Password.IconLeft = ((System.Drawing.Image)(resources.GetObject("textBox_Password.IconLeft")));
            this.textBox_Password.IconLeftSize = new System.Drawing.Size(35, 35);
            this.textBox_Password.Location = new System.Drawing.Point(73, 332);
            this.textBox_Password.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.textBox_Password.Name = "textBox_Password";
            this.textBox_Password.PlaceholderForeColor = System.Drawing.Color.Black;
            this.textBox_Password.PlaceholderText = "";
            this.textBox_Password.SelectedText = "";
            this.textBox_Password.Size = new System.Drawing.Size(505, 47);
            this.textBox_Password.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(73, 217);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 20);
            this.label1.TabIndex = 9;
            this.label1.Text = "Đăng nhập";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(73, 307);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 20);
            this.label2.TabIndex = 10;
            this.label2.Text = "Mật khẩu";
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(645, 552);
            this.Controls.Add(this.button_DangNhap);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox_Password);
            this.Controls.Add(this.textBox_Email);
            this.Controls.Add(this.linkLabel_QuenMatKhau);
            this.Controls.Add(this.pictureBox1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.LinkLabel linkLabel_QuenMatKhau;
        private System.Windows.Forms.Button button_DangNhap;
        private Guna.UI2.WinForms.Guna2TextBox textBox_Email;
        private Guna.UI2.WinForms.Guna2TextBox textBox_Password;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}