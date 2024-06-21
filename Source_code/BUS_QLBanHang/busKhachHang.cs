using DAL_QLBanHang;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO_QLBanHang;

namespace BUS_QLBanHang
{
    public class busKhachHang
    {
        DAL_Khach dalKhach = new DAL_Khach();

        public DataTable getKhach()
        {
            return dalKhach.getKhach();
        }

        public bool InsertKhach(DTO_KhachHang khach)
        {
            return dalKhach.insertKhach(khach);
        }

        public bool UpdateKhach(DTO_KhachHang khach)
        {
            return dalKhach.updateKhach(khach);
        }

        public bool DeleteKhach(string soDT)
        {
            return dalKhach.DeleteKhach(soDT);
        }

        public DataTable SearchKhach(string soDT)
        {
            return dalKhach.SearchKhach(soDT);
        }
    }
}
