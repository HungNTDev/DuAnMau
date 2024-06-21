namespace GUI_QLBanHang
{
    partial class FrmThongKe
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
            this.tcThongKe = new System.Windows.Forms.TabControl();
            this.tpSanPham = new System.Windows.Forms.TabPage();
            this.dgvsp = new System.Windows.Forms.DataGridView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dgvtonkho = new System.Windows.Forms.DataGridView();
            this.tcThongKe.SuspendLayout();
            this.tpSanPham.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvsp)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvtonkho)).BeginInit();
            this.SuspendLayout();
            // 
            // tcThongKe
            // 
            this.tcThongKe.Controls.Add(this.tpSanPham);
            this.tcThongKe.Controls.Add(this.tabPage2);
            this.tcThongKe.Location = new System.Drawing.Point(12, 10);
            this.tcThongKe.Name = "tcThongKe";
            this.tcThongKe.SelectedIndex = 0;
            this.tcThongKe.Size = new System.Drawing.Size(464, 245);
            this.tcThongKe.TabIndex = 0;
            this.tcThongKe.Tag = "";
            this.tcThongKe.Selected += new System.Windows.Forms.TabControlEventHandler(this.tcThongKe_Selected);
            // 
            // tpSanPham
            // 
            this.tpSanPham.Controls.Add(this.dgvsp);
            this.tpSanPham.Location = new System.Drawing.Point(4, 22);
            this.tpSanPham.Name = "tpSanPham";
            this.tpSanPham.Padding = new System.Windows.Forms.Padding(3);
            this.tpSanPham.Size = new System.Drawing.Size(456, 219);
            this.tpSanPham.TabIndex = 0;
            this.tpSanPham.Text = "Sản Phẩm Nhập Kho";
            this.tpSanPham.UseVisualStyleBackColor = true;
            this.tpSanPham.Click += new System.EventHandler(this.tpSanPham_Click);
            // 
            // dgvsp
            // 
            this.dgvsp.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvsp.Location = new System.Drawing.Point(0, 7);
            this.dgvsp.Name = "dgvsp";
            this.dgvsp.Size = new System.Drawing.Size(452, 211);
            this.dgvsp.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.dgvtonkho);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(456, 219);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Tồn Kho";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // dgvtonkho
            // 
            this.dgvtonkho.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvtonkho.Location = new System.Drawing.Point(3, 0);
            this.dgvtonkho.Name = "dgvtonkho";
            this.dgvtonkho.Size = new System.Drawing.Size(432, 198);
            this.dgvtonkho.TabIndex = 0;
            // 
            // FrmThongKe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(500, 279);
            this.Controls.Add(this.tcThongKe);
            this.Name = "FrmThongKe";
            this.Text = "FrmThongKe";
            this.Load += new System.EventHandler(this.FrmThongKe_Load);
            this.tcThongKe.ResumeLayout(false);
            this.tpSanPham.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvsp)).EndInit();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvtonkho)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tcThongKe;
        private System.Windows.Forms.TabPage tpSanPham;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView dgvsp;
        private System.Windows.Forms.DataGridView dgvtonkho;
    }
}