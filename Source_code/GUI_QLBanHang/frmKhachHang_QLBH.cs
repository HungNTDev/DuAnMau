using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS_QLBanHang;
using DTO_QLBanHang;

namespace GUI_QLBanHang
{
    public partial class frmKhachHang_QLBH : Form
    {
        busKhachHang busKhach = new busKhachHang();
        string stremail = FrmMain_QLBanHang.mail; // nhận mail từ Frmmain
        public frmKhachHang_QLBH()
        {
            InitializeComponent();
        }
        private void LoadGridView_KhachHang()
        {
            dgvKhachHang.DataSource = busKhach.getKhach();
            dgvKhachHang.Columns[0].HeaderText = "Điện thoại";
            dgvKhachHang.Columns[1].HeaderText = "Họ và Tên";
            dgvKhachHang.Columns[2].HeaderText = "Địa chỉ";
            dgvKhachHang.Columns[3].HeaderText = "Giới Tính";
            dgvKhachHang.Columns[4].Visible = false;
        }

        private void ResetValue()
        {
            txtDiaChi.Text = null;
            txtDienThoai.Text = null;
            txtHoVaTen.Text = null;
            rdoNam.Checked = false;
            rdoNu.Checked = false;

            txtDiaChi.Enabled = false;
            txtDienThoai.Enabled = false;
            txtHoVaTen.Enabled = false;
            rdoNu.Enabled = false;
            rdoNam.Enabled = false;
            dgvKhachHang.Enabled = true;

            btnThem.Enabled = true;
            btnLuu.Enabled = false;
            btnDong.Enabled = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;

            txtDienThoai.Focus();
        }
        private void frmKhachHang_QLBH_Load(object sender, EventArgs e)
        {
            ResetValue();
            LoadGridView_KhachHang();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            txtDienThoai.Text = null;
            txtHoVaTen.Text = null;
            txtDiaChi.Text= null;
            txtDienThoai.Enabled = true;
            txtHoVaTen.Enabled = true;
            txtDiaChi.Enabled = true;
            rdoNam.Enabled = true;
            rdoNu.Enabled = true;
            btnLuu.Enabled= true;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            rdoNam.Checked = false;
            rdoNu.Checked = false;
            txtDienThoai.Focus();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            float intDienThoai;
            bool isInt = float.TryParse(txtDienThoai.Text.Trim().ToString(), out intDienThoai); // ép kiểu để kiểm tra là số hay chữ
            string phai = "Nam";
            if (rdoNu.Checked == true)
                phai = "Nữ";
            if(!isInt || float.Parse(txtDienThoai.Text) <0) // kiểm tra số điện thoại
            {
                MessageBox.Show("Bạn phải nhập số điện thoại >0, số nguyên", "Thống báo",MessageBoxButtons.OK,MessageBoxIcon.Information);
                txtDienThoai.Focus();
                return;
            }
            else
            {
                DTO_KhachHang kh = new DTO_KhachHang(txtDienThoai.Text,txtHoVaTen.Text,txtDiaChi.Text,phai,stremail);
                if (busKhach.InsertKhach(kh))
                {
                    MessageBox.Show("Thêm thành công");
                    ResetValue();
                    LoadGridView_KhachHang();
                }
                else
                {
                    MessageBox.Show("Thêm ko thành công");
                }
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            float intDienThoai;
            bool isInt = float.TryParse(txtDienThoai.Text.Trim().ToString(), out intDienThoai); // ép kiểu để kiểm tra là số hay chữ
            string phai = "Nam";
            if (rdoNu.Checked == true)
                phai = "Nữ";
            if (!isInt || float.Parse(txtDienThoai.Text) < 0) // kiểm tra số điện thoại
            {
                MessageBox.Show("Bạn phải nhập số điện thoại >0, số nguyên", "Thống báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtDienThoai.Focus();
                return;
            }
            else
            {
                DTO_KhachHang kh = new DTO_KhachHang(txtDienThoai.Text, txtHoVaTen.Text, txtDiaChi.Text, phai, stremail);
                if (MessageBox.Show("Bạn có chắc muốn chỉnh sửa", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (busKhach.UpdateKhach(kh))
                    {
                        MessageBox.Show("Cập nhật khách hàng thành công");
                        ResetValue();
                        LoadGridView_KhachHang(); // refresh datagridview
                    }
                    else
                    {
                        MessageBox.Show("Cập nhật khách hàng không thành công");
                    }
                }
                else
                {
                    ResetValue();
                }
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string soDT = txtDienThoai.Text;
            if (MessageBox.Show("Bạn có chắc muốn xóa dữ liệu khách hàng", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                //do something if YES
                if (busKhach.DeleteKhach(soDT))
                {
                    MessageBox.Show("Xóa dữ liệu khách hàng thành công");
                    ResetValue();
                    LoadGridView_KhachHang(); // refresh datagridview
                }
                else
                {
                    MessageBox.Show("Xóa dữ liệu khách hàng không thành công");
                }
            }
            else
            {
                //do something if NO
                ResetValue();
            }
        }
    

        private void dgvKhachHang_Click(object sender, EventArgs e)
        {
            if (dgvKhachHang.Rows.Count > 1)
            {
                btnLuu.Enabled = false;
                txtDiaChi.Enabled = true;
                txtDienThoai.Enabled = true;
                txtHoVaTen.Enabled = true;
                rdoNu.Enabled = true;
                rdoNam.Enabled = true;
                txtDienThoai.Focus();
                btnSua.Enabled = true;
                btnXoa.Enabled = true;
                txtDienThoai.Text = dgvKhachHang.CurrentRow.Cells["DienThoai"].Value.ToString();
                txtHoVaTen.Text = dgvKhachHang.CurrentRow.Cells["TenKhach"].Value.ToString();
                txtDiaChi.Text = dgvKhachHang.CurrentRow.Cells["DiaChi"].Value.ToString();
                string phai = dgvKhachHang.CurrentRow.Cells["Phai"].Value.ToString();
                if (phai == "Nam")
                    rdoNam.Checked = true;
                else
                    rdoNu.Checked = true;
            }
            else
            {
                MessageBox.Show("Bảng không tồn tại dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string soDT = txtTimKiem.Text;
            DataTable ds = busKhach.SearchKhach(soDT);
            if (ds.Rows.Count > 0)
            {
                dgvKhachHang.DataSource = ds;
                dgvKhachHang.Columns[0].HeaderText = "Điện Thoại";
                dgvKhachHang.Columns[1].HeaderText = "Họ và Tên";
                dgvKhachHang.Columns[2].HeaderText = "Địa Chỉ";
                dgvKhachHang.Columns[3].HeaderText = "Giới Tính";
                dgvKhachHang.Columns[4].Visible = false;
            }
            else
            {
                MessageBox.Show("Không tìm thấy khách hàng nào phù hợp tiêu chí tìm kiếm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTimKiem.Focus();
            }
            txtTimKiem.Text = "Nhập số điện thoại khach hàng";
            txtTimKiem.BackColor = Color.LightGray;
            ResetValue();
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDanhSach_Click(object sender, EventArgs e)
        {
            ResetValue();
            LoadGridView_KhachHang();
        }
    }
}
