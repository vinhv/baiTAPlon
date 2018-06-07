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
   public class PCGDDADAL:KetNoi
    {
       
            public DataTable LoadData(string sql)
            {
                Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                DataTable dt = new DataTable();
                SqlDataReader dr = cmd.ExecuteReader();
                dt.Load(dr);
                return dt;
            }
            public DataTable HienThiDS()
            {
                string sql = "select MaLop,MaMon,CanBoGiaoVien.HoTen,PhanCongGiangDay.NgayPhanCong from PhanCongGiangDay inner join CanBoGiaoVien on PhanCongGiangDay.MaCanBoGiaoVien=CanBoGiaoVien.MaCanBoGiaoVien";
            return LoadData(sql);
            }
        public DataTable getMamon()
        {
            string sql = "select MaMon,TenMon from MonHoc";
            return LoadData(sql);
        }
        public DataTable getMalop()
        {
            string sql = "select MaLop,TenLop from Lop";
            return LoadData(sql);
        }
        public DataTable getGiaovien()
        {
            string sql = "select MaCanBoGiaoVien,HoTen from CanBoGiaoVien";
            return LoadData(sql);
        }
        public int Them(PhanCongGiangDay x)
        {
            Open();
            string sql = "insert into PhanCongGiangDay values(@malop,@mamon,@magv,@ngay) ";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("malop", x.MaLop);
            cmd.Parameters.AddWithValue("mamon", x.MaMon);
            cmd.Parameters.AddWithValue("magv", x.MaCanBoGV);
            cmd.Parameters.AddWithValue("ngay", x.NgayPhanCong);

            return cmd.ExecuteNonQuery();

        }
    }
    }

