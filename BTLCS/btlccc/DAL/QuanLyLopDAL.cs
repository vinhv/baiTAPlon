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
    public class QuanLyLopDAL:KetNoi
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
        public DataTable HienThi()
        {
            string sql = "select * from Lop";
            return LoadData(sql);
        }
        public int Update(string sql, string[] name, object[] value, int n)
        {
            Open();
            SqlCommand cmd = new SqlCommand(sql, conn);
            for (int i = 0; i < n; i++)
            {
                cmd.Parameters.AddWithValue(name[i], value[i]);
            }
            return cmd.ExecuteNonQuery();
        }
        public int Them(Lop x)
        {
            int n = 5;
            string[] name = new string[n];
            object[] value = new object[n];
            name[0] = "@MaLop";
            name[1] = "@TenLop";
            name[2] = "@NienKhoa";
            name[3] = "@SiSo";
            name[4] = "@GVCN";
            value[0] = x.MaLop;
            value[1] = x.TenLop;
            value[2] = x.NienKhoa;
            value[3] = x.SiSo;
            value[4] = x.GiaoVienChuNhiem;
            string sql = "insert into Lop values(@MaLop,@TenLop,@NienKhoa,@SiSo,@GVCN)";
            return Update(sql, name, value, n);
        }
        public int Sua(Lop x)
        {
            int n = 5;
            string[] name = new string[n];
            object[] value = new object[n];
            name[0] = "@MaLop";
            name[1] = "@TenLop";
            name[2] = "@NienKhoa";
            name[3] = "@SiSo";
            name[4] = "@GVCN";
            value[0] = x.MaLop;
            value[1] = x.TenLop;
            value[2] = x.NienKhoa;
            value[3] = x.SiSo;
            value[4] = x.GiaoVienChuNhiem;
            string sql = "update Lop set TenLop=@TenLop, NienKhoa=@NienKhoa, SiSo=@SiSo, GiaoVienChuNhiem=@GVCN where MaLop=@MaLop";
            return Update(sql, name, value, n);
        }
        public int Xoa(Lop x)
        {
            int n = 1;
            string[] name = new string[n];
            object[] value = new object[n];
            name[0] = "@MaLop";
            value[0] = x.MaLop;
            string sql = "delete Lop where MaLop=@MaLop";
            return Update(sql, name, value, n);

        }
        public DataTable Xem(Lop x)
        {
            Open();
            string sql = "select * from Lop where MaLop=@MaLop";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("MaLop", x.MaLop);
            DataTable dt = new DataTable();
            SqlDataReader dr = cmd.ExecuteReader();
            dt.Load(dr);
            return dt;
        }
    }
}
