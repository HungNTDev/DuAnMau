using DAL_QLBanHang;
using DTO_QLBanHang;
using System.Data;
using System.Security.Cryptography;
using System.Text;

namespace BUS_QLBanHang
{
    public class busNhanVien
    {
        DAL_NhanVien dalNhanVien = new DAL_NhanVien();
        public bool NhanVienDangNhap(DTO_NhanVien nv) 
        {
            return dalNhanVien.NhanVienDangNhap(nv);
        }

        // encrypt pass
        public string encryption (string password)
        {
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            byte[] encrypt;
            UTF8Encoding encode = new UTF8Encoding();
            encrypt = md5.ComputeHash(encode.GetBytes(password));
            StringBuilder encryptdata = new StringBuilder();
            for(int i = 0; i < encrypt.Length; i++)
            {
                encryptdata.Append(encrypt[i].ToString());
            }
            return encryptdata.ToString();
        }

        public bool NhanVienQuenMK(string email)
        {
            return dalNhanVien.NhanVienQuenMatKhau(email);
        }

        public bool TaoMatKhau(string email, string password)
        {
            return dalNhanVien.TaoMatKhau(email, password);
        }

        public DataTable VaiTroNhanVien(string email)
        {
            return dalNhanVien.VaiTroNhanVien(email);
        }

        public bool UpdateMatKhau(string email, string matkhaucu, string matkhaumoi)
        {
            return dalNhanVien.UpdateMatKhau(email, matkhaucu, matkhaumoi);
        }

        public DataTable getNhanVien()
        {
            return dalNhanVien.getNhanVien();
        }

        public bool InsertNhanVien(DTO_NhanVien nv)
        {
            return dalNhanVien.InsertNhanVien(nv);
        }

        public bool UpdateNhanVien(DTO_NhanVien nv)
        {
            return dalNhanVien.UpdateNhanVien(nv);
        }

        public bool DeleteNhanVien(string tenDN) 
        {
            return dalNhanVien.DeleteNhanVien(tenDN);
        }

        public DataTable SearchNhanVien(string tenNhanVien)
        {
            return dalNhanVien.SearchNhanVien(tenNhanVien);
        }
    }
}
