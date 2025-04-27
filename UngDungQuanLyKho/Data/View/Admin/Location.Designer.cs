namespace UngDungQuanLyKho.Data.View.Admin
{
    partial class Location
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
            this.cbbArea = new System.Windows.Forms.ComboBox();
            this.btnSaveLocation = new System.Windows.Forms.Button();
            this.btnClearLocation = new System.Windows.Forms.Button();
            this.dgvLocations = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.txtLocationName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLocations)).BeginInit();
            this.SuspendLayout();
            // 
            // cbbArea
            // 
            this.cbbArea.FormattingEnabled = true;
            this.cbbArea.Location = new System.Drawing.Point(142, 179);
            this.cbbArea.Name = "cbbArea";
            this.cbbArea.Size = new System.Drawing.Size(167, 24);
            this.cbbArea.TabIndex = 0;
            // 
            // btnSaveLocation
            // 
            this.btnSaveLocation.Location = new System.Drawing.Point(27, 249);
            this.btnSaveLocation.Name = "btnSaveLocation";
            this.btnSaveLocation.Size = new System.Drawing.Size(104, 59);
            this.btnSaveLocation.TabIndex = 1;
            this.btnSaveLocation.Text = "Lưu vị trí kho";
            this.btnSaveLocation.UseVisualStyleBackColor = true;
            this.btnSaveLocation.Click += new System.EventHandler(this.btnSaveLocation_Click_1);
            // 
            // btnClearLocation
            // 
            this.btnClearLocation.Location = new System.Drawing.Point(208, 249);
            this.btnClearLocation.Name = "btnClearLocation";
            this.btnClearLocation.Size = new System.Drawing.Size(101, 59);
            this.btnClearLocation.TabIndex = 2;
            this.btnClearLocation.Text = "Xoá vị trí kho";
            this.btnClearLocation.UseVisualStyleBackColor = true;
            this.btnClearLocation.Click += new System.EventHandler(this.btnClearLocation_Click_1);
            // 
            // dgvLocations
            // 
            this.dgvLocations.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLocations.Location = new System.Drawing.Point(339, 12);
            this.dgvLocations.Name = "dgvLocations";
            this.dgvLocations.RowHeadersWidth = 51;
            this.dgvLocations.RowTemplate.Height = 24;
            this.dgvLocations.Size = new System.Drawing.Size(449, 426);
            this.dgvLocations.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(106, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(122, 16);
            this.label1.TabIndex = 4;
            this.label1.Text = "Chọn vị trí kho hàng";
            // 
            // txtLocationName
            // 
            this.txtLocationName.Location = new System.Drawing.Point(142, 134);
            this.txtLocationName.Name = "txtLocationName";
            this.txtLocationName.Size = new System.Drawing.Size(167, 22);
            this.txtLocationName.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 140);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 16);
            this.label2.TabIndex = 6;
            this.label2.Text = "Tên vị trí";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 187);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 16);
            this.label3.TabIndex = 7;
            this.label3.Text = "Khu vực";
            // 
            // Location
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtLocationName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvLocations);
            this.Controls.Add(this.btnClearLocation);
            this.Controls.Add(this.btnSaveLocation);
            this.Controls.Add(this.cbbArea);
            this.Name = "Location";
            this.Text = "Location";
            ((System.ComponentModel.ISupportInitialize)(this.dgvLocations)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbbArea;
        private System.Windows.Forms.Button btnSaveLocation;
        private System.Windows.Forms.Button btnClearLocation;
        private System.Windows.Forms.DataGridView dgvLocations;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtLocationName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}