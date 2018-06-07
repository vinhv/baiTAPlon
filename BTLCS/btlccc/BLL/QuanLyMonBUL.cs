using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;
using System.Data;

namespace BLL
{
    public class QuanLyMonBUL
    {
        QuanLyMonDAL cls = new QuanLyMonDAL();
        public DataTable HienThi()
        {
            return cls.HienThi();
        }
        public int Them(MonHoc x)
        {
            return cls.Them(x);
        }
        public int Sua(MonHoc x)
        {
            return cls.Sua(x);
        }
        public int Xoa(MonHoc x)
        {
            return cls.Xoa(x);
        }
        public DataTable Xem(MonHoc x)
        {
            return cls.Xem(x);
        }
    }
}
