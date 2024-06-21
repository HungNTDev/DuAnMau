using BUS_QLBanHang;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI_QLBanHang
{
    public partial class ThongTinNV : Form
    {
       
        string stremail; // nhận email từ frmMain
        busNhanVien busNV = new busNhanVien();  
        frm_DangNhap dn = new frm_DangNhap();
        public ThongTinNV(string email)
        {
            InitializeComponent();
            stremail = email;
            txtEmailDN.Text = stremail;
            txtEmailDN.Enabled = false;
        }

       

        private void ThongTinNV_Load(object sender, EventArgs e)
        {

        }

        private void btnDMK_Click(object sender, EventArgs e)
        {
            if (txtMatKhauCu.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mật khẩu cũ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMatKhauCu.Focus();
                return;
            }
            else if (txtMKMoi.Text.Trim().Length == 0) 
            {
                MessageBox.Show("Bạn phải nhập mật khẩu mới", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMKMoi.Focus();
                return;
            }
            else if (txtNhapLaiMKM.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập lại mật khẩu mới", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtNhapLaiMKM.Focus();
                return;
            }
            else
            {
                if(MessageBox.Show("Bạn chắc chắn muốn đổi mật khẩu", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information)==DialogResult.Yes)
                {
                    //do something if Yes
                    string matkhaumoi = busNV.encryption(txtMKMoi.Text);
                    string matkhaucu = busNV.encryption(txtMatKhauCu.Text);
                    if (busNV.UpdateMatKhau(txtEmailDN.Text, matkhaucu, matkhaumoi))
                    {
                        FrmMain_QLBanHang.profile = 1;
                        FrmMain_QLBanHang.session = 0; // đưa về tình trạng chưa đăng nhập
                        dn.SendMail(stremail, txtNhapLaiMKM.Text);
                        MessageBox.Show("Cập nhật mật khẩu thành công, bạn cần phải đăng nhập lại");
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Mật khẩu cũ không đúng, Cập nhật mật khẩu không thành công");
                        txtMatKhauCu.Text = null;
                        txtMKMoi.Text = null;
                        txtNhapLaiMKM.Text = null;
                    }
                }
                else
                {
                    // do somgthing is NO
                    txtMatKhauCu.Text = null;
                    txtMKMoi.Text = null;
                    txtNhapLaiMKM.Text = null;
                }
            }
        }
    }
}
