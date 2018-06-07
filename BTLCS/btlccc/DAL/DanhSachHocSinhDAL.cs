using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using DTO;

namespace DAL
{
    public class DanhSachHocSinhDAL:KetNoi
    {
        public DataTable HienThi(HoSoHocSinh x)
        {
            Open();
            string sql = "select MaHocSinh,HoTen,GioiTinh,DiaChi,HoTenBoMe,SoDienThoai from HoSoHocSinh where MaLop=@MaLop";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("MaLop", x.MaLop);
            DataTable dt = new DataTable();
            SqlDataReader dr = cmd.ExecuteReader();
            dt.Load(dr);
            return dt;
        }
        public DataTable LayMaLop()
        {
            Open();
            string sql = "select MaLop,TenLop from Lop";
            SqlCommand cmd = new SqlCommand(sql, conn);
            DataTable dt = new DataTable();
            SqlDataReader dr = cmd.ExecuteReader();
            dt.Load(dr);
            return dt;
        }
    }
}
