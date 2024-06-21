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

namespace GUI_QLBanHang
{
    public partial class FrmThongKe : Form
    {
        busSanPham bussp = new busSanPham(); 
        public FrmThongKe()
        {
            InitializeComponent();
            tpSanPham.Focus();
        }

        private void tpSanPham_Click(object sender, EventArgs e)
        {

        }

        private void LoadGridview_ThongKeHang()
        {
            dgvsp.AutoResizeColumns();
            dgvsp.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvsp.DataSource = bussp.ThongKeHang();
            dgvsp.Columns[0].HeaderText = "Mã nhân viên";
            dgvsp.Columns[1].HeaderText = "Tên nhân viên";
            dgvsp.Columns[2].HeaderText = "Số Lượng Sản Phẩm Nhập";
            dgvsp.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvsp.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }
        private void LoadGridview_ThongKeTonKho()
        {
            dgvtonkho.AutoResizeColumns();
            dgvtonkho.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvtonkho.DataSource = bussp.ThongKeTonKho();
            dgvtonkho.Columns[0].HeaderText = "Tên Sản Phẩm";
            dgvtonkho.Columns[1].HeaderText = "Số Lượng Tồn";
            dgvtonkho.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvtonkho.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }
        private void tcThongKe_Selected(object sender, TabControlEventArgs e)
        {
            if(e.TabPage == tpSanPham)
            {
                LoadGridview_ThongKeHang();
            }
            else
            {
                LoadGridview_ThongKeTonKho();
            }
        }

        private void FrmThongKe_Load(object sender, EventArgs e)
        {

        }
    }
}
