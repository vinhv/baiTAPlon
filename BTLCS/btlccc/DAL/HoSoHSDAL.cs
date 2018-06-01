using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using System.Data;

namespace DAL
{
    public class HoSoHSDAL:QuanLyCBGVDAL
    {
        QuanLyCBGVDAL cls = new QuanLyCBGVDAL();
        public DataTable HienThiDS()
        {
            return cls.LoadData("select * from HoSoHocSinh");
        }
        public DataTable LayMaLop()
        {
            return cls.LoadData("select MaLop,TenLop from Lop");
        }
    }
}
