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
    public class DanhSachHocSinhBUL
    {
        DanhSachHocSinhDAL cls = new DanhSachHocSinhDAL();
        public DataTable HienThi(HoSoHocSinh x)
        {
            return cls.HienThi(x);
        }
        public DataTable LayMaLop()
        {
            return cls.LayMaLop();
        }
    }
}
