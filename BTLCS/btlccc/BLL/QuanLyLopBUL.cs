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
    public class QuanLyLopBUL
    {
        QuanLyLopDAL cls = new QuanLyLopDAL();
        public DataTable HienThi()
        {
            return cls.HienThi();
        }
        public int Them(Lop x)
        {
            return cls.Them(x);
        }
        public int Sua(Lop x)
        {
            return cls.Sua(x);
        }
        public int Xoa(Lop x)
        {
            return cls.Xoa(x);
        }
        public DataTable Xem(Lop x)
        {
            return cls.Xem(x);
        }
    }
}
