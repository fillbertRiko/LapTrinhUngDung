namespace UngDungQuanLyKho.Data.View.Admin
{
    partial class StockStatus
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
            this.dgvStockStatus = new System.Windows.Forms.DataGridView();
            this.btnRefesh = new System.Windows.Forms.Button();
            this.btnSendAlert = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStockStatus)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvStockStatus
            // 
            this.dgvStockStatus.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStockStatus.Location = new System.Drawing.Point(12, 12);
            this.dgvStockStatus.Name = "dgvStockStatus";
            this.dgvStockStatus.RowHeadersWidth = 51;
            this.dgvStockStatus.RowTemplate.Height = 24;
            this.dgvStockStatus.Size = new System.Drawing.Size(776, 351);
            this.dgvStockStatus.TabIndex = 0;
            // 
            // btnRefesh
            // 
            this.btnRefesh.Location = new System.Drawing.Point(138, 404);
            this.btnRefesh.Name = "btnRefesh";
            this.btnRefesh.Size = new System.Drawing.Size(188, 34);
            this.btnRefesh.TabIndex = 1;
            this.btnRefesh.Text = "button1";
            this.btnRefesh.UseVisualStyleBackColor = true;
            // 
            // btnSendAlert
            // 
            this.btnSendAlert.Location = new System.Drawing.Point(419, 404);
            this.btnSendAlert.Name = "btnSendAlert";
            this.btnSendAlert.Size = new System.Drawing.Size(188, 34);
            this.btnSendAlert.TabIndex = 2;
            this.btnSendAlert.Text = "button1";
            this.btnSendAlert.UseVisualStyleBackColor = true;
            // 
            // StockStatus
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnSendAlert);
            this.Controls.Add(this.btnRefesh);
            this.Controls.Add(this.dgvStockStatus);
            this.Name = "StockStatus";
            this.Text = "StockStatus";
            this.Load += new System.EventHandler(this.StockStatus_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvStockStatus)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvStockStatus;
        private System.Windows.Forms.Button btnRefesh;
        private System.Windows.Forms.Button btnSendAlert;
    }
}