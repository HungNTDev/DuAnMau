using BUS_QLBanHang;
using System;
using System.Net.Mail;
using System.Windows.Forms;
using DTO_QLBanHang;
using System.Net;
using System.Drawing;
using System.Data;

namespace GUI_QLBanHang
{
    public partial class frmNhanVien_QLBH : Form
    {
        busNhanVien busNV = new busNhanVien();
        public frmNhanVien_QLBH()
        {
            InitializeComponent();
        }
        public void SendMail(string email)
        {
            try
            {
                MailMessage Msg = new MailMessage();
                Msg.Body = "Chào anh/ chị. : Mật khẩu truy cập phần mềm là abc123. Vui lòng nhập và thay đồi mật khẩu";
                Msg.To.Add(email);
                Msg.From = new MailAddress("hungntps38090@gmail.com");
                Msg.Subject = "Chúc mừng bạn đã được nhận vào làm";

                SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
                client.EnableSsl = true;

                client.Credentials = new NetworkCredential("hungntps38090@gmail.com", "xlib chji tuaz dmxl");
                client.Send(Msg);
                MessageBox.Show("Mail đã được gửi");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void LoadGridView_NhanVien()
        {
            dgvNhanVien.DataSource = busNV.getNhanVien();
            dgvNhanVien.Columns[0].HeaderText = "Email";
            dgvNhanVien.Columns[1].HeaderText = "Tên Nhân Viên";
            dgvNhanVien.Columns[2].HeaderText = "Địa chỉ";
            dgvNhanVien.Columns[3].HeaderText = "Vai trò";
            dgvNhanVien.Columns[4].HeaderText = "Tình Trạng";
        }

        private void ResetValues()
        {
            txtTimKiem.Text = "Nhập tên nhân viên";
            txtEmail.Text = null;
            txtTenNV.Text = null;
            txtDiaChi.Text = null;
            txtEmail.Enabled = false;
            txtTenNV.Enabled = false;
            txtDiaChi.Enabled = false;
            chkHoatDong.Enabled = false;
            chkNgungHoatDong.Enabled=false;
            chkNhanVien.Enabled = false;
            chkQuanTri.Enabled = false;
            btnThem.Enabled = true;
            btnLuu.Enabled = false;
            btnDong.Enabled =true;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
        }
        private void frmNhanVien_QLBH_Load(object sender, EventArgs e)
        {
            ResetValues();
            LoadGridView_NhanVien();
        }
        public bool IsValid(string emailaddress) // check rule email
        {
            try
            {
                MailAddress m = new MailAddress(emailaddress);
                return true;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi " + ex);
                return false;
            }
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            txtEmail.Text = null;
            txtTenNV.Text = null;
            txtDiaChi.Text = null;
            txtTenNV.Enabled = true;
            txtEmail.Enabled = true;
            txtDiaChi.Enabled = true;
            chkNhanVien.Enabled = true;
            chkQuanTri.Enabled=true;
            chkNgungHoatDong.Enabled = true;
            chkHoatDong.Enabled=true;
            btnLuu.Enabled=true;
            btnSua.Enabled=true;
            btnXoa.Enabled=true;
            chkNhanVien.Checked = false;
            chkQuanTri.Checked = false;
            chkNgungHoatDong.Checked = false;
            chkHoatDong.Checked=false;
            txtEmail.Focus();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                int role = 0; //  Vai trò nhân viên
                if (chkQuanTri.Checked)
                {
                    role = 1;// quản trị
                }

                int tinhtrang = 0; // ngừng hoạt động
                if (chkHoatDong.Checked)
                {
                    tinhtrang = 1; // hoạt động
                }

                if (txtEmail.Text.Trim().Length == 0) // kiểm tra phải nhập email
                {
                    MessageBox.Show("Bạn phải nhập email", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtEmail.Focus();
                    return;
                }

                else if (!IsValid(txtEmail.Text.Trim()))
                {
                    MessageBox.Show("Bạn phải nhập đúng định dạng email", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtEmail.Focus();
                    return;
                }

                else if (txtTenNV.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Bạn phải nhập tên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtTenNV.Focus();
                    return;
                }

                else if (txtDiaChi.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Bạn phải nhập địa chỉ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtDiaChi.Focus();
                    return;
                }

                if (chkQuanTri.Checked == false && chkNhanVien.Checked == false)
                {
                    MessageBox.Show("Bạn phải nhập vai trò", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtTenNV.Focus();
                    return;
                }

                if (chkQuanTri.Checked == false && chkNhanVien.Checked == false)
                {
                    MessageBox.Show("Bạn phải nhập tình trạng ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtTenNV.Focus();
                    return;
                }
                else
                {
                    // Tạo 1 DTO
                    DTO_NhanVien nv = new DTO_NhanVien(txtEmail.Text, txtTenNV.Text, txtDiaChi.Text, role, tinhtrang);
                    if (busNV.InsertNhanVien(nv))
                    {
                        MessageBox.Show("Thêm thành công");
                        ResetValues();
                        LoadGridView_NhanVien();
                        SendMail(nv.EmailNv);
                    }
                    else
                    {
                        MessageBox.Show("Thêm ko thành công");
                    }
                }
            }
            catch (Exception ex) 
            {
                MessageBox.Show("Lõi " + ex);
            }
        }

        private void dgvNhanVien_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvNhanVien_Click(object sender, EventArgs e)
        {
            if(dgvNhanVien.Rows.Count > 1)
            {
                btnLuu.Enabled = false;
                txtTenNV.Enabled = true;
                txtDiaChi.Enabled = true;
                chkQuanTri.Enabled = true;
                chkNhanVien.Enabled = true;
                chkHoatDong.Enabled = true;
                chkNgungHoatDong.Enabled=true;
                btnSua.Enabled = true;
                btnXoa.Enabled = true;
                // Show data from selected row to controls
                txtEmail.Text = dgvNhanVien.CurrentRow.Cells["Email"].Value.ToString();
                txtTenNV.Text = dgvNhanVien.CurrentRow.Cells["TenNV"].Value.ToString();
                txtDiaChi.Text = dgvNhanVien.CurrentRow.Cells["DiaChi"].Value.ToString();
                if (int.Parse(dgvNhanVien.CurrentRow.Cells["VaiTro"].Value.ToString()) == 1)
                {
                    chkQuanTri.Checked = true;

                }
                else
                    chkNhanVien.Checked = true;
                if (int.Parse(dgvNhanVien.CurrentRow.Cells["tinhTrang"].Value.ToString()) == 1)
                {
                    chkHoatDong.Checked = true;
                }
                else 
                    chkNgungHoatDong.Checked= true;
            }
            else
            {
                MessageBox.Show("Bảng không tồn tại dữ liệu","Thông báo",MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (txtTenNV.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTenNV.Focus();
                return;
            }
            else if (txtDiaChi.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập địa chỉ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtDiaChi.Focus();
                return;
            }
            else
            {
                int role = 0; // vai trò nhân viên
                if (chkQuanTri.Checked)
                {
                    role = 1; // vai trò quản trị
                }
                
                int tinhtrang = 0; // ngừng hoạt động
                if (chkHoatDong.Checked)
                {
                    tinhtrang = 1; // hoạt động
                }

                // Tạo DTO
                DTO_NhanVien nv = new DTO_NhanVien(txtEmail.Text, txtTenNV.Text, txtDiaChi.Text, role, tinhtrang); // Vì ID tự tăng
                if(MessageBox.Show("Bạn có chắc muốn chỉnh sửa", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (busNV.UpdateNhanVien(nv))
                    {
                        MessageBox.Show("Sửa thành công");
                        ResetValues();
                        LoadGridView_NhanVien(); // refresh datagridview
                    }
                    else
                    {
                        MessageBox.Show("Sửa ko thành công");
                    }
                }
                else
                {
                    ResetValues();
                }
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text;
            if (MessageBox.Show("Bạn có chắc muốn xoá dữ liệu", "Thông báo",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) 
            {
                if (busNV.DeleteNhanVien(email))
                {
                    MessageBox.Show("Xoá thành công");
                    ResetValues();
                    LoadGridView_NhanVien();
                }
                else
                {
                    MessageBox.Show("Xoá ko thành công");
                }
            }
            else
            {
                ResetValues();
            }
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
          
        }

        private void txtTimKiem_Click(object sender, EventArgs e)
        {
            txtTimKiem.Text = null;
            txtTimKiem.BackColor = Color.White;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string tenNhanVien = txtTimKiem.Text; // search by name
            DataTable ds = busNV.SearchNhanVien(tenNhanVien);
            if (ds.Rows.Count > 0) 
            {
                dgvNhanVien.DataSource = ds;
                dgvNhanVien.Columns[0].HeaderText = "Email";
                dgvNhanVien.Columns[1].HeaderText = "Tên Nhân Viên";
                dgvNhanVien.Columns[2].HeaderText = "Địa chỉ";
                dgvNhanVien.Columns[3].HeaderText = "Vai trò";
                dgvNhanVien.Columns[4].HeaderText = "Tình trạng";
            }
            else
            {
                MessageBox.Show("Không tìm thấy nhân viên","Thông báo",MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            txtTimKiem.Text = "Nhập tên nhân viên";
            txtTimKiem.BackColor = Color.LightGray;
            ResetValues();
        }

        private void btnDanhSach_Click(object sender, EventArgs e)
        {
            ResetValues();
            LoadGridView_NhanVien();
        }

        private void btnBoQua_Click(object sender, EventArgs e)
        {
            ResetValues();
            LoadGridView_NhanVien();
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
