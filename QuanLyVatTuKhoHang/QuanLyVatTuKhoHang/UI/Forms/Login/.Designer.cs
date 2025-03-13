namespace QuanLyVatTuKhoHang.Auth
{
    partial class FormRecover
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
            this.lblUsername = new System.Windows.Forms.Label();
            this.lblEmail = new System.Windows.Forms.Label();
            this.lblRePassword = new System.Windows.Forms.Label();
            this.lblPassword = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtRePassword = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.btnRecover = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(169, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(444, 111);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsername.Location = new System.Drawing.Point(109, 164);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(131, 28);
            this.lblUsername.TabIndex = 1;
            this.lblUsername.Text = "Tên tài khoản:";
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmail.Location = new System.Drawing.Point(109, 284);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(63, 28);
            this.lblEmail.TabIndex = 2;
            this.lblEmail.Text = "Email:";
            // 
            // lblRePassword
            // 
            this.lblRePassword.AutoSize = true;
            this.lblRePassword.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRePassword.Location = new System.Drawing.Point(109, 244);
            this.lblRePassword.Name = "lblRePassword";
            this.lblRePassword.Size = new System.Drawing.Size(175, 28);
            this.lblRePassword.TabIndex = 3;
            this.lblRePassword.Text = "Nhập lại mật khẩu:";
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPassword.Location = new System.Drawing.Point(109, 204);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(98, 28);
            this.lblPassword.TabIndex = 4;
            this.lblPassword.Text = "Mật khẩu:";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(301, 170);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(264, 22);
            this.txtName.TabIndex = 5;
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(301, 285);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(264, 22);
            this.txtEmail.TabIndex = 6;
            // 
            // txtRePassword
            // 
            this.txtRePassword.Location = new System.Drawing.Point(301, 247);
            this.txtRePassword.Name = "txtRePassword";
            this.txtRePassword.Size = new System.Drawing.Size(264, 22);
            this.txtRePassword.TabIndex = 7;
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(301, 208);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(264, 22);
            this.txtPassword.TabIndex = 8;
            // 
            // btnRecover
            // 
            this.btnRecover.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btnRecover.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRecover.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnRecover.Location = new System.Drawing.Point(303, 371);
            this.btnRecover.Name = "btnRecover";
            this.btnRecover.Size = new System.Drawing.Size(177, 53);
            this.btnRecover.TabIndex = 9;
            this.btnRecover.Text = "Lấy Lại Mật Khẩu";
            this.btnRecover.UseVisualStyleBackColor = false;
            // 
            // FormRecover
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnRecover);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtRePassword);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.lblRePassword);
            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.lblUsername);
            this.Controls.Add(this.pictureBox1);
            this.Name = "FormRecover";
            this.Text = "Lấy lại mật khẩu";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.Label lblRePassword;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtRePassword;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Button btnRecover;
    }
}