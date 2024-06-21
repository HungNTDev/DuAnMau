using System.Data.SqlClient;
using System.Configuration;

namespace DAL_QLBanHang
{
    public class DBConnect
    {
        // Kết nối đến cơ sở dữ liệu
       
        protected SqlConnection _conn = new SqlConnection("Data Source=ADMIN\\TUANHUNG;Initial Catalog=Quan_Ly_Ban_Hang;Integrated Security=True;Encrypt=False");
       
       // protected string _conn = ConfigurationManager.ConnectionStrings["QLBH"].ConnectionString;
    }
}
    

