using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO_QLBanHang;

namespace DAL_QLBanHang
{
    public class DAL_SanPham : DBConnect
    {

        public DataTable getHang()
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "DanhSachSanPham";
                cmd.Connection = _conn;
                DataTable dthang = new DataTable();
                dthang.Load(cmd.ExecuteReader());
                return dthang;
            }
            finally { _conn.Close(); }
        }

        public bool InsertHang(DTO_SanPham sp)
        {


            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "InsertSanPham";
                cmd.Parameters.AddWithValue("tenHang", sp.TenHang);
                cmd.Parameters.AddWithValue("SoLuong", sp.SoLuong);
                cmd.Parameters.AddWithValue("DonGiaNhap", sp.DonGiaNhap);
                cmd.Parameters.AddWithValue("DonGiaBan", sp.DonGiaBan);
                cmd.Parameters.AddWithValue("HinhAnh", sp.HinhAnh);
                cmd.Parameters.AddWithValue("GhiChu", sp.GhiChu);
                cmd.Parameters.AddWithValue("Email", sp.EmailNV);
                if (cmd.ExecuteNonQuery() > 0)
                {
                    return true;
                }
            }
            finally { _conn.Close(); }
            return false;

        }

        public bool UpdateHang(DTO_SanPham sp)
        {


            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "UpdateHang";
                cmd.Parameters.AddWithValue("MaHang", sp.MaHang);
                cmd.Parameters.AddWithValue("TenHang", sp.TenHang);
                cmd.Parameters.AddWithValue("SoLuong", sp.SoLuong);
                cmd.Parameters.AddWithValue("DonGiaBan", sp.DonGiaBan);
                cmd.Parameters.AddWithValue("DonGiaNhap", sp.DonGiaNhap);
                cmd.Parameters.AddWithValue("HinhAnh", sp.HinhAnh);
                cmd.Parameters.AddWithValue("GhiChu", sp.GhiChu);

                if (cmd.ExecuteNonQuery() > 0)
                {
                    return true;
                }
            }
            finally { _conn.Close(); }
            return false;
        }


        public bool DeleteHang(int maHang)
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "DeleteHang";
                cmd.Parameters.AddWithValue("MaHang", maHang);
                if (cmd.ExecuteNonQuery() > 0)
                {
                    return true;
                }
            }
            finally { _conn.Close(); }
            return false;

        }

        public DataTable SearchHang(string tenHang)
        {


            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SearchHang";
                cmd.Parameters.AddWithValue("TenHang", tenHang);

                DataTable dtHang = new DataTable();
                dtHang.Load(cmd.ExecuteReader());
                return dtHang;
            }
            finally { _conn.Close(); }

        }

        public DataTable ThongKeHang()
        {

            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "ThongKeSP";
                cmd.Connection = _conn;
                DataTable dtHang = new DataTable();
                dtHang.Load(cmd.ExecuteReader());
                return dtHang;
            }
            finally { _conn.Close(); }


        }

        public DataTable ThongKeTonKho()
        {

            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "ThongKeTonKho";
                cmd.Connection = _conn;
                DataTable dtHang = new DataTable();
                dtHang.Load(cmd.ExecuteReader());
                return dtHang;
            }
            finally { _conn.Close(); }


        }
    }
}

