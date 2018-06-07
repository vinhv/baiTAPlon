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
    public class QuanLyMonDAL:KetNoi
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
            string sql = "select * from MonHoc";
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
        public int Them(MonHoc x)
        {
            int n = 3;
            string[] name = new string[n];
            object[] value = new object[n];
            name[0] = "@MaMon";
            name[1] = "@TenMon";
            name[2] = "@SoTiet";
            value[0] = x.MaMon;
            value[1] = x.TenMon;
            value[2] = x.SoTiet;
            string sql = "insert into MonHoc values(@MaMon,@TenMon,@SoTiet)";
            return Update(sql, name, value, n);
        }
        public int Sua(MonHoc x)
        {
            int n = 3;
            string[] name = new string[n];
            object[] value = new object[n];
            name[0] = "@MaMon";
            name[1] = "@TenMon";
            name[2] = "@SoTiet";
            value[0] = x.MaMon;
            value[1] = x.TenMon;
            value[2] = x.SoTiet;
            string sql = "update MonHoc set TenMon=@TenMon, SoTiet=@SoTiet where MaMon=@MaMon";
            return Update(sql, name, value, n);
        }
        public int Xoa(MonHoc x)
        {
            int n = 1;
            string[] name = new string[n];
            object[] value = new object[n];
            name[0] = "@MaMon";
            value[0] = x.MaMon;
            string sql = "delete MonHoc where MaMon=@MaMon";
            return Update(sql, name, value, n);
        }
        public DataTable Xem(MonHoc x)
        {
            Open();
            string sql = "select * from MonHoc where MaMon=@MaMon";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("MaMon", x.MaMon);
            DataTable dt = new DataTable();
            SqlDataReader dr = cmd.ExecuteReader();
            dt.Load(dr);
            return dt;
        }
    }
}
