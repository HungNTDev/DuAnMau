using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL_QLBanHang;
using DTO_QLBanHang;

namespace BUS_QLBanHang
{
    public class busSanPham
    {
        DAL_SanPham dalsp = new DAL_SanPham();
        public DataTable getHang()
        {
            return dalsp.getHang();
        }

        public bool InsertHang(DTO_SanPham sp)
        {
            return dalsp.InsertHang(sp);
        }

        public bool UpdateHang(DTO_SanPham sp) 
        {
            return dalsp.UpdateHang(sp);
        }

        public bool DeleteHang(int mahang)
        {
            return dalsp.DeleteHang(mahang);
        }

        public DataTable SearchHang(string tenhang)
        {
            return dalsp.SearchHang(tenhang);
        }
        public DataTable ThongKeHang()
        {
            return dalsp.ThongKeHang();
        }
        public DataTable ThongKeTonKho()
        {
            return dalsp.ThongKeTonKho();
        }
    }
}
