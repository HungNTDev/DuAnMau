using DTO_QLBanHang;
using System;
using System.Data.SqlClient;
using System.Data;
using System.Linq.Expressions;
using System.Net.Mail;


namespace DAL_QLBanHang
{
    public class DAL_NhanVien : DBConnect
    {
        
        public bool NhanVienDangNhap(DTO_NhanVien nv)
        {
            
                try
                {
                    //Kết nối
                    _conn.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = _conn;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "DangNhap";
                    cmd.Parameters.AddWithValue("Email", nv.EmailNv);
                    cmd.Parameters.AddWithValue("MatKhau", nv.Matkhau);
                    
                    // Query và kiểm tra
                    if (Convert.ToInt16(cmd.ExecuteScalar()) > 0)
                    {
                        return true;
                    }
                    return false;
                }
                finally { _conn.Close(); }

            
        }

        public bool NhanVienQuenMatKhau(string email)
        {
           
                try
                {
                    _conn.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = _conn;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "QuenMatKhau";
                    cmd.Parameters.AddWithValue("Email", email);

                    // Query và kiểm tra
                    if (Convert.ToInt16(cmd.ExecuteScalar()) > 0)
                    {
                        return true;
                    }
                    return false;
                }
                finally { _conn.Close(); }
            
        }

        public bool TaoMatKhau(string email, string matKhauMoi)
        {
           
                try
                {
                    _conn.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = _conn;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "TaoMatKhauMoi";
                    cmd.Parameters.AddWithValue("Email", email);
                    cmd.Parameters.AddWithValue("MatKhau", matKhauMoi);

                    // Query và kiểm tra
                    if (Convert.ToInt16(cmd.ExecuteScalar()) > 0)
                    {
                        return true;
                    }
                    
                }
                finally { _conn.Close(); }
                return false;
            
          
            
        }
        public DataTable VaiTroNhanVien(string email)
        {
            
                try
                {
                    _conn.Open();
                    SqlCommand cmd = new SqlCommand();

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "[LayVaiTroNV]";
                    cmd.Parameters.AddWithValue("Email", email);
                    cmd.Connection = _conn;

                    DataTable dtNhanVien = new DataTable();
                    dtNhanVien.Load(cmd.ExecuteReader());
                    return dtNhanVien;
                }
                finally { _conn.Close(); }
            
            
        }

        public bool UpdateMatKhau(string email, string matkhaucu, string matkhaumoi)
        {
           
                try
                {
                    _conn.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = _conn;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "ThayDoiMatKhau";
                    cmd.Parameters.AddWithValue("Email", email);
                    cmd.Parameters.AddWithValue("@opwd", matkhaucu);
                    cmd.Parameters.AddWithValue("@npwd", matkhaumoi);

                    //Query và kiẻm tra
                    if (cmd.ExecuteNonQuery() > 0)
                    {
                        return true;
                    }
                }
                finally { _conn.Close(); }
               
                return false;
            
            
        }
        
        // Lấy danh sách nhân viên
        public DataTable getNhanVien()
        {
            
                try
                {
                    _conn.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "DanhSachNV";
                    cmd.Connection = _conn;
                    DataTable dtHang = new DataTable();
                    dtHang.Load(cmd.ExecuteReader());
                    return dtHang;
                }
                finally { _conn.Close(); }
            
            
        }

        // Thêm nhân viên
        public bool InsertNhanVien(DTO_NhanVien nv)
        {
           
                try
                {
                    _conn.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = _conn;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "InsertNhanVien";
                    cmd.Parameters.AddWithValue("email", nv.EmailNv);
                    cmd.Parameters.AddWithValue("tennv", nv.TenNhanVien);
                    cmd.Parameters.AddWithValue("diachi", nv.DiaChi);
                    cmd.Parameters.AddWithValue("vaiTro", nv.VaiTro);
                    cmd.Parameters.AddWithValue("tinhTrang", nv.TinhTrang);

                    // Query và kiểm tra
                    if (cmd.ExecuteNonQuery() > 0)
                    {
                        return true;
                    }
                }
                finally { _conn.Close(); }
                return false;
            
        }

        // Sửa nhân viên 
        public bool UpdateNhanVien(DTO_NhanVien nv)
        {
            
            
                try
                {
                    _conn.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = _conn;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "UpdateNhanVien";
                    cmd.Parameters.AddWithValue("email", nv.EmailNv);
                    cmd.Parameters.AddWithValue("tennv", nv.TenNhanVien);
                    cmd.Parameters.AddWithValue("diachi", nv.DiaChi);
                    cmd.Parameters.AddWithValue("vaiTro", nv.VaiTro);
                    cmd.Parameters.AddWithValue("tinhTrang", nv.TinhTrang);

                    // Query và kiểm tra
                    if (cmd.ExecuteNonQuery() > 0)
                    {
                        return true;
                    }
                }
                finally { _conn.Close(); }
                return false;
            
        }

        public bool DeleteNhanVien(string email)
        {
            
                try
                {
                    _conn.Open();
                    SqlCommand cmd = new SqlCommand();

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "DeleteNhanVien";
                    cmd.Parameters.AddWithValue("email", email);
                    cmd.Connection = _conn;
                    if (cmd.ExecuteNonQuery() > 0)
                    {
                        return true;
                    }
                }
                finally { _conn.Close(); }
                return false;
            
            
        }

        public DataTable SearchNhanVien (string tenNhanVien)
        {
           
                try
                {
                    _conn.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "SearchNhanVien";
                    cmd.Parameters.AddWithValue("tenNV", tenNhanVien);
                    cmd.Connection = _conn;
                    DataTable dtNhanVien = new DataTable();
                    dtNhanVien.Load(cmd.ExecuteReader());
                    return dtNhanVien;
                }
                finally { _conn.Close(); }
            
            
        }
    }
}
