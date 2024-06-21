namespace GUI_QLBanHang
{
    partial class frm_DangNhap
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_DangNhap));
            this.picImgDN = new System.Windows.Forms.PictureBox();
            this.lbl_TieuDe = new System.Windows.Forms.Label();
            this.lblEmailDN = new System.Windows.Forms.Label();
            this.txtEmailDN = new System.Windows.Forms.TextBox();
            this.lblMatKhau = new System.Windows.Forms.Label();
            this.txtMatKhau = new System.Windows.Forms.TextBox();
            this.chkGhiNhoTaiKhoan = new System.Windows.Forms.CheckBox();
            this.btnDN = new System.Windows.Forms.Button();
            this.btnQuenMK = new System.Windows.Forms.Button();
            this.picbMo = new System.Windows.Forms.PictureBox();
            this.picBHide = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picImgDN)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picbMo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBHide)).BeginInit();
            this.SuspendLayout();
            // 
            // picImgDN
            // 
            this.picImgDN.BackColor = System.Drawing.Color.Transparent;
            this.picImgDN.Image = ((System.Drawing.Image)(resources.GetObject("picImgDN.Image")));
            this.picImgDN.InitialImage = ((System.Drawing.Image)(resources.GetObject("picImgDN.InitialImage")));
            this.picImgDN.Location = new System.Drawing.Point(225, 39);
            this.picImgDN.Margin = new System.Windows.Forms.Padding(2);
            this.picImgDN.Name = "picImgDN";
            this.picImgDN.Size = new System.Drawing.Size(64, 52);
            this.picImgDN.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picImgDN.TabIndex = 0;
            this.picImgDN.TabStop = false;
            // 
            // lbl_TieuDe
            // 
            this.lbl_TieuDe.AutoSize = true;
            this.lbl_TieuDe.BackColor = System.Drawing.Color.Transparent;
            this.lbl_TieuDe.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_TieuDe.ForeColor = System.Drawing.Color.White;
            this.lbl_TieuDe.Location = new System.Drawing.Point(107, 93);
            this.lbl_TieuDe.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_TieuDe.Name = "lbl_TieuDe";
            this.lbl_TieuDe.Size = new System.Drawing.Size(277, 31);
            this.lbl_TieuDe.TabIndex = 1;
            this.lbl_TieuDe.Text = "Đăng Nhập Hệ Thống";
            this.lbl_TieuDe.Click += new System.EventHandler(this.lbl_TieuDe_Click);
            // 
            // lblEmailDN
            // 
            this.lblEmailDN.AutoSize = true;
            this.lblEmailDN.BackColor = System.Drawing.Color.Transparent;
            this.lblEmailDN.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmailDN.ForeColor = System.Drawing.Color.White;
            this.lblEmailDN.Location = new System.Drawing.Point(68, 158);
            this.lblEmailDN.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblEmailDN.Name = "lblEmailDN";
            this.lblEmailDN.Size = new System.Drawing.Size(158, 24);
            this.lblEmailDN.TabIndex = 2;
            this.lblEmailDN.Text = "Email Đăng Nhập";
            // 
            // txtEmailDN
            // 
            this.txtEmailDN.BackColor = System.Drawing.Color.White;
            this.txtEmailDN.Location = new System.Drawing.Point(72, 184);
            this.txtEmailDN.Margin = new System.Windows.Forms.Padding(2);
            this.txtEmailDN.Multiline = true;
            this.txtEmailDN.Name = "txtEmailDN";
            this.txtEmailDN.Size = new System.Drawing.Size(377, 25);
            this.txtEmailDN.TabIndex = 3;
            // 
            // lblMatKhau
            // 
            this.lblMatKhau.AutoSize = true;
            this.lblMatKhau.BackColor = System.Drawing.Color.Transparent;
            this.lblMatKhau.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMatKhau.ForeColor = System.Drawing.Color.White;
            this.lblMatKhau.Location = new System.Drawing.Point(68, 229);
            this.lblMatKhau.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblMatKhau.Name = "lblMatKhau";
            this.lblMatKhau.Size = new System.Drawing.Size(89, 24);
            this.lblMatKhau.TabIndex = 4;
            this.lblMatKhau.Text = "Mật Khẩu";
            // 
            // txtMatKhau
            // 
            this.txtMatKhau.Location = new System.Drawing.Point(72, 255);
            this.txtMatKhau.Margin = new System.Windows.Forms.Padding(2);
            this.txtMatKhau.Multiline = true;
            this.txtMatKhau.Name = "txtMatKhau";
            this.txtMatKhau.PasswordChar = '*';
            this.txtMatKhau.Size = new System.Drawing.Size(377, 25);
            this.txtMatKhau.TabIndex = 5;
            // 
            // chkGhiNhoTaiKhoan
            // 
            this.chkGhiNhoTaiKhoan.AutoSize = true;
            this.chkGhiNhoTaiKhoan.BackColor = System.Drawing.Color.Transparent;
            this.chkGhiNhoTaiKhoan.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkGhiNhoTaiKhoan.ForeColor = System.Drawing.Color.White;
            this.chkGhiNhoTaiKhoan.Location = new System.Drawing.Point(73, 294);
            this.chkGhiNhoTaiKhoan.Margin = new System.Windows.Forms.Padding(2);
            this.chkGhiNhoTaiKhoan.Name = "chkGhiNhoTaiKhoan";
            this.chkGhiNhoTaiKhoan.Size = new System.Drawing.Size(153, 24);
            this.chkGhiNhoTaiKhoan.TabIndex = 6;
            this.chkGhiNhoTaiKhoan.Text = "Ghi nhớ tài khoản";
            this.chkGhiNhoTaiKhoan.UseVisualStyleBackColor = false;
            this.chkGhiNhoTaiKhoan.CheckedChanged += new System.EventHandler(this.chkGhiNhoTaiKhoan_CheckedChanged);
            // 
            // btnDN
            // 
            this.btnDN.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnDN.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDN.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.btnDN.Location = new System.Drawing.Point(131, 340);
            this.btnDN.Margin = new System.Windows.Forms.Padding(2);
            this.btnDN.Name = "btnDN";
            this.btnDN.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnDN.Size = new System.Drawing.Size(236, 54);
            this.btnDN.TabIndex = 8;
            this.btnDN.Text = "Đăng Nhập";
            this.btnDN.UseVisualStyleBackColor = false;
            this.btnDN.Click += new System.EventHandler(this.btnDN_Click);
            // 
            // btnQuenMK
            // 
            this.btnQuenMK.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnQuenMK.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQuenMK.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnQuenMK.Location = new System.Drawing.Point(301, 288);
            this.btnQuenMK.Name = "btnQuenMK";
            this.btnQuenMK.Size = new System.Drawing.Size(148, 34);
            this.btnQuenMK.TabIndex = 10;
            this.btnQuenMK.Text = "Quên Mật Khẩu ?";
            this.btnQuenMK.UseVisualStyleBackColor = false;
            this.btnQuenMK.Click += new System.EventHandler(this.btnQuenMK_Click);
            // 
            // picbMo
            // 
            this.picbMo.Image = ((System.Drawing.Image)(resources.GetObject("picbMo.Image")));
            this.picbMo.Location = new System.Drawing.Point(420, 255);
            this.picbMo.Name = "picbMo";
            this.picbMo.Size = new System.Drawing.Size(29, 25);
            this.picbMo.TabIndex = 11;
            this.picbMo.TabStop = false;
            this.picbMo.Click += new System.EventHandler(this.picbMo_Click);
            // 
            // picBHide
            // 
            this.picBHide.BackColor = System.Drawing.Color.White;
            this.picBHide.Image = ((System.Drawing.Image)(resources.GetObject("picBHide.Image")));
            this.picBHide.Location = new System.Drawing.Point(420, 255);
            this.picBHide.Name = "picBHide";
            this.picBHide.Size = new System.Drawing.Size(29, 25);
            this.picBHide.TabIndex = 12;
            this.picBHide.TabStop = false;
            this.picBHide.Click += new System.EventHandler(this.picBHide_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(131, 413);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(236, 54);
            this.button1.TabIndex = 13;
            this.button1.Text = "Thoát";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // frm_DangNhap
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.BackgroundImage = global::GUI_QLBanHang.Properties.Resources.pexels_photo_1624496;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(512, 486);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.picBHide);
            this.Controls.Add(this.picbMo);
            this.Controls.Add(this.btnQuenMK);
            this.Controls.Add(this.btnDN);
            this.Controls.Add(this.chkGhiNhoTaiKhoan);
            this.Controls.Add(this.txtMatKhau);
            this.Controls.Add(this.lblMatKhau);
            this.Controls.Add(this.txtEmailDN);
            this.Controls.Add(this.lblEmailDN);
            this.Controls.Add(this.lbl_TieuDe);
            this.Controls.Add(this.picImgDN);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "frm_DangNhap";
            this.Text = "Đăng Nhập";
            this.Load += new System.EventHandler(this.frm_DangNhap_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picImgDN)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picbMo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBHide)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picImgDN;
        private System.Windows.Forms.Label lbl_TieuDe;
        private System.Windows.Forms.Label lblEmailDN;
        private System.Windows.Forms.TextBox txtEmailDN;
        private System.Windows.Forms.Label lblMatKhau;
        private System.Windows.Forms.TextBox txtMatKhau;
        private System.Windows.Forms.CheckBox chkGhiNhoTaiKhoan;
        private System.Windows.Forms.Button btnDN;
        private System.Windows.Forms.Button btnQuenMK;
        private System.Windows.Forms.PictureBox picbMo;
        private System.Windows.Forms.PictureBox picBHide;
        private System.Windows.Forms.Button button1;
    }
}

