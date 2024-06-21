using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_QLBanHang
{
    public  class DTO_KhachHang
    {
        private string sodienthoai;
        private string tenkhach;
        private string diachi;
        private string phai;
        private string emailkhach;
        private string Manv;

        public string SoDienThoai
        {
            get { return sodienthoai; } set { sodienthoai = value; }
        }

        public string TenKhach
        {
            get { return tenkhach; }
            set { tenkhach = value; }
        }

        public string Diachi
        {
            get { return diachi; }
            set { diachi = value; }
        }

        public string Phai
        {
            get { return phai; }
            set { phai = value; }
        }

        public string Emailkhach
        {
            get { return emailkhach; }
            set { emailkhach = value; }
        }

        public DTO_KhachHang(string dienThoai, string tenKhach, string diachi, string phai, string email=null)
        {
            this.sodienthoai = dienThoai;
            this.tenkhach = tenKhach;
            this.diachi = diachi;
            this.phai = phai;
            this.emailkhach = email;
        }
    }
}
