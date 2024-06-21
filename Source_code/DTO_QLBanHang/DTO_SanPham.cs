using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_QLBanHang
{
    public class DTO_SanPham
    {
        private int maHang;
        private string tenHang;
        private int soLuong;
        private float donGiaNhap;
        private float donGiaBan;
        private string hinhAnh;
        private string ghiChu;
        private string Manv;
        private string emailNv;// ghi nhận nhân viên nào nhập sản phảm

        public int MaHang
        {
            get { return maHang; }
            set { maHang = value; }
        }

        public string TenHang
        {
            get { return tenHang; }
            set { tenHang = value; }
        }

        public int SoLuong
        {
            get { return soLuong; }
            set { soLuong = value; }
        }

        public float DonGiaNhap
        {
            get { return donGiaNhap; }
            set {  donGiaNhap = value; }
        }

        public float DonGiaBan
        {
            get { return donGiaBan; }
            set { donGiaBan = value; }
        }

        public string HinhAnh
        {
            get { return hinhAnh; }
            set {  hinhAnh = value; }
        }

        public string GhiChu
        {
            get { return ghiChu; }
            set { ghiChu = value; }
        }

        public string manv
        {
            get { return Manv; }
            set { Manv = value; }
        }

        public string EmailNV
        {
            get { return emailNv; }
            set { emailNv = value; }
        }

        public DTO_SanPham(int maHang, string tenHang, int soLuong, float donGiaNhap, float donGiaBan, string hinhAnh, string ghiChu, string emailNv = null)
        {
            this.maHang = maHang;
            this.tenHang = tenHang;
            this.soLuong = soLuong;
            this.donGiaNhap = donGiaNhap;
            this.donGiaBan = donGiaBan;
            this.hinhAnh = hinhAnh;
            this.ghiChu = ghiChu;
            this.emailNv = emailNv;
        }

        public DTO_SanPham(string tenHang, int soLuong, float donGiaNhap, float donGiaBan, string hinhAnh, string ghiChu, string emailNv = null)
        {
            this.tenHang = tenHang;
            this.soLuong = soLuong;
            this.donGiaNhap = donGiaNhap;
            this.donGiaBan = donGiaBan;
            this.hinhAnh = hinhAnh;
            this.ghiChu = ghiChu;
            this.emailNv = emailNv;
        }

        public DTO_SanPham() { }
           
    }
}
