namespace UngDungQuanLyKho.Data.View.Admin
{
    partial class Products
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
            this.btnPrevPage = new System.Windows.Forms.Button();
            this.btnNextPage = new System.Windows.Forms.Button();
            this.btnStockReport = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtProductName = new System.Windows.Forms.TextBox();
            this.txtCategory = new System.Windows.Forms.TextBox();
            this.txtUnit = new System.Windows.Forms.TextBox();
            this.txtQuantity = new System.Windows.Forms.TextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnLoad = new System.Windows.Forms.Button();
            this.dgvProducts = new System.Windows.Forms.DataGridView();
            this.label5 = new System.Windows.Forms.Label();
            this.txtMinQuantity = new System.Windows.Forms.TextBox();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.lblLocationName = new System.Windows.Forms.Label();
            this.cbbLocation = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProducts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnPrevPage
            // 
            this.btnPrevPage.Location = new System.Drawing.Point(638, 51);
            this.btnPrevPage.Name = "btnPrevPage";
            this.btnPrevPage.Size = new System.Drawing.Size(112, 30);
            this.btnPrevPage.TabIndex = 35;
            this.btnPrevPage.Text = "Trang trước";
            this.btnPrevPage.UseVisualStyleBackColor = true;
            this.btnPrevPage.Click += new System.EventHandler(this.btnPrevPage_Click);
            // 
            // btnNextPage
            // 
            this.btnNextPage.Location = new System.Drawing.Point(756, 51);
            this.btnNextPage.Name = "btnNextPage";
            this.btnNextPage.Size = new System.Drawing.Size(116, 30);
            this.btnNextPage.TabIndex = 34;
            this.btnNextPage.Text = "Trang sau";
            this.btnNextPage.UseVisualStyleBackColor = true;
            this.btnNextPage.Click += new System.EventHandler(this.btnNextPage_Click);
            // 
            // btnStockReport
            // 
            this.btnStockReport.Location = new System.Drawing.Point(639, 402);
            this.btnStockReport.Name = "btnStockReport";
            this.btnStockReport.Size = new System.Drawing.Size(234, 47);
            this.btnStockReport.TabIndex = 33;
            this.btnStockReport.Text = "Kiểm tra số lượng tồn kho";
            this.btnStockReport.UseVisualStyleBackColor = true;
            this.btnStockReport.Click += new System.EventHandler(this.btnStockReport_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(644, 171);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 16);
            this.label4.TabIndex = 32;
            this.label4.Text = "Danh mục";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(667, 219);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 16);
            this.label3.TabIndex = 31;
            this.label3.Text = "Đơn vị";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(651, 267);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 16);
            this.label2.TabIndex = 30;
            this.label2.Text = "Số lượng";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(620, 123);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 16);
            this.label1.TabIndex = 29;
            this.label1.Text = "Tên hàng hoá";
            // 
            // txtProductName
            // 
            this.txtProductName.Location = new System.Drawing.Point(716, 125);
            this.txtProductName.Name = "txtProductName";
            this.txtProductName.Size = new System.Drawing.Size(157, 22);
            this.txtProductName.TabIndex = 28;
            this.txtProductName.TextChanged += new System.EventHandler(this.txtProductName_TextChanged);
            // 
            // txtCategory
            // 
            this.txtCategory.Location = new System.Drawing.Point(716, 172);
            this.txtCategory.Name = "txtCategory";
            this.txtCategory.Size = new System.Drawing.Size(157, 22);
            this.txtCategory.TabIndex = 27;
            this.txtCategory.TextChanged += new System.EventHandler(this.txtCategory_TextChanged);
            // 
            // txtUnit
            // 
            this.txtUnit.Location = new System.Drawing.Point(715, 219);
            this.txtUnit.Name = "txtUnit";
            this.txtUnit.Size = new System.Drawing.Size(157, 22);
            this.txtUnit.TabIndex = 26;
            this.txtUnit.TextChanged += new System.EventHandler(this.txtUnit_TextChanged);
            // 
            // txtQuantity
            // 
            this.txtQuantity.Location = new System.Drawing.Point(715, 266);
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.Size = new System.Drawing.Size(157, 22);
            this.txtQuantity.TabIndex = 25;
            this.txtQuantity.TextChanged += new System.EventHandler(this.txtQuantity_TextChanged);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(638, 455);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(72, 47);
            this.btnAdd.TabIndex = 24;
            this.btnAdd.Text = "Thêm";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click_1);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(716, 455);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(72, 47);
            this.btnEdit.TabIndex = 23;
            this.btnEdit.Text = "Sửa";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click_1);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(801, 455);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(72, 47);
            this.btnDelete.TabIndex = 22;
            this.btnDelete.Text = "Xoá";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click_1);
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(716, 87);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(157, 22);
            this.txtSearch.TabIndex = 21;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(638, 87);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(72, 22);
            this.btnSearch.TabIndex = 20;
            this.btnSearch.Text = "Tìm kiếm";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click_1);
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(638, 22);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(235, 23);
            this.btnLoad.TabIndex = 19;
            this.btnLoad.Text = "Hiển thị hàng hoá";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // dgvProducts
            // 
            this.dgvProducts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProducts.Location = new System.Drawing.Point(12, 12);
            this.dgvProducts.Name = "dgvProducts";
            this.dgvProducts.RowHeadersWidth = 51;
            this.dgvProducts.RowTemplate.Height = 24;
            this.dgvProducts.Size = new System.Drawing.Size(517, 490);
            this.dgvProducts.TabIndex = 18;
            this.dgvProducts.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProducts_CellContentClick);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(601, 315);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(108, 16);
            this.label5.TabIndex = 37;
            this.label5.Text = "Số lượng tối thiểu";
            // 
            // txtMinQuantity
            // 
            this.txtMinQuantity.Location = new System.Drawing.Point(716, 313);
            this.txtMinQuantity.Name = "txtMinQuantity";
            this.txtMinQuantity.Size = new System.Drawing.Size(157, 22);
            this.txtMinQuantity.TabIndex = 36;
            this.txtMinQuantity.TextChanged += new System.EventHandler(this.txtMinQuantity_TextChanged);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // lblLocationName
            // 
            this.lblLocationName.AutoSize = true;
            this.lblLocationName.Location = new System.Drawing.Point(654, 363);
            this.lblLocationName.Name = "lblLocationName";
            this.lblLocationName.Size = new System.Drawing.Size(57, 16);
            this.lblLocationName.TabIndex = 39;
            this.lblLocationName.Text = "Tên vị trí";
            // 
            // cbbLocation
            // 
            this.cbbLocation.FormattingEnabled = true;
            this.cbbLocation.Items.AddRange(new object[] {
            "Khu A"});
            this.cbbLocation.Location = new System.Drawing.Point(715, 360);
            this.cbbLocation.Name = "cbbLocation";
            this.cbbLocation.Size = new System.Drawing.Size(156, 24);
            this.cbbLocation.TabIndex = 42;
            this.cbbLocation.SelectedIndexChanged += new System.EventHandler(this.cbbArea_SelectedIndexChanged);
            // 
            // Products
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(938, 515);
            this.Controls.Add(this.cbbLocation);
            this.Controls.Add(this.lblLocationName);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtMinQuantity);
            this.Controls.Add(this.btnPrevPage);
            this.Controls.Add(this.btnNextPage);
            this.Controls.Add(this.btnStockReport);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtProductName);
            this.Controls.Add(this.txtCategory);
            this.Controls.Add(this.txtUnit);
            this.Controls.Add(this.txtQuantity);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.dgvProducts);
            this.Name = "Products";
            this.Text = "Products";
            ((System.ComponentModel.ISupportInitialize)(this.dgvProducts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnPrevPage;
        private System.Windows.Forms.Button btnNextPage;
        private System.Windows.Forms.Button btnStockReport;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtProductName;
        private System.Windows.Forms.TextBox txtCategory;
        private System.Windows.Forms.TextBox txtUnit;
        private System.Windows.Forms.TextBox txtQuantity;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.DataGridView dgvProducts;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtMinQuantity;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Label lblLocationName;
        private System.Windows.Forms.ComboBox cbbLocation;
    }
}