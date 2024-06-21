using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using DTO_QLBanHang;

namespace DAL_QLBanHang
{
    public class DAL_Khach : DBConnect
    {

        public DataTable getKhach()
        {

            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "DanhSachKhach";
                cmd.Connection = _conn;
                DataTable dtkhach = new DataTable();
                dtkhach.Load(cmd.ExecuteReader());
                return dtkhach;
            }
            finally { _conn.Close(); }


        }

        public bool insertKhach(DTO_KhachHang khach)
        {

            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "InsertKhach";
                cmd.Parameters.AddWithValue("dienthoai", khach.SoDienThoai);
                cmd.Parameters.AddWithValue("tenkhach", khach.TenKhach);
                cmd.Parameters.AddWithValue("diachi", khach.Diachi);
                cmd.Parameters.AddWithValue("phai", khach.Phai);
                cmd.Parameters.AddWithValue("email", khach.Emailkhach);

                //Query vả kiềm tra
                if (cmd.ExecuteNonQuery() > 0)
                {
                    return true;
                }
            }
            finally { _conn.Close(); }

            return false;
        }

        public bool updateKhach(DTO_KhachHang khach)
        {

            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "UpdateKhachHang";
                cmd.Parameters.AddWithValue("DienThoai", khach.SoDienThoai);
                cmd.Parameters.AddWithValue("TenKhach", khach.TenKhach);
                cmd.Parameters.AddWithValue("Diachi", khach.Diachi);
                cmd.Parameters.AddWithValue("Phai", khach.Phai);

                if (cmd.ExecuteNonQuery() > 0)
                { return true; }
            }
            finally { _conn.Close(); }
            return false;

        }

        public bool DeleteKhach(string soDT)
        {

            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "DeleteKhachHang";
                cmd.Parameters.AddWithValue("DienThoai", soDT);
                if (cmd.ExecuteNonQuery() > 0)
                {
                    return true;
                }
            }
            finally { _conn.Close(); }
            return false;

        }

        public DataTable SearchKhach(string soDT)
        {

            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SearchKhach";
                cmd.Parameters.AddWithValue("DienThoai", soDT);

                DataTable dtKhach = new DataTable();
                dtKhach.Load(cmd.ExecuteReader());
                return dtKhach;
            }
            finally { _conn.Close(); }


        }
    }
}
