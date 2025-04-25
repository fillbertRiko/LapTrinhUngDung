namespace UngDungQuanLyKho.Data.View.MENU
{
    partial class PhieuXuatKho
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
            this.components = new System.ComponentModel.Container();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtExportID = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbCustomerID = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dtpExportDate = new System.Windows.Forms.DateTimePicker();
            this.cbEmployeeID = new System.Windows.Forms.ComboBox();
            this.guna2DragControl1 = new Guna.UI2.WinForms.Guna2DragControl(this.components);
            this.btnNew = new System.Windows.Forms.Button();
            this.btnBackMenu = new System.Windows.Forms.Button();
            this.btnDeleteExport = new System.Windows.Forms.Button();
            this.btnAddExport = new System.Windows.Forms.Button();
            this.btnEditExport = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnLoadExports = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgvExports = new System.Windows.Forms.DataGridView();
            this.status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ImportID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProductID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Quantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ImportDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EmployeeID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Supplier = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtProductID = new System.Windows.Forms.TextBox();
            this.txtQuantity = new System.Windows.Forms.NumericUpDown();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.dgvExportDetails = new System.Windows.Forms.DataGridView();
            this.btnShowDetails = new System.Windows.Forms.Button();
            this.btnCaculateTotal = new System.Windows.Forms.Button();
            this.btnExportExcel = new System.Windows.Forms.Button();
            this.lblTotalAmount = new System.Windows.Forms.Label();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvExports)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtQuantity)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvExportDetails)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnExportExcel);
            this.groupBox3.Controls.Add(this.txtExportID);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.cbCustomerID);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.dtpExportDate);
            this.groupBox3.Controls.Add(this.cbEmployeeID);
            this.groupBox3.Location = new System.Drawing.Point(12, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(458, 240);
            this.groupBox3.TabIndex = 33;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Thông tin xuất hàng";
            // 
            // txtExportID
            // 
            this.txtExportID.Location = new System.Drawing.Point(158, 34);
            this.txtExportID.Name = "txtExportID";
            this.txtExportID.Size = new System.Drawing.Size(291, 22);
            this.txtExportID.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mã Phiếu Xuất";
            // 
            // cbCustomerID
            // 
            this.cbCustomerID.FormattingEnabled = true;
            this.cbCustomerID.Location = new System.Drawing.Point(158, 139);
            this.cbCustomerID.Name = "cbCustomerID";
            this.cbCustomerID.Size = new System.Drawing.Size(291, 24);
            this.cbCustomerID.TabIndex = 26;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Ngày Xuất";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 107);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(120, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "Mã Nhân Viên Xuất";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(17, 142);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(107, 16);
            this.label4.TabIndex = 3;
            this.label4.Text = "Tên Khách Hàng";
            // 
            // dtpExportDate
            // 
            this.dtpExportDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpExportDate.Location = new System.Drawing.Point(158, 67);
            this.dtpExportDate.Name = "dtpExportDate";
            this.dtpExportDate.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dtpExportDate.Size = new System.Drawing.Size(291, 22);
            this.dtpExportDate.TabIndex = 9;
            // 
            // cbEmployeeID
            // 
            this.cbEmployeeID.FormattingEnabled = true;
            this.cbEmployeeID.Location = new System.Drawing.Point(158, 104);
            this.cbEmployeeID.Name = "cbEmployeeID";
            this.cbEmployeeID.Size = new System.Drawing.Size(147, 24);
            this.cbEmployeeID.TabIndex = 10;
            // 
            // guna2DragControl1
            // 
            this.guna2DragControl1.DockIndicatorTransparencyValue = 0.6D;
            this.guna2DragControl1.UseTransparentDrag = true;
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(931, 163);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(135, 54);
            this.btnNew.TabIndex = 31;
            this.btnNew.Text = "Thêm Phiếu Xuất Mới";
            this.btnNew.UseVisualStyleBackColor = true;
            // 
            // btnBackMenu
            // 
            this.btnBackMenu.Location = new System.Drawing.Point(931, 26);
            this.btnBackMenu.Name = "btnBackMenu";
            this.btnBackMenu.Size = new System.Drawing.Size(135, 54);
            this.btnBackMenu.TabIndex = 30;
            this.btnBackMenu.Text = "Quay Về Menu";
            this.btnBackMenu.UseVisualStyleBackColor = true;
            // 
            // btnDeleteExport
            // 
            this.btnDeleteExport.Location = new System.Drawing.Point(903, 36);
            this.btnDeleteExport.Name = "btnDeleteExport";
            this.btnDeleteExport.Size = new System.Drawing.Size(75, 23);
            this.btnDeleteExport.TabIndex = 26;
            this.btnDeleteExport.Text = "Xoá";
            this.btnDeleteExport.UseVisualStyleBackColor = true;
            // 
            // btnAddExport
            // 
            this.btnAddExport.Location = new System.Drawing.Point(659, 36);
            this.btnAddExport.Name = "btnAddExport";
            this.btnAddExport.Size = new System.Drawing.Size(75, 23);
            this.btnAddExport.TabIndex = 25;
            this.btnAddExport.Text = "Thêm";
            this.btnAddExport.UseVisualStyleBackColor = true;
            // 
            // btnEditExport
            // 
            this.btnEditExport.Location = new System.Drawing.Point(788, 36);
            this.btnEditExport.Name = "btnEditExport";
            this.btnEditExport.Size = new System.Drawing.Size(75, 23);
            this.btnEditExport.TabIndex = 24;
            this.btnEditExport.Text = "Sửa";
            this.btnEditExport.UseVisualStyleBackColor = true;
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(399, 36);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(181, 23);
            this.btnClear.TabIndex = 23;
            this.btnClear.Text = "Dọn sạch bảng";
            this.btnClear.UseVisualStyleBackColor = true;
            // 
            // btnLoadExports
            // 
            this.btnLoadExports.Location = new System.Drawing.Point(189, 36);
            this.btnLoadExports.Name = "btnLoadExports";
            this.btnLoadExports.Size = new System.Drawing.Size(75, 23);
            this.btnLoadExports.TabIndex = 22;
            this.btnLoadExports.Text = "Hiển thị";
            this.btnLoadExports.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnDeleteExport);
            this.groupBox2.Controls.Add(this.btnAddExport);
            this.groupBox2.Controls.Add(this.btnEditExport);
            this.groupBox2.Controls.Add(this.btnClear);
            this.groupBox2.Controls.Add(this.btnLoadExports);
            this.groupBox2.Controls.Add(this.dgvExports);
            this.groupBox2.Location = new System.Drawing.Point(12, 261);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1044, 494);
            this.groupBox2.TabIndex = 29;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Bảng Thông Tin Xuất Hàng";
            // 
            // dgvExports
            // 
            this.dgvExports.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvExports.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.status,
            this.ImportID,
            this.ProductID,
            this.Quantity,
            this.ImportDate,
            this.EmployeeID,
            this.Supplier});
            this.dgvExports.Location = new System.Drawing.Point(0, 78);
            this.dgvExports.Name = "dgvExports";
            this.dgvExports.RowHeadersWidth = 51;
            this.dgvExports.RowTemplate.Height = 24;
            this.dgvExports.Size = new System.Drawing.Size(1032, 422);
            this.dgvExports.TabIndex = 21;
            // 
            // status
            // 
            this.status.HeaderText = "STT";
            this.status.MinimumWidth = 6;
            this.status.Name = "status";
            this.status.ReadOnly = true;
            this.status.Width = 125;
            // 
            // ImportID
            // 
            this.ImportID.HeaderText = "Mã phiếu nhập";
            this.ImportID.MinimumWidth = 6;
            this.ImportID.Name = "ImportID";
            this.ImportID.ReadOnly = true;
            this.ImportID.Width = 200;
            // 
            // ProductID
            // 
            this.ProductID.HeaderText = "Mã Hàng Hoá";
            this.ProductID.MinimumWidth = 6;
            this.ProductID.Name = "ProductID";
            this.ProductID.ReadOnly = true;
            this.ProductID.Width = 250;
            // 
            // Quantity
            // 
            this.Quantity.HeaderText = "Số lượng";
            this.Quantity.MinimumWidth = 6;
            this.Quantity.Name = "Quantity";
            this.Quantity.ReadOnly = true;
            this.Quantity.Width = 150;
            // 
            // ImportDate
            // 
            this.ImportDate.HeaderText = "Ngày nhập";
            this.ImportDate.MinimumWidth = 6;
            this.ImportDate.Name = "ImportDate";
            this.ImportDate.ReadOnly = true;
            this.ImportDate.Width = 250;
            // 
            // EmployeeID
            // 
            this.EmployeeID.HeaderText = "Mã nhân viên";
            this.EmployeeID.MinimumWidth = 6;
            this.EmployeeID.Name = "EmployeeID";
            this.EmployeeID.ReadOnly = true;
            this.EmployeeID.Width = 200;
            // 
            // Supplier
            // 
            this.Supplier.HeaderText = "Nhà cung cấp";
            this.Supplier.MinimumWidth = 6;
            this.Supplier.Name = "Supplier";
            this.Supplier.ReadOnly = true;
            this.Supplier.Width = 300;
            // 
            // txtProductID
            // 
            this.txtProductID.Location = new System.Drawing.Point(144, 43);
            this.txtProductID.Name = "txtProductID";
            this.txtProductID.Size = new System.Drawing.Size(291, 22);
            this.txtProductID.TabIndex = 12;
            // 
            // txtQuantity
            // 
            this.txtQuantity.Location = new System.Drawing.Point(144, 79);
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.Size = new System.Drawing.Size(291, 22);
            this.txtQuantity.TabIndex = 13;
            // 
            // txtPrice
            // 
            this.txtPrice.Location = new System.Drawing.Point(144, 113);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(291, 22);
            this.txtPrice.TabIndex = 15;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 46);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(91, 16);
            this.label5.TabIndex = 4;
            this.label5.Text = "Mã Hàng Hoá";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 81);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(67, 16);
            this.label6.TabIndex = 5;
            this.label6.Text = "Số Lượng ";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 116);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(55, 16);
            this.label7.TabIndex = 6;
            this.label7.Text = "Đơn Giá";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblTotalAmount);
            this.groupBox1.Controls.Add(this.btnCaculateTotal);
            this.groupBox1.Controls.Add(this.txtProductID);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.txtQuantity);
            this.groupBox1.Controls.Add(this.txtPrice);
            this.groupBox1.Location = new System.Drawing.Point(473, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(452, 240);
            this.groupBox1.TabIndex = 32;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Danh mục thông tin";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.dgvExportDetails);
            this.groupBox4.Location = new System.Drawing.Point(1072, 9);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(486, 746);
            this.groupBox4.TabIndex = 34;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Chi tiết sản phẩm xuất";
            // 
            // dgvExportDetails
            // 
            this.dgvExportDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvExportDetails.Location = new System.Drawing.Point(6, 21);
            this.dgvExportDetails.Name = "dgvExportDetails";
            this.dgvExportDetails.RowHeadersWidth = 51;
            this.dgvExportDetails.RowTemplate.Height = 24;
            this.dgvExportDetails.Size = new System.Drawing.Size(474, 719);
            this.dgvExportDetails.TabIndex = 0;
            // 
            // btnShowDetails
            // 
            this.btnShowDetails.Location = new System.Drawing.Point(931, 93);
            this.btnShowDetails.Name = "btnShowDetails";
            this.btnShowDetails.Size = new System.Drawing.Size(125, 64);
            this.btnShowDetails.TabIndex = 35;
            this.btnShowDetails.Text = "Hiển thị chi tiết đơn hàng";
            this.btnShowDetails.UseVisualStyleBackColor = true;
            // 
            // btnCaculateTotal
            // 
            this.btnCaculateTotal.Location = new System.Drawing.Point(25, 175);
            this.btnCaculateTotal.Name = "btnCaculateTotal";
            this.btnCaculateTotal.Size = new System.Drawing.Size(194, 40);
            this.btnCaculateTotal.TabIndex = 36;
            this.btnCaculateTotal.Text = "Tổng giá trị đơn hàng";
            this.btnCaculateTotal.UseVisualStyleBackColor = true;
            // 
            // btnExportExcel
            // 
            this.btnExportExcel.Location = new System.Drawing.Point(6, 184);
            this.btnExportExcel.Name = "btnExportExcel";
            this.btnExportExcel.Size = new System.Drawing.Size(194, 40);
            this.btnExportExcel.TabIndex = 37;
            this.btnExportExcel.Text = "In đơn xuất hàng";
            this.btnExportExcel.UseVisualStyleBackColor = true;
            // 
            // lblTotalAmount
            // 
            this.lblTotalAmount.AutoSize = true;
            this.lblTotalAmount.Location = new System.Drawing.Point(282, 187);
            this.lblTotalAmount.Name = "lblTotalAmount";
            this.lblTotalAmount.Size = new System.Drawing.Size(57, 16);
            this.lblTotalAmount.TabIndex = 37;
            this.lblTotalAmount.Text = "tong tien";
            // 
            // PhieuXuatKho
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1570, 773);
            this.Controls.Add(this.btnShowDetails);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.btnBackMenu);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "PhieuXuatKho";
            this.Text = "PhieuXuatKho";
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvExports)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtQuantity)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvExportDetails)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txtExportID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbCustomerID;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtpExportDate;
        private System.Windows.Forms.ComboBox cbEmployeeID;
        private Guna.UI2.WinForms.Guna2DragControl guna2DragControl1;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnBackMenu;
        private System.Windows.Forms.Button btnDeleteExport;
        private System.Windows.Forms.Button btnAddExport;
        private System.Windows.Forms.Button btnEditExport;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnLoadExports;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dgvExports;
        private System.Windows.Forms.DataGridViewTextBoxColumn status;
        private System.Windows.Forms.DataGridViewTextBoxColumn ImportID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Quantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn ImportDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn EmployeeID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Supplier;
        private System.Windows.Forms.TextBox txtProductID;
        private System.Windows.Forms.NumericUpDown txtQuantity;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.DataGridView dgvExportDetails;
        private System.Windows.Forms.Button btnCaculateTotal;
        private System.Windows.Forms.Button btnShowDetails;
        private System.Windows.Forms.Button btnExportExcel;
        private System.Windows.Forms.Label lblTotalAmount;
    }
}