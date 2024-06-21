using BUS_QLBanHang;
using DTO_QLBanHang;
using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace GUI_QLBanHang
{
    public partial class frmHang_QLBH : Form
    {
        busSanPham busHang = new busSanPham();
        string stremail = FrmMain_QLBanHang.mail; // nhận mail từ frmMail
        string checkUrlImage; // kiểm tra hình khi cập nhật
        string fileName; // tên file
        string fileSavePath; // url store image
        string fileAddress; // url load images
        public frmHang_QLBH()
        {
            InitializeComponent();
        }

        public frmHang_QLBH(string email)
        {
            stremail = email;
        }
        private void LoadGridview_Hang()
        {
            dgvHang.DataSource = busHang.getHang();
            dgvHang.Columns[0].HeaderText = "Mã Sản Phẩm";
            dgvHang.Columns[1].HeaderText = "Tên Sản Phẩm";
            dgvHang.Columns[2].HeaderText = "Số Lượng";
            dgvHang.Columns[3].HeaderText = "Đơn Giá Nhập";
            dgvHang.Columns[4].HeaderText = "Đơn Giá Bán";
            dgvHang.Columns[5].HeaderText = "Hình Ảnh";
            dgvHang.Columns[7].Visible = false;

        }

        private void ResetValue()
        {
            txtMaHang.Text = null;
            txtTenHang.Text = null;
            txtSoLuong.Text = null;
            txtDonGiaNhap.Text = null;
            txtDonGiaBan.Text = null;
            txtHinh.Text = null;
            picb.Image = null;
            txtGhiChu.Text = null;

            txtTenHang.Enabled = false;
            txtSoLuong.Enabled = false;
            txtDonGiaNhap.Enabled = false;
            txtDonGiaBan.Enabled = false;
            txtHinh.Enabled = false;
            txtGhiChu.Enabled = false;
            btnMoHinh.Enabled = false;
            btnThem.Enabled = true;
            btnLuu.Enabled = false;
            btnDong.Enabled = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
        }
        private void frmHang_QLBH_Load(object sender, EventArgs e)
        {
            LoadGridview_Hang();
            ResetValue();
        }
        private void btnMoHinh_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog dlgOpen = new OpenFileDialog();
                dlgOpen.Filter = "Bitmap(*.bmp)|*.bmp|JPEG(*.jpg)|*.jpg|GIF(*.gif)|*.gif|All files(*.*)|*.*";
                dlgOpen.FilterIndex = 2;
                dlgOpen.Title = "Chọn ảnh minh hoạ cho sản phẩm";
                if (dlgOpen.ShowDialog() == DialogResult.OK)
                {
                    fileAddress = dlgOpen.FileName;
                    picb.Image = Image.FromFile(fileAddress);
                    fileName = Path.GetFileName(dlgOpen.FileName);
                    string saveDirectory = Application.StartupPath.Substring(0, (Application.StartupPath.Length - 12));
                    fileSavePath = saveDirectory + "\\Images\\" + fileName;// combine with file name*/
                    txtHinh.Text = "\\Images\\" + fileName;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi: " + ex.Message);
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            int intSoLuong;
            bool isInt = int.TryParse(txtSoLuong.Text.Trim(), out intSoLuong); // ép kiểu để kiểm tra là số ay chữ
            float floatDonGiaNhap;
            bool isFloatNhap = float.TryParse(txtDonGiaNhap.Text.Trim(), out floatDonGiaNhap);
            float floatDonGiaBan;
            bool isFloatBan = float.TryParse(txtDonGiaBan.Text.Trim(), out floatDonGiaBan);
            if (txtTenHang.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTenHang.Focus();
                return;
            }
            else if (!isInt || int.Parse(txtSoLuong.Text) < 0)// kiem tra so nguyen > 0
            {
                MessageBox.Show("Bạn phải nhập số lượng sản phẩm >0, số nguyên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtSoLuong.Focus();
                return;
            }
            else if (!isFloatNhap || float.Parse(txtDonGiaNhap.Text) < 0)// kiem tra so > 0
            {
                MessageBox.Show("Bạn phải nhập đơn giá nhập >0", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtDonGiaNhap.Focus();
                return;
            }
            else if (!isFloatBan || float.Parse(txtDonGiaBan.Text) < 0)// kiem tra so > 0
            {
                MessageBox.Show("Bạn phải nhập đơn giá bán >0", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtDonGiaBan.Focus();
                return;
            }
            else if (txtHinh.Text.Trim().Length == 0)// kiem tra phai nhap hinh
            {
                MessageBox.Show("Bạn phải upload hình", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnMoHinh.Focus();
                return;
            }
            else
            {
                DTO_SanPham h = new DTO_SanPham(txtTenHang.Text, int.Parse(txtSoLuong.Text), float.Parse(txtDonGiaNhap.Text)
                    , float.Parse(txtDonGiaBan.Text), "\\Images\\" + fileName, txtGhiChu.Text, stremail);
                if (busHang.InsertHang(h))
                {
                    MessageBox.Show("Thêm sản phẩm thành công");
                    File.Copy(fileAddress, fileSavePath, true); // copy file hình vào ứng dụng
                    ResetValue();
                    LoadGridview_Hang(); // refresh datagridview
                }
                else
                {
                    MessageBox.Show("Thêm sản phẩm ko thành công");
                }
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnBoQua.Enabled = true;
            btnLuu.Enabled = true;
            btnThem.Enabled = false;
            btnMoHinh.Enabled = true;
            txtTenHang.Enabled = true;
            txtSoLuong.Enabled = true;
            txtDonGiaNhap.Enabled = true;
            txtDonGiaBan.Enabled = true;
            txtGhiChu.Enabled = true;
            txtMaHang.Text = null;
            txtTenHang.Text = null;
            txtSoLuong.Text = null;
            txtDonGiaNhap.Text = null;
            txtDonGiaBan.Text = null;
            txtHinh.Text = null;
            picb.Image = null;
            txtGhiChu.Text = null;
            txtMaHang.Enabled = false;
            txtTenHang.Focus();
        }

        private void dgvHang_Click(object sender, EventArgs e)
        {
            string saveDirectory = Application.StartupPath.Substring(0, (Application.StartupPath.Length - 12));
            if (dgvHang.Rows.Count > 1)
            {
                btnMoHinh.Enabled = true;
                btnLuu.Enabled = false;
                txtTenHang.Enabled = true;
                txtSoLuong.Enabled = true;
                txtDonGiaNhap.Enabled = true;
                txtDonGiaBan.Enabled = true;
                txtGhiChu.Enabled = true;
                txtTenHang.Focus();
                btnSua.Enabled = true;
                btnXoa.Enabled = true;
                txtMaHang.Text = dgvHang.CurrentRow.Cells["MaHang"].Value.ToString();
                txtTenHang.Text = dgvHang.CurrentRow.Cells["TenHang"].Value.ToString();
                txtSoLuong.Text = dgvHang.CurrentRow.Cells["SoLuong"].Value.ToString();
                txtDonGiaNhap.Text = dgvHang.CurrentRow.Cells["DonGiaNhap"].Value.ToString();
                txtDonGiaBan.Text = dgvHang.CurrentRow.Cells["DonGiaBan"].Value.ToString();
                txtHinh.Text = dgvHang.CurrentRow.Cells["HinhAnh"].Value.ToString();
                checkUrlImage = txtHinh.Text; // giữ đường dẫn file hình
                picb.Image = Image.FromFile(saveDirectory + dgvHang.CurrentRow.Cells["HinhAnh"].Value.ToString());
                txtGhiChu.Text = dgvHang.CurrentRow.Cells["GhiChu"].Value.ToString();
            }
            else
            {
                MessageBox.Show("Bảng không tồn tại dữ liệu ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            int intSoLuong;
            bool isInt = int.TryParse(txtSoLuong.Text.Trim(), out intSoLuong); // ép kiểu để kiểm tra là số ay chữ
            float floatDonGiaNhap;
            bool isFloatNhap = float.TryParse(txtDonGiaNhap.Text.Trim(), out floatDonGiaNhap);
            float floatDonGiaBan;
            bool isFloatBan = float.TryParse(txtDonGiaBan.Text.Trim(), out floatDonGiaBan);
            if (txtTenHang.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTenHang.Focus();
                return;
            }
            else if (!isInt || int.Parse(txtSoLuong.Text) < 0)// kiem tra so nguyen > 0
            {
                MessageBox.Show("Bạn phải nhập số lượng sản phẩm >0, số nguyên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtSoLuong.Focus();
                return;
            }
            else if (!isFloatNhap || float.Parse(txtDonGiaNhap.Text) < 0)// kiem tra so > 0
            {
                MessageBox.Show("Bạn phải nhập đơn giá nhập >0", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtDonGiaNhap.Focus();
                return;
            }
            else if (!isFloatBan || float.Parse(txtDonGiaBan.Text) < 0)// kiem tra so > 0
            {
                MessageBox.Show("Bạn phải nhập đơn giá bán >0", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtDonGiaBan.Focus();
                return;
            }
            else if (txtHinh.Text.Trim().Length == 0)// kiem tra phai nhap hinh
            {
                MessageBox.Show("Bạn phải upload hình", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnMoHinh.Focus();
                return;
            }
            else
            {
                DTO_SanPham h = new DTO_SanPham(int.Parse(txtMaHang.Text), txtTenHang.Text, int.Parse(txtSoLuong.Text),
                    float.Parse(txtDonGiaNhap.Text), float.Parse(txtDonGiaBan.Text), txtHinh.Text, txtGhiChu.Text, stremail);
                if (busHang.UpdateHang(h))
                {
                    if (txtHinh.Text != checkUrlImage) // nếu có thay đổi hình
                    {
                        if (File.Exists(checkUrlImage))
                        {
                            File.Copy(fileAddress, fileSavePath, true); // copy file hình vào ứng dụng
                        }
                    }
                    MessageBox.Show("Sửa sản phẩm thành công");
                    ResetValue();
                    LoadGridview_Hang(); // refresh datagridview
                }
                else
                {
                    MessageBox.Show("Sửa sản phẩm ko thành công");
                }
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            int maHang = int.Parse(txtMaHang.Text);
            if (MessageBox.Show("Bạn có chắc muốn xóa dữ liệu", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                //do something if YES
                if (busHang.DeleteHang(maHang))
                {
                    MessageBox.Show("Xóa dữ liệu thành công");
                    ResetValue();
                    LoadGridview_Hang(); // refresh datagridview
                }
                else
                {
                    MessageBox.Show("Xóa không thành công");
                }
            }
            else
            {
                //do something if NO
                ResetValue();
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string tenHang = txtTimKiem.Text;
            DataTable ds = busHang.SearchHang(tenHang);
            if (ds.Rows.Count > 0)
            {
                dgvHang.DataSource = ds;
                dgvHang.Columns[0].HeaderText = "Mã Sản Phẩm";
                dgvHang.Columns[1].HeaderText = "Tên Sản Phẩm";
                dgvHang.Columns[2].HeaderText = "Số Lượng";
                dgvHang.Columns[3].HeaderText = "Đơn Giá Nhập";
                dgvHang.Columns[4].HeaderText = "Đơn Giá Bán";
            }
            else
            {
                MessageBox.Show("Không tìm thấy san pham", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            txtTimKiem.Text = "Nhập tên sản phẩm";
            txtTimKiem.BackColor = Color.LightGray;
            ResetValue();
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnBoQua_Click(object sender, EventArgs e)
        {
            ResetValue();
        }

        private void picb_Click(object sender, EventArgs e)
        {

        }

        private void btnDanhSach_Click(object sender, EventArgs e)
        {
            ResetValue();
            LoadGridview_Hang();
        }
    }
}
