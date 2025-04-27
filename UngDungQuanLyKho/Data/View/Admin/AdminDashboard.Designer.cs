namespace UngDungQuanLyKho.Data.View.Admin
{
    partial class AdminDashboard
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnImport = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnProductManager = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.btnReportManager = new System.Windows.Forms.Button();
            this.btnAccountManager = new System.Windows.Forms.Button();
            this.btnLocation = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnLogout);
            this.panel1.Controls.Add(this.btnLocation);
            this.panel1.Controls.Add(this.btnImport);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btnProductManager);
            this.panel1.Controls.Add(this.btnExport);
            this.panel1.Controls.Add(this.btnReportManager);
            this.panel1.Controls.Add(this.btnAccountManager);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(315, 450);
            this.panel1.TabIndex = 3;
            // 
            // btnImport
            // 
            this.btnImport.Location = new System.Drawing.Point(12, 232);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(137, 49);
            this.btnImport.TabIndex = 6;
            this.btnImport.Text = "Quản lý nhập hàng";
            this.btnImport.UseVisualStyleBackColor = true;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(44, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(227, 16);
            this.label1.TabIndex = 4;
            this.label1.Text = "Chào mừng bạn đến với trang quản trị";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // btnProductManager
            // 
            this.btnProductManager.Location = new System.Drawing.Point(155, 112);
            this.btnProductManager.Name = "btnProductManager";
            this.btnProductManager.Size = new System.Drawing.Size(137, 49);
            this.btnProductManager.TabIndex = 3;
            this.btnProductManager.Text = "Quản lý sản phẩm";
            this.btnProductManager.UseVisualStyleBackColor = true;
            this.btnProductManager.Click += new System.EventHandler(this.btnProductManager_Click);
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(155, 172);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(137, 49);
            this.btnExport.TabIndex = 2;
            this.btnExport.Text = "Quản lý xuất hàng";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExportImport_Click);
            // 
            // btnReportManager
            // 
            this.btnReportManager.Location = new System.Drawing.Point(12, 172);
            this.btnReportManager.Name = "btnReportManager";
            this.btnReportManager.Size = new System.Drawing.Size(137, 49);
            this.btnReportManager.TabIndex = 1;
            this.btnReportManager.Text = "Thống kê báo cáo";
            this.btnReportManager.UseVisualStyleBackColor = true;
            this.btnReportManager.Click += new System.EventHandler(this.btnReportManager_Click);
            // 
            // btnAccountManager
            // 
            this.btnAccountManager.Location = new System.Drawing.Point(12, 112);
            this.btnAccountManager.Name = "btnAccountManager";
            this.btnAccountManager.Size = new System.Drawing.Size(137, 49);
            this.btnAccountManager.TabIndex = 0;
            this.btnAccountManager.Text = "Quản lý tài khoản";
            this.btnAccountManager.UseVisualStyleBackColor = true;
            this.btnAccountManager.Click += new System.EventHandler(this.btnAccountManager_Click);
            // 
            // btnLocation
            // 
            this.btnLocation.Location = new System.Drawing.Point(155, 232);
            this.btnLocation.Name = "btnLocation";
            this.btnLocation.Size = new System.Drawing.Size(137, 49);
            this.btnLocation.TabIndex = 7;
            this.btnLocation.Text = "Quản lý khu vực";
            this.btnLocation.UseVisualStyleBackColor = true;
            this.btnLocation.Click += new System.EventHandler(this.btnLocation_Click);
            // 
            // btnLogout
            // 
            this.btnLogout.Location = new System.Drawing.Point(91, 348);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(137, 49);
            this.btnLogout.TabIndex = 8;
            this.btnLogout.Text = "Đăng xuất";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // AdminDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel1);
            this.IsMdiContainer = true;
            this.Name = "AdminDashboard";
            this.Text = "AdminDashboard";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.AdminDashboard_Load_1);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnProductManager;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Button btnReportManager;
        private System.Windows.Forms.Button btnAccountManager;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Button btnLocation;
    }
}