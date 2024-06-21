using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS_QLBanHang;
using DTO_QLBanHang;

namespace GUI_QLBanHang
{
    public partial class frm_DangNhap : Form
    {
        busNhanVien busNV = new busNhanVien();

        public string vaitro{ set; get; }// đăng nhập thành công, kiểm tra vai trò
    
        public frm_DangNhap()
        {
            InitializeComponent();
        }

        private void lbl_TieuDe_Click(object sender, EventArgs e)
        {

        }
        private void frm_DangNhap_Load(object sender, EventArgs e)
        {
            txtEmailDN.Text = Properties.Settings.Default.email;
            txtMatKhau.Text = Properties.Settings.Default.password;
            if(Properties.Settings.Default.email != "")
            {
                chkGhiNhoTaiKhoan.Checked = true;
            }
            FrmMain_QLBanHang.session = 0; // not yet login
        }

        
        private void btnDN_Click(object sender, EventArgs e)
        {
            try
            {
                DTO_NhanVien nv = new DTO_NhanVien();
                nv.EmailNv = txtEmailDN.Text;
                nv.Matkhau = busNV.encryption(txtMatKhau.Text); // mã mật khẩu để so sánh với mật khẩu đã mã hoá trong csdl
                if (busNV.NhanVienDangNhap(nv)) // successfull login
                {
                    //login = true
                    FrmMain_QLBanHang.mail = nv.EmailNv; // truyền email đăng nhập cho frmMain
                    DataTable dt = busNV.VaiTroNhanVien(nv.EmailNv);
                    vaitro = dt.Rows[0][0].ToString();  // lấy vai trò của nhân viên, hiển thị các chức năng mã nhân viên có thể thao tác
                    MessageBox.Show("Đăng nhập thành công");
                    FrmMain_QLBanHang.session = 1; // cập nhật trạng thái đã đăng nhập thành công
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Đăng nhập không thành công, kiểm tra lại email hoặc mật khẩu");
                    txtEmailDN.Text = null;
                    txtMatKhau.Text = null;
                    txtEmailDN.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi " + ex);
            }
        }
        public string RandomString(int size, bool lowerCase)
        {
            StringBuilder builder = new StringBuilder();
            Random random = new Random();
            char ch;
            for (int i = 0; i < size; i++)
            {
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
                builder.Append(ch);
            }
            if (lowerCase)
            {
                return builder.ToString().ToLower();
            }
            return builder.ToString();
        }

        public int RandomNumber(int min, int max)
        {
            Random random = new Random();
            return random.Next(min, max);
        }

        public void SendMail(string email, string matkhau)
        {
            try
            {
                MailMessage Msg = new MailMessage();
                Msg.Body = "Chào anh/ chị. Mật khẩu mới: " + matkhau;
                Msg.To.Add(email);
                Msg.From = new MailAddress("hungntps38090@gmail.com");
                Msg.Subject = "Bạn đã sử dụng tính năng quên mật khẩu";

                SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
                client.EnableSsl = true;
               
                client.Credentials = new NetworkCredential("hungntps38090@gmail.com", "xlib chji tuaz dmxl");
                client.Send(Msg);
                MessageBox.Show("Gửi mail thành công");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btnQuenMK_Click(object sender, EventArgs e)
        {
            if (txtEmailDN.Text != "")
            {
                if (busNV.NhanVienQuenMK(txtEmailDN.Text))
                {
                    StringBuilder builder = new StringBuilder();
                    builder.Append(RandomString(4, true));
                    builder.Append(RandomNumber(1000, 9999));
                    builder.Append(RandomString(2, false));
                    string matkhaumoi = busNV.encryption(builder.ToString());
                    busNV.TaoMatKhau(txtEmailDN.Text, matkhaumoi);
                    SendMail(txtEmailDN.Text, builder.ToString());
                }
                else
                {
                    MessageBox.Show("Email không tồn tại, vui lòng nhập lại email");
                }
            }
            else
            {
                MessageBox.Show("Bạn cần nhập email nhận thông tin hồi phục mật khẩu");
            }
        }

        // ẩn pass
        private void picBHide_Click(object sender, EventArgs e)
        {
            if(txtMatKhau.PasswordChar == '*')
            {
                picbMo.BringToFront();
                txtMatKhau.PasswordChar = '\0';
            }
        }
        
        // hiện pass
        private void picbMo_Click(object sender, EventArgs e)
        {
            if (txtMatKhau.PasswordChar == '\0')
            {
                picBHide.BringToFront();
                txtMatKhau.PasswordChar = '*';
            }
        }

        private void chkGhiNhoTaiKhoan_CheckedChanged(object sender, EventArgs e)
        {
            if(txtEmailDN.Text != "" && txtMatKhau.Text != "")
            {
                if(chkGhiNhoTaiKhoan.Checked == true)
                {
                    string user = txtEmailDN.Text;
                    string pass = txtMatKhau.Text;
                    Properties.Settings.Default.email = user;
                    Properties.Settings.Default.password = pass;
                    Properties.Settings.Default.Save();
                }
                else
                {
                    Properties.Settings.Default.Reset();
                }
            }
            else
            {
                MessageBox.Show("Bạn chưa nhập email hoặc mật khẩu","Thông báo",MessageBoxButtons.OKCancel);
                chkGhiNhoTaiKhoan.Checked = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
