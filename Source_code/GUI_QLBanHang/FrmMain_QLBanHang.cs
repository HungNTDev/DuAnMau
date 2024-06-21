using System;
using System.Windows.Forms;
using System.IO;
using System.Data.SqlClient;

namespace GUI_QLBanHang
{
    public partial class FrmMain_QLBanHang : Form
    {
        public static int session = 0; // kiểm tra tình trạng login
        public static int profile = 0;//
        public static string mail; // 
        frm_DangNhap dn;
        

        public FrmMain_QLBanHang()
        {
            InitializeComponent();
            this.IsMdiContainer = true;
        }

        // CheckExistForm để kiẻm tra xem 1 form với tên nào đó đã hiển thị trong 
        // Form Cha (frmMain) chưa? => Trả về True (đã hiển thị) hoặc False (nếu chưa hiển thị)
        private bool CheckExistForm(string name)
        {
            bool check = false;
            foreach (Form frm in this.MdiChildren)
            {
                if (frm.Name == name)
                {
                    check = true;
                    break;
                }
            }
            return check;
        }

        // ActiveChildForm dùng để kích hoạt hiện thị lên trên 
        // cùng các trong số các form con nếu nó đã hiện mà ko phải tạo thể hiện mới
        private void ActiveChildForm(string name)
        {
            foreach (Form frm in this.MdiChildren)
            {
                if (frm.Name == name)
                {
                    frm.Activate();
                    break;
                }
            }
        }
        public void frm_DangNhap_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Refresh();
            FrmMain_QLBanHang_Load(sender, e);
        }
        private void đăngNhậpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                dn = new frm_DangNhap();
                if (!CheckExistForm("frm_DangNhap"))
                {
                    dn.MdiParent = this;
                    dn.Show();
                    dn.FormClosed += new FormClosedEventHandler(frm_DangNhap_FormClosed);
                }
                else
                {
                    ActiveChildForm("frm_DangNhap");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi " + ex.Message);
            }
        }

        private void VaiTroNv()
        {
            nhânViênToolStripMenuItem.Visible = false;
            thốngKêToolStripMenuItem.Visible = false;
        }

        // thiết lập lại phân quyền khi load form main
        private void ResetValue()
        {
            if(session == 1)
            {
                thongTinToolStripMenuItem.Text = "Chào " + FrmMain_QLBanHang.mail;
                nhânViênToolStripMenuItem.Visible = true;
                danhMụcToolStripMenuItem.Visible = true;
                đăngXuấtToolStripMenuItem.Enabled = true;
                thốngKêToolStripMenuItem.Visible = true;
                thốngKêSảnPhẩmToolStripMenuItem.Visible = true;
                hồSơNhânViênToolStripMenuItem.Visible=true;
                đăngNhậpToolStripMenuItem.Enabled=false;
                if (int.Parse(dn.vaitro) == 0)
                {
                    VaiTroNv();
                }
                
            }
            else
            {
                nhânViênToolStripMenuItem.Visible = false;
                danhMụcToolStripMenuItem.Visible = false;
                đăngXuấtToolStripMenuItem.Enabled = false;
                thốngKêToolStripMenuItem.Visible = false;
                thốngKêSảnPhẩmToolStripMenuItem.Visible = false;
                hồSơNhânViênToolStripMenuItem.Visible = false;
                đăngNhậpToolStripMenuItem.Enabled = true;
            }
        }

        private void FrmMain_QLBanHang_Load(object sender, EventArgs e)
        {
            ResetValue();
            if(profile == 1) // Nếu vừa cập nhật mật khẩu thì 
                             // phải login lại, mục 'thông tin nhân viên ẩn'
            {
                thongTinToolStripMenuItem.Text = null;
                profile = 0;
            }
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
        private void FrmThongTinNV_FormClosed(object sender, EventArgs e)
        {
            this.Refresh();
            FrmMain_QLBanHang_Load(sender, e);  
        }
        private void hồSơNhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ThongTinNV thongTinNV = new ThongTinNV(FrmMain_QLBanHang.mail);

            if (!CheckExistForm("ThongTinNV"))
            {
                thongTinNV.MdiParent = this;
                thongTinNV.FormClosed += new FormClosedEventHandler(FrmThongTinNV_FormClosed);
                thongTinNV.Show();
            }
            else
            {
                ActiveChildForm("ThongTinNV");
            }
        }

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            thongTinToolStripMenuItem.Text = null;
            session = 0;
            ResetValue();
        }

        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void kháchHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!CheckExistForm("frmKhachHang_QLBH"))
            {
                frmKhachHang_QLBH nv = new frmKhachHang_QLBH();
                nv.MdiParent = this;
                nv.Show();
            }
            else//hiển thị focus
                ActiveChildForm("frmKhachHang_QLBH");
        }

        private void sảnPhẩmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!CheckExistForm("frmHang_QLBH"))
            {
                frmHang_QLBH sp = new frmHang_QLBH();
                sp.MdiParent = this;
                sp.Show();
            }
            else//hiển thị focus
                ActiveChildForm("frmHang_QLBH");
        }

        private void nhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!CheckExistForm("frmNhanVien-QLBH"))
            {
                frmNhanVien_QLBH nv = new frmNhanVien_QLBH();
                nv.MdiParent = this;
                nv.Show();
            }
            else//hiển thị focus
                ActiveChildForm("frmNhanVien-QLBH");
        }

        private void thốngKêSảnPhẩmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!CheckExistForm("FrmThongKe"))
            {
                FrmThongKe tk = new FrmThongKe();
                tk.MdiParent = this;
                tk.Show();
            }
            else//hiển thị focus
                ActiveChildForm("FrmThongKe");
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void hướngDẫnSửDụngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                var path = Path.Combine(Directory.GetCurrentDirectory(), "Nguyen_Tuan_Hung_PS38090.docx");
                System.Diagnostics.Process.Start(path);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi" + ex);
            }
        }

        private void giớiThiệuPhầnMềmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!CheckExistForm("About"))
            {
                About ab = new About();
                ab.MdiParent = this;
                ab.Show();
            }
            else//hiển thị focus
                ActiveChildForm("About");
        }
    }
}
